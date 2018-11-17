namespace HostManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("主机");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("主机");
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.cmsHost = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tvHost = new System.Windows.Forms.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tvTag = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHostApply = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucHostDetails1 = new HostManager.ucHostDetails();
            this.toolStrip1.SuspendLayout();
            this.cmsHost.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbDelete,
            this.tsbRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(642, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(28, 28);
            this.tsbNew.Text = "New";
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(28, 28);
            this.tsbDelete.Text = "toolStripButton2";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(28, 28);
            this.tsbRefresh.Text = "toolStripButton3";
            // 
            // cmsHost
            // 
            this.cmsHost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiDelete,
            this.tsmiRefresh});
            this.cmsHost.Name = "cmsHost";
            this.cmsHost.Size = new System.Drawing.Size(101, 70);
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(100, 22);
            this.tsmiNew.Text = "新建";
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmiDelete.Text = "删除";
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(100, 22);
            this.tsmiRefresh.Text = "刷新";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 507);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(642, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl2.Location = new System.Drawing.Point(0, 31);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(169, 476);
            this.tabControl2.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tvHost);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(161, 450);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Host";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tvHost
            // 
            this.tvHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvHost.Location = new System.Drawing.Point(3, 3);
            this.tvHost.Name = "tvHost";
            treeNode1.Name = "节点0";
            treeNode1.Text = "主机";
            this.tvHost.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvHost.Size = new System.Drawing.Size(155, 444);
            this.tvHost.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tvTag);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(161, 450);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Tag";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tvTag
            // 
            this.tvTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTag.Location = new System.Drawing.Point(3, 3);
            this.tvTag.Name = "tvTag";
            treeNode2.Name = "节点0";
            treeNode2.Text = "主机";
            this.tvTag.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvTag.Size = new System.Drawing.Size(155, 444);
            this.tvTag.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(169, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(473, 476);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucHostDetails1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(465, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHostApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 45);
            this.panel1.TabIndex = 0;
            // 
            // btnHostApply
            // 
            this.btnHostApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHostApply.Location = new System.Drawing.Point(379, 6);
            this.btnHostApply.Name = "btnHostApply";
            this.btnHostApply.Size = new System.Drawing.Size(75, 34);
            this.btnHostApply.TabIndex = 0;
            this.btnHostApply.Text = "应用";
            this.btnHostApply.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(465, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(32, 17);
            this.tsslStatus.Text = "就绪";
            // 
            // ucHostDetails1
            // 
            this.ucHostDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucHostDetails1.Location = new System.Drawing.Point(3, 3);
            this.ucHostDetails1.Name = "ucHostDetails1";
            this.ucHostDetails1.Size = new System.Drawing.Size(459, 399);
            this.ucHostDetails1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 529);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Host管理";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsHost.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ContextMenuStrip cmsHost;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView tvHost;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView tvTag;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ucHostDetails ucHostDetails1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHostApply;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
    }
}

