using Serilog;
using System;
using System.Windows.Forms;
using System.IO;
using LiteDB;
using Common.Support._interfaces;
using Common.Interfaces;
using Common;
using Common.Models;
using Presentation_Layer.DrawingModule;
using System.Collections.Generic;
using static Common.Helpers;

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
            //MessageBox.Show("Beolvasom az adatbázist a memóriába");
            frameWork.LoadDatabase();

            // betölti az ábrákat
            LoadSymbols();

            // példa: létrehoz egy ábrát
            ISymbol symbolRouter = new Symbol();
            symbolRouter.Load("router", @".\Resources\router.jpg");
            frameWork.AddSymbol(symbolRouter);

            ISymbol exampleSymbol = frameWork.GetSymbol(2);

            pictureBox1.Image = exampleSymbol.GetImage();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // példa: létrehoz egy új aktív eszközt
            IItemActive item = new ItemActive
            {
                DeviceName = "akármi",
                DeviceID = "router1",
                Notes = "ajtó mellett balra",
                SymbolID = 1
            };

            frameWork.AddItemActive(item);
            int itemId = item.Id;
            //MessageBox.Show("adatbázisba elmentve: eszköz id: " + item.Id.ToString());

            // példa: létrehoz egy második aktív eszközt
            IItemActive item2 = new ItemActive
            {
                DeviceName = "teve",
                DeviceID = "switch",
                Notes = "ajtó mellett balra",
                SymbolID = 2
            };

            frameWork.AddItemActive(item2);
            int itemId2 = item2.Id;
            //MessageBox.Show("adatbázisba elmentve: eszköz id: " + item2.Id.ToString());

            // példa: létrehoz egy aktív portot
            IPortActive port1 = new PortActive
            {
                ItemID = 1,
                PortNumber = 1,
                PortName = "elso",
                PhysicalLocation = "ajto mellett",
                PortID = "5/1",
                PortPhysicalType = "UTP",
                SymbolID = 2
            };

            frameWork.AddPortActive(port1.ItemID, port1);
           // MessageBox.Show("adatbázisba mentett port itemid és portnumber: " + port1.ItemID.ToString()
            //    + " " + port1.PortNumber.ToString());

            // példa: létrehoz egy második aktív portot
            IPortActive port2 = new PortActive
            {
                ItemID = 2,
                PortNumber = 1,
                PortName = "2/1",
                PhysicalLocation = "ablak mellett",
                PortID = "6/1",
                PortPhysicalType = "Ethernet",
                SymbolID = 2
            };

            frameWork.AddPortActive(port1.ItemID, port1);
            //MessageBox.Show("adatbázisba mentett port itemid és portnumber: " + port1.ItemID.ToString()
             //   + " " + port1.PortNumber.ToString());

            // példa: létrehoz egy connection-t
            IConnection connection1 = new Connection
            {
                Name = "UTP kábel",
                SourceItemId = 1,
                SourcePortNumber = 1,
                DestinationItemId = 2,
                DestinationPortNumber = 1
            };

            frameWork.AddConnection(connection1);



            //példa:  egy eszközt lekér
            IItemActive item3 = frameWork.GetItemActive(itemId);
            //MessageBox.Show("lekérve: eszköz neve: " + item3.DeviceName);

            //példa:  egy eszközt lekér
            IItemActive item4 = frameWork.GetItemActive(itemId2);
            //MessageBox.Show("lekérve: eszköz neve: " + item4.DeviceName);

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

        private void LoadSymbols()
        {
            IList<string> symbolNameList = Helpers.GetSymbolNames();

            string symbolPath = @".\Resources\";
            ISymbol loadSymbol;
            foreach (string itemName in symbolNameList)
            {
                loadSymbol = new Symbol();
                loadSymbol.Load(itemName, symbolPath + itemName + ".jpg");
                frameWork.AddSymbol(loadSymbol);
            }
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
