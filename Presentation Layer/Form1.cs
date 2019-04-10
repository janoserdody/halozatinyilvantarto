using Serilog;
using System;
using System.Windows.Forms;
using System.IO;
using LiteDB;
using BusinessLayer.Support._interfaces;
using BusinessLayer.Interfaces;
using BusinessLayer;
using BusinessLayer.Models;
using Presentation_Layer.DrawingModule;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        // switch between MySQL or LiteDB
        private readonly bool isMySQL = false;

        private IUIFactory uiFactory;

        private IFrameWork frameWork;

        private EventMediator eventMediator;

        private DrawingModule drawingModule;

        public Form1()
        {
            eventMediator = new EventMediator();
            // feliratkozás az ErrorMessage Event-re
            // hibaüzenet esetén az OnErrorMessage metódus megjeleníti a hibaüzenetet
            eventMediator.ErrorMessage += OnErrorMessage;

            FactorySupport factorySupport = new FactorySupport();
            Directory.CreateDirectory(@"C:\Log");
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\Log\Log.txt", rollingInterval: RollingInterval.Hour).CreateLogger();
            Directory.CreateDirectory(@"C:\db");
            LiteRepository repo = new LiteRepository(ApplicationConfig.DbConnectionString);

            frameWork = factorySupport.Create(isMySQL, repo, eventMediator);

            drawingModule = new DrawingModule(uiFactory, frameWork, eventMediator);

            InitializeComponent();

            // példa: lekéri a GetService() -vel a UIFactory szervízt
            // utána kirajzol egy button-t a felhasználói felületen.

            uiFactory = (IUIFactory)(frameWork.GetService(typeof(IUIFactory)));

            if (uiFactory == null)
            {
                throw new Exception("Hibás UIFactory!");
            }
            
            // példa lekéri a stílusát egy gombnak
            uiFactory.GetButton(this.button1, "blueButton", "search", "DrawingModule");

            // Betölti az egész adatbázist a memóriába
            MessageBox.Show("Beolvasom az adatbázist a memóriába");
            frameWork.LoadDatabase();

            // példa: létrehoz egy új aktív eszközt
            IItemActive item = new ItemActive();
                item.DeviceName = "akármi";
                item.DeviceID = "router";
                item.Notes = "ajtó mellett balra";
                frameWork.AddItemActive(item);
                int itemId = item.Id;
                MessageBox.Show("adatbázisba elmentve: eszköz id: " + item.Id.ToString());

                // példa: létrehoz egy második aktív eszközt
                IItemActive item2 = new ItemActive();
                item2.DeviceName = "majom";
                item2.DeviceID = "router";
                item2.Notes = "ajtó mellett balra";
                frameWork.AddItemActive(item2);
                int itemId2 = item2.Id;
                MessageBox.Show("adatbázisba elmentve: eszköz id: " + item2.Id.ToString());

            // példa: létrehoz egy aktív portot
            IPortActive port1 = new PortActive();
            port1.ItemID = 1;
            port1.PortNumber = 1;
            port1.PortName = "elso";
            port1.PhysicalLocation = "ajto mellett";
            port1.PortID = "5/1";
            port1.PortPhysicalType = "UTP";
            port1.SymbolID = 2;
            frameWork.AddPortActive(port1.ItemID, port1);
            MessageBox.Show("adatbázisba mentett port itemid és portnumber: " + port1.ItemID.ToString()
                + " " + port1.PortNumber.ToString());

            //példa:  egy eszközt lekér
            IItemActive item3 = frameWork.GetItemActive(itemId);
            MessageBox.Show("lekérve: eszköz neve: " + item3.DeviceName);

            //példa:  egy eszközt lekér
            IItemActive item4 = frameWork.GetItemActive(itemId2);
            MessageBox.Show("lekérve: eszköz neve: " + item4.DeviceName);

            // példa: lekéri a GetService() -vel az IErrorservice szervízt
            // utána megjeleníti a hibaüzenetet

            IErrorService errorService = (IErrorService)(frameWork.GetService(typeof(IErrorService)));

            if (errorService == null)
            {
                throw new Exception("Hibás ErrorService!");
            }

            IError error = new Error(ErrorType.InputError, "Példa a beviteli hibára");
            errorService.Write(error);

            // hibeüzenet 2. példa
            IError errorExample2 = new Error(ErrorType.DatabaseError, "Példa: Adatbázis üzenet a datalayertől");
            errorService.Write(errorExample2);

            this.Focus();
        }

        // ToDo: ezt a metódust külön osztályba tenni, hogy más UI elemek, Form-ok is fel tudjanak iratkozni
        // az ErrorMessage Event-re
        private void OnErrorMessage(object sender, ErrorMessageEventArgs e)
        {
            // Az errorService által küldött üzenetet egy label-en megjeleníti, 
            // vagy errorType-tól függőn MesseageBox-ban is megjelenítheti a hibaüzenetet

            if (e.errorType == ErrorType.DatabaseError)
            {
                MessageBox.Show(e.message);
            }
            else
            {
            errorLabel.Text = e.message;
            }
        }

        private void ButtonClickOpenDrawingModule(object sender, EventArgs e)
        {
            drawingModule.Show();
        }
    }
}
