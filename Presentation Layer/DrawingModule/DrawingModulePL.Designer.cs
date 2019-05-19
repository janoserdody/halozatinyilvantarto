using System;
using System.Windows.Forms;

namespace PresentationLayer.DrawingModule
{
    partial class DrawingModulePL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                UnSubscribe();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void UnSubscribe()
        {
            eventMediator.ErrorMessage -= OnErrorMessage;
        }
    

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.comboBoxSource = new System.Windows.Forms.ComboBox();
            this.comboBoxDestination = new System.Windows.Forms.ComboBox();
            this.comboLabel1 = new System.Windows.Forms.Label();
            this.comboLabel2 = new System.Windows.Forms.Label();
            this.buttonPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deviceNameTextBox = new System.Windows.Forms.TextBox();
            this.deviceIdTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.portListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.portNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.connectionTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.portNumberTextBox = new System.Windows.Forms.TextBox();
            this.portIdTextBox = new System.Windows.Forms.TextBox();
            this.portLocationTextBox = new System.Windows.Forms.TextBox();
            this.portTypeTextBox = new System.Windows.Forms.TextBox();
            this.portConfigTextBox = new System.Windows.Forms.TextBox();
            this.portMacAddressTextBox = new System.Windows.Forms.TextBox();
            this.portIpAddressTextBox = new System.Windows.Forms.TextBox();
            this.drawingModulePLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.drawingModulePLBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.drawingModulePLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawingModulePLBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScrollMargin = new System.Drawing.Size(2, 2);
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 15;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 77);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1800, 615);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(1479, 14);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(111, 20);
            this.errorLabel.TabIndex = 1;
            this.errorLabel.Text = "error message";
            // 
            // comboBoxSource
            // 
            this.comboBoxSource.DropDownHeight = 500;
            this.comboBoxSource.DropDownWidth = 189;
            this.comboBoxSource.FormattingEnabled = true;
            this.comboBoxSource.IntegralHeight = false;
            this.comboBoxSource.Location = new System.Drawing.Point(201, 18);
            this.comboBoxSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxSource.Name = "comboBoxSource";
            this.comboBoxSource.Size = new System.Drawing.Size(260, 28);
            this.comboBoxSource.TabIndex = 2;
            this.comboBoxSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxSource_KeyPress);
            // 
            // comboBoxDestination
            // 
            this.comboBoxDestination.DropDownHeight = 500;
            this.comboBoxDestination.DropDownWidth = 189;
            this.comboBoxDestination.FormattingEnabled = true;
            this.comboBoxDestination.IntegralHeight = false;
            this.comboBoxDestination.Location = new System.Drawing.Point(616, 18);
            this.comboBoxDestination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDestination.Name = "comboBoxDestination";
            this.comboBoxDestination.Size = new System.Drawing.Size(282, 28);
            this.comboBoxDestination.TabIndex = 3;
            this.comboBoxDestination.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxDestination_KeyPress);
            // 
            // comboLabel1
            // 
            this.comboLabel1.AutoSize = true;
            this.comboLabel1.Location = new System.Drawing.Point(84, 23);
            this.comboLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.comboLabel1.Name = "comboLabel1";
            this.comboLabel1.Size = new System.Drawing.Size(109, 20);
            this.comboLabel1.TabIndex = 4;
            this.comboLabel1.Text = "Forrás eszköz";
            // 
            // comboLabel2
            // 
            this.comboLabel2.AutoSize = true;
            this.comboLabel2.Location = new System.Drawing.Point(520, 23);
            this.comboLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.comboLabel2.Name = "comboLabel2";
            this.comboLabel2.Size = new System.Drawing.Size(86, 20);
            this.comboLabel2.TabIndex = 5;
            this.comboLabel2.Text = "Cél eszköz";
            // 
            // buttonPath
            // 
            this.buttonPath.Location = new System.Drawing.Point(927, 18);
            this.buttonPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPath.Name = "buttonPath";
            this.buttonPath.Size = new System.Drawing.Size(206, 35);
            this.buttonPath.TabIndex = 6;
            this.buttonPath.Text = "Útvonal rajzolás";
            this.buttonPath.UseVisualStyleBackColor = true;
            this.buttonPath.Click += new System.EventHandler(this.buttonPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 746);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Eszköz név";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 791);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Eszköz azonosító";
            // 
            // deviceNameTextBox
            // 
            this.deviceNameTextBox.Location = new System.Drawing.Point(399, 746);
            this.deviceNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceNameTextBox.Name = "deviceNameTextBox";
            this.deviceNameTextBox.ReadOnly = true;
            this.deviceNameTextBox.Size = new System.Drawing.Size(190, 26);
            this.deviceNameTextBox.TabIndex = 9;
            // 
            // deviceIdTextBox
            // 
            this.deviceIdTextBox.Location = new System.Drawing.Point(399, 791);
            this.deviceIdTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deviceIdTextBox.Name = "deviceIdTextBox";
            this.deviceIdTextBox.ReadOnly = true;
            this.deviceIdTextBox.Size = new System.Drawing.Size(190, 26);
            this.deviceIdTextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(248, 834);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Leírás";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(399, 834);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(190, 26);
            this.descriptionTextBox.TabIndex = 12;
            // 
            // portListBox
            // 
            this.portListBox.FormattingEnabled = true;
            this.portListBox.ItemHeight = 20;
            this.portListBox.Location = new System.Drawing.Point(740, 748);
            this.portListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portListBox.Name = "portListBox";
            this.portListBox.Size = new System.Drawing.Size(234, 384);
            this.portListBox.TabIndex = 13;
            this.portListBox.SelectedIndexChanged += new System.EventHandler(this.portListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 748);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Portok listája";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1040, 746);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Port név";
            // 
            // portNameTextBox
            // 
            this.portNameTextBox.Location = new System.Drawing.Point(1188, 748);
            this.portNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portNameTextBox.Name = "portNameTextBox";
            this.portNameTextBox.ReadOnly = true;
            this.portNameTextBox.Size = new System.Drawing.Size(218, 26);
            this.portNameTextBox.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 746);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Kapcsolat név";
            // 
            // connectionTextBox
            // 
            this.connectionTextBox.Location = new System.Drawing.Point(30, 791);
            this.connectionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.connectionTextBox.Name = "connectionTextBox";
            this.connectionTextBox.ReadOnly = true;
            this.connectionTextBox.Size = new System.Drawing.Size(182, 26);
            this.connectionTextBox.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1040, 792);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Port sorszám";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1040, 838);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Port azonosító";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1040, 885);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Elhelyezkedés";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1040, 931);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Port típus";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1040, 977);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Konfiguráció";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1040, 1023);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "MAC cím";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1040, 1069);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "IP cím";
            // 
            // portNumberTextBox
            // 
            this.portNumberTextBox.Location = new System.Drawing.Point(1188, 792);
            this.portNumberTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portNumberTextBox.Name = "portNumberTextBox";
            this.portNumberTextBox.ReadOnly = true;
            this.portNumberTextBox.Size = new System.Drawing.Size(218, 26);
            this.portNumberTextBox.TabIndex = 26;
            // 
            // portIdTextBox
            // 
            this.portIdTextBox.Location = new System.Drawing.Point(1188, 838);
            this.portIdTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portIdTextBox.Name = "portIdTextBox";
            this.portIdTextBox.ReadOnly = true;
            this.portIdTextBox.Size = new System.Drawing.Size(218, 26);
            this.portIdTextBox.TabIndex = 27;
            // 
            // portLocationTextBox
            // 
            this.portLocationTextBox.Location = new System.Drawing.Point(1188, 885);
            this.portLocationTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portLocationTextBox.Name = "portLocationTextBox";
            this.portLocationTextBox.ReadOnly = true;
            this.portLocationTextBox.Size = new System.Drawing.Size(218, 26);
            this.portLocationTextBox.TabIndex = 28;
            // 
            // portTypeTextBox
            // 
            this.portTypeTextBox.Location = new System.Drawing.Point(1188, 931);
            this.portTypeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portTypeTextBox.Name = "portTypeTextBox";
            this.portTypeTextBox.ReadOnly = true;
            this.portTypeTextBox.Size = new System.Drawing.Size(218, 26);
            this.portTypeTextBox.TabIndex = 29;
            // 
            // portConfigTextBox
            // 
            this.portConfigTextBox.Location = new System.Drawing.Point(1188, 977);
            this.portConfigTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portConfigTextBox.Name = "portConfigTextBox";
            this.portConfigTextBox.ReadOnly = true;
            this.portConfigTextBox.Size = new System.Drawing.Size(218, 26);
            this.portConfigTextBox.TabIndex = 30;
            // 
            // portMacAddressTextBox
            // 
            this.portMacAddressTextBox.Location = new System.Drawing.Point(1188, 1023);
            this.portMacAddressTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portMacAddressTextBox.Name = "portMacAddressTextBox";
            this.portMacAddressTextBox.ReadOnly = true;
            this.portMacAddressTextBox.Size = new System.Drawing.Size(218, 26);
            this.portMacAddressTextBox.TabIndex = 31;
            // 
            // portIpAddressTextBox
            // 
            this.portIpAddressTextBox.Location = new System.Drawing.Point(1188, 1069);
            this.portIpAddressTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.portIpAddressTextBox.Name = "portIpAddressTextBox";
            this.portIpAddressTextBox.ReadOnly = true;
            this.portIpAddressTextBox.Size = new System.Drawing.Size(218, 26);
            this.portIpAddressTextBox.TabIndex = 32;
            // 
            // drawingModulePLBindingSource
            // 
            this.drawingModulePLBindingSource.DataSource = typeof(PresentationLayer.DrawingModule.DrawingModulePL);
            // 
            // drawingModulePLBindingSource1
            // 
            this.drawingModulePLBindingSource1.DataSource = typeof(PresentationLayer.DrawingModule.DrawingModulePL);
            // 
            // DrawingModulePL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1860, 1050);
            this.Controls.Add(this.portIpAddressTextBox);
            this.Controls.Add(this.portMacAddressTextBox);
            this.Controls.Add(this.portConfigTextBox);
            this.Controls.Add(this.portTypeTextBox);
            this.Controls.Add(this.portLocationTextBox);
            this.Controls.Add(this.portIdTextBox);
            this.Controls.Add(this.portNumberTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.connectionTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.portNameTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.portListBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deviceIdTextBox);
            this.Controls.Add(this.deviceNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonPath);
            this.Controls.Add(this.comboLabel2);
            this.Controls.Add(this.comboLabel1);
            this.Controls.Add(this.comboBoxDestination);
            this.Controls.Add(this.comboBoxSource);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DrawingModulePL";
            this.Text = "DrawingModule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DrawingModule_FormClosing);
            this.Load += new System.EventHandler(this.DrawingModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawingModulePLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawingModulePLBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Label errorLabel;
        private ComboBox comboBoxSource;
        private ComboBox comboBoxDestination;
        private Label comboLabel1;
        private Label comboLabel2;
        private BindingSource drawingModulePLBindingSource;
        private BindingSource drawingModulePLBindingSource1;
        private Button buttonPath;
        private Label label1;
        private Label label2;
        private TextBox deviceNameTextBox;
        private TextBox deviceIdTextBox;
        private Label label3;
        private TextBox descriptionTextBox;
        private ListBox portListBox;
        private Label label4;
        private Label label5;
        private TextBox portNameTextBox;
        private Label label6;
        private TextBox connectionTextBox;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox portNumberTextBox;
        private TextBox portIdTextBox;
        private TextBox portLocationTextBox;
        private TextBox portTypeTextBox;
        private TextBox portConfigTextBox;
        private TextBox portMacAddressTextBox;
        private TextBox portIpAddressTextBox;
    }
}