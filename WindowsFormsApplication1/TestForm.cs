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
using WindowsFormsApplication1.http.bean;
using WpfSlovo;

namespace WindowsFormsApplication1
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        //登陆
        private void button1_Click(object sender, EventArgs e)
        {
            txt_name.Text = "test1";
            txtword.Text = "888888";
            Boolean result = HttpRequest.Login(txt_name.Text, txtword.Text);

            Console.WriteLine(result);
        }

        //关联模板集合
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String result = HttpRequest.GetTemplates(QRanalyze.QRDecod(txtTemplates.Text), Session.Id);

                TemplateResult TemplateResult = JsonConvert.DeserializeObject<TemplateResult>(result);

                Console.WriteLine(result);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        //获取模板明细详情
        private void button3_Click(object sender, EventArgs e)
        {
           
            try
            {
                String result = HttpRequest.GetTemplateInfo(txtTemlateInfo.Text, Session.Id);
                TemplateInfoResult templateInfoResult = JsonConvert.DeserializeObject<TemplateInfoResult>(result);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //验证下级码值是否关联
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String result = HttpRequest.ConfirmLowerCodeRelation(QRanalyze.QRDecod(txtLowcodes.Text), Session.Id);
                TemplateInfoResult templateInfoResult = JsonConvert.DeserializeObject<TemplateInfoResult>(result);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //验证上级码值是否关联
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String result = HttpRequest.ConfirmSuperCodeRelation(QRanalyze.QRDecod(txtSupercode.Text), Session.Id);
                //TemplateInfoResult templateInfoResult = JsonConvert.DeserializeObject<TemplateInfoResult>(result);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
