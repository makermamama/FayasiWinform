namespace WindowsFormsApplication1
{
    partial class Upload
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbBoxTag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBoxID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgBox = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbBoxTag);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbBoxID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 139);
            this.panel1.TabIndex = 0;
            // 
            // tbBoxTag
            // 
            this.tbBoxTag.Location = new System.Drawing.Point(223, 93);
            this.tbBoxTag.Name = "tbBoxTag";
            this.tbBoxTag.Size = new System.Drawing.Size(372, 25);
            this.tbBoxTag.TabIndex = 3;
            this.tbBoxTag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBoxTag_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(67, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "扫描箱标签:";
            // 
            // tbBoxID
            // 
            this.tbBoxID.Location = new System.Drawing.Point(223, 32);
            this.tbBoxID.Name = "tbBoxID";
            this.tbBoxID.Size = new System.Drawing.Size(372, 25);
            this.tbBoxID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(41, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "未上传箱号ID:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 311);
            this.panel2.TabIndex = 1;
            // 
            // dgBox
            // 
            this.dgBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBox.Location = new System.Drawing.Point(0, 0);
            this.dgBox.Name = "dgBox";
            this.dgBox.RowTemplate.Height = 27;
            this.dgBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBox.Size = new System.Drawing.Size(800, 311);
            this.dgBox.TabIndex = 0;
            this.dgBox.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBox_CellClick);
            // 
            // Upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Upload";
            this.Text = "Upload";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBoxID;
        private System.Windows.Forms.TextBox tbBoxTag;
        private System.Windows.Forms.Label label2;
    }
}