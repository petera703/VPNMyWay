namespace VPNMyWay
{
    partial class Form1
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.rasPhoneBook1 = new DotRas.RasPhoneBook(this.components);
      this.btnConnect = new System.Windows.Forms.Button();
      this.rasDialer1 = new DotRas.RasDialer(this.components);
      this.rasConnectionWatcher1 = new DotRas.RasConnectionWatcher(this.components);
      this.btnDisconnect = new System.Windows.Forms.Button();
      this.lblConnectionStatus = new System.Windows.Forms.Label();
      this.chkReconnectIfDropped = new System.Windows.Forms.CheckBox();
      this.tmrReconnect = new System.Windows.Forms.Timer(this.components);
      this.lbConnectionLog = new System.Windows.Forms.ListBox();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.ctxtMnuTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuItenOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuItemReconnectIfDropped = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuItemLikeIt = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuItemExit = new System.Windows.Forms.ToolStripMenuItem();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.lnkVisitSite = new System.Windows.Forms.LinkLabel();
      this.ctxtMnuFeedbackUrl = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuItemCopyUrlToClipboard = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.rasConnectionWatcher1)).BeginInit();
      this.ctxtMnuTrayIcon.SuspendLayout();
      this.ctxtMnuFeedbackUrl.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(6, 4);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(75, 23);
      this.btnConnect.TabIndex = 0;
      this.btnConnect.Text = "Connect";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // rasDialer1
      // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
      this.rasDialer1.Credentials = null;
      this.rasDialer1.EapOptions = new DotRas.RasEapOptions(false, false, false);
      this.rasDialer1.Options = new DotRas.RasDialOptions(false, false, false, false, false, false, false, false, false, false, false);
      this.rasDialer1.SynchronizingObject = this;
      this.rasDialer1.StateChanged += new System.EventHandler<DotRas.StateChangedEventArgs>(this.rasDialer1_StateChanged);
      this.rasDialer1.DialCompleted += new System.EventHandler<DotRas.DialCompletedEventArgs>(this.rasDialer1_DialCompleted);
      this.rasDialer1.Error += new System.EventHandler<System.IO.ErrorEventArgs>(this.rasDialer1_Error);
      // 
      // rasConnectionWatcher1
      // 
      this.rasConnectionWatcher1.EnableRaisingEvents = true;
      this.rasConnectionWatcher1.Handle = null;
      this.rasConnectionWatcher1.SynchronizingObject = this;
      this.rasConnectionWatcher1.Connected += new System.EventHandler<DotRas.RasConnectionEventArgs>(this.rasConnectionWatcher1_Connected);
      this.rasConnectionWatcher1.Disconnected += new System.EventHandler<DotRas.RasConnectionEventArgs>(this.rasConnectionWatcher1_Disconnected);
      this.rasConnectionWatcher1.Error += new System.EventHandler<System.IO.ErrorEventArgs>(this.rasConnectionWatcher1_Error);
      // 
      // btnDisconnect
      // 
      this.btnDisconnect.Enabled = false;
      this.btnDisconnect.Location = new System.Drawing.Point(6, 42);
      this.btnDisconnect.Name = "btnDisconnect";
      this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
      this.btnDisconnect.TabIndex = 2;
      this.btnDisconnect.Text = "Disconnect";
      this.btnDisconnect.UseVisualStyleBackColor = true;
      this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
      // 
      // lblConnectionStatus
      // 
      this.lblConnectionStatus.AutoSize = true;
      this.lblConnectionStatus.Location = new System.Drawing.Point(87, 9);
      this.lblConnectionStatus.Name = "lblConnectionStatus";
      this.lblConnectionStatus.Size = new System.Drawing.Size(0, 13);
      this.lblConnectionStatus.TabIndex = 3;
      // 
      // chkReconnectIfDropped
      // 
      this.chkReconnectIfDropped.AutoSize = true;
      this.chkReconnectIfDropped.Checked = true;
      this.chkReconnectIfDropped.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkReconnectIfDropped.Location = new System.Drawing.Point(90, 7);
      this.chkReconnectIfDropped.Name = "chkReconnectIfDropped";
      this.chkReconnectIfDropped.Size = new System.Drawing.Size(185, 17);
      this.chkReconnectIfDropped.TabIndex = 4;
      this.chkReconnectIfDropped.Text = "Reconnect if connection dropped";
      this.chkReconnectIfDropped.UseVisualStyleBackColor = true;
      this.chkReconnectIfDropped.Click += new System.EventHandler(this.chkReconnectIfDropped_Click);
      // 
      // tmrReconnect
      // 
      this.tmrReconnect.Interval = 10000;
      this.tmrReconnect.Tick += new System.EventHandler(this.tmrReconnect_Tick);
      // 
      // lbConnectionLog
      // 
      this.lbConnectionLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbConnectionLog.FormattingEnabled = true;
      this.lbConnectionLog.Location = new System.Drawing.Point(6, 72);
      this.lbConnectionLog.Name = "lbConnectionLog";
      this.lbConnectionLog.Size = new System.Drawing.Size(816, 199);
      this.lbConnectionLog.TabIndex = 5;
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.ContextMenuStrip = this.ctxtMnuTrayIcon;
      this.notifyIcon1.Text = "notifyIcon1";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
      // 
      // ctxtMnuTrayIcon
      // 
      this.ctxtMnuTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItenOpen,
            this.toolStripSeparator1,
            this.mnuItemConnect,
            this.mnuItemReconnectIfDropped,
            this.mnuItemDisconnect,
            this.toolStripSeparator2,
            this.mnuItemLikeIt,
            this.toolStripSeparator3,
            this.mnuItemExit});
      this.ctxtMnuTrayIcon.Name = "contextMenuStrip1";
      this.ctxtMnuTrayIcon.Size = new System.Drawing.Size(337, 154);
      // 
      // mnuItenOpen
      // 
      this.mnuItenOpen.Name = "mnuItenOpen";
      this.mnuItenOpen.Size = new System.Drawing.Size(336, 22);
      this.mnuItenOpen.Text = "Open VPNMyWay";
      this.mnuItenOpen.Click += new System.EventHandler(this.mnuItenOpen_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(333, 6);
      // 
      // mnuItemConnect
      // 
      this.mnuItemConnect.Name = "mnuItemConnect";
      this.mnuItemConnect.Size = new System.Drawing.Size(336, 22);
      this.mnuItemConnect.Text = "Connect";
      this.mnuItemConnect.Click += new System.EventHandler(this.mnuItemConnect_Click);
      // 
      // mnuItemReconnectIfDropped
      // 
      this.mnuItemReconnectIfDropped.Checked = true;
      this.mnuItemReconnectIfDropped.CheckOnClick = true;
      this.mnuItemReconnectIfDropped.CheckState = System.Windows.Forms.CheckState.Checked;
      this.mnuItemReconnectIfDropped.Name = "mnuItemReconnectIfDropped";
      this.mnuItemReconnectIfDropped.Size = new System.Drawing.Size(336, 22);
      this.mnuItemReconnectIfDropped.Text = "Reconnect if connection dropped";
      this.mnuItemReconnectIfDropped.Click += new System.EventHandler(this.mnuItemReconnectIfDropped_Click);
      // 
      // mnuItemDisconnect
      // 
      this.mnuItemDisconnect.Name = "mnuItemDisconnect";
      this.mnuItemDisconnect.Size = new System.Drawing.Size(336, 22);
      this.mnuItemDisconnect.Text = "Disconnect";
      this.mnuItemDisconnect.Click += new System.EventHandler(this.mnuItemDisconnect_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(333, 6);
      // 
      // mnuItemLikeIt
      // 
      this.mnuItemLikeIt.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemLikeIt.Image")));
      this.mnuItemLikeIt.Name = "mnuItemLikeIt";
      this.mnuItemLikeIt.Size = new System.Drawing.Size(336, 22);
      this.mnuItemLikeIt.Text = "Like it? Buy me a beer!  [Launches your browser...]";
      this.mnuItemLikeIt.Click += new System.EventHandler(this.mnuItemLikeIt_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(333, 6);
      // 
      // mnuItemExit
      // 
      this.mnuItemExit.Name = "mnuItemExit";
      this.mnuItemExit.Size = new System.Drawing.Size(336, 22);
      this.mnuItemExit.Text = "Exit VPNMyWay";
      this.mnuItemExit.Click += new System.EventHandler(this.mnuItemExit_Click);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "NotConnected1");
      this.imageList1.Images.SetKeyName(1, "Connected1");
      this.imageList1.Images.SetKeyName(2, "ConnectionDropped1");
      this.imageList1.Images.SetKeyName(3, "Connected2");
      this.imageList1.Images.SetKeyName(4, "ConnectionDropped2");
      this.imageList1.Images.SetKeyName(5, "NotConnected2");
      this.imageList1.Images.SetKeyName(6, "NotConnected");
      this.imageList1.Images.SetKeyName(7, "Connected");
      this.imageList1.Images.SetKeyName(8, "ConnectionDropped");
      // 
      // lnkVisitSite
      // 
      this.lnkVisitSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lnkVisitSite.AutoSize = true;
      this.lnkVisitSite.ContextMenuStrip = this.ctxtMnuFeedbackUrl;
      this.lnkVisitSite.Location = new System.Drawing.Point(741, 4);
      this.lnkVisitSite.Name = "lnkVisitSite";
      this.lnkVisitSite.Size = new System.Drawing.Size(86, 13);
      this.lnkVisitSite.TabIndex = 6;
      this.lnkVisitSite.TabStop = true;
      this.lnkVisitSite.Text = "Help && feedback";
      this.lnkVisitSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVisitSite_LinkClicked);
      // 
      // ctxtMnuFeedbackUrl
      // 
      this.ctxtMnuFeedbackUrl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemCopyUrlToClipboard});
      this.ctxtMnuFeedbackUrl.Name = "ctxtMnuFeedbackUrl";
      this.ctxtMnuFeedbackUrl.Size = new System.Drawing.Size(146, 26);
      // 
      // mnuItemCopyUrlToClipboard
      // 
      this.mnuItemCopyUrlToClipboard.Name = "mnuItemCopyUrlToClipboard";
      this.mnuItemCopyUrlToClipboard.Size = new System.Drawing.Size(145, 22);
      this.mnuItemCopyUrlToClipboard.Text = "Copy address";
      this.mnuItemCopyUrlToClipboard.Click += new System.EventHandler(this.mnuItemCopyUrlToClipboard_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(828, 283);
      this.Controls.Add(this.lnkVisitSite);
      this.Controls.Add(this.lbConnectionLog);
      this.Controls.Add(this.btnConnect);
      this.Controls.Add(this.chkReconnectIfDropped);
      this.Controls.Add(this.lblConnectionStatus);
      this.Controls.Add(this.btnDisconnect);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "VPNMyWay";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Shown += new System.EventHandler(this.Form1_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.rasConnectionWatcher1)).EndInit();
      this.ctxtMnuTrayIcon.ResumeLayout(false);
      this.ctxtMnuFeedbackUrl.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private DotRas.RasPhoneBook rasPhoneBook1;
        private System.Windows.Forms.Button btnConnect;
        private DotRas.RasDialer rasDialer1;
        private DotRas.RasConnectionWatcher rasConnectionWatcher1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.CheckBox chkReconnectIfDropped;
        private System.Windows.Forms.Timer tmrReconnect;
        private System.Windows.Forms.ListBox lbConnectionLog;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip ctxtMnuTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuItenOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuItemConnect;
        private System.Windows.Forms.ToolStripMenuItem mnuItemReconnectIfDropped;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDisconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemLikeIt;
        private System.Windows.Forms.LinkLabel lnkVisitSite;
        private System.Windows.Forms.ContextMenuStrip ctxtMnuFeedbackUrl;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCopyUrlToClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

