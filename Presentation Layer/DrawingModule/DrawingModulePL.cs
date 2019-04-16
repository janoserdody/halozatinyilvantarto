using BusinessLayer.DrawingModule;
using BusinessLayer.DrawingModule._interfaces;
using BusinessLayer.Interfaces;
using BusinessLayer.Support._interfaces;
using Common;
using Common.Interfaces;
using PresentationLayer.DrawingModule._interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Common.Helpers;

namespace PresentationLayer.DrawingModule
{
    public partial class DrawingModulePL : Form, IDrawingModulePL
    {
        private IUIFactory uiFactory;

        private IFrameWork frameWork;

        private readonly int rowNumber = 5;

        private readonly int columnNumber = 15;

        private IPrintPath printPath;

        int IDrawingModulePL.RowNumber { get => rowNumber; }

        int IDrawingModulePL.ColumnNumber { get => columnNumber; }

        private EventMediator eventMediator;
        private IDrawingModuleBL drawingModuleBL;
        private IFactorySupportDrawingModule factorySupport;

        public DrawingModulePL(IUIFactory uiFactory, IFrameWork frameWork, EventMediator eventMediator)
        {
            this.uiFactory = uiFactory;
            this.frameWork = frameWork;
            this.eventMediator = eventMediator;

            factorySupport = new FactorySupportDrawingModule(this, frameWork);
            printPath = factorySupport.CreatePrintPath();
            drawingModuleBL = factorySupport.CreateDrawingModuleBL();

            // feliratkozás az ErrorMessage Event-re
            // hibaüzenet esetén az OnErrorMessage metódus megjeleníti a hibaüzenetet
            eventMediator.ErrorMessage += OnErrorMessage;

            InitializeComponent();
        }

         void IDrawingModulePL.ImageLoad(int x, int y, Bitmap image)
        {
            ImageLoad(x, y, image);
        }
         private void ImageLoad(int x, int y, Bitmap image)
        {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = image;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                tableLayoutPanel1.Controls.Add(pictureBox, x, y);

            //TODO remove method
                //tableLayoutPanel1.Controls.Remove((tableLayoutPanel1.GetControlFromPosition(i / 6, i % 6)));
           //TODO getcontrol method
                //tableLayoutPanel1.GetControlFromPosition(i / 6, i % 6).Visible = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void DrawingModule_Load(object sender, EventArgs e)
        {
            // példa kirajzolásra
            // SetUpMatrix();

            drawingModuleBL.Drawing();
        }

        private void SetUpMatrix()
        {
            // példa beolvassa az ábrákat
            ISymbol routerSymbol = frameWork.GetSymbol("router");

            // másik variáció enum-mal is megadható
            ISymbol switchSymbol = frameWork.GetSymbol(SymbolName.Switch);

            ISymbol lineVertical = frameWork.GetSymbol("linevertical");

            ISymbol lineHorizontal = frameWork.GetSymbol("linehorizontal");

            // példa két eszközt kirajzol a képernyőre
            ImageLoad(1, 1, routerSymbol.GetImage());
            ImageLoad(2, 2, switchSymbol.GetImage());
            Random rnd = new Random();

            // példa a képernyőre kiírásra
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ImageLoad(i, j, frameWork.GetSymbol(rnd.Next(1, 12)).GetImage());
                }
            }
        }

        private void DrawingModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void OnErrorMessage(object sender, ErrorMessageEventArgs e)
        {
            // Az errorService által küldött üzenetet egy label-en megjeleníti, 
            // vagy errorType-tól függőn MesseageBox-ban is megjelenítheti a hibaüzenetet
                errorLabel.Text = e.message;
        }
    }
}
