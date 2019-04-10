using BusinessLayer;
using BusinessLayer.Interfaces;
using BusinessLayer.Support._interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            InitializeComponent();



        }
    }
}
