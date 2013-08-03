using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace StatProgramProject
{
    public partial class MainForm:Form
    {
        private const double UPTIME_TIMER_UPDATE = 1000;
        private Timer uptimeTimer;
        long totalSeconds = 0;
        int weeks = 0, days = 0, hours = 0, minutes = 0, seconds = 0;

        void uptimeTimer_Tick(object sender, EventArgs e)
        {
            updateUptime();
        }

        public long getUptime()
        {
            return totalSeconds;
        }

        private void setUptime(long i)
        {
            totalSeconds = i;
        }

        public void updateUptime()
        {
            totalSeconds++;
            seconds++;
            if (seconds == 60)
            {
                seconds -= 60;
                minutes++;
                if (minutes == 60)
                {
                    minutes -= 60;
                    hours++;
                    if (hours == 24)
                    {
                        hours -= 24;
                        days++;
                        if (days == 7)
                        {
                            days -= 7;
                            weeks++;
                        }
                    }
                }
            }
            if (weeks > 0)
                lblUptime.Text = weeks.ToString() + "w " + days.ToString() + "d " + hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
            else if (days > 0)
                lblUptime.Text = days.ToString() + "d " + hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
            else if (hours > 0)
                lblUptime.Text = hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
            else if (minutes > 0)
                lblUptime.Text = minutes.ToString() + "m " + seconds.ToString() + "s";
            else
                lblUptime.Text = seconds.ToString() + "s";
        }
    }
}
