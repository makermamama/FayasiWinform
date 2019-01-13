using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestForms.Http;
using WindowsFormsApplication1.http.bean;
using WindowsFormsApplication1.tool;
using WpfSlovo;

namespace WindowsFormsApplication1
{
    public partial class ParmSet : Form
    {

        Hashtable hashtable = new Hashtable();
        
        public ParmSet()
        {
            InitializeComponent();
        }

        //扫描箱码
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    String result = HttpRequest.GetTemplates(QRanalyze.QRDecod(textBox1.Text.Substring(textBox1.Text.Length - 35, 35)), Session.Id);

                    TemplateResult Result = JsonConvert.DeserializeObject<TemplateResult>(result);

                    if (Result.success)
                    {
                        hashtable.Clear();
                        comboBox.Items.Clear();
                        foreach (UnitTemp unitTemp in Result.data.unitTemps)
                        {
                            foreach (TempDel Temp in unitTemp.tempDels)
                            {
                                comboBox.Items.Add(Temp.id);
                                hashtable.Add(Temp.id, Temp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                textBox1.Text = "";
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String id = comboBox.SelectedItem.ToString();
            TempDel tempDel = (TempDel)hashtable[id];
            textunitLevel.Text = tempDel.unitLevel.ToString();
            textlowerQuantity.Text = tempDel.lowerQuantity.ToString();
            textgoodsName.Text = tempDel.goodsName.ToString();
            textlowerGoodsName.Text = tempDel.lowerGoodsName.ToString();
            textunit.Text = tempDel.unit.ToString();
            textlowerUnit.Text = tempDel.lowerUnit.ToString();

            BaseData.TempId = id;
            BaseData.CapSum = tempDel.lowerQuantity;
        }

        private void buttonSure_Click(object sender, EventArgs e)
        {
            if (textunitLevel.Text == "")
            {
                MessageBox.Show("请选择采集模板");
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }
    }
}
