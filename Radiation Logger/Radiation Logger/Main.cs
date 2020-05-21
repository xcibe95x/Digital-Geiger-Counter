using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Radiation_Logger
{

    public partial class Main : Form
    {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        private SerialPort _comPort;
        private List<string> _graphData = new List<string>();
        private double _conversionFactor;
        private bool _saveToLogBool = false;
        private string _logFilePath;
        private bool _close = false;
        private int _alarmThreshold = 0;
        private List<string> _logBuffer = new List<string>();

        public Main()
        {
            InitializeComponent();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsForm = new ConnectionSettingsForm();
            settingsForm.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Logs"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\Logs");
            }
            conversionFactorLabel.Text =
                Properties.Settings.Default.ConversionFactor.ToString(CultureInfo.InvariantCulture);
            SaveLogToFileTooltip.SetToolTip(SaveLogToFileCheckbox,
                                            "Logs will be saved to \r\n" +
                                            Path.GetDirectoryName(Application.ExecutablePath) + @"\Log\");
            AlertThresholdLabel.Text = Properties.Settings.Default.AlertThreshold.ToString(CultureInfo.InvariantCulture);
            TrayIcon.ContextMenuStrip = trayMenuStrip;
        }

        private void conversionFactorSaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ConversionFactor =
                conversionFactorLabel.Text.ToString(CultureInfo.InvariantCulture);
            Properties.Settings.Default.Save();
        }

        private void startLogButton_Click(object sender, EventArgs e)
        {
            _alarmThreshold = int.Parse(AlertThresholdLabel.Text);
            if (SaveLogToFileCheckbox.Checked)
            {
                _saveToLogBool = true;
                _logFilePath = Application.StartupPath + @"\Logs\log-" +
                               DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss", CultureInfo.InvariantCulture) + @".csv";
            }
            if (Properties.Settings.Default.PortString == "")
            {
                MessageBox.Show("Please configure settings");
                return;
            }
            if (
                double.TryParse(conversionFactorLabel.Text.ToString(CultureInfo.InvariantCulture), out _conversionFactor) ==
                false)
            {
                MessageBox.Show("Please set Conversion Factor (try comma instead of dot)");
                return;
            }

            if (startLogButton.Text == "Start Log")
            {
                _logBuffer.Clear();
                PortTimeoutTimer.Enabled = true;
                _graphData.Clear();
                startLogButton.Text = "Stop Log";
                var stopBitsString = "";
                switch (Properties.Settings.Default.StopBit)
                {
                    case 0:
                        {
                            stopBitsString = "One";
                        }
                        break;
                    case 1:
                        {
                            stopBitsString = "OnePointFive";
                        }
                        break;
                    default:
                        stopBitsString = "Two";
                        break;
                }
                var stopBits = (StopBits) Enum.Parse(typeof (StopBits), stopBitsString);
                var port = Properties.Settings.Default.PortString;
                var parity = (Parity) Enum.Parse(typeof (Parity), Properties.Settings.Default.ParityString);
                var speed = int.Parse(Properties.Settings.Default.SpeedString);
                var dataBits = int.Parse(Properties.Settings.Default.DataBitsString);

                _comPort = new SerialPort(port, speed, parity, dataBits, stopBits);
                _comPort.DataReceived += comPort_DataReceived;
                _comPort.ReadTimeout = 15000;

                try
                {
                    _comPort.Open();
                }
                catch (Exception)
                {
                    startLogButton.Text = "Start Log";
                    MessageBox.Show("Port is busy");
                    _comPort.Close();
                }
            }
            else if (startLogButton.Text == "Stop Log")
            {
                PortTimeoutTimer.Enabled = false;
                _comPort.Close();
                startLogButton.Text = "Start Log";
            }
        }

        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);
            int cpmParsedInt;
            var cpmReceivedString = string.Empty;
            try
            {
                cpmReceivedString = _comPort.ReadExisting().Trim();
            }
            catch (Exception)
            {
            }

            if (!int.TryParse(cpmReceivedString, out cpmParsedInt))
            {
                return;
            }
            BeginInvoke(new MethodInvoker(() => PortTimeoutTimer.Stop()));
            BeginInvoke(new MethodInvoker(() => PortTimeoutTimer.Start()));
            var itemToAdd = new StringBuilder();
            itemToAdd.Append(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture));
            itemToAdd.Append(" ");
            itemToAdd.Append(cpmReceivedString);
            itemToAdd.Append(" CPM");
            BeginInvoke(new MethodInvoker(() => listBox1.Items.Add(itemToAdd)));
            BeginInvoke(new MethodInvoker(() => listBox1.TopIndex = listBox1.Items.Count - 1));
            BeginInvoke(
                new MethodInvoker(
                    () =>
                    currentRadiationLevelLabel.Text =
                    (_conversionFactor*cpmParsedInt) +
                    " uSv/h"));
            _graphData.Add(itemToAdd.ToString());
            if (_saveToLogBool)
            {
                appendToLog(itemToAdd.ToString());
            }
            checkAlarm(cpmParsedInt);
        }

        private void checkAlarm(int cpm)
        {
            if (cpm < _alarmThreshold)
            {
                return;
            }
            Invoke(new MethodInvoker(() => FlashTimer.Enabled = true));
            Invoke(new MethodInvoker(() => FlashingStopTimer.Enabled = true));
            Invoke(
                new MethodInvoker(
                    () =>
                    TrayIcon.ShowBalloonTip(100, "Radiation Alert", "Current CPM level = " + cpm.ToString(),
                                            ToolTipIcon.Warning)));
        }

        private void graphFromCurrentLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var graphForm = new Graph {GraphData = _graphData};
            graphForm.Show();
        }

        private void AlertThresholdSaveButton_Click(object sender, EventArgs e)
        {
            int parsedThreshold;
            if (int.TryParse(AlertThresholdLabel.Text, out parsedThreshold) == true)
            {
                Properties.Settings.Default.AlertThreshold = parsedThreshold;
                Properties.Settings.Default.Save();
            }
            else
            {
                MessageBox.Show("Please enter integer threshold number before saving!");
            }

        }

        private void appendToLog(string stringToAppendToLog)
        {
            if (_logBuffer.Count > 0)
            {
                try
                {
                    var log = new StreamWriter(Path.GetFullPath(_logFilePath), true);
                    foreach (var logEntry in _logBuffer)
                    {
                        log.WriteLine(logEntry);
                    }
                    log.Close();
                    _logBuffer.Clear();
                }
                catch (Exception)
                {
                }
            }

            try
            {
                var log = new StreamWriter(Path.GetFullPath(_logFilePath), true);
                log.WriteLine(stringToAppendToLog.Replace(' ', ',').Replace(",CPM", " CPM"));
                log.Close();
            }
            catch (IOException)
            {
                _logBuffer.Add(stringToAppendToLog.Replace(' ', ',').Replace(",CPM", " CPM"));
            }

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var aboutForm = new About_Radiation_Logger();
            aboutForm.ShowDialog();
        }

        private void emailSupportradiohobbystorecomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string emailSupport = "mailto:support@radiohobbystore.com";
            Process.Start(emailSupport);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _close = true;
            CloseProgram();
        }

        private void graphFromlogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphFromFileOpenfiledialog.ShowDialog();
            if (GraphFromFileOpenfiledialog.FileName == "")
            {
                return;
            }
            var graphFromFileData = new List<string>();
            graphFromFileData.Clear();
            graphFromFileData.AddRange(File.ReadAllLines(GraphFromFileOpenfiledialog.FileName));
            var graphFromFileForm = new Graph {GraphData = graphFromFileData};
            graphFromFileForm.Show();
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_close || e.CloseReason == CloseReason.WindowsShutDown)
            {
                CloseProgram();
            }
            else
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void OpenContextMenuItem1_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void ExitContextMenuItem1_Click(object sender, EventArgs e)
        {
            _close = true;
            CloseProgram();
        }

        private void CloseProgram()
        {
            try
            {
                _comPort.Close();
            }
            catch (Exception)
            {
            }
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
            }
            try
            {
                TrayIcon.Dispose();
            }
            catch (Exception)
            {

            }

        }

        private void FlashTimer_Tick(object sender, EventArgs e)
        {
            //var handle = Handle;
            FlashWindow(Handle, true);
        }

        private void FlashingStopTimer_Tick(object sender, EventArgs e)
        {
            FlashTimer.Enabled = false;
            FlashingStopTimer.Enabled = false;
        }

        private void PortTimeoutTimer_Tick(object sender, EventArgs e)
        {
            _comPort.Close();
            PortTimeoutTimer.Enabled = false;
            startLogButton.Text = "Start Log";
            MessageBox.Show("Device disconnected!");
        }

        private void logsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath+"/Logs/");
        }

    }
}