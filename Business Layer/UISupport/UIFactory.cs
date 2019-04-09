using Common.Support._interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Support
{
    public class UIFactory : IUIFactory
    {
        Button IUIFactory.GetButton(Button button, string buttonType, string id, string text)
        {
            button.Name = id;
            button.Text = text;

            switch (buttonType)
            {
                case "blueButton":
                BlueButton(button);
                    break;
                case "redButton":
                RedButton(button);
                    break;
                default:
                    break;
            }
            return button;
        }

        ListBox IUIFactory.GetListBox(ListBox listBox, string listBoxType, string id, string text)
        {
            throw new NotImplementedException();
        }

        Label IUIFactory.GetLabel(Label label, string labelType, string id, string text)
        {
            throw new NotImplementedException();
        }

        TextBox IUIFactory.GetTextBox(TextBox textBox, string textBoxType, string id, string text)
        {
            throw new NotImplementedException();
        }

        private Button BlueButton(Button button)
        {
            button.BackColor = System.Drawing.Color.Blue;
            GetDefaultButton(button);

            return button;
        }

        private Button RedButton(Button button)
        {
            button.BackColor = System.Drawing.Color.Red;
            return button;
        }

        private void GetDefaultButton(Button button)
        {
            button.Size = new System.Drawing.Size(75, 23);
            button.UseVisualStyleBackColor = false;
        }
    }
}
