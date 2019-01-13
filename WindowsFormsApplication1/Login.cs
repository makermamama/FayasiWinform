using PLCWindowsForms.toolBean;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WpfSlovo;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_name.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("用户名不能为空");
                    return;
                }
                if (tb_password.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("密码不能为空");
                    return;
                }
                if (HttpRequest.Login(tb_name.Text, tb_password.Text))
                {
                    mainform aa = new mainform();
                    aa.Show();
                    this.Visible = false;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
         private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                SendKeys.Send("{Tab}");  
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tb_name.Focus();
            foreach (Control c in this.Controls) //获取页面中的所有控件
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")//如果是TextBox控件，则添加事件
                {
                    TextBox tb1 = c as TextBox;
                    c.KeyDown += new KeyEventHandler(Key_Down);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
