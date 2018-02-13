namespace AQDEF.Views {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sourceEditor = new System.Windows.Forms.TextBox();
            this.transResult = new System.Windows.Forms.TextBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_Transform = new System.Windows.Forms.ToolStripButton();
            this.toolStrip_OpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sourceEditor);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.transResult);
            this.splitContainer1.Size = new System.Drawing.Size(835, 492);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.TabIndex = 0;
            // 
            // sourceEditor
            // 
            this.sourceEditor.AcceptsReturn = true;
            this.sourceEditor.AcceptsTab = true;
            this.sourceEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceEditor.Location = new System.Drawing.Point(0, 0);
            this.sourceEditor.Multiline = true;
            this.sourceEditor.Name = "sourceEditor";
            this.sourceEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sourceEditor.Size = new System.Drawing.Size(346, 407);
            this.sourceEditor.TabIndex = 0;
            // 
            // transResult
            // 
            this.transResult.AcceptsReturn = true;
            this.transResult.AcceptsTab = true;
            this.transResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transResult.Location = new System.Drawing.Point(0, 0);
            this.transResult.Multiline = true;
            this.transResult.Name = "transResult";
            this.transResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.transResult.Size = new System.Drawing.Size(485, 492);
            this.transResult.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(835, 492);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(835, 517);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_Transform,
            this.toolStrip_OpenFile});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(179, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStrip_Transform
            // 
            this.toolStrip_Transform.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_Transform.Image")));
            this.toolStrip_Transform.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_Transform.Name = "toolStrip_Transform";
            this.toolStrip_Transform.Size = new System.Drawing.Size(88, 22);
            this.toolStrip_Transform.Text = "Transform";
            // 
            // toolStrip_OpenFile
            // 
            this.toolStrip_OpenFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStrip_OpenFile.Image")));
            this.toolStrip_OpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_OpenFile.Name = "toolStrip_OpenFile";
            this.toolStrip_OpenFile.Size = new System.Drawing.Size(79, 22);
            this.toolStrip_OpenFile.Text = "Open &_O";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 85);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 517);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "KKeyEntiesView";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox sourceEditor;
        private System.Windows.Forms.TextBox transResult;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStrip_Transform;
        private System.Windows.Forms.ToolStripButton toolStrip_OpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

