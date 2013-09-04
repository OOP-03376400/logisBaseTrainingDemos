namespace zigbee_controler
{
    partial class frmControler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControler));
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressHumunity = new System.Windows.Forms.ProgressBar();
            this.progressTemp = new System.Windows.Forms.ProgressBar();
            this.lblCurrentHumunity = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMinHumunity = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMaxHumunity = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNodeID = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCurrentTemp = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMinTemp = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMaxTemp = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbNodes = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUploadNodeInfo = new System.Windows.Forms.Button();
            this.btnStartMonitoring = new System.Windows.Forms.Button();
            this.btnStopMonitoring = new System.Windows.Forms.Button();
            this.btnStopUpload = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbNotUsedNodes = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(722, 519);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(90, 28);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "退出(&X)";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressHumunity);
            this.groupBox1.Controls.Add(this.progressTemp);
            this.groupBox1.Controls.Add(this.lblCurrentHumunity);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblMinHumunity);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblMaxHumunity);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblNodeID);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblCurrentTemp);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblMinTemp);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblMaxTemp);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(179, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 476);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前节点";
            // 
            // progressHumunity
            // 
            this.progressHumunity.Location = new System.Drawing.Point(47, 286);
            this.progressHumunity.Name = "progressHumunity";
            this.progressHumunity.Size = new System.Drawing.Size(534, 23);
            this.progressHumunity.TabIndex = 2;
            // 
            // progressTemp
            // 
            this.progressTemp.Location = new System.Drawing.Point(47, 145);
            this.progressTemp.Name = "progressTemp";
            this.progressTemp.Size = new System.Drawing.Size(534, 23);
            this.progressTemp.TabIndex = 2;
            // 
            // lblCurrentHumunity
            // 
            this.lblCurrentHumunity.AutoSize = true;
            this.lblCurrentHumunity.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentHumunity.Location = new System.Drawing.Point(291, 323);
            this.lblCurrentHumunity.Name = "lblCurrentHumunity";
            this.lblCurrentHumunity.Size = new System.Drawing.Size(107, 26);
            this.lblCurrentHumunity.TabIndex = 1;
            this.lblCurrentHumunity.Text = "当前湿度：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(225, 330);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "当前湿度：";
            // 
            // lblMinHumunity
            // 
            this.lblMinHumunity.AutoSize = true;
            this.lblMinHumunity.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMinHumunity.Location = new System.Drawing.Point(65, 330);
            this.lblMinHumunity.Name = "lblMinHumunity";
            this.lblMinHumunity.Size = new System.Drawing.Size(70, 12);
            this.lblMinHumunity.TabIndex = 1;
            this.lblMinHumunity.Text = "最小湿度：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "最小湿度：";
            // 
            // lblMaxHumunity
            // 
            this.lblMaxHumunity.AutoSize = true;
            this.lblMaxHumunity.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaxHumunity.Location = new System.Drawing.Point(550, 330);
            this.lblMaxHumunity.Name = "lblMaxHumunity";
            this.lblMaxHumunity.Size = new System.Drawing.Size(70, 12);
            this.lblMaxHumunity.TabIndex = 1;
            this.lblMaxHumunity.Text = "最大湿度：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(493, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "最大湿度：";
            // 
            // lblNodeID
            // 
            this.lblNodeID.AutoSize = true;
            this.lblNodeID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNodeID.Location = new System.Drawing.Point(94, 66);
            this.lblNodeID.Name = "lblNodeID";
            this.lblNodeID.Size = new System.Drawing.Size(86, 19);
            this.lblNodeID.TabIndex = 1;
            this.lblNodeID.Text = "结点ID：";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLocation.Location = new System.Drawing.Point(424, 66);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(104, 19);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "所在位置：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(364, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "所在位置：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "湿度信息：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "温度信息：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "基本信息：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "节点ID：";
            // 
            // lblCurrentTemp
            // 
            this.lblCurrentTemp.AutoSize = true;
            this.lblCurrentTemp.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentTemp.Location = new System.Drawing.Point(291, 180);
            this.lblCurrentTemp.Name = "lblCurrentTemp";
            this.lblCurrentTemp.Size = new System.Drawing.Size(107, 26);
            this.lblCurrentTemp.TabIndex = 1;
            this.lblCurrentTemp.Text = "当前温度：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(226, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "当前温度：";
            // 
            // lblMinTemp
            // 
            this.lblMinTemp.AutoSize = true;
            this.lblMinTemp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMinTemp.Location = new System.Drawing.Point(65, 187);
            this.lblMinTemp.Name = "lblMinTemp";
            this.lblMinTemp.Size = new System.Drawing.Size(70, 12);
            this.lblMinTemp.TabIndex = 1;
            this.lblMinTemp.Text = "最低温度：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "最低温度：";
            // 
            // lblMaxTemp
            // 
            this.lblMaxTemp.AutoSize = true;
            this.lblMaxTemp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaxTemp.Location = new System.Drawing.Point(550, 187);
            this.lblMaxTemp.Name = "lblMaxTemp";
            this.lblMaxTemp.Size = new System.Drawing.Size(70, 12);
            this.lblMaxTemp.TabIndex = 1;
            this.lblMaxTemp.Text = "最高温度：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "最高温度：";
            // 
            // lbNodes
            // 
            this.lbNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNodes.FormattingEnabled = true;
            this.lbNodes.ItemHeight = 12;
            this.lbNodes.Location = new System.Drawing.Point(3, 17);
            this.lbNodes.Name = "lbNodes";
            this.lbNodes.Size = new System.Drawing.Size(158, 292);
            this.lbNodes.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbNodes);
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 323);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "已使用节点列表";
            // 
            // btnUploadNodeInfo
            // 
            this.btnUploadNodeInfo.Location = new System.Drawing.Point(556, 519);
            this.btnUploadNodeInfo.Name = "btnUploadNodeInfo";
            this.btnUploadNodeInfo.Size = new System.Drawing.Size(116, 28);
            this.btnUploadNodeInfo.TabIndex = 17;
            this.btnUploadNodeInfo.Text = "上传节点信息(&W)";
            this.btnUploadNodeInfo.UseVisualStyleBackColor = true;
            this.btnUploadNodeInfo.Click += new System.EventHandler(this.btnUploadNodeInfo_Click);
            // 
            // btnStartMonitoring
            // 
            this.btnStartMonitoring.Location = new System.Drawing.Point(406, 519);
            this.btnStartMonitoring.Name = "btnStartMonitoring";
            this.btnStartMonitoring.Size = new System.Drawing.Size(116, 28);
            this.btnStartMonitoring.TabIndex = 17;
            this.btnStartMonitoring.Text = "启动监控(&S)";
            this.btnStartMonitoring.UseVisualStyleBackColor = true;
            this.btnStartMonitoring.Click += new System.EventHandler(this.btnStartMonitoring_Click);
            // 
            // btnStopMonitoring
            // 
            this.btnStopMonitoring.Location = new System.Drawing.Point(256, 519);
            this.btnStopMonitoring.Name = "btnStopMonitoring";
            this.btnStopMonitoring.Size = new System.Drawing.Size(116, 28);
            this.btnStopMonitoring.TabIndex = 17;
            this.btnStopMonitoring.Text = "停止监控(&T)";
            this.btnStopMonitoring.UseVisualStyleBackColor = true;
            this.btnStopMonitoring.Click += new System.EventHandler(this.btnStopMonitoring_Click);
            // 
            // btnStopUpload
            // 
            this.btnStopUpload.Location = new System.Drawing.Point(495, 519);
            this.btnStopUpload.Name = "btnStopUpload";
            this.btnStopUpload.Size = new System.Drawing.Size(116, 28);
            this.btnStopUpload.TabIndex = 17;
            this.btnStopUpload.Text = "停止上传(&C)";
            this.btnStopUpload.UseVisualStyleBackColor = true;
            this.btnStopUpload.Click += new System.EventHandler(this.btnStopUpload_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbNotUsedNodes);
            this.groupBox3.Location = new System.Drawing.Point(13, 348);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 151);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "未使用节点列表";
            // 
            // lbNotUsedNodes
            // 
            this.lbNotUsedNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNotUsedNodes.FormattingEnabled = true;
            this.lbNotUsedNodes.ItemHeight = 12;
            this.lbNotUsedNodes.Location = new System.Drawing.Point(3, 17);
            this.lbNotUsedNodes.Name = "lbNotUsedNodes";
            this.lbNotUsedNodes.Size = new System.Drawing.Size(154, 124);
            this.lbNotUsedNodes.TabIndex = 0;
            // 
            // frmControler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 568);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnStopMonitoring);
            this.Controls.Add(this.btnStartMonitoring);
            this.Controls.Add(this.btnStopUpload);
            this.Controls.Add(this.btnUploadNodeInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmControler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "节点监控";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCurrentTemp;
        private System.Windows.Forms.Label lblMinTemp;
        private System.Windows.Forms.Label lblMaxTemp;
        private System.Windows.Forms.Label lblCurrentHumunity;
        private System.Windows.Forms.Label lblMinHumunity;
        private System.Windows.Forms.Label lblMaxHumunity;
        private System.Windows.Forms.Label lblNodeID;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListBox lbNodes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUploadNodeInfo;
        private System.Windows.Forms.ProgressBar progressTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressHumunity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartMonitoring;
        private System.Windows.Forms.Button btnStopMonitoring;
        private System.Windows.Forms.Button btnStopUpload;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbNotUsedNodes;
    }
}