using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.DrawingModule
{
    public partial class Progress : Form
    {
        public Progress(int maximum)
        {
            InitializeComponent();

            progressBar1.Maximum = maximum;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.RightToLeft = RightToLeft.No;
        }

        public void Perform()
        {
            progressBar1.PerformStep();
        }

        private void Progress_Activated(object sender, EventArgs e)
        {
            label1.Update();
        }
    }
}
