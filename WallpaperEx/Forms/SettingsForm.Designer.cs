namespace WallpaperEx.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itmSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApply = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayContextMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Wallpaper Settings";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSettings,
            this.itmExit});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.trayContextMenu.Size = new System.Drawing.Size(117, 48);
            // 
            // itmSettings
            // 
            this.itmSettings.Name = "itmSettings";
            this.itmSettings.Size = new System.Drawing.Size(116, 22);
            this.itmSettings.Text = "Settings";
            this.itmSettings.Click += new System.EventHandler(this.itmSettings_Click);
            // 
            // itmExit
            // 
            this.itmExit.Name = "itmExit";
            this.itmExit.Size = new System.Drawing.Size(116, 22);
            this.itmExit.Text = "Exit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(379, 56);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(12, 27);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(442, 23);
            this.tbUrl.TabIndex = 1;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(10, 9);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(31, 15);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "URL:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 87);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wallpaper Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Resize += new System.EventHandler(this.SettingsForm_Resize);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon trayIcon;
        private Button btnApply;
        private TextBox tbUrl;
        private ContextMenuStrip trayContextMenu;
        private ToolStripMenuItem itmSettings;
        private ToolStripMenuItem itmExit;
        private Label lblUrl;
    }
}