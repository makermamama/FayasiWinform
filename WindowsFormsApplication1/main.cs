using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == treeView1.Nodes[0])//增删查改用户
            {
                CapForm sub = new CapForm();
                sub.TopLevel = false;
                sub.Dock = DockStyle.Fill;//把子窗体设置为控件
                PanelRightMain.Controls.Clear();
                PanelRightMain.Controls.Add(sub);
                sub.Show();
                ToolStripButton tsb = new ToolStripButton("盒码采集");
                toolStrip1.Items.Clear();
                toolStrip1.Items.Add(tsb);

            }
            else if (treeView1.SelectedNode == treeView1.Nodes[1])//增删查改用户
            {

                Upload sub = new Upload();
                sub.TopLevel = false;
                sub.Dock = DockStyle.Fill;//把子窗体设置为控件
                PanelRightMain.Controls.Clear();
                PanelRightMain.Controls.Add(sub);
                sub.Show();

                ToolStripButton tsb = new ToolStripButton("上传箱号");
                toolStrip1.Items.Clear();
                toolStrip1.Items.Add(tsb);
            }
            else if(treeView1.SelectedNode == treeView1.Nodes[2])//增删查改用户
            {

                CapCaseAndBox sub = new CapCaseAndBox();
                sub.TopLevel = false;
                sub.Dock = DockStyle.Fill;//把子窗体设置为控件
                PanelRightMain.Controls.Clear();
                PanelRightMain.Controls.Add(sub);
                sub.Show();

                ToolStripButton tsb = new ToolStripButton("上传箱号");
                toolStrip1.Items.Clear();
                toolStrip1.Items.Add(tsb);
            }
        }

        private void mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
