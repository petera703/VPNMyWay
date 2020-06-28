using DotRas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VPNMyWay
{
  public partial class Form1 : Form
  {
    private Point startuplocation;

    public Form1()
    {
      InitializeComponent();

      notifyIcon1.Icon = Icon.FromHandle(((Bitmap)imageList1.Images["NotConnected"]).GetHicon());
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.startuplocation = this.Location;
      this.Location = new Point(-1000, -1000);
    }

    private void Form1_Shown(object sender, EventArgs e) //fires first time shown
    {
      hideForm();
      this.Location = this.startuplocation;

      getStartupArgs();

      if (this.connectionName != null)
      {
        IEnumerable<RasConnection> cns = RasConnection.GetActiveConnections().Where(c => c.EntryName == this.connectionName);

        if (cns.Count() == 1)
        {
          addConnectionLog("VPNMyWay detected that your computer was already connected to {0}", this.connectionName);
          //   addConnectionLog("You may close this window");
          this.isConnected = true;
          setTitle("disconnect from " + this.connectionName);
          notifyIcon1.Icon = Icon.FromHandle(((Bitmap)imageList1.Images["Connected"]).GetHicon());
          btnConnect.Enabled = mnuItemConnect.Enabled = false; ;
          btnDisconnect.Enabled = mnuItemDisconnect.Enabled = true;
          //  this.Visible = false;
          //    hideForm();

          //     notifyIcon1.ShowBalloonTip(2000, "VPNMyWay", "Already connected to " + this.connectionName, ToolTipIcon.Info);
        }
        else
        {
          //   setTitle("connect to " + this.connectionName);
          if (this.isConnectOnLaunch)
            connect(isRunPreconnectCmd: true);
          else
            setTitle("connect to " + this.connectionName);
        }

        mnuItemConnect.Text = "Connect to " + this.connectionName;
        mnuItemDisconnect.Text = "Disconnect from " + this.connectionName;
      }
      else
      {
        notifyIcon1.Visible = false;
        string caption = "Command-line error: VPN name not specified";
        string msg = "Edit your VPNMyWay shortcut to add your VPN name after the command:\r\n\r\n\tVPNMyWay <vpnname>";
        MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        this.isExiting = true;
        this.Close();
        //setTitle("command-line error");
        //btnConnect.Enabled = false;
        //     showForm();
      }
    }

    private void getStartupArgs()
    {
      string startupMsg = "VPNMyWay 1.5 launched for {0}";

      List<string> args = Environment.GetCommandLineArgs().ToList();

      if (args.Count > 1)
        this.connectionName = args[1];

      for (int i = 2; i < args.Count; i++)
        startupMsg += " " + args[i];

      addConnectionLog(startupMsg, this.connectionName);

      this.isVerbose = (args.Contains("/verbose"));
      this.isConnectOnLaunch = !args.Contains("/manualfirstconnect");
      chkReconnectIfDropped.Checked = mnuItemReconnectIfDropped.Checked = !args.Contains("/manualreconnect");
      this.preconnectCmdName = getArgValue("/preconnect", args);
      this.connectedCmdName = getArgValue("/connected", args);
      this.postdisconnectCmdName = getArgValue("/postdisconnect", args);
      this.connectionErrorCmdName = getArgValue("/connectionerror", args);
    }

    private string getArgValue(string argName, List<string> args)
    {
      string argValue = null;
      string[] argParts = null;

      string arg = args.FirstOrDefault(a => a.StartsWith(argName));

      if (arg != null)
      {
        argParts = arg.Split('=');
        if (argParts.Length == 2)
          argValue = argParts[1];
      }

      return argValue;
    }

    private void runCmd(string cmd, string description)
    {
      addConnectionLog("Executing {0} {1}", description, cmd);

      try
      {
        Process p = new Process();
        p.StartInfo.FileName = cmd;
        p.StartInfo.Arguments = this.connectionName;

        //These are not expected to be long-running commands; don't wait all day for them to complete.
        int timeoutSeconds = 30;

        if (p.Start())
          p.WaitForExit(timeoutSeconds * 1000);
        else
          //If Start returns false it means it reused an existing process... not expected here, or particularly useful.
          throw new Exception(string.Format("The process failed to start. Check whether your {0} is already executing.", description));

        if (!p.HasExited)
          throw new Exception(string.Format("Timeout: {0} did not exit within {1} seconds", description, timeoutSeconds));

        if (p.ExitCode == 0)
          addConnectionLog("{0} completed with exit code 0", description);
        else
          throw new Exception(string.Format("Non-zero exit code {0}", p.ExitCode));

      }
      catch (Exception ex)
      {
        notifyIcon1.ShowBalloonTip(2000, "VPNMyWay", string.Format("{0} failed: {1}", description, ex.Message), ToolTipIcon.Error);
        throw;
      }
    }

    private void showForm()
    {
      //   this.Visible = true;
      this.WindowState = FormWindowState.Normal; //Started out minimized to avoid flicker. (sigh...)
      this.Show();
      this.Activate();
    }

    private void hideForm()
    {
      this.Hide();
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      connect(isRunPreconnectCmd: true);
    }

    /// <summary>
    /// Connect to the VPN. Does its own exception handling and logging.
    /// </summary>
    private void connect(bool isRunPreconnectCmd)
    {
      try
      {
        btnConnect.Enabled = false;
        setTitle("connecting to " + this.connectionName + "...");
        addConnectionLog("Connection requested");

        if (isRunPreconnectCmd && this.preconnectCmdName != null)
        {
          try
          {
            runCmd(this.preconnectCmdName, "Pre-connect command");
          }
          catch
          {
            addConnectionLog("Not connecting as pre-connect command failed.");
            throw;
          }
        }

        addConnectionLog("Connecting");
        Application.DoEvents();

        rasDialer1.PhoneBookPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Network\Connections\Pbk\rasphone.pbk");
        rasDialer1.EntryName = this.connectionName;
        rasDialer1.AllowUseStoredCredentials = true;

        rasDialer1.DialAsync();
      }
      catch (Exception ex)
      {
        addConnectionLog(ex.Message);
        btnConnect.Enabled = true;
        setTitle("connect to " + this.connectionName);
      }
    }

    private void rasDialer1_Error(object sender, ErrorEventArgs e)
    {
      BeginInvoke((MethodInvoker)delegate ()
      {
        addConnectionLog(e.GetException().Message);

        if (this.connectionErrorCmdName != null)
        {
          string description = "Connection error command";

          try
          {
            runCmd(this.connectionErrorCmdName, description);
          }
          catch (Exception ex)
          {
            addConnectionLog("{0} failed: {1}", description, ex.Message);
          }
        }
      });
    }

    private void rasDialer1_StateChanged(object sender, DotRas.StateChangedEventArgs e)
    {
      if (this.isVerbose)
      {
        BeginInvoke((MethodInvoker)delegate ()
        {
          addConnectionLog(e.State.ToString());
        });
      }
    }

    private void rasDialer1_DialCompleted(object sender, DotRas.DialCompletedEventArgs e)
    {
      BeginInvoke((MethodInvoker)delegate ()
      {
        if (e.Cancelled)
          addConnectionLog("Cancelled!");
        else if (e.TimedOut)
          addConnectionLog("Timeout!");
        else if (e.Error != null)
              //    addConnectionLog(e.Error.ToString());  //"DotRas.RasDialException: Exception of type 'DotRas.RasDialException' was thrown." Right.
              {
          addConnectionLog("Unable to connect to your '{0}' VPN!", this.connectionName);
          addConnectionLog("Use Windows directly to check you can connect to '{0}'", this.connectionName);
                //TODO rationalize setting title more centrally?
                setTitle("connect to " + this.connectionName);
        }
        else if (e.Connected)
                //this.Visible = false;
                hideForm();


        btnConnect.Enabled = !e.Connected;
      });
    }

    private void btnDisconnect_Click(object sender, EventArgs e)
    {
      disconnect();

      //Two calls for testing the command callouts, as these events aren't easy to conjour up
      // rasConnectionWatcher1_Error(null, new ErrorEventArgs(new Exception("TMP rasConnectionWatcher1_Error EXCPT")));
      //  rasDialer1_Error(null, new ErrorEventArgs(new Exception("TMP rasDialer1_Error EXCPT")));

    }

    /// <summary>
    /// Disconnect from the VPN. Does its own exception handling and logging.
    /// </summary>
    private void disconnect()
    {
      try
      {
        btnDisconnect.Enabled = false;

        this.isManualDisconnect = true;
        addConnectionLog("Disconnection requested");

        IEnumerable<RasConnection> cns = RasConnection.GetActiveConnections().Where(c => c.EntryName == this.connectionName);

        if (cns.Count() == 1)
          cns.First().HangUp();

        btnConnect.Enabled = true;
        setTitle("connect to " + this.connectionName);
      }
      catch (Exception ex)
      {
        addConnectionLog(ex.Message);
      }
    }

    private void rasConnectionWatcher1_Connected(object sender, DotRas.RasConnectionEventArgs e)
    {
      if (e.Connection.EntryName == this.connectionName)
      {
        this.isConnected = true;

        BeginInvoke((MethodInvoker)delegate ()
        {
          notifyIcon1.Icon = Icon.FromHandle(((Bitmap)imageList1.Images["Connected"]).GetHicon());
          notifyIcon1.ShowBalloonTip(2000, "VPNMyWay", "Connected to " + this.connectionName, ToolTipIcon.Info);
          mnuItemConnect.Enabled = btnConnect.Enabled = false;
          mnuItemDisconnect.Enabled = btnDisconnect.Enabled = true;
          this.isManualDisconnect = false;
          addConnectionLog("Connected");

          setTitle("disconnect from " + this.connectionName);

          tmrReconnect.Enabled = false;

          if (this.connectedCmdName != null)
          {
            string description = "Connect command";

            try
            {
              runCmd(this.connectedCmdName, description);
            }
            catch (Exception ex)
            {
              addConnectionLog("{0} failed: {1}", description, ex.Message);
            }
          }
        });

      }
    }

    private void rasConnectionWatcher1_Disconnected(object sender, DotRas.RasConnectionEventArgs e)
    {
      if (e.Connection.EntryName == this.connectionName)
      {
        this.isConnected = false;

        BeginInvoke((MethodInvoker)delegate ()
        {
          mnuItemDisconnect.Enabled = btnDisconnect.Enabled = false;
          addConnectionLog("Disconnected");

          if (chkReconnectIfDropped.Checked && !this.isManualDisconnect)
          {
            notifyIcon1.Icon = Icon.FromHandle(((Bitmap)imageList1.Images["ConnectionDropped"]).GetHicon());
            notifyIcon1.ShowBalloonTip(2000, "VPNMyWay", "Your VPN connection to " + this.connectionName + " dropped. Reconnecting in 10 seconds...", ToolTipIcon.Error);
            addConnectionLog("Disconnection was unexpected. Reconnecting in 10 seconds...");
            setTitle("reconnect pending (click to cancel)...");
            tmrReconnect.Enabled = true;
          }
          else
          {
            notifyIcon1.Icon = Icon.FromHandle(((Bitmap)imageList1.Images["NotConnected"]).GetHicon());
            notifyIcon1.ShowBalloonTip(2000, "VPNMyWay", "Disconnected from " + this.connectionName, ToolTipIcon.Info);

            if (this.postdisconnectCmdName != null)
            {
              string description = "Post-disconnect command";

              try
              {
                runCmd(this.postdisconnectCmdName, description);
              }
              catch (Exception ex)
              {
                addConnectionLog("{0} failed: {1}", description, ex.Message);
              }
            }

            btnConnect.Enabled = mnuItemConnect.Enabled = true;
            setTitle("connect to " + this.connectionName);
          }
        });
      }
    }

    private void rasConnectionWatcher1_Error(object sender, ErrorEventArgs e)
    {
      Exception exWatcher = e.GetException();

      BeginInvoke((MethodInvoker)delegate ()
      {
        addConnectionLog(exWatcher.ToString());
        addConnectionLog("Error: {0}", exWatcher.Message);

        if (this.connectionErrorCmdName != null)
        {
          string description = "Connection error command";

          try
          {
            runCmd(this.connectionErrorCmdName, description);
          }
          catch (Exception exCmd)
          {
            addConnectionLog("{0} failed: {1}", description, exCmd.Message);
          }
        }
      });
    }

    private void addConnectionLog(string message, params object[] args)
    {
      string entry = string.Format("{0}: {1}", DateTime.Now, string.Format(message, args));
      addConnectionLogObject(entry);
    }

    private void addConnectionLogObject(object entry)
    {
      lbConnectionLog.Items.Add(entry);

      //Select last item so as to ensure visible, then deselect it again.  (Sigh...)
      lbConnectionLog.SelectedIndex = lbConnectionLog.Items.Count - 1;
      lbConnectionLog.SelectedIndex = -1;
    }

    private void tmrReconnect_Tick(object sender, EventArgs e)
    {
      //   TODO disable timer here? But what about retries on failure, as opposed to dropped cn?
      //Leave for now - seems to work pretty well as is!
      connect(isRunPreconnectCmd: false);
    }

    private void setTitle(string statusMsg)
    {
      this.Text = notifyIcon1.Text = string.Format("VPNMyWay / {0}", statusMsg);
    }
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.isExiting)
      {
        notifyIcon1.Visible = false;
      }
      else
      {
        e.Cancel = true;
        //this.Visible = false;
        hideForm();

      }
    }

    private void notifyIcon1_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        //      showForm();  //nope--one-click connect/disconnect is even better! Menu for all else.

        if (this.isConnected)
          disconnect();
        else if (tmrReconnect.Enabled)
          abortReconnect();
        else
          connect(isRunPreconnectCmd: true);
      }
    }

    private void abortReconnect()
    {
      //stop the timer to abort the reconnection attempts.
      tmrReconnect.Enabled = false;

      //reset the UI 
      //  disconnect();
      //  btnDisconnect.Enabled = false;
      addConnectionLog("Cancel requested");
      //  btnConnect.Enabled = true;
      setTitle("connect to " + this.connectionName);

      //disconnect() won't reset the tray icon--that's normally done in the disconnect event handler, but we're not connected.
      notifyIcon1.Icon = Icon.FromHandle(((Bitmap)imageList1.Images["NotConnected"]).GetHicon());
    }

    private void mnuItenOpen_Click(object sender, EventArgs e)
    {
      showForm();
    }

    private void mnuItemConnect_Click(object sender, EventArgs e)
    {
      showForm();
      connect(isRunPreconnectCmd: true);
    }

    private void mnuItemDisconnect_Click(object sender, EventArgs e)
    {
      disconnect();
    }

    private void mnuItemExit_Click(object sender, EventArgs e)
    {
      this.isExiting = true;

      this.Close();
    }

    private void mnuItemReconnectIfDropped_Click(object sender, EventArgs e)
    {
      chkReconnectIfDropped.Checked = mnuItemReconnectIfDropped.Checked;
    }

    private void chkReconnectIfDropped_Click(object sender, EventArgs e)
    {
      mnuItemReconnectIfDropped.Checked = chkReconnectIfDropped.Checked;
    }

    private void mnuItemLikeIt_Click(object sender, EventArgs e)
    {
      launchBrowserForFeedback(this.beerUrl);
    }

    private void launchBrowserForFeedback(string url)
    {
      try
      {
        Process.Start(url);
      }
      catch (Exception ex)
      {
        showForm();
        addConnectionLog("Couldn't launch your browser!");
        addConnectionLog(ex.Message);
        addConnectionLog("Please visit " + url + " using your browser");
      }
    }

    private void lnkVisitSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        launchBrowserForFeedback(this.faqUrl);
      }
    }

    private void mnuItemCopyUrlToClipboard_Click(object sender, EventArgs e)
    {
      try
      {
        Clipboard.SetData(DataFormats.StringFormat, this.faqUrl);
      }
      catch (Exception ex)
      {
        showForm();
        addConnectionLog("Couldn't copy to your clipboard!");
        addConnectionLog(ex.Message);
        addConnectionLog("Please enter " + this.faqUrl + " into your browser");
      }
    }

    private string connectionName = null;
    private bool isManualDisconnect = false;
    private bool isVerbose = false;
    private bool isConnected = false;
    private bool isConnectOnLaunch = true;

    private string preconnectCmdName;
    private string connectedCmdName;
    private string postdisconnectCmdName;
    private string connectionErrorCmdName;
    private bool isExiting = false;
    private string faqUrl = "https://vpnmyway.wordpress.com/faq/";
    private string beerUrl = "https://vpnmyway.wordpress.com/buy-me-a-beer/";
  }
}
