namespace FactorySystem
{
    partial class frmProducing
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducing));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Process2_Wet = new System.Windows.Forms.TextBox();
            this.Process2_Tem = new System.Windows.Forms.TextBox();
            this.Process2_Product = new System.Windows.Forms.TextBox();
            this.Process2_code = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Process1_Wet = new System.Windows.Forms.TextBox();
            this.Process1_Tem = new System.Windows.Forms.TextBox();
            this.Process1_Product = new System.Windows.Forms.TextBox();
            this.Process1_code = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvProductInfo = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chaxun = new System.Windows.Forms.Button();
            this.Condition = new System.Windows.Forms.TextBox();
            this.IndexCondi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Process2_Wet);
            this.groupBox2.Controls.Add(this.Process2_Tem);
            this.groupBox2.Controls.Add(this.Process2_Product);
            this.groupBox2.Controls.Add(this.Process2_code);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Location = new System.Drawing.Point(476, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 293);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工序二";
            // 
            // Process2_Wet
            // 
            this.Process2_Wet.Location = new System.Drawing.Point(219, 264);
            this.Process2_Wet.Name = "Process2_Wet";
            this.Process2_Wet.ReadOnly = true;
            this.Process2_Wet.Size = new System.Drawing.Size(57, 21);
            this.Process2_Wet.TabIndex = 8;
            // 
            // Process2_Tem
            // 
            this.Process2_Tem.Location = new System.Drawing.Point(82, 265);
            this.Process2_Tem.Name = "Process2_Tem";
            this.Process2_Tem.ReadOnly = true;
            this.Process2_Tem.Size = new System.Drawing.Size(58, 21);
            this.Process2_Tem.TabIndex = 7;
            // 
            // Process2_Product
            // 
            this.Process2_Product.Location = new System.Drawing.Point(82, 236);
            this.Process2_Product.Name = "Process2_Product";
            this.Process2_Product.ReadOnly = true;
            this.Process2_Product.Size = new System.Drawing.Size(150, 21);
            this.Process2_Product.TabIndex = 6;
            // 
            // Process2_code
            // 
            this.Process2_code.Location = new System.Drawing.Point(82, 207);
            this.Process2_code.Name = "Process2_code";
            this.Process2_code.ReadOnly = true;
            this.Process2_code.Size = new System.Drawing.Size(150, 21);
            this.Process2_code.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(155, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "当前湿度：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "当前温度：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "产品名称：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "产品编码：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(42, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(213, 177);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.Process1_Wet);
            this.groupBox1.Controls.Add(this.Process1_Tem);
            this.groupBox1.Controls.Add(this.Process1_Product);
            this.groupBox1.Controls.Add(this.Process1_code);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(52, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 293);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工序一";
            // 
            // Process1_Wet
            // 
            this.Process1_Wet.Location = new System.Drawing.Point(219, 264);
            this.Process1_Wet.Name = "Process1_Wet";
            this.Process1_Wet.Size = new System.Drawing.Size(57, 21);
            this.Process1_Wet.TabIndex = 8;
            // 
            // Process1_Tem
            // 
            this.Process1_Tem.Location = new System.Drawing.Point(82, 265);
            this.Process1_Tem.Name = "Process1_Tem";
            this.Process1_Tem.Size = new System.Drawing.Size(58, 21);
            this.Process1_Tem.TabIndex = 7;
            // 
            // Process1_Product
            // 
            this.Process1_Product.Location = new System.Drawing.Point(82, 236);
            this.Process1_Product.Name = "Process1_Product";
            this.Process1_Product.Size = new System.Drawing.Size(150, 21);
            this.Process1_Product.TabIndex = 6;
            // 
            // Process1_code
            // 
            this.Process1_code.Location = new System.Drawing.Point(82, 207);
            this.Process1_code.Name = "Process1_code";
            this.Process1_code.Size = new System.Drawing.Size(150, 21);
            this.Process1_code.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "当前湿度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "当前温度：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "产品名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "产品编码：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.AllowUserToAddRows = false;
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductInfo.Location = new System.Drawing.Point(1, 45);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.RowTemplate.Height = 23;
            this.dgvProductInfo.Size = new System.Drawing.Size(843, 259);
            this.dgvProductInfo.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.chaxun);
            this.panel1.Controls.Add(this.Condition);
            this.panel1.Controls.Add(this.IndexCondi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 40);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(699, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "查看产成品信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chaxun
            // 
            this.chaxun.Location = new System.Drawing.Point(581, 10);
            this.chaxun.Name = "chaxun";
            this.chaxun.Size = new System.Drawing.Size(54, 23);
            this.chaxun.TabIndex = 5;
            this.chaxun.Text = "查询";
            this.chaxun.UseVisualStyleBackColor = true;
            // 
            // Condition
            // 
            this.Condition.Location = new System.Drawing.Point(460, 11);
            this.Condition.Name = "Condition";
            this.Condition.Size = new System.Drawing.Size(100, 21);
            this.Condition.TabIndex = 4;
            // 
            // IndexCondi
            // 
            this.IndexCondi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.IndexCondi.FormattingEnabled = true;
            this.IndexCondi.Items.AddRange(new object[] {
            "产品编码",
            "产品名称",
            "订单号",
            "公司名称"});
            this.IndexCondi.Location = new System.Drawing.Point(336, 11);
            this.IndexCondi.Name = "IndexCondi";
            this.IndexCondi.Size = new System.Drawing.Size(108, 20);
            this.IndexCondi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "查询条件:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "生产列表：";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(197, 635);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "停止生产";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 8000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 4000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 4001;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(94, 635);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "开始生产";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // timer4
            // 
            this.timer4.Interval = 3000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // PList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 679);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvProductInfo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产";
            this.Load += new System.EventHandler(this.PList_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Process2_Wet;
        private System.Windows.Forms.TextBox Process2_Tem;
        private System.Windows.Forms.TextBox Process2_Product;
        private System.Windows.Forms.TextBox Process2_code;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Process1_Wet;
        private System.Windows.Forms.TextBox Process1_Tem;
        private System.Windows.Forms.TextBox Process1_Product;
        private System.Windows.Forms.TextBox Process1_code;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvProductInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button chaxun;
        private System.Windows.Forms.TextBox Condition;
        private System.Windows.Forms.ComboBox IndexCondi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer4;
    }
}