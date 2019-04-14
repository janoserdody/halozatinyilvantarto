using Common;
using Common.Interfaces;
using Common.Support._interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Common.Helpers;

namespace Presentation_Layer.DrawingModule
{
    public partial class DrawingModule : Form
    {
        private IUIFactory uiFactory;

        private IFrameWork frameWork;

        private EventMediator eventMediator;

        public DrawingModule(IUIFactory uiFactory, IFrameWork frameWork, EventMediator eventMediator)
        {
            this.uiFactory = uiFactory;
            this.frameWork = frameWork;
            this.eventMediator = eventMediator;

            // feliratkozás az ErrorMessage Event-re
            // hibaüzenet esetén az OnErrorMessage metódus megjeleníti a hibaüzenetet
            eventMediator.ErrorMessage += OnErrorMessage;

            InitializeComponent();

        }

        public  void ImageLoad(int x, int y, Bitmap image)
        {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                tableLayoutPanel1.Controls.Add(pictureBox, x, y);
                //tableLayoutPanel1.Controls.Remove((tableLayoutPanel1.GetControlFromPosition(i / 6, i % 6)));
           
                //tableLayoutPanel1.GetControlFromPosition(i / 6, i % 6).Visible = false;
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void DrawingModule_Load(object sender, EventArgs e)
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
