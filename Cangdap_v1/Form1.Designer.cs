namespace Cangdap_v1
{
    partial class Form1
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
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGetPorts = new System.Windows.Forms.Button();
            this.BoxParity = new System.Windows.Forms.ComboBox();
            this.BoxBaudRate = new System.Windows.Forms.ComboBox();
            this.BoxNamePorts = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Box_numsample = new System.Windows.Forms.ComboBox();
            this.ScreenInform = new System.Windows.Forms.TextBox();
            this.buttonScroll = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.dGridV = new System.Windows.Forms.DataGridView();
            this.Screen = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridV)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.buttonStatus);
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonGetPorts);
            this.groupBox1.Controls.Add(this.BoxParity);
            this.groupBox1.Controls.Add(this.BoxBaudRate);
            this.groupBox1.Controls.Add(this.BoxNamePorts);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1327, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial";
            // 
            // buttonStatus
            // 
            this.buttonStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStatus.Location = new System.Drawing.Point(1133, 10);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.Size = new System.Drawing.Size(85, 38);
            this.buttonStatus.TabIndex = 3;
            this.buttonStatus.Text = "Open";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(954, 17);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(115, 24);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Disconected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Parity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(644, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Baud rate";
            // 
            // buttonGetPorts
            // 
            this.buttonGetPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetPorts.Location = new System.Drawing.Point(254, 16);
            this.buttonGetPorts.Name = "buttonGetPorts";
            this.buttonGetPorts.Size = new System.Drawing.Size(72, 32);
            this.buttonGetPorts.TabIndex = 1;
            this.buttonGetPorts.Text = "Get";
            this.buttonGetPorts.UseVisualStyleBackColor = true;
            this.buttonGetPorts.Click += new System.EventHandler(this.buttonGetPorts_Click);
            // 
            // BoxParity
            // 
            this.BoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxParity.FormattingEnabled = true;
            this.BoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.BoxParity.Location = new System.Drawing.Point(465, 18);
            this.BoxParity.Name = "BoxParity";
            this.BoxParity.Size = new System.Drawing.Size(121, 26);
            this.BoxParity.TabIndex = 0;
            // 
            // BoxBaudRate
            // 
            this.BoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxBaudRate.FormattingEnabled = true;
            this.BoxBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.BoxBaudRate.Location = new System.Drawing.Point(743, 19);
            this.BoxBaudRate.Name = "BoxBaudRate";
            this.BoxBaudRate.Size = new System.Drawing.Size(121, 26);
            this.BoxBaudRate.TabIndex = 0;
            // 
            // BoxNamePorts
            // 
            this.BoxNamePorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxNamePorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxNamePorts.FormattingEnabled = true;
            this.BoxNamePorts.Location = new System.Drawing.Point(127, 18);
            this.BoxNamePorts.Name = "BoxNamePorts";
            this.BoxNamePorts.Size = new System.Drawing.Size(121, 26);
            this.BoxNamePorts.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Box_numsample);
            this.groupBox2.Controls.Add(this.ScreenInform);
            this.groupBox2.Controls.Add(this.buttonScroll);
            this.groupBox2.Controls.Add(this.buttonBrowse);
            this.groupBox2.Controls.Add(this.buttonExport);
            this.groupBox2.Controls.Add(this.textBoxPath);
            this.groupBox2.Controls.Add(this.dGridV);
            this.groupBox2.Controls.Add(this.Screen);
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1327, 588);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(1088, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Number of Sample";
            // 
            // Box_numsample
            // 
            this.Box_numsample.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Box_numsample.FormattingEnabled = true;
            this.Box_numsample.Items.AddRange(new object[] {
            "200",
            "500",
            "1000",
            "3000"});
            this.Box_numsample.Location = new System.Drawing.Point(1091, 69);
            this.Box_numsample.Name = "Box_numsample";
            this.Box_numsample.Size = new System.Drawing.Size(80, 26);
            this.Box_numsample.TabIndex = 8;
            // 
            // ScreenInform
            // 
            this.ScreenInform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScreenInform.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ScreenInform.Location = new System.Drawing.Point(7, 21);
            this.ScreenInform.Multiline = true;
            this.ScreenInform.Name = "ScreenInform";
            this.ScreenInform.ReadOnly = true;
            this.ScreenInform.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ScreenInform.Size = new System.Drawing.Size(602, 74);
            this.ScreenInform.TabIndex = 7;
            // 
            // buttonScroll
            // 
            this.buttonScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScroll.Location = new System.Drawing.Point(1213, 69);
            this.buttonScroll.Name = "buttonScroll";
            this.buttonScroll.Size = new System.Drawing.Size(81, 26);
            this.buttonScroll.TabIndex = 6;
            this.buttonScroll.Text = "disable";
            this.buttonScroll.UseVisualStyleBackColor = true;
            this.buttonScroll.Click += new System.EventHandler(this.buttonScroll_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowse.Location = new System.Drawing.Point(1091, 101);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(92, 28);
            this.buttonBrowse.TabIndex = 5;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrwose_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExport.Location = new System.Drawing.Point(1189, 102);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(132, 27);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(7, 102);
            this.textBoxPath.Multiline = true;
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(1078, 26);
            this.textBoxPath.TabIndex = 3;
            // 
            // dGridV
            // 
            this.dGridV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridV.Location = new System.Drawing.Point(6, 134);
            this.dGridV.Name = "dGridV";
            this.dGridV.ReadOnly = true;
            this.dGridV.RowHeadersWidth = 51;
            this.dGridV.RowTemplate.Height = 24;
            this.dGridV.Size = new System.Drawing.Size(1315, 448);
            this.dGridV.TabIndex = 2;
            // 
            // Screen
            // 
            this.Screen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Screen.Location = new System.Drawing.Point(615, 21);
            this.Screen.Multiline = true;
            this.Screen.Name = "Screen";
            this.Screen.ReadOnly = true;
            this.Screen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Screen.Size = new System.Drawing.Size(706, 76);
            this.Screen.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1213, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "scroll";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1351, 672);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LANDING GEAR";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGetPorts;
        private System.Windows.Forms.ComboBox BoxBaudRate;
        private System.Windows.Forms.ComboBox BoxNamePorts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BoxParity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Screen;
        private System.Windows.Forms.DataGridView dGridV;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonScroll;
        private System.Windows.Forms.TextBox ScreenInform;
        private System.Windows.Forms.ComboBox Box_numsample;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

