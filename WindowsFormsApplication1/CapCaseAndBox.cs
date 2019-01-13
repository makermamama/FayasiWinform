using LZ.WpfSlovo.db.Access;
using PLCWindowsForms.toolBean;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.tool;

namespace WindowsFormsApplication1
{
    public partial class CapCaseAndBox : Form
    {
        SerialPort port;
        DataTable TableCase = new DataTable();
        DataTable TableBox = new DataTable();
        HashSet<String> hashSetCases = new HashSet<String>();

        public CapCaseAndBox()
        {
            InitializeComponent();
            TableBox.Columns.Add("箱号ID", typeof(string));
            TableBox.Columns.Add("上传状态", typeof(string));
            TableBox.Columns.Add("关联箱码", typeof(string));
            dataGridViewBox.DataSource = TableBox;
            GetUnUplaodBoxs();
            dataGridViewCase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBox.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// 开始运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                port = new SerialPort();
                port.PortName = XmlTool.Read("Root/ComSensor");
                port.BaudRate = Convert.ToInt32(XmlTool.Read("Root/BateRate"));
                port.Open();
                this.port.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
            catch (Exception ex)
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        //串口数据接收
        private String portData;
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[port.BytesToRead];
            port.Read(ReDatas, 0, ReDatas.Length);
            string str = Encoding.Default.GetString(ReDatas);
            portData += str;
            if (portData.Substring(portData.Length - 1, 1) == @"/r" && portData.Length==65) {
                portData = portData.Substring(0, portData.Length - 1);
                AddOneCase(portData);
                portData = "";
            }
        }

        //增加一个盒号
        private void AddOneCase(String msg) {
            if (hashSetCases.Add(msg)) {
                ViewGridAddRow(msg);
                if (hashSetCases.Count == BaseData.CapSum) {
                    Console.WriteLine("生成箱单开始"+  DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                    Guid boxGuid = Guid.NewGuid();
                    AccessDB.CreatBoxOrder(hashSetCases, boxGuid.ToString());
                    AddOneNoUpBox(boxGuid.ToString());
                    ViewGridClear();
                    Console.WriteLine("生成箱单结束" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                }
            }
        }

        //增加一个未上传的箱号
        private void AddOneNoUpBox(String Guid)
        {
            DataRow row = TableBox.NewRow();
            row[0] = Guid;
            row[1] = "未上传";
            row[2] = "空";
            TableBox.Rows.Add(row);
            dataGridViewBox.DataSource = null;
            dataGridViewBox.DataSource = TableBox;
        }

        //增加一个已上传的箱号
        private void UpOneUpBox(String Guid, String BindBoxNumber)
        {
            String sql = String.Format("箱号ID = '{0}'", Guid);
            DataRow[] rows = TableBox.Select(sql);
            if (rows.Length == 1)
            {
                rows[0][0] = Guid;
                rows[0][1] = "已上传";
                rows[0][2] = BindBoxNumber;
                dataGridViewBox.DataSource = null;
                dataGridViewBox.DataSource = TableBox;
            }
            else {
                throw new Exception("箱号Id不唯一");
            }
        }
    
        
        private void ViewGridAddRow(String Case)
        {
            DataGridViewRow dr = new DataGridViewRow();
            dr.CreateCells(dataGridViewCase);
            dr.Cells[0].Value = Case;
            dataGridViewCase.Rows.Insert(0, dr);
        }

        private void ViewGridClear()
        {
            hashSetCases.Clear();
            dataGridViewCase.Rows.Clear();
        }

        /// <summary>
        /// 停止运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                if (port != null) {
                    this.port.DataReceived -= new SerialDataReceivedEventHandler(serialPort_DataReceived);
                    port.Close();
                    port.Dispose();
                }
            }
            catch (Exception ex)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        //上传箱号
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    String BoxGuid = AccessDB.UpDataOne(textBox2.Text);
                    UpOneUpBox(BoxGuid, textBox2.Text);
                    textBox2.Text = "";
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtCase_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (e.KeyChar == 13) {
                    AddOneCase(txtCase.Text);
                    txtCase.Text = "";
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        //QueryNoUplaodBox
        //获取未完成的箱号
        private void GetUnUplaodBoxs()
        {
            try
            {
                DataSet dataSet = AccessDB.QueryNoUplaodBox();
                foreach (DataRow row in dataSet.Tables[0].Rows) {
                    String boxGuid = row["FGuid"].ToString();
                    AddOneNoUpBox(boxGuid);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
