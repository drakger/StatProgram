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
        private const double NETCHECK_TIMER_UPDATE = 60000;
        private Timer netTimer;
        private Timer netcheckTimer;
        long bytesSentAtStartUp, bytesReceivedAtStartUp;
        bool startUp = true;
        bool reMaximized = false;
        protected string netUpSpeedType = "byte/s";
        protected string netDownSpeedType = "byte/s";
        protected long totalBytesSent, totalBytesReceived, bytesSent, bytesReceived, netUpSpeed, netDownSpeed;
        protected int gbSent, mbSent, kbSent, gbReceived, mbReceived, kbReceived;
        protected string dataSentType = "byte";
        protected string dataReceivedType = "byte";
        private const double KB_FROM_BYTES = 1024;
        private const double MB_FROM_BYTES = KB_FROM_BYTES * 1024;
        private const double GB_FROM_BYTES = MB_FROM_BYTES * 1024;

        //The minimum speed required. Passing 0 will not filter connection using speed.

        public static bool IsNetworkAvailable()
        {
            Ping ping = new Ping();
            try
            {
                PingReply pingStatus = ping.Send("google.com");
                if (pingStatus.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }    
        }

        public void netcheckTimer_Tick(object sender, EventArgs e)
        {
            netavailable();
        }

        public void netavailable()
        {
            if (!isMinimized())
            {
                if (IsNetworkAvailable())
                {
                    picNetAvailable.ImageLocation = @"yesinternet.png";
                }
                else
                {
                    picNetAvailable.ImageLocation = @"nointernet.png";
                }
            }
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

        private void setNetDownSpeed(long n)
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

        private void setNetUpSpeed(long n)
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

        public long getNetDownSpeed()
        {
            return netDownSpeed;
        }

        public long getNetUpSpeed()
        {
            return netUpSpeed;
        }

        private void setDataSent(long n1, long n2)
        {
            totalBytesSent = (n1 - n2);
            gbSent = (int)(totalBytesSent / GB_FROM_BYTES);
            mbSent = (int)(totalBytesSent % GB_FROM_BYTES / MB_FROM_BYTES);
            kbSent = (int)(totalBytesSent % MB_FROM_BYTES / KB_FROM_BYTES);
            bytesSent = (int)(totalBytesSent % KB_FROM_BYTES);

            /*if (gbSent > 0 && getDataSentType() != "Gb")
                setDataSentType("Gb");
            else if (mbSent > 0 && getDataSentType() != "Mb" && getDataSentType() != "Gb")
                setDataSentType("Mb");
            else if (kbSent > 0 && getDataSentType() != "kb" && getDataSentType() != "Mb" && getDataSentType() != "Gb")
                setDataSentType("kb");*/

            if (gbSent > 0)
                setDataSentType("Gb");
            else if (mbSent > 0)
                setDataSentType("Mb");
            else if (kbSent > 0)
                setDataSentType("kb");
        }

        private void setDataReceived(long n1, long n2)
        {
            totalBytesReceived = (n1 - n2);
            gbReceived = (int)(totalBytesReceived / GB_FROM_BYTES);
            mbReceived = (int)(totalBytesReceived % GB_FROM_BYTES / MB_FROM_BYTES);
            kbReceived = (int)(totalBytesReceived % MB_FROM_BYTES / KB_FROM_BYTES);
            bytesReceived = (int)(totalBytesReceived % KB_FROM_BYTES);

            /*if (gbReceived > 0 && getDataReceivedType() != "Gb")
                setDataReceivedType("Gb");
            else if (mbReceived > 0 && getDataReceivedType() != "Mb" && getDataReceivedType() != "Gb")
                setDataReceivedType("Mb");
            else if (kbReceived > 0 && getDataReceivedType() != "kb" && getDataReceivedType() != "Mb" && getDataReceivedType() != "Gb")
                setDataReceivedType("kb");*/

            if (gbReceived > 0)
                setDataReceivedType("Gb");
            else if (mbReceived > 0)
                setDataReceivedType("Mb");
            else if (kbReceived > 0)
                setDataReceivedType("kb");   
        }

        public string getDataSent()
        {
            if (getDataSentType() == "Gb")
                return String.Format("{0:0.00}", (gbSent + mbSent / KB_FROM_BYTES));
            if (getDataSentType() == "Mb")
                return String.Format("{0:0.00}", (mbSent + kbSent / KB_FROM_BYTES));
            if (getDataSentType() == "kb")
                return String.Format("{0:0.00}", (kbSent + bytesSent / KB_FROM_BYTES));
            else 
                return bytesSent.ToString();
        }

        public string getDataReceived()
        {
            if (getDataReceivedType() == "Gb")
                return String.Format("{0:0.00}", (gbReceived + mbReceived / KB_FROM_BYTES));
            if (getDataReceivedType() == "Mb")
                return String.Format("{0:0.00}", (mbReceived + kbReceived / KB_FROM_BYTES));
            if (getDataReceivedType() == "kb")
                return String.Format("{0:0.00}", (kbReceived + bytesReceived / KB_FROM_BYTES));
            else
                return bytesReceived.ToString();
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
                    int bytesSentSpeed = (int)(interfaceStats.BytesSent - bytesSentAtStartUp - totalBytesSent);
                    int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - bytesReceivedAtStartUp - totalBytesReceived);
                    setNetUpSpeed(bytesSentSpeed);
                    setNetDownSpeed(bytesReceivedSpeed);
                }
                lblUpSpeedCount.Text = getNetUpSpeed().ToString() + " " + getNetUpSpeedType();
                lblDownSpeedCount.Text = getNetDownSpeed().ToString() + " " + getNetDownSpeedType();

                // Display traffic that happened since the program was started
                setDataSent(interfaceStats.BytesSent, bytesSentAtStartUp);
                setDataReceived(interfaceStats.BytesReceived, bytesReceivedAtStartUp);
                lblDataSentCount.Text = getDataSent() + " " + getDataSentType();
                lblDataReceivedCount.Text = getDataReceived() + " " + getDataReceivedType();
                if (reMaximized) reMaximized = false;

            }
            string notifyicontext = "Download Speed: " + getNetDownSpeed().ToString() + " " + getNetDownSpeedType() + " Upload Speed: " + getNetUpSpeed().ToString() + " " + getNetUpSpeedType() +
                "\n" + "Downloaded: " + getDataReceived().ToString() + " " + getDataReceivedType() + " Uploaded: " + getDataSent().ToString() + " " + getDataSentType();
            SetNotifyIconText(notifyIcon1, notifyicontext);  
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
