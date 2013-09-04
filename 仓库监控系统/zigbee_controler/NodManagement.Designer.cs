namespace zigbee_controler
{
    partial class NodManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodManagement));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMinHumunity = new System.Windows.Forms.NumericUpDown();
            this.txtMinTemp = new System.Windows.Forms.NumericUpDown();
            this.txtMaxHumunity = new System.Windows.Forms.NumericUpDown();
            this.txtMaxTemp = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNodeID = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvZigbeeNodes = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinHumunity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxHumunity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZigbeeNodes)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMinHumunity);
            this.groupBox1.Controls.Add(this.txtMinTemp);
            this.groupBox1.Controls.Add(this.txtMaxHumunity);
            this.groupBox1.Controls.Add(this.txtMaxTemp);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNodeID);
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 116);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "结点信息";
            // 
            // txtMinHumunity
            // 
            this.txtMinHumunity.Location = new System.Drawing.Point(444, 86);
            this.txtMinHumunity.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtMinHumunity.Name = "txtMinHumunity";
            this.txtMinHumunity.Size = new System.Drawing.Size(154, 21);
            this.txtMinHumunity.TabIndex = 2;
            // 
            // txtMinTemp
            // 
            this.txtMinTemp.Location = new System.Drawing.Point(444, 54);
            this.txtMinTemp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtMinTemp.Name = "txtMinTemp";
            this.txtMinTemp.Size = new System.Drawing.Size(154, 21);
            this.txtMinTemp.TabIndex = 2;
            // 
            // txtMaxHumunity
            // 
            this.txtMaxHumunity.Location = new System.Drawing.Point(87, 86);
            this.txtMaxHumunity.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtMaxHumunity.Name = "txtMaxHumunity";
            this.txtMaxHumunity.Size = new System.Drawing.Size(154, 21);
            this.txtMaxHumunity.TabIndex = 2;
            // 
            // txtMaxTemp
            // 
            this.txtMaxTemp.Location = new System.Drawing.Point(87, 54);
            this.txtMaxTemp.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtMaxTemp.Name = "txtMaxTemp";
            this.txtMaxTemp.Size = new System.Drawing.Size(154, 21);
            this.txtMaxTemp.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(373, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "最小湿度：";
            // 
            // txtNodeID
            // 
            this.txtNodeID.Location = new System.Drawing.Point(87, 19);
            this.txtNodeID.Name = "txtNodeID";
            this.txtNodeID.Size = new System.Drawing.Size(154, 21);
            this.txtNodeID.TabIndex = 0;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(444, 20);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(154, 21);
            this.txtLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "节点ID：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "最大湿度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "位置说明：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(373, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "最低温度：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "最高温度：";
            // 
            // dgvZigbeeNodes
            // 
            this.dgvZigbeeNodes.AllowUserToAddRows = false;
            this.dgvZigbeeNodes.AllowUserToDeleteRows = false;
            this.dgvZigbeeNodes.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZigbeeNodes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvZigbeeNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvZigbeeNodes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvZigbeeNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvZigbeeNodes.Location = new System.Drawing.Point(3, 17);
            this.dgvZigbeeNodes.Name = "dgvZigbeeNodes";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZigbeeNodes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvZigbeeNodes.RowHeadersWidth = 20;
            this.dgvZigbeeNodes.RowTemplate.Height = 23;
            this.dgvZigbeeNodes.Size = new System.Drawing.Size(661, 265);
            this.dgvZigbeeNodes.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvZigbeeNodes);
            this.groupBox2.Location = new System.Drawing.Point(12, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 285);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "节点列表";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(698, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 25);
            this.button1.TabIndex = 18;
            this.button1.Text = "增加（&A）";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(698, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 25);
            this.button2.TabIndex = 18;
            this.button2.Text = "删除（&X）";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(698, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 25);
            this.button3.TabIndex = 18;
            this.button3.Text = "退出（&X）";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // NodManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 479);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NodManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "监控节点管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinHumunity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxHumunity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZigbeeNodes)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvZigbeeNodes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNodeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown txtMinHumunity;
        private System.Windows.Forms.NumericUpDown txtMinTemp;
        private System.Windows.Forms.NumericUpDown txtMaxHumunity;
        private System.Windows.Forms.NumericUpDown txtMaxTemp;
    }
}