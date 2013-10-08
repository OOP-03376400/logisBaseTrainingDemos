namespace transportSimulation
{
    partial class Form3
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
            this.lblLat = new System.Windows.Forms.Label();
            this.lblLng = new System.Windows.Forms.Label();
            this.lblCurrentRoad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDestnation = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCarID = new System.Windows.Forms.Label();
            this.btnRoad1 = new System.Windows.Forms.Button();
            this.btnRoad2 = new System.Windows.Forms.Button();
            this.btnStartPoint = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前道路:";
            // 
            // lblLat
            // 
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(293, 130);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(47, 12);
            this.lblLat.TabIndex = 1;
            this.lblLat.Text = "116.118";
            // 
            // lblLng
            // 
            this.lblLng.AutoSize = true;
            this.lblLng.Location = new System.Drawing.Point(351, 130);
            this.lblLng.Name = "lblLng";
            this.lblLng.Size = new System.Drawing.Size(41, 12);
            this.lblLng.TabIndex = 1;
            this.lblLng.Text = "39.456";
            // 
            // lblCurrentRoad
            // 
            this.lblCurrentRoad.AutoSize = true;
            this.lblCurrentRoad.Font = new System.Drawing.Font("宋体", 19F);
            this.lblCurrentRoad.Location = new System.Drawing.Point(291, 79);
            this.lblCurrentRoad.Name = "lblCurrentRoad";
            this.lblCurrentRoad.Size = new System.Drawing.Size(116, 26);
            this.lblCurrentRoad.TabIndex = 2;
            this.lblCurrentRoad.Text = "朝阳北路";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "GPS信息:";
            // 
            // btnDestnation
            // 
            this.btnDestnation.Location = new System.Drawing.Point(445, 89);
            this.btnDestnation.Name = "btnDestnation";
            this.btnDestnation.Size = new System.Drawing.Size(96, 58);
            this.btnDestnation.TabIndex = 3;
            this.btnDestnation.Text = "通州火车站";
            this.btnDestnation.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 19F);
            this.label6.Location = new System.Drawing.Point(164, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "=>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "车牌号:";
            // 
            // lblCarID
            // 
            this.lblCarID.AutoSize = true;
            this.lblCarID.Font = new System.Drawing.Font("宋体", 19F);
            this.lblCarID.Location = new System.Drawing.Point(108, 22);
            this.lblCarID.Name = "lblCarID";
            this.lblCarID.Size = new System.Drawing.Size(116, 26);
            this.lblCarID.TabIndex = 0;
            this.lblCarID.Text = "京A12345";
            // 
            // btnRoad1
            // 
            this.btnRoad1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRoad1.Location = new System.Drawing.Point(253, 167);
            this.btnRoad1.Name = "btnRoad1";
            this.btnRoad1.Size = new System.Drawing.Size(139, 77);
            this.btnRoad1.TabIndex = 4;
            this.btnRoad1.UseVisualStyleBackColor = true;
            // 
            // btnRoad2
            // 
            this.btnRoad2.Location = new System.Drawing.Point(253, 275);
            this.btnRoad2.Name = "btnRoad2";
            this.btnRoad2.Size = new System.Drawing.Size(139, 77);
            this.btnRoad2.TabIndex = 4;
            this.btnRoad2.UseVisualStyleBackColor = true;
            // 
            // btnStartPoint
            // 
            this.btnStartPoint.Location = new System.Drawing.Point(36, 79);
            this.btnStartPoint.Name = "btnStartPoint";
            this.btnStartPoint.Size = new System.Drawing.Size(109, 63);
            this.btnStartPoint.TabIndex = 5;
            this.btnStartPoint.UseVisualStyleBackColor = true;
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(36, 388);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 6;
            this.btnPre.Text = "<- 返回";
            this.btnPre.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(641, 339);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(546, 388);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 8;
            this.btnRestart.Text = "重新开始";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 428);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnStartPoint);
            this.Controls.Add(this.btnRoad2);
            this.Controls.Add(this.btnRoad1);
            this.Controls.Add(this.btnDestnation);
            this.Controls.Add(this.lblCurrentRoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLng);
            this.Controls.Add(this.lblLat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCarID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "行驶状态";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.Label lblLng;
        private System.Windows.Forms.Label lblCurrentRoad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDestnation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCarID;
        private System.Windows.Forms.Button btnRoad1;
        private System.Windows.Forms.Button btnRoad2;
        private System.Windows.Forms.Button btnStartPoint;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRestart;
    }
}