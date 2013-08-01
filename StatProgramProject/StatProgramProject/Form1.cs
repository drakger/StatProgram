using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        GlobalKeyboardHook kHook;

        public Form1()
        {
            InitializeComponent();
            kHook = new GlobalKeyboardHook();
            kHook.KeyUp += new KeyEventHandler(gHook_KeyUp);
            kHook.hook();
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                kHook.HookedKeys.Add(key);
            MouseHook.Start();
            MouseHook.MouseAction += new EventHandler(Mouse);
        }
        private void Mouse(object sender, EventArgs e)
        {
            vmi.lclick++;
            label1.Text = Convert.ToString(vmi.lclick);
        }
        public void gHook_KeyUp(object sender, KeyEventArgs e)
        {
            vmi.keys++;
            label2.Text = Convert.ToString(vmi.keys);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon1, null);
            }
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.Focus();
                this.TopMost = true;
                this.TopMost = false;
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vmi.exit = true;
            this.Close();
        }

        public static class vmi
        {
            public static int rclick;
            public static int lclick;
            public static int keys;
            public static bool exit;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vmi.exit == false)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                e.Cancel = true;
            }
        }
        public static class MouseHook
        {
            public static event EventHandler MouseAction = delegate { };

            public static void Start()
            {
                _hookID = SetHook(_proc);


            }
            public static void stop()
            {
                UnhookWindowsHookEx(_hookID);
            }

            private static LowLevelMouseProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;

            private static IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc,
                      GetModuleHandle(curModule.ModuleName), 0);
                }
            }

            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

            private static IntPtr HookCallback(
              int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    MouseAction(null, new EventArgs());
                }
                if (nCode >= 0 && MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    MouseAction(null, new EventArgs());
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }

            private const int WH_MOUSE_LL = 14;

            private enum MouseMessages
            {
                WM_LBUTTONDOWN = 0x0201,
                WM_LBUTTONUP = 0x0202,
                WM_MOUSEMOVE = 0x0200,
                WM_MOUSEWHEEL = 0x020A,
                WM_RBUTTONDOWN = 0x0204,
                WM_RBUTTONUP = 0x0205
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public int x;
                public int y;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public uint mouseData;
                public uint flags;
                public uint time;
                public IntPtr dwExtraInfo;
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook,
              LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
              IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);

        }
    }
}
