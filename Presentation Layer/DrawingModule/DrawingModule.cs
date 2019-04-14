using Common;
using Common.Interfaces;
using Common.Models;
using Common.Support._interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            ISymbol routerSymbol = frameWork.GetSymbol(Helpers.GetSymbolIndex("router"));

            ISymbol switchSymbol = frameWork.GetSymbol(Helpers.GetSymbolIndex("switch"));

            ISymbol lineVertical = frameWork.GetSymbol(Helpers.GetSymbolIndex("linevertical"));

            ISymbol lineHorizontal = frameWork.GetSymbol(Helpers.GetSymbolIndex("linehorizontal"));

            ImageLoad(1, 1, routerSymbol.GetImage());
            ImageLoad(2, 2, switchSymbol.GetImage());
            Random rnd = new Random();

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
    }
}
