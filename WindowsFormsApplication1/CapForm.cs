using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestForms.Http;
using WebApplication1;
using WindowsFormsApplication1.http.bean;
using WindowsFormsApplication1.tool;
using WpfSlovo;

namespace WindowsFormsApplication1
{
    public partial class CapForm : Form
    {
        private int capsum = 0;

        private HashSet<String> Datas = new HashSet<String>();

        private DataTable DataSource = new DataTable();

        public CapForm()
        {
            InitializeComponent();
            dgShow.DataSource = DataSource;
            DataSource.Columns.Add("ID",    typeof(String));
            DataSource.Columns.Add("盒码",   typeof(String));
            DataSource.Columns.Add("采集时间", typeof(String));

            dgShow.Columns["ID"].Width = 300;
            dgShow.Columns["盒码"].Width = 300;
            dgShow.Columns["采集时间"].Width = 300;

            ParmSet f2 = new ParmSet();
            f2.ShowDialog(this);
            tbCaseNumber.Focus();
        }

        //数据采集触发
        private void tbCaseNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    String result = HttpRequest.ConfirmLowerCodeRelation(QRanalyze.QRDecod(tbCaseNumber.Text.Substring(tbCaseNumber.Text.Length - 35, 35)), Session.Id);
                    RelationResult Result = JsonConvert.DeserializeObject<RelationResult>(result);
                    if (!Result.success)
                    {
                        throw new Exception(Result.message);
                    }

                    if (Datas.Add(tbCaseNumber.Text.Substring(tbCaseNumber.Text.Length - 35, 35)))
                    {
                        capsum++;
                        tbCapSum.Text = capsum.ToString();
                        DataSource.Rows.Add(capsum.ToString(), tbCaseNumber.Text.Substring(tbCaseNumber.Text.Length - 35, 35), DateTime.Now.ToString());
                    }
                    else
                    {
                        MessageBox.Show(tbCaseNumber.Text + "重复扫描");
                    }

                    //一箱数据采集完毕
                    if (Datas.Count == BaseData.CapSum)
                    {
                        DBOperation dBOperation = new DBOperation();
                        Guid BoxId = Guid.NewGuid();
                        dBOperation.AddBoxs(BoxId);
                        dBOperation.CreatBoxOrder(BoxId, Datas);
                        dBOperation.Dispose();
                        Datas.Clear();
                        DataSource.Clear();
                        capsum = 0;
                        tbCapSum.Text = capsum.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                tbCaseNumber.Text = "";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
    }
}
