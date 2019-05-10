namespace DukeArt
{
    partial class frmMain
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
            this.preview = new System.Windows.Forms.PictureBox();
            this.grpAttributes = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtAnimationSpeed = new System.Windows.Forms.TextBox();
            this.cboAnimationType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtYcenter = new System.Windows.Forms.TextBox();
            this.txtNumFrames = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtXcenter = new System.Windows.Forms.TextBox();
            this.txtIndexSelector = new System.Windows.Forms.NumericUpDown();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.import24bitBitmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.grpAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndexSelector)).BeginInit();
            this.grpPreview.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(22, 19);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(128, 128);
            this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.preview.TabIndex = 9;
            this.preview.TabStop = false;
            // 
            // grpAttributes
            // 
            this.grpAttributes.Controls.Add(this.btnUpdate);
            this.grpAttributes.Controls.Add(this.txtAnimationSpeed);
            this.grpAttributes.Controls.Add(this.cboAnimationType);
            this.grpAttributes.Controls.Add(this.label1);
            this.grpAttributes.Controls.Add(this.label4);
            this.grpAttributes.Controls.Add(this.txtYcenter);
            this.grpAttributes.Controls.Add(this.txtNumFrames);
            this.grpAttributes.Controls.Add(this.label2);
            this.grpAttributes.Controls.Add(this.label3);
            this.grpAttributes.Controls.Add(this.txtXcenter);
            this.grpAttributes.Location = new System.Drawing.Point(12, 27);
            this.grpAttributes.Name = "grpAttributes";
            this.grpAttributes.Size = new System.Drawing.Size(281, 185);
            this.grpAttributes.TabIndex = 12;
            this.grpAttributes.TabStop = false;
            this.grpAttributes.Text = "Attributes";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(126, 156);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 23);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtAnimationSpeed
            // 
            this.txtAnimationSpeed.Location = new System.Drawing.Point(126, 19);
            this.txtAnimationSpeed.Name = "txtAnimationSpeed";
            this.txtAnimationSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtAnimationSpeed.TabIndex = 13;
            this.txtAnimationSpeed.Text = "0";
            this.txtAnimationSpeed.Validating += new System.ComponentModel.CancelEventHandler(this.txtAnimationSpeed_Validating);
            this.txtAnimationSpeed.Validated += new System.EventHandler(this.txtAnimationSpeed_Validated);
            // 
            // cboAnimationType
            // 
            this.cboAnimationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnimationType.FormattingEnabled = true;
            this.cboAnimationType.Items.AddRange(new object[] {
            "none",
            "oscillating",
            "forward",
            "backward"});
            this.cboAnimationType.Location = new System.Drawing.Point(126, 97);
            this.cboAnimationType.Name = "cboAnimationType";
            this.cboAnimationType.Size = new System.Drawing.Size(100, 21);
            this.cboAnimationType.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Animation speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Number of Frames:";
            // 
            // txtYcenter
            // 
            this.txtYcenter.Location = new System.Drawing.Point(126, 45);
            this.txtYcenter.Name = "txtYcenter";
            this.txtYcenter.Size = new System.Drawing.Size(100, 20);
            this.txtYcenter.TabIndex = 15;
            this.txtYcenter.Text = "0";
            this.txtYcenter.Validating += new System.ComponentModel.CancelEventHandler(this.txtYcenter_Validating);
            this.txtYcenter.Validated += new System.EventHandler(this.txtYcenter_Validated);
            // 
            // txtNumFrames
            // 
            this.txtNumFrames.Location = new System.Drawing.Point(126, 124);
            this.txtNumFrames.Name = "txtNumFrames";
            this.txtNumFrames.Size = new System.Drawing.Size(100, 20);
            this.txtNumFrames.TabIndex = 19;
            this.txtNumFrames.Text = "0";
            this.txtNumFrames.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumFrames_Validating);
            this.txtNumFrames.Validated += new System.EventHandler(this.txtNumFrames_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Y-Center Offset:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "X-Center Offset:";
            // 
            // txtXcenter
            // 
            this.txtXcenter.Location = new System.Drawing.Point(126, 71);
            this.txtXcenter.Name = "txtXcenter";
            this.txtXcenter.Size = new System.Drawing.Size(100, 20);
            this.txtXcenter.TabIndex = 17;
            this.txtXcenter.Text = "0";
            this.txtXcenter.Validating += new System.ComponentModel.CancelEventHandler(this.txtXcenter_Validating);
            this.txtXcenter.Validated += new System.EventHandler(this.txtXcenter_Validated);
            // 
            // txtIndexSelector
            // 
            this.txtIndexSelector.Location = new System.Drawing.Point(299, 192);
            this.txtIndexSelector.Name = "txtIndexSelector";
            this.txtIndexSelector.Size = new System.Drawing.Size(174, 20);
            this.txtIndexSelector.TabIndex = 22;
            this.txtIndexSelector.ValueChanged += new System.EventHandler(this.txtIndexSelector_ValueChanged);
            // 
            // grpPreview
            // 
            this.grpPreview.Controls.Add(this.preview);
            this.grpPreview.Location = new System.Drawing.Point(299, 27);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Size = new System.Drawing.Size(174, 159);
            this.grpPreview.TabIndex = 13;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Preview";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(485, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.import24bitBitmapToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // import24bitBitmapToolStripMenuItem
            // 
            this.import24bitBitmapToolStripMenuItem.Name = "import24bitBitmapToolStripMenuItem";
            this.import24bitBitmapToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.import24bitBitmapToolStripMenuItem.Text = "Import 24-bit Bitmap";
            this.import24bitBitmapToolStripMenuItem.Click += new System.EventHandler(this.import24bitBitmapToolStripMenuItem_Click);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatus,
            this.toolStatusMessage});
            this.status.Location = new System.Drawing.Point(0, 221);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(485, 24);
            this.status.TabIndex = 25;
            this.status.Text = "statusStrip1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolStatus
            // 
            this.toolStatus.AutoSize = false;
            this.toolStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStatus.Name = "toolStatus";
            this.toolStatus.Size = new System.Drawing.Size(43, 19);
            this.toolStatus.Text = "Ready";
            // 
            // toolStatusMessage
            // 
            this.toolStatusMessage.Name = "toolStatusMessage";
            this.toolStatusMessage.Size = new System.Drawing.Size(0, 19);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 245);
            this.Controls.Add(this.status);
            this.Controls.Add(this.txtIndexSelector);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.grpAttributes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Duke ART Editor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.grpAttributes.ResumeLayout(false);
            this.grpAttributes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndexSelector)).EndInit();
            this.grpPreview.ResumeLayout(false);
            this.grpPreview.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.GroupBox grpAttributes;
        private System.Windows.Forms.TextBox txtAnimationSpeed;
        private System.Windows.Forms.ComboBox cboAnimationType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYcenter;
        private System.Windows.Forms.TextBox txtNumFrames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXcenter;
        private System.Windows.Forms.NumericUpDown txtIndexSelector;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem import24bitBitmapToolStripMenuItem;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusMessage;
    }
}

