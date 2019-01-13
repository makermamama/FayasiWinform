namespace WindowsFormsApplication1
{
    partial class TestForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txtword = new System.Windows.Forms.TextBox();
            this.txtTemplates = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtTemlateInfo = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtLowcodes = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.txtSupercode = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "登陆";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(62, 43);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 25);
            this.txt_name.TabIndex = 1;
            // 
            // txtword
            // 
            this.txtword.Location = new System.Drawing.Point(62, 93);
            this.txtword.Name = "txtword";
            this.txtword.Size = new System.Drawing.Size(100, 25);
            this.txtword.TabIndex = 2;
            // 
            // txtTemplates
            // 
            this.txtTemplates.Location = new System.Drawing.Point(258, 43);
            this.txtTemplates.Name = "txtTemplates";
            this.txtTemplates.Size = new System.Drawing.Size(226, 25);
            this.txtTemplates.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(258, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "关联模板集合";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(258, 228);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "获取模板明细详情";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtTemlateInfo
            // 
            this.txtTemlateInfo.Location = new System.Drawing.Point(258, 176);
            this.txtTemlateInfo.Name = "txtTemlateInfo";
            this.txtTemlateInfo.Size = new System.Drawing.Size(226, 25);
            this.txtTemlateInfo.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(258, 355);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(226, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "验证下级码值是否符合关联";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtLowcodes
            // 
            this.txtLowcodes.Location = new System.Drawing.Point(258, 303);
            this.txtLowcodes.Name = "txtLowcodes";
            this.txtLowcodes.Size = new System.Drawing.Size(226, 25);
            this.txtLowcodes.TabIndex = 7;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(538, 95);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(226, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "验证上级码值是否关联";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtSupercode
            // 
            this.txtSupercode.Location = new System.Drawing.Point(538, 43);
            this.txtSupercode.Name = "txtSupercode";
            this.txtSupercode.Size = new System.Drawing.Size(226, 25);
            this.txtSupercode.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(548, 355);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "获取模板明细详情";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(548, 303);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(226, 25);
            this.textBox7.TabIndex = 11;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(548, 241);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(226, 25);
            this.textBox8.TabIndex = 13;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(548, 176);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(226, 25);
            this.textBox9.TabIndex = 14;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtSupercode);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtLowcodes);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtTemlateInfo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtTemplates);
            this.Controls.Add(this.txtword);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.button1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txtword;
        private System.Windows.Forms.TextBox txtTemplates;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtTemlateInfo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtLowcodes;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtSupercode;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
    }
}