using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer.Support._interfaces
{
    public interface IUIFactory
    {
        Button GetButton(Button button, string buttonType, string id, string text);

        Form SetFormSize(Form form, int sizeX, int sizeY);

        ListBox GetListBox(ListBox listBox, string listBoxType, string id, string text);

        Label GetLabel(Label label, string labelType, string id, string text);

        TextBox GetTextBox(TextBox textBox, string textBoxType, string id, string text);
    }
}
