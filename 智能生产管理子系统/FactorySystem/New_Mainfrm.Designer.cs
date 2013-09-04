namespace FactorySystem
{
    partial class New_Mainfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(New_Mainfrm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuBaseManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSysManage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPopedomSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBaseManage,
            this.menuSysManage});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(862, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuBaseManage
            // 
            this.menuBaseManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEmployee,
            this.menuCompany,
            this.menuCustomer});
            this.menuBaseManage.Image = ((System.Drawing.Image)(resources.GetObject("menuBaseManage.Image")));
            this.menuBaseManage.Name = "menuBaseManage";
            this.menuBaseManage.Size = new System.Drawing.Size(124, 21);
            this.menuBaseManage.Text = "智能生产管理[&B]";
            // 
            // menuEmployee
            // 
            this.menuEmployee.Name = "menuEmployee";
            this.menuEmployee.Size = new System.Drawing.Size(152, 22);
            this.menuEmployee.Tag = "1";
            this.menuEmployee.Text = "产品贴标[&E]";
            this.menuEmployee.Click += new System.EventHandler(this.menuEmployee_Click);
            // 
            // menuCompany
            // 
            this.menuCompany.Name = "menuCompany";
            this.menuCompany.Size = new System.Drawing.Size(152, 22);
            this.menuCompany.Tag = "2";
            this.menuCompany.Text = "生产列表[&C]";
            this.menuCompany.Click += new System.EventHandler(this.menuCompany_Click);
            // 
            // menuCustomer
            // 
            this.menuCustomer.Name = "menuCustomer";
            this.menuCustomer.Size = new System.Drawing.Size(152, 22);
            this.menuCustomer.Tag = "30";
            this.menuCustomer.Text = "产成品列表[&K]";
            this.menuCustomer.Click += new System.EventHandler(this.menuCustomer_Click);
            // 
            // menuSysManage
            // 
            this.menuSysManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPopedomSet,
            this.menuChangePwd});
            this.menuSysManage.Image = ((System.Drawing.Image)(resources.GetObject("menuSysManage.Image")));
            this.menuSysManage.Name = "menuSysManage";
            this.menuSysManage.Size = new System.Drawing.Size(104, 21);
            this.menuSysManage.Text = "系统设置[&W]";
            // 
            // menuPopedomSet
            // 
            this.menuPopedomSet.Name = "menuPopedomSet";
            this.menuPopedomSet.Size = new System.Drawing.Size(152, 22);
            this.menuPopedomSet.Tag = "21";
            this.menuPopedomSet.Text = "串口设置[&Q]";
            this.menuPopedomSet.Click += new System.EventHandler(this.menuPopedomSet_Click);
            // 
            // menuChangePwd
            // 
            this.menuChangePwd.Name = "menuChangePwd";
            this.menuChangePwd.Size = new System.Drawing.Size(152, 22);
            this.menuChangePwd.Tag = "22";
            this.menuChangePwd.Text = "企业设置[&C]";
            // 
            // New_Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(862, 517);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "New_Mainfrm";
            this.Text = "智能生产系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuBaseManage;
        private System.Windows.Forms.ToolStripMenuItem menuEmployee;
        private System.Windows.Forms.ToolStripMenuItem menuCompany;
        private System.Windows.Forms.ToolStripMenuItem menuCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuSysManage;
        private System.Windows.Forms.ToolStripMenuItem menuPopedomSet;
        private System.Windows.Forms.ToolStripMenuItem menuChangePwd;
    }
}