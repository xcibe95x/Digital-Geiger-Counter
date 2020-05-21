using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO.Ports;
using System.Windows.Forms;

namespace Radiation_Logger
{
    public partial class ConnectionSettingsForm : Form
    {
        private SerialPort _comPort;
        
        public ConnectionSettingsForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AvailablePorts != null)
            {
                PortComboBox.Items.Clear();
                foreach (var s in Properties.Settings.Default.AvailablePorts)
                {
                    PortComboBox.Items.Add(s);
                }

                PortComboBox.SelectedIndex = Properties.Settings.Default.Port;
            }
            else
            {
                TestConnectionButton.Enabled = false;
            }

            StopBitComboBox.SelectedIndex = Properties.Settings.Default.StopBit;
            ParityComboBox.SelectedIndex = Properties.Settings.Default.Parity;
            SpeedComboBox.SelectedIndex = Properties.Settings.Default.Speed;
            DataBitsComboBox.SelectedIndex = Properties.Settings.Default.DataBits;
        }
        
        private void TestConnectionButton_Click(object sender, EventArgs e)
        {
            TestConnectionButton.Text = "Trying to connect...";
            TestConnectionButton.Enabled = false;
            var port = PortComboBox.SelectedItem.ToString();
            var stopBitsString = "";
            switch (StopBitComboBox.SelectedIndex)
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
            var parity = (Parity) Enum.Parse(typeof (Parity), ParityComboBox.SelectedItem.ToString());

            var speed = int.Parse(SpeedComboBox.SelectedItem.ToString());
            var dataBits = int.Parse(DataBitsComboBox.SelectedItem.ToString());

            _comPort = new SerialPort(port, speed, parity, dataBits, stopBits);

            _comPort.DataReceived += comPort_DataReceived;
            _comPort.ReadTimeout = 15000;

            try
            {
                _comPort.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Port is busy");
                _comPort.Close();
                TestConnectionButton.Text = "Test connection";
                TestConnectionButton.Enabled = true;
            }
            if (_comPort.IsOpen)
            {
                ConnectionTestTimer.Interval = 15000; //15 seconds
                ConnectionTestTimer.Start();
            }
        }

        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _comPort.Close();
            var enableSaveButton = new DelegateVoid(ConnectionTestSuccessfull);
            Invoke(enableSaveButton);
        }

        private delegate void DelegateVoid();

        private void ConnectionTestSuccessfull()
        {
            SaveSettingsButton.Enabled = true;
            TestConnectionButton.Enabled = true;
            TestConnectionButton.Text = "Connected!";
            ConnectionTestTimer.Stop();
        }

        private void GetAvailablePortsButton_Click(object sender, EventArgs e)
        {
            try
            {
                PortComboBox.Items.Clear();
                Properties.Settings.Default.AvailablePorts.Clear();
            }
            catch (Exception)
            {
             
            }
            
            var portNames = SerialPort.GetPortNames();
            Array.Sort(portNames, new AlphanumComparatorFast());

            //hack to initialize Settings collection
            if (Properties.Settings.Default.AvailablePorts == null)
            {
                var availablePorts = new StringCollection();
                Properties.Settings.Default.AvailablePorts = availablePorts;
            }

            foreach (var s in portNames)
            {
                PortComboBox.Items.Add(s);
                Properties.Settings.Default.AvailablePorts.Add(s);
            }
            
            if (PortComboBox.Items.Count > 0)
            {
                PortComboBox.SelectedItem = portNames[0];
                TestConnectionButton.Enabled = true;
            }

            switch (portNames.Length)
            {
                case 0:
                    MessageBox.Show("No ports found!");
                    break;
                case 1:
                    MessageBox.Show("1 port found");
                    break;
                default:
                    MessageBox.Show("Found " + portNames.Length + " ports");
                    break;
            }
        }

        

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = PortComboBox.SelectedIndex;
            Properties.Settings.Default.StopBit = StopBitComboBox.SelectedIndex;
            Properties.Settings.Default.Parity = ParityComboBox.SelectedIndex;
            Properties.Settings.Default.Speed = SpeedComboBox.SelectedIndex;
            Properties.Settings.Default.DataBits = DataBitsComboBox.SelectedIndex;
            Properties.Settings.Default.PortString = PortComboBox.Text;
            Properties.Settings.Default.ParityString = ParityComboBox.Text;
            Properties.Settings.Default.SpeedString = SpeedComboBox.Text;
            Properties.Settings.Default.DataBitsString = DataBitsComboBox.Text;
            Properties.Settings.Default.Save();
            Close();
        }

        //Sorts list of ports by name and number
        private class AlphanumComparatorFast : IComparer
        {
            public int Compare(object x, object y)
            {
                var s1 = x as string;
                if (s1 == null)
                {
                    return 0;
                }
                var s2 = y as string;
                if (s2 == null)
                {
                    return 0;
                }

                var len1 = s1.Length;
                var len2 = s2.Length;
                var marker1 = 0;
                var marker2 = 0;

                // Walk through two the strings with two markers.
                while (marker1 < len1 && marker2 < len2)
                {
                    var ch1 = s1[marker1];
                    var ch2 = s2[marker2];

                    // Some buffers we can build up characters in for each chunk.
                    var space1 = new char[len1];
                    var loc1 = 0;
                    var space2 = new char[len2];
                    var loc2 = 0;

                    // Walk through all following characters that are digits or
                    // characters in BOTH strings starting at the appropriate marker.
                    // Collect char arrays.
                    do
                    {
                        space1[loc1++] = ch1;
                        marker1++;

                        if (marker1 < len1)
                        {
                            ch1 = s1[marker1];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                    do
                    {
                        space2[loc2++] = ch2;
                        marker2++;

                        if (marker2 < len2)
                        {
                            ch2 = s2[marker2];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                    // If we have collected numbers, compare them numerically.
                    // Otherwise, if we have strings, compare them alphabetically.
                    var str1 = new string(space1);
                    var str2 = new string(space2);

                    int result;

                    if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                    {
                        int thisNumericChunk = int.Parse(str1);
                        int thatNumericChunk = int.Parse(str2);
                        result = thisNumericChunk.CompareTo(thatNumericChunk);
                    }
                    else
                    {
                        result = String.Compare(str1, str2, StringComparison.Ordinal);
                    }

                    if (result != 0)
                    {
                        return result;
                    }
                }
                return len1 - len2;
            }
        }

        private void ConnectionTestTimer_Tick(object sender, EventArgs e)
        {
            TestConnectionButton.Text = "Test connection";
            TestConnectionButton.Enabled = true;
            MessageBox.Show("Can not connect!");
            ConnectionTestTimer.Stop();
            _comPort.Close();
        }
    }
}
