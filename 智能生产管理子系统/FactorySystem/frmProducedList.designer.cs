namespace FactorySystem
{
    partial class frmProducedList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducedList));
            this.chaxun = new System.Windows.Forms.Button();
            this.Condition1 = new System.Windows.Forms.TextBox();
            this.IndexCon1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dv1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dv1)).BeginInit();
            this.SuspendLayout();
            // 
            // chaxun
            // 
            this.chaxun.Location = new System.Drawing.Point(638, 11);
            this.chaxun.Name = "chaxun";
            this.chaxun.Size = new System.Drawing.Size(54, 23);
            this.chaxun.TabIndex = 5;
            this.chaxun.Text = "查询";
            this.chaxun.UseVisualStyleBackColor = true;
            this.chaxun.Click += new System.EventHandler(this.chaxun_Click);
            // 
            // Condition1
            // 
            this.Condition1.Location = new System.Drawing.Point(517, 12);
            this.Condition1.Name = "Condition1";
            this.Condition1.Size = new System.Drawing.Size(100, 21);
            this.Condition1.TabIndex = 4;
            // 
            // IndexCon1
            // 
            this.IndexCon1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.IndexCon1.FormattingEnabled = true;
            this.IndexCon1.Items.AddRange(new object[] {
            "产品编码",
            "产品名称",
            "产品类别",
            "生产车间"});
            this.IndexCon1.Location = new System.Drawing.Point(393, 12);
            this.IndexCon1.Name = "IndexCon1";
            this.IndexCon1.Size = new System.Drawing.Size(108, 20);
            this.IndexCon1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.chaxun);
            this.panel1.Controls.Add(this.Condition1);
            this.panel1.Controls.Add(this.IndexCon1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 40);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(715, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 16);
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
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "产成品列表：";
            // 
            // dv1
            // 
            this.dv1.AllowUserToAddRows = false;
            this.dv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dv1.Location = new System.Drawing.Point(0, 39);
            this.dv1.Name = "dv1";
            this.dv1.RowTemplate.Height = 23;
            this.dv1.Size = new System.Drawing.Size(843, 461);
            this.dv1.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // P_ed_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 499);
            this.Controls.Add(this.dv1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "P_ed_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "产成品";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chaxun;
        private System.Windows.Forms.TextBox Condition1;
        private System.Windows.Forms.ComboBox IndexCon1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dv1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;

    }
}