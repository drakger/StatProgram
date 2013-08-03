using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace StatProgramProject
{

    public partial class MainForm: Form
    {
        IPv4InterfaceStatistics interfaceStats = NetworkInterface.GetAllNetworkInterfaces()[0].GetIPv4Statistics();
        private NetworkInterface[] nicArr;
        private const double NET_TIMER_UPDATE = 1000;
        private Timer netTimer;
        long bytesSentAtStartUp, bytesReceivedAtStartUp;
        bool startUp = true;
        bool reMaximized = false;
        protected string netUpSpeedType = "byte/s";
        protected string netDownSpeedType = "byte/s";
        protected int netUpSpeed, netDownSpeed, dataSent, dataReceived;
        protected long bytesSent, bytesReceived;
        protected string dataSentType = "byte";
        protected string dataReceivedType = "byte";
 
        public static bool IsNetworkAvailable()
        {
            return IsNetworkAvailable(0);
            //Filter connections below a specified speed, as well as virtual network cards.
            //true if a network connection is available; otherwise, <c>false</c>.
        }

        //The minimum speed required. Passing 0 will not filter connection using speed.
        public static bool IsNetworkAvailable(long minimumSpeed)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return false;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // discard because of standard reasons
                if ((ni.OperationalStatus != OperationalStatus.Up) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                    continue;

                // this allow to filter modems, serial, etc.
                // I use 10000000 as a minimum speed for most cases
                if (ni.Speed < minimumSpeed)
                    continue;

                // discard virtual cards (virtual box, virtual pc, etc.)
                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                    continue;

                // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                    continue;

                return true;
            }
            return false;
        }

        void netTimer_Tick(object sender, EventArgs e)
        {
            updateNetStats();
        }
        private void InitializeNetworkInterface()
        {
            // Grab all local interfaces to this computer
            nicArr = NetworkInterface.GetAllNetworkInterfaces();
        }

        private void setNetDownSpeedType(string s)
        {
            netDownSpeedType = s;
        }

        private void setNetUpSpeedType(string s)
        {
            netUpSpeedType = s;
        }

        public string getNetDownSpeedType()
        {
            return netDownSpeedType;
        }

        public string getNetUpSpeedType()
        {
            return netUpSpeedType;
        }

        private void setNetDownSpeed(int n)
        {
            if (n > 1024)
            {
                if ((n / 1024) > 1024)
                {
                    if ((n / 1024 / 1024) > 1024)
                    {
                        netDownSpeed = n / 1024 / 1024 / 1024;
                        setNetDownSpeedType("Gb/s");
                        return;
                    }
                    netDownSpeed = n / 1024 / 1024;
                    setNetDownSpeedType("Mb/s");
                    return;
                }
                netDownSpeed = n / 1024;
                setNetDownSpeedType("kb/s");
                return;
            }
            netDownSpeed = n;
            setNetDownSpeedType("byte/s");
        }

        private void setNetUpSpeed(int n)
        {
            if (n > 1024)
            {
                if ((n / 1024) > 1024)
                {
                    if ((n / 1024 / 1024) > 1024)
                    {
                        netUpSpeed = n / 1024 / 1024 / 1024;
                        setNetUpSpeedType("Gb/s");
                        return;
                    }
                    netUpSpeed = n / 1024 / 1024;
                    setNetUpSpeedType("Mb/s");
                    return;
                }
                netUpSpeed = n / 1024;
                setNetUpSpeedType("kb/s");
                return;
            }
            netUpSpeed = n;
            setNetUpSpeedType("byte/s");
        }

        public int getNetDownSpeed()
        {
            return netDownSpeed;
        }

        public int getNetUpSpeed()
        {
            return netUpSpeed;
        }

        private void setDataSent(long n1, long n2)
        {
            bytesSent = (n1 - n2);
            if (bytesSent > (1024))
            {
                if (bytesSent > (1024 * 1024))
                {
                    if (bytesSent > (1024 * 1024 * 1024))
                        setDataSentType("Gb");
                    else
                        setDataSentType("Mb");
                }
                else
                    setDataSentType("kb");
            }
            if (getDataSentType() == "byte")
                dataSent = (int)bytesSent;
            else if (getDataSentType() == "kb")
                dataSent = (int)bytesSent / 1024;
            else if (getDataSentType() == "Mb")
                dataSent = (int)bytesSent / 1024 / 1024;
            else if (getDataSentType() == "Gb")
                dataSent = (int)bytesSent / 1024 / 1024 / 1024;
        }

        private void setDataReceived(long n1, long n2)
        {
            bytesReceived = (n1 - n2);
            if (bytesReceived > (1024))
            {
                if (bytesReceived > (1024 * 1024))
                {
                    if (bytesReceived > (1024 * 1024 * 1024))
                        setDataReceivedType("Gb");
                    else
                        setDataReceivedType("Mb");
                }
                else
                    setDataReceivedType("kb");
            }
            if (getDataReceivedType() == "byte")
                dataReceived = (int)bytesReceived;
            else if (getDataReceivedType() == "kb")
                dataReceived = (int)bytesReceived / 1024;
            else if (getDataReceivedType() == "Mb")
                dataReceived = (int)bytesReceived / 1024 / 1024;
            else if (getDataReceivedType() == "Gb")
                dataReceived = (int)bytesReceived / 1024 / 1024 / 1024;
        }

        public int getDataSent()
        {
            return dataSent;
        }

        public int getDataReceived()
        {
            return dataReceived;
        }

        private void setDataSentType(string s)
        {
            dataSentType = s;
        }

        private void setDataReceivedType(string s)
        {
            dataReceivedType = s;
        }

        public string getDataSentType()
        {
            return dataSentType;
        }

        public string getDataReceivedType()
        {
            return dataReceivedType;
        }
        public void updateNetStats()
        {
            if (!isMinimized())
            {
                // TO-DO: ADD CHOICES BETWEEN LOCAL INTERFACES http://www.m0interactive.com/archives/2008/02/06/how_to_calculate_network_bandwidth_speed_in_c_/
                // PERHAPS TO-DO: ADD BETTER TIMER http://www.m0interactive.com/archives/2006/12/21/high_resolution_timer_in_net_2_0.html
                // TO-DO: IF THE NUMBER REACHES A HIGH ENOUGH VALUE, CONVERT IT TO A BIGGER TYPE
                NetworkInterface nic = nicArr[0];
                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();

                // Get values of traffic at the program's startup
                if (startUp)
                {
                    bytesSentAtStartUp = interfaceStats.BytesSent;
                    bytesReceivedAtStartUp = interfaceStats.BytesReceived;
                    startUp = false;
                }

                // Calculate speed if there was already a change in traffic
                if (lblDataSentCount.Text != "0" && lblDataReceivedCount.Text != "0" && !reMaximized)
                {
                    int bytesSentSpeed = (int)(interfaceStats.BytesSent - bytesSentAtStartUp - bytesSent);
                    int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - bytesReceivedAtStartUp - bytesReceived);
                    setNetUpSpeed(bytesSentSpeed);
                    setNetDownSpeed(bytesReceivedSpeed);
                }
                lblUpSpeedCount.Text = getNetUpSpeed().ToString() + " " + getNetUpSpeedType();
                lblDownSpeedCount.Text = getNetDownSpeed().ToString() + " " + getNetDownSpeedType();

                // Display traffic that happened since the program was started
                setDataSent(interfaceStats.BytesSent, bytesSentAtStartUp);
                setDataReceived(interfaceStats.BytesReceived, bytesReceivedAtStartUp);
                lblDataSentCount.Text = getDataSent().ToString() + " " + getDataSentType();
                lblDataReceivedCount.Text = getDataReceived().ToString() + " " + getDataReceivedType();

                if (reMaximized) reMaximized = false;
            }
            string notifyicontext = "Download Speed: " + getNetDownSpeed().ToString() + " " + getNetDownSpeedType() + " Upload Speed: " + getNetUpSpeed().ToString() + " " + getNetUpSpeedType() +
                "\n" + "Downloaded: " + getDataReceived().ToString() + " " + getDataReceivedType() + " Uploaded: " + getDataSent().ToString() + " " + getDataSentType();
            SetNotifyIconText(notifyIcon1, notifyicontext);
            if (IsNetworkAvailable(1000))
            {
                lblNetAvailable.Text = "ON";
            }
            else
            {
                lblNetAvailable.Text = "OFF";
            }
        }
        public static void SetNotifyIconText(NotifyIcon ni, string text)
        {
            if (text.Length >= 128) throw new ArgumentOutOfRangeException("Text limited to 127 characters");
            Type t = typeof(NotifyIcon);
            BindingFlags hidden = BindingFlags.NonPublic | BindingFlags.Instance;
            t.GetField("text", hidden).SetValue(ni, text);
            if ((bool)t.GetField("added", hidden).GetValue(ni))
                t.GetMethod("UpdateIcon", hidden).Invoke(ni, new object[] { true });
        }
    }
}
