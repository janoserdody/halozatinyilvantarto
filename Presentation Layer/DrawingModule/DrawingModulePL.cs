using BusinessLayer.DrawingModule;
using BusinessLayer.DrawingModule._interfaces;
using BusinessLayer.Interfaces;
using BusinessLayer.Support._interfaces;
using Common;
using Common.Interfaces;
using PresentationLayer.DrawingModule._interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private int sourceItem = 1;

        private int destinationItem = 1;

        private int pathIndex;

        private IItemActive item;

        private BindingList<KeyValuePair<int, string>> portList = new BindingList<KeyValuePair<int, string>>();

        public BindingList<KeyValuePair<int, string>> itemSourceList = new BindingList<KeyValuePair<int, string>>();

        public BindingList<KeyValuePair<int, string>> itemDestinationList = new BindingList<KeyValuePair<int, string>>();

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

        private void InitializeItemList()
        {
            for (int i = 1; i < frameWork.ItemActiveCount + 1; i++)
            {
                KeyValuePair<int, string> keyValue = new KeyValuePair<int, string>(i,
                  frameWork.GetItemActive(i).DeviceName);
                itemSourceList.Add(keyValue);
                itemDestinationList.Add(keyValue);
            }

            comboBoxSource.DataSource = null;
            comboBoxSource.DataSource = itemSourceList;
            comboBoxSource.ValueMember = "Key";
            comboBoxSource.DisplayMember = "Value";
            this.comboBoxSource.SelectedIndexChanged += new System.EventHandler(this.comboBoxSource_SelectedIndexChanged);
            comboBoxDestination.DataSource = null;
            comboBoxDestination.DataSource = itemDestinationList;
            comboBoxDestination.ValueMember = "Key";
            comboBoxDestination.DisplayMember = "Value";
            this.comboBoxDestination.SelectedIndexChanged += new System.EventHandler(this.comboBoxDestination_SelectedIndexChanged);
            portListBox.DataSource = null;
            portListBox.DataSource = portList;
            portListBox.ValueMember = "Key";
            portListBox.DisplayMember = "Value";
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
                pictureBox.MouseClick += pictureBox_Click;

                tableLayoutPanel1.Controls.Add(pictureBox, x, y);
        }

        void IDrawingModulePL.ClearPath()
        {
            tableLayoutPanel1.Controls.Clear();
        }

        private void DrawingModule_Load(object sender, EventArgs e)
        {
            InitializeItemList();
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

        private void comboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceItem = (int)comboBoxSource.SelectedValue;
        }

        private void comboBoxDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            destinationItem = (int)comboBoxDestination.SelectedValue;
        }
       
        private void buttonPath_Click(object sender, EventArgs e)
        {
            string text = comboBoxDestination.Text;

            int index = comboBoxDestination.FindString(text);

            if (index == -1)
            {
                MessageBox.Show("Hibás bevitel, kérem válasszon másik cél eszközt!");
                return;
            }

            comboBoxDestination.SelectedIndex = index;

            destinationItem = (int)comboBoxDestination.SelectedValue;

            text = comboBoxSource.Text;

            index = comboBoxSource.FindString(text);

            if (index == -1)
            {
                MessageBox.Show("Hibás bevitel, kérem válasszon másik forrás eszközt!");
                return;
            }
            comboBoxSource.SelectedIndex = index;

            sourceItem = (int)comboBoxSource.SelectedValue;

            drawingModuleBL.Drawing(sourceItem, destinationItem);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            Point point = tableLayoutPanel1.PointToClient(Cursor.Position);
            if (!IsValidPosition(point))
            {
                return;
            }
            CalculateIndex(point);
            if (pathIndex % 2 == 0)
            {
            ItemPrintToScreen();
            }
            else
            {
            ConnectionPrintToScreen();
            }
        }

        private void ItemPrintToScreen()
        {
            connectionTextBox.Text = string.Empty;
            int selectedItemIndex = printPath.Path[pathIndex / 2];
            item = frameWork.GetItemActive(selectedItemIndex);
            deviceNameTextBox.Text = item.DeviceName;
            deviceIdTextBox.Text = item.DeviceID;
            descriptionTextBox.Text = item.Notes;
            portList.Clear();

            foreach (var portNumber in item.GetPortsNumberList())
            {
                IPortActive portActive = frameWork.GetPortActive(item.Id, portNumber);
                portList.Add(new KeyValuePair<int, string>(portNumber, portActive.PortName));
            }
        }

        private void ConnectionPrintToScreen()
        {
            InitializeItemTextBox();
            int selectedItemIndex = printPath.Path[pathIndex / 2];
            item = frameWork.GetItemActive(selectedItemIndex);
            IList<int> connectionIdList = item.GetConnectionsIDList();
            if ((pathIndex / 2) +1 >= printPath.Path.Count)
            {
                MessageBox.Show("out of index");
                return;
            }
            IItemActive nextItem = frameWork.GetItemActive(printPath.Path[(pathIndex / 2) + 1]);
            IConnection connection;
            foreach (int searchId in connectionIdList)
            {
                connection = frameWork.GetConnection(searchId);
                if (connection.DestinationItemId == nextItem.Id || connection.SourceItemId == nextItem.Id)
                {
                    connectionTextBox.Text = connection.Name;
                    break;
                }
            }
        }

        private void InitializeItemTextBox()
        {
            deviceNameTextBox.Text = string.Empty;
            deviceIdTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
            portList.Clear();
            portNameTextBox.Text = string.Empty;
            portNumberTextBox.Text = string.Empty;
            portIdTextBox.Text = string.Empty;
            portLocationTextBox.Text = string.Empty;
            portTypeTextBox.Text =string.Empty;
            portConfigTextBox.Text = string.Empty;
            portMacAddressTextBox.Text = string.Empty;
            portIpAddressTextBox.Text = string.Empty;
        }

        private void CalculateIndex(Point point)
        {
            int x = point.X;
            int y = point.Y;
            int positionX = x / 80;
            int positionY = y / 80;

            pathIndex = positionY * columnNumber;
            pathIndex += positionY % 2 == 0 ? positionX : columnNumber - (positionX + 1);
        }

        private bool IsValidPosition(Point point)
        {
            bool isValid = false;
        if (point.X > 1199 || point.Y > 399)
            {
                return isValid;
            }
        else
            {
            isValid = true;
            return isValid;
            }
        }

        private void portListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = portListBox.SelectedIndex;
            if (index == -1)
            {
                return;
            }
            int portNumber = (int)portListBox.SelectedValue;

            IPortActive port = frameWork.GetPortActive(item.Id, portNumber);

            portNameTextBox.Text = port.PortName;

            portNumberTextBox.Text = port.PortNumber.ToString();

            portIdTextBox.Text = port.PortID;

            portLocationTextBox.Text = port.PhysicalLocation;

            portTypeTextBox.Text = port.PortPhysicalType;

            portConfigTextBox.Text = port.PortConfig;

            portMacAddressTextBox.Text = port.MacAddress;

            portIpAddressTextBox.Text = port.IPAddress;
        }
    }
}
