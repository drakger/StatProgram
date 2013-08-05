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
        private const int NET_TIMER_UPDATE = 1000;
        private const int NETCHECK_TIMER_UPDATE = 60000;
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
            bytesSent = totalBytesSent - gbSent * 1024 * 1024 * 1024 - mbSent * 1024 * 1024 - kbSent * 1024;
            while (bytesSent > 1024)
            {
                bytesSent -= 1024;
                kbSent++;
                if (kbSent == 1024)
                {
                    kbSent -= 1024;
                    mbSent++;
                    if (mbSent == 1024)
                    {
                        mbSent -= 1024;
                        gbSent++;
                    }
                }
            }

            if (gbSent > 0)
                setDataSentType("Gb");
            else if (mbSent > 0)
                setDataSentType("Mb");
            else if (kbSent > 0)
                setDataSentType("kb");

          /*  if (totalBytesSent > (1024))
            {
                if (totalBytesSent > (1024 * 1024))
                {
                    if (totalBytesSent > (1024 * 1024 * 1024))
                    {
                        setDataSentType("Gb");
                    }
                    else
                        setDataSentType("Mb");
                }
                else
                    setDataSentType("kb");
            }
            if (getDataSentType() == "byte")
                dataSent = totalBytesSent;
            else if (getDataSentType() == "kb")
                dataSent = totalBytesSent / 1024;
            else if (getDataSentType() == "Mb")
                dataSent = totalBytesSent / 1024 / 1024;
            else if (getDataSentType() == "Gb")
                dataSent = totalBytesSent / 1024 / 1024 / 1024; */
        }

        private void setDataReceived(long n1, long n2)
        {
            totalBytesReceived = (n1 - n2);
            bytesReceived = totalBytesReceived - gbReceived * 1024 * 1024 * 1024 - mbReceived * 1024 * 1024 - kbReceived * 1024;
            while (bytesReceived > 1024)
            {
                bytesReceived -= 1024;
                kbReceived++;
                if (kbReceived == 1024)
                {
                    kbReceived -= 1024;
                    mbReceived++;
                    if (mbReceived == 1024)
                    {
                        mbReceived -= 1024;
                        gbReceived++;
                    }
                }
            }

            if (gbReceived > 0)
                setDataReceivedType("Gb");
            else if (mbReceived > 0)
                setDataReceivedType("Mb");
            else if (kbReceived > 0)
                setDataReceivedType("kb");

           /* totalBytesReceived = (n1 - n2);
            if (totalBytesReceived > (1024))
            {
                if (totalBytesReceived > (1024 * 1024))
                {
                    if (totalBytesReceived > (1024 * 1024 * 1024))
                        setDataReceivedType("Gb");
                    else
                        setDataReceivedType("Mb");
                }
                else
                    setDataReceivedType("kb");
            }
            if (getDataReceivedType() == "byte")
                dataReceived = totalBytesReceived;
            else if (getDataReceivedType() == "kb")
                dataReceived = totalBytesReceived / 1024;
            else if (getDataReceivedType() == "Mb")
                dataReceived = totalBytesReceived / 1024 / 1024;
            else if (getDataReceivedType() == "Gb")
                dataReceived = totalBytesReceived / 1024 / 1024 / 1024;*/
        }

        public string getDataSent()
        {
            string mbSentPercentage, kbSentPercentage, byteSentPercentage;
            if (getDataSentType() == "Gb")
            {
                if (Math.Round(mbSent / 1024.0 * 100) < 10)
                    mbSentPercentage = "0" + Math.Round(mbSent / 1024.0 * 100);
                else if (Math.Round(mbSent / 1024.0 * 100) == 100)
                    mbSentPercentage = "99";
                else 
                    mbSentPercentage = Math.Round(mbSent / 1024.0 * 100).ToString();
                return gbSent.ToString() + "." + mbSentPercentage;
            }
            else if (getDataSentType() == "Mb")
            {
                if (Math.Round(kbSent / 1024.0 * 100) < 10)
                    kbSentPercentage = "0" + Math.Round(kbSent / 1024.0 * 100);
                else if (Math.Round(kbSent / 1024.0 * 100) == 100)
                    kbSentPercentage = "99";
                else 
                    kbSentPercentage = Math.Round(kbSent / 1024.0 * 100).ToString();
                return mbSent.ToString() + "." + kbSentPercentage;
            }
            else if (getDataSentType() == "kb")
            {
                if (Math.Round(bytesSent / 1024.0 * 100) <10)
                    byteSentPercentage = "0" + Math.Round(bytesSent / 1024.0 * 100);
                else if (Math.Round(bytesSent / 1024.0 * 100) == 100)
                    byteSentPercentage = "99";
                else 
                    byteSentPercentage = Math.Round(bytesSent / 1024.0 * 100).ToString();
                return kbSent.ToString() + "." + byteSentPercentage;
            }

            else return bytesSent.ToString();
        }

        public string getDataReceived()
        {
            string mbReceivedPercentage, kbReceivedPercentage, byteReceivedPercentage;
            if (getDataReceivedType() == "Gb")
            {
                if (Math.Round(mbReceived / 1024.0 * 100) < 10)
                    mbReceivedPercentage = "0" + Math.Round(mbReceived / 1024.0 * 100);
                else if (Math.Round(mbReceived / 1024.0 * 100) == 100)
                    mbReceivedPercentage = "99";
                else 
                    mbReceivedPercentage = Math.Round(mbReceived / 1024.0 * 100).ToString();
                return gbReceived.ToString() + "." + mbReceivedPercentage;
            }
            else if (getDataReceivedType() == "Mb")
            {
                if (Math.Round(kbReceived / 1024.0 * 100) < 10)
                    kbReceivedPercentage = "0" + Math.Round(kbReceived / 1024.0 * 100);
                else if (Math.Round(kbReceived / 1024.0 * 100) == 100)
                    kbReceivedPercentage = "99";
                else 
                    kbReceivedPercentage = Math.Round(kbReceived / 1024.0 * 100).ToString();
                return mbReceived.ToString() + "." + kbReceivedPercentage;
            }
            else if (getDataReceivedType() == "kb")
            {
                if (Math.Round(bytesReceived / 1024.0 * 100) < 10)
                    byteReceivedPercentage = "0" + Math.Round(bytesReceived / 1024.0 * 100);
                else if (Math.Round(bytesReceived / 1024.0 * 100) == 100)
                    byteReceivedPercentage = "99";
                else 
                    byteReceivedPercentage = Math.Round(bytesReceived / 1024.0 * 100).ToString();
                return kbReceived.ToString() + "." + byteReceivedPercentage;
            }
            else return bytesReceived.ToString();
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
