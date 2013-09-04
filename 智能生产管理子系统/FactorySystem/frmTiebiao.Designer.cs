namespace FactorySystem
{
    partial class frmTiebiao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiebiao));
            this.btnWriteEpc = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbProductCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtEpc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.dv1 = new System.Windows.Forms.DataGridView();
            this.lblTip = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dv1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWriteEpc
            // 
            this.btnWriteEpc.Enabled = false;
            this.btnWriteEpc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWriteEpc.Location = new System.Drawing.Point(305, 112);
            this.btnWriteEpc.Name = "btnWriteEpc";
            this.btnWriteEpc.Size = new System.Drawing.Size(99, 28);
            this.btnWriteEpc.TabIndex = 57;
            this.btnWriteEpc.Text = "写入标签";
            this.btnWriteEpc.UseVisualStyleBackColor = true;
            this.btnWriteEpc.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblTip);
            this.groupBox5.Controls.Add(this.cmbProductCategory);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.txtEpc);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.btnWriteEpc);
            this.groupBox5.Location = new System.Drawing.Point(23, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(435, 428);
            this.groupBox5.TabIndex = 58;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "贴标";
            // 
            // cmbProductCategory
            // 
            this.cmbProductCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductCategory.FormattingEnabled = true;
            this.cmbProductCategory.Location = new System.Drawing.Point(79, 21);
            this.cmbProductCategory.Name = "cmbProductCategory";
            this.cmbProductCategory.Size = new System.Drawing.Size(325, 20);
            this.cmbProductCategory.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 66;
            this.label1.Text = "标签编码：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 28);
            this.button3.TabIndex = 64;
            this.button3.Text = "生成EPC";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // txtEpc
            // 
            this.txtEpc.Location = new System.Drawing.Point(79, 60);
            this.txtEpc.Name = "txtEpc";
            this.txtEpc.Size = new System.Drawing.Size(325, 21);
            this.txtEpc.TabIndex = 60;
            this.txtEpc.TextChanged += new System.EventHandler(this.txtEpc_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 63;
            this.label2.Text = "产品类别：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 28);
            this.button2.TabIndex = 59;
            this.button2.Text = "读取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(305, 162);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 28);
            this.button4.TabIndex = 65;
            this.button4.Text = "加入生产列表";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.dv1);
            this.groupBox1.Location = new System.Drawing.Point(464, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 428);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "已贴标列表";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(360, 389);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 28);
            this.button5.TabIndex = 67;
            this.button5.Text = "开始生产";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dv1
            // 
            this.dv1.AllowUserToAddRows = false;
            this.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv1.Location = new System.Drawing.Point(9, 21);
            this.dv1.Name = "dv1";
            this.dv1.RowTemplate.Height = 23;
            this.dv1.Size = new System.Drawing.Size(450, 360);
            this.dv1.TabIndex = 66;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(77, 84);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(41, 12);
            this.lblTip.TabIndex = 68;
            this.lblTip.Text = "label3";
            this.lblTip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTiebiao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 493);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTiebiao";
            this.Text = "产品贴标";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWriteEpc;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtEpc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dv1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProductCategory;
        private System.Windows.Forms.Label lblTip;
    }
}