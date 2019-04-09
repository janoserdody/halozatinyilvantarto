using Serilog;
using System;
using System.Windows.Forms;
using System.IO;
using LiteDB;
using Common.Support._interfaces;
using Common.Interfaces;
using Common;
using Common.Models;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        // switch between MySQL or LiteDB
        private readonly bool isMySQL = false;

        private IUIFactory uiFactory;

        private IFrameWork frameWork;

        public Form1()
        {
            FactorySupport factorySupport = new FactorySupport();
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"C:\Log\Log.txt", rollingInterval: RollingInterval.Hour).CreateLogger();
            Directory.CreateDirectory(@"C:\db");
            LiteRepository repo = new LiteRepository(ApplicationConfig.DbConnectionString);

            frameWork = factorySupport.Create(isMySQL, repo);

            InitializeComponent();

            // példa: lekéri a GetService() -vel a UIFactory szervízt
            // utána kirajzol egy button-t a felhasználói felületen.

            uiFactory = (IUIFactory)(frameWork.GetService(typeof(IUIFactory)));

            if (uiFactory == null)
            {
                throw new Exception("Hibás UIFactory!");
            }
            
            // példa lekéri a stílusát egy gombnak
            uiFactory.GetButton(this.button1, "blueButton", "search", "Keresés");

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

            IError error = new Error(ErrorType.InputError, "Beviteli hiba");
            errorService.Write(error);

            this.Focus();
        }
    }
}
