namespace WindowsFormsApplication1
{
    partial class ParmSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textunitLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textlowerQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textgoodsName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textlowerGoodsName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textunit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textlowerUnit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonSure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "扫描箱号获取模板:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(235, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 25);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(235, 122);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(247, 23);
            this.comboBox.TabIndex = 2;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "模板选择:";
            // 
            // textunitLevel
            // 
            this.textunitLevel.Location = new System.Drawing.Point(235, 167);
            this.textunitLevel.Name = "textunitLevel";
            this.textunitLevel.Size = new System.Drawing.Size(247, 25);
            this.textunitLevel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "模板等级:";
            // 
            // textlowerQuantity
            // 
            this.textlowerQuantity.Location = new System.Drawing.Point(235, 216);
            this.textlowerQuantity.Name = "textlowerQuantity";
            this.textlowerQuantity.Size = new System.Drawing.Size(247, 25);
            this.textlowerQuantity.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "上级码值关联的下级码值数量:";
            // 
            // textgoodsName
            // 
            this.textgoodsName.Location = new System.Drawing.Point(235, 263);
            this.textgoodsName.Name = "textgoodsName";
            this.textgoodsName.Size = new System.Drawing.Size(247, 25);
            this.textgoodsName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "上级商品名称:";
            // 
            // textlowerGoodsName
            // 
            this.textlowerGoodsName.Location = new System.Drawing.Point(235, 315);
            this.textlowerGoodsName.Name = "textlowerGoodsName";
            this.textlowerGoodsName.Size = new System.Drawing.Size(247, 25);
            this.textlowerGoodsName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "下级商品名称:";
            // 
            // textunit
            // 
            this.textunit.Location = new System.Drawing.Point(235, 361);
            this.textunit.Name = "textunit";
            this.textunit.Size = new System.Drawing.Size(247, 25);
            this.textunit.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "上级商品单位:";
            // 
            // textlowerUnit
            // 
            this.textlowerUnit.Location = new System.Drawing.Point(235, 404);
            this.textlowerUnit.Name = "textlowerUnit";
            this.textlowerUnit.Size = new System.Drawing.Size(247, 25);
            this.textlowerUnit.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 407);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "下级商品单位:";
            // 
            // buttonSure
            // 
            this.buttonSure.Location = new System.Drawing.Point(235, 462);
            this.buttonSure.Name = "buttonSure";
            this.buttonSure.Size = new System.Drawing.Size(247, 23);
            this.buttonSure.TabIndex = 16;
            this.buttonSure.Text = "确定";
            this.buttonSure.UseVisualStyleBackColor = true;
            this.buttonSure.Click += new System.EventHandler(this.buttonSure_Click);
            // 
            // ParmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 511);
            this.Controls.Add(this.buttonSure);
            this.Controls.Add(this.textlowerUnit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textunit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textlowerGoodsName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textgoodsName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textlowerQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textunitLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "ParmSet";
            this.Text = "参数设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textunitLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textlowerQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textgoodsName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textlowerGoodsName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textunit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textlowerUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSure;
    }
}