namespace SampleApplication
{
    partial class UiCapturer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiCapturer));
            this.config = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.signUpLinkLabel = new System.Windows.Forms.LinkLabel();
            this.streamBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chanelCountBox = new System.Windows.Forms.TextBox();
            this.sourceIDBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nstrateBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chanelTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.streamNameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.config.SuspendLayout();
            this.streamBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // config
            // 
            this.config.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.config.Controls.Add(this.textBoxPassword);
            this.config.Controls.Add(this.label1);
            this.config.Controls.Add(this.labelUsername);
            this.config.Controls.Add(this.username);
            resources.ApplyResources(this.config, "config");
            this.config.Name = "config";
            this.config.TabStop = false;
            // 
            // textBoxPassword
            // 
            resources.ApplyResources(this.textBoxPassword, "textBoxPassword");
            this.textBoxPassword.Name = "textBoxPassword";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labelUsername
            // 
            resources.ApplyResources(this.labelUsername, "labelUsername");
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Click += new System.EventHandler(this.username_Click);
            // 
            // username
            // 
            resources.ApplyResources(this.username, "username");
            this.username.Name = "username";
            // 
            // stop
            // 
            resources.ApplyResources(this.stop, "stop");
            this.stop.Name = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // start
            // 
            resources.ApplyResources(this.start, "start");
            this.start.Name = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // signUpLinkLabel
            // 
            resources.ApplyResources(this.signUpLinkLabel, "signUpLinkLabel");
            this.signUpLinkLabel.Name = "signUpLinkLabel";
            this.signUpLinkLabel.TabStop = true;
            this.signUpLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.signUpLinkLabel_LinkClicked);
            // 
            // streamBox
            // 
            this.streamBox.Controls.Add(this.label6);
            this.streamBox.Controls.Add(this.chanelCountBox);
            this.streamBox.Controls.Add(this.sourceIDBox);
            this.streamBox.Controls.Add(this.label5);
            this.streamBox.Controls.Add(this.nstrateBox);
            this.streamBox.Controls.Add(this.label4);
            this.streamBox.Controls.Add(this.chanelTBox);
            this.streamBox.Controls.Add(this.label3);
            this.streamBox.Controls.Add(this.label2);
            this.streamBox.Controls.Add(this.streamNameBox);
            resources.ApplyResources(this.streamBox, "streamBox");
            this.streamBox.Name = "streamBox";
            this.streamBox.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // chanelCountBox
            // 
            resources.ApplyResources(this.chanelCountBox, "chanelCountBox");
            this.chanelCountBox.Name = "chanelCountBox";
            // 
            // sourceIDBox
            // 
            resources.ApplyResources(this.sourceIDBox, "sourceIDBox");
            this.sourceIDBox.Name = "sourceIDBox";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // nstrateBox
            // 
            resources.ApplyResources(this.nstrateBox, "nstrateBox");
            this.nstrateBox.Name = "nstrateBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // chanelTBox
            // 
            resources.ApplyResources(this.chanelTBox, "chanelTBox");
            this.chanelTBox.Name = "chanelTBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // streamNameBox
            // 
            resources.ApplyResources(this.streamNameBox, "streamNameBox");
            this.streamNameBox.Name = "streamNameBox";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // UiCapturer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.streamBox);
            this.Controls.Add(this.signUpLinkLabel);
            this.Controls.Add(this.config);
            this.Controls.Add(this.start);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UiCapturer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestForm_FormClosed);
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.config.ResumeLayout(false);
            this.config.PerformLayout();
            this.streamBox.ResumeLayout(false);
            this.streamBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox config;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel signUpLinkLabel;
        private System.Windows.Forms.GroupBox streamBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox streamNameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox chanelTBox;
        private System.Windows.Forms.TextBox nstrateBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sourceIDBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox chanelCountBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

