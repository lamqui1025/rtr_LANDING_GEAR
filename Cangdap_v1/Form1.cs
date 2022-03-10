using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClosedXML.Excel;

using System.IO;
using System.IO.Ports;
using System.Xml;

namespace Cangdap_v1
{
    public partial class Form1 : Form
    {
        const int LEN_FRAME = 12;
        const int LEN_DATA = 8;
        const byte bSTX = 0x02;
        const byte bETX = 0x03;
        const int bRX = 0xFF;
        const int bSRX = 0xF2;
        const int bERX = 0xF3;

        int NUM_Sample = 200;

        //uint longtime = 0;
        
        //delegate void SetTextCallback(byte[] str);
        delegate void newSetTextCallback(int oneb);
        byte[] INPUTdata = new byte[LEN_FRAME];
        
        bool flag_addRX = false;
        bool flag_stack = false;
        bool rec_success = false;
        bool enable_rec = false;
        bool grid_scroll = true;

        DateTime TimeStart;
        TimeSpan longTimePause = TimeSpan.Zero;

        int[] buffData = new int[LEN_DATA];
        int k = 0;

        int count_file = 0;
        string strFile;

        string Path;
        BindingSource dts = new BindingSource();
        DataTable dt = new DataTable();
        
        int cnt = 0;
        enum SYSTEM_STATE
        {
            MOTOR_IDLE = 0,
            MOTOR_1_IDLE,
            MOTOR_1_CW,
            MOTOR_1_CCW,
            MOTOR_2_IDLE,
            MOTOR_2_CW,
            MOTOR_2_CCW
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            serialPort1.Close();
            BoxParity.SelectedIndex = 0;
            BoxBaudRate.SelectedIndex = 9;
            Box_numsample.SelectedIndex = 3;
            LoadGridView();
            LoadDataTable();
            strFile = "EXPORT SUCCESSFULLY " + count_file + " FILE!";
            //LoadListView();
        }

        private void OpenPort()
        {
            serialPort1.PortName = BoxNamePorts.Text;
            serialPort1.BaudRate = Convert.ToInt32(BoxBaudRate.Text);
            if (BoxParity.Text == "None")
                serialPort1.Parity = Parity.None;
            else if (BoxParity.Text == "Odd")
                serialPort1.Parity = Parity.Odd;
            else if (BoxParity.Text == "Even")
                serialPort1.Parity = Parity.Even;
            else if (BoxParity.Text == "Mark")
                serialPort1.Parity = Parity.Mark;
            else if (BoxParity.Text == "Space")
                serialPort1.Parity = Parity.Space;
            enable_rec = true;
            serialPort1.Open();
            TimeStart = DateTime.Now;
        }

        private void ClosePort()
        {
            serialPort1.Close();
            longTimePause += DateTime.Now - TimeStart;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                labelStatus.Text = "Disconnected";
                labelStatus.ForeColor = Color.Red;
                buttonStatus.Text = "Open";
                buttonStatus.BackColor = Color.Green;
                TimeStart = DateTime.Now;
            }
            else if (serialPort1.IsOpen)
            {
                labelStatus.Text = "Connected";
                labelStatus.ForeColor = Color.Green;
                buttonStatus.Text = "Close";
            }
            if (grid_scroll)
                buttonScroll.Text = "disable";
            else buttonScroll.Text = "enable";

            TimeSpan ts = DateTime.Now - TimeStart + longTimePause;
            string strlongtime = ts.Days + " days " + ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
            ScreenInform.Text = "Time stamp: " + strlongtime + Environment.NewLine + strFile;
        }

        /*private string count_longtime()
        {
            longtime += 1;
            uint sec = (longtime / 10) % 60;
            uint min = (longtime / (10 * 60)) % 60;
            uint hou = (longtime / (10 * 60 * 60));
            
            string strlongtime = hou.ToString() + ":" + min.ToString() + ":" + sec.ToString();
            return strlongtime;
        }*/

        private void buttonGetPorts_Click(object sender, EventArgs e)
        {
            BoxNamePorts.DataSource = SerialPort.GetPortNames();
        }

        private async void buttonStatus_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                if (BoxNamePorts.Text == "" || BoxBaudRate.Text == "")
                {
                    if (BoxNamePorts.Text == "")
                    {
                        MessageBox.Show("Chưa chọn Port!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (BoxBaudRate.Text == "")
                    {
                        MessageBox.Show("Chưa chọn Baud Rate!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (Path == null)
                {
                    MessageBox.Show("Chose PATH!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    OpenPort();
                    buttonStatus.Text = "Close";
                    BoxNamePorts.Enabled = false;
                    BoxBaudRate.Enabled = false;
                    BoxParity.Enabled = false;
                    Box_numsample.Enabled = false;
                    NUM_Sample = Convert.ToUInt16(Box_numsample.Text);
                }

                //serialPort1.Write("HELLO!");
            }
            else if (serialPort1.IsOpen)
            {
                enable_rec = false;
                Task closeP = Task_ClosePort();
                //ClosePort();
                await closeP;
                buttonStatus.Text = "Open";
                BoxNamePorts.Enabled = true;
                BoxBaudRate.Enabled = true;
                BoxParity.Enabled = true;
                Box_numsample.Enabled = true;
            }
        }

        private async Task Task_ClosePort()
        {
            Action myaction = () =>
            {
                ClosePort();
            };
            Task task = new Task(myaction);
            task.Start();
            await task;
        }

        private void buttonScroll_Click(object sender, EventArgs e)
        {
            //Screen.Clear();
            grid_scroll = !grid_scroll;
        }

        private byte[] SubArray(byte[] buff, int index, int offer)
        {
            byte[] subtemp = new byte[offer];
            for(int i = 0; i < offer; i++)
            {
                subtemp[i] = buff[index++];
            }
            return subtemp;
        }
        // Add RX data buffer
        private void Add_RXBuff(int dRec)
        {
            // check byte to set flag
            if (dRec == 0xFF)
                flag_stack = true;
            else if (flag_stack && dRec == 0xF2)
            {
                buffData = new int[LEN_DATA];        // clear buffData
                flag_addRX = true;
                flag_stack = false;
                k = 0;
            }
            else if (flag_stack && dRec == 0xF3)
            {
                flag_addRX = false;
                flag_stack = false;

                if (k == LEN_DATA)
                {
                    rec_success = true;
                    Screen.Text = "Received sucess:" + ByteArrayTostrHEX(buffData) + Environment.NewLine + Screen.Text;
                }
                else
                {
                    rec_success = false;
                    Screen.Text = "One FRAME ERROR!! -- Received " + k.ToString() + " byte Data" + Environment.NewLine + Screen.Text;
                }
            }
            else
            {
                if (flag_addRX)
                {
                    if (k < LEN_DATA)
                    {
                        buffData[k] = dRec;
                        flag_stack = false;
                        k++;
                    }
                    else
                        Screen.Text = "ERROR: Out of LENGTH DATA -- len=" + (k+1) + Environment.NewLine + Screen.Text;
                }
            }
        }

        private void LoadGridView()
        {
            dts.DataSource = typeof(cData);
            dGridV.DataSource = dts;
            dGridV.Columns["ct"].HeaderText = "Count";
            dGridV.Columns["cdati"].HeaderText = "Date & Time";
            dGridV.Columns["cM1"].HeaderText = "M1 Current";
            dGridV.Columns["cM1_st"].HeaderText = "M1 State";
            dGridV.Columns["cM2"].HeaderText = "M2 Current";
            dGridV.Columns["cM2_st"].HeaderText = "M2 State";
            dGridV.Columns["cCy_cnt"].HeaderText = "Cycle Counter";
            //dGridV.FirstDisplayedScrollingRowIndex = dGridV.RowCount - 1;
        }

        private void LoadDataTable()
        {
            dt.Columns.Add("Count", typeof(int));
            dt.Columns.Add("Date & Time", typeof(string));
            dt.Columns.Add("M1 Current", typeof(int));
            dt.Columns.Add("M1 State", typeof(string));
            dt.Columns.Add("M2 Current", typeof(int));
            dt.Columns.Add("M2 State", typeof(string));
            dt.Columns.Add("Cycle Counter", typeof(int));
        }

        private String enumToString(Enum eff)
        {
            return Enum.GetName(eff.GetType(), eff);
        }

            private void ProcessData(int[] RXbuff)
        {
            int M1 = RXbuff[0]*256 + RXbuff[1];
            int M1_st = RXbuff[2];
            int M2 = RXbuff[3]*256 + RXbuff[4];
            int M2_st = RXbuff[5];
            int cy_cnt = RXbuff[6]*256 + RXbuff[7];
            string dati = DateTime.Now.ToString();

            SYSTEM_STATE eM1_st = (SYSTEM_STATE)RXbuff[2];
            SYSTEM_STATE eM2_st = (SYSTEM_STATE)RXbuff[5];

            string sM1_st = enumToString(eM1_st);
            string sM2_st = enumToString(eM2_st);

            cnt++;
            dts.Add(new cData() {ct = cnt, cdati = dati, cM1 = M1, cM1_st = sM1_st, cM2 = M2, cM2_st = sM2_st, cCy_cnt = cy_cnt });
            // -
            dt.Rows.Add(cnt, dati, M1, sM1_st, M2, sM2_st, cy_cnt);

            if (grid_scroll)
                dGridV.FirstDisplayedScrollingRowIndex = dGridV.RowCount - 1;

            dGridV.DataSource = dts;

            if (cnt >= NUM_Sample)
            {
                Screen.Clear();
                
                //Task ex2 = Task_Export2Excel(Path + count_file.ToString());
                //Export2Excel(dGridV, Path + count_file);
                newExport2Excel(Path + count_file);
                cnt = 0;
            }
        }

        public static string ByteArrayTostrHEX(int[] buffer)
        {
            //StrBuilder.Clear();
            StringBuilder StrBuilder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                StrBuilder.AppendFormat("{0:X2} ", buffer[i]);
            }
            return StrBuilder.ToString();
        }

        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            if (enable_rec)
            {
                try
                {
                    int bb = serialPort1.ReadByte();
                    newSetText(bb);
                }
                catch (Exception ex)
                {
                    Screen.Text = ex.Message + Environment.NewLine + Screen.Text;
                }
            }
            else return;
        }


        private void newSetText(int brec)
        {
            if (this.Screen.InvokeRequired && this.ScreenInform.InvokeRequired && this.dGridV.InvokeRequired)
            {
                newSetTextCallback del = new newSetTextCallback(newSetText);
                this.Invoke(del, new object[] { brec });
            }
            else
            {
                Add_RXBuff(brec);
                if (rec_success)
                {
                    rec_success = false;
                    ProcessData(buffData);
                }
            }
        }

      /*  private void SetText(byte[] buff)
        {
            if (this.dGridV.InvokeRequired)
            {
                SetTextCallback del = new SetTextCallback(SetText);
                this.Invoke(del, new object[] { buff });
            }
            else
            {
                string str = ByteArrayTostrHEX(buff);
                Screen.Text = str + Environment.NewLine + Screen.Text;
                //ProcessData(buff);
            }
        }*/

        private void buttonBrwose_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Path = saveFileDialog1.FileName;
                textBoxPath.Text = Path;
            }
        }
        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (Path != null)
            {
                newExport2Excel(Path);
                //Task ex2 = Task_Export2Excel(Path);
            }
            else
                MessageBox.Show("Browse to Path!", "Chose Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /*private void Export2Excel(DataGridView dgv1, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook wb;
            Microsoft.Office.Interop.Excel.Worksheet ws;
            //Microsoft.Office.Interop.Excel.Range exrange;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                wb = excel.Workbooks.Add(Type.Missing);
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets["Sheet1"];
                ws.Name = "Sheet1";

                //Export Header
                for (int i = 0; i<dGridV.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1] = dGridV.Columns[i].HeaderText;
                }
                //export content
                for (int i = 0; i < dGridV.RowCount - 1; i++)
                {
                    for (int j = 0; j < dGridV.ColumnCount; j++)
                    {
                        ws.Cells[i + 2, j + 1] = dGridV.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //save workbook
                wb.SaveAs(fileName);
                
                wb.Close();
                excel.Quit();
                strFile = "EXPORT SUCCESSFULLY " + count_file + " FILE!";
                dts.Clear();
                //MessageBox.Show("Export Successfully ^.^", "Congratulation!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //ScreenInform.Text = strFile;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                wb = null;
                ws = null;
            }
        }*/

        /*private Task Task_Export2Excel(string fileName)
        {
            Action myaction = () =>
            {
                Export2Excel(dGridV, fileName);
            };
            Task task = new Task(myaction);
            task.Start();
            return task;
        }*/

        private void newExport2Excel(string fileName)
        {
            var wb = new XLWorkbook();
            //var ws = wb.Worksheets.Add("Sheet1");
            try
            {
                wb.Worksheets.Add(dt, "Sheet1");
                wb.SaveAs(fileName + ".xlsx");

                strFile = "EXPORT SUCCESSFULLY " + count_file + " FILE!";
                count_file++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wb = null;
                dt.Clear();
                dts.Clear();
                //ws = null;
            }
        }


        /*private void ThreadOne (Microsoft.Office.Interop.Excel.Workbook wb, string fileName)
        {
            wb.SaveAs(fileName);
        }*/

        /*private void saveWorkBook(wb, string fileName)
        {
            wb.SaveAs(fileName);
            wb.Close();
            excel.Quit();
            MessageBox.Show("Export Successully ^.^", "Congratulation!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/

        /* EVENT ARE HERE ------------------------------------------------------------*/


    }
    class cData
   {
        public int ct { set; get; }
        public string cdati { set; get; }
        public int cM1 { set; get; }
        public string cM1_st { set; get; }
        public int cM2 { set; get; }
        public string cM2_st { set; get; }
        public int cCy_cnt { set; get; }
   }
}

