using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using MouseKeyboardLibrary;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;   
using System.Security;
using System.Security.Cryptography;
using CAMCoF;
using LSL;

namespace SampleApplication
{
    public partial class UiCapturer : Form
    {

        MouseHook mouseHook = new MouseHook();
        KeyboardHook keyboardHook = new KeyboardHook();
        

        static string filePath;
        static string configFile;
        static string usernameString;
        static string dir;
        static IntPtr m_hhook;

      
        
        System.IO.StreamWriter file;
        Boolean captureStatus;
        WinEventDelegate winEventProc;
        
        NotifyIcon notifyIcon;

        liblsl.StreamInfo inf;
        liblsl.StreamOutlet outl;

        public UiCapturer()
        {

            

            InitializeComponent();
            dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            startNotifyIcon();
            captureStatus = false;

            

           

            filePath = System.IO.Path.Combine(dir, ".\\Records\\");
            configFile = System.IO.Path.Combine(dir, "config.xml");
            //usernameString = "";
            textBoxPassword.PasswordChar = '*';
            stop.Enabled = false;

            streamNameBox.Text = "test";
            chanelTBox.Text = "Markers";
            chanelCountBox.Text = "1";
            nstrateBox.Text ="0";
            sourceIDBox.Text = "mouse&&Keyboard";
            

            
            bool isExists = System.IO.Directory.Exists(filePath);
            if (!isExists) { 
                System.IO.Directory.CreateDirectory(filePath);
            
               configInit();
            }


           
        }

        private void startNotifyIcon()    {
            //icon rending
            notifyIcon = new NotifyIcon();
            string iconPath = System.IO.Path.Combine(dir, "task_bar.ico");
            notifyIcon.Icon = new Icon(iconPath);
            notifyIcon.Visible = true;
            // Handle the DoubleClick event to activate the form.
            notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);

        }
        private void configInit()
        {
            System.IO.StreamWriter file;
            file = new System.IO.StreamWriter(configFile);
            file.WriteLine("<Config>");
            file.WriteLine("<UserDB>");
            file.WriteLine("<Logged>none</Logged>");
            file.WriteLine("<UserRecords>");
            file.WriteLine("</UserRecords>");
            file.WriteLine("</UserDB>");
            file.WriteLine("</Config>");

            file.Close();

            
        
 

        }




        

        

        private void notifyIcon_Click(object Sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            
            //when cursor is in the taskbar
            bool cursorNotInBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if (this.WindowState == FormWindowState.Minimized && cursorNotInBar){
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
                this.Hide();
            }
        
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
            mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);
            mouseHook.MouseWheel += new MouseEventHandler(mouseHook_MouseWheel);

            keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
            keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);
            keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);


        }

        void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddKeyboardEvent(
                "KeyPress",
                "",
                e.KeyChar.ToString(),
                "",
                "",
                ""
                );
        }

        void keyboardHook_KeyUp(object sender, KeyEventArgs e)
        {
            AddKeyboardEvent(
                "KeyUp",
                e.KeyCode.ToString(),
                "",
                e.Shift.ToString(),
                e.Alt.ToString(),
                e.Control.ToString()
                );
        }

        void keyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            AddKeyboardEvent(
                "KeyDown",
                e.KeyCode.ToString(),
                "",
                e.Shift.ToString(),
                e.Alt.ToString(),
                e.Control.ToString()
                );
        }

        void mouseHook_MouseWheel(object sender, MouseEventArgs e)
        {
            AddMouseEvent(
                "MouseWheel",
                "",
                "",
                "",
                e.Delta.ToString()
                );
        }

        void mouseHook_MouseUp(object sender, MouseEventArgs e)
        {
            AddMouseEvent(
                "MouseUp",
                e.Button.ToString(),
                e.X.ToString(),
                e.Y.ToString(),
                ""
                );
        }

        void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {



            AddMouseEvent(
                "MouseDown",
                e.Button.ToString(),
                e.X.ToString(),
                e.Y.ToString(),
                ""
                );
        }

        void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            AddMouseEvent(
                "MouseMov",
                e.Button.ToString(),
                e.X.ToString(),
                e.Y.ToString(),
                ""
                );
        }

     

        void AddMouseEvent(string eventType, string button, string x, string y, string delta)
        {
            if (eventType.Equals("MouseMov"))
            {
                file.WriteLine("MOV," + getCurrentTimeMillis() + "," + button + "," + x + "," + y); //movimento
                string[] str = { "MOV," + getCurrentTimeMillis() + "," + button + "," + x + "," + y };
                outl.push_sample(str);

             
            }
            if (eventType.Equals("MouseDown"))
            {
                file.WriteLine("MD," + getCurrentTimeMillis() + "," + button + "," + x + "," + y);  //MOV,timestamp,button,X,Y
                string[] str = { "MD," + getCurrentTimeMillis() + "," + button + "," + x + "," + y };
                outl.push_sample(str);
            }
            if (eventType.Equals("MouseUp"))
            {
                file.WriteLine("MU," + getCurrentTimeMillis() + "," + button + "," + x + "," + y);  //MOV,timestamp,button,X,Y
                string[] str = { "MU," + getCurrentTimeMillis() + "," + button + "," + x + "," + y };
                outl.push_sample(str);
            }
            if (eventType.Equals("MouseWheel"))
            {
                file.WriteLine("MW," + getCurrentTimeMillis() + "," + delta);  //MOV,timestamp,button,X,Y
                string[] str = { "MW," + getCurrentTimeMillis() + "," + delta };
                outl.push_sample(str);
              
            }

        }

        void AddKeyboardEvent(string eventType, string keyCode, string keyChar, string shift, string alt, string control)
        {
            /* 
             */
               // if (eventType.Equals("KeyDown")) file.WriteLine("KD," + getCurrentTimeMillis() + "," + keyCode + "," + keyChar);
               // if (eventType.Equals("KeyUp")) file.WriteLine("KU," + getCurrentTimeMillis() + "," + keyCode + "," + keyChar);

            string key = keyChar + keyCode;
            // encrypted keycod 
            if (eventType.Equals("KeyDown"))
            {
                file.WriteLine("KD," + getCurrentTimeMillis() + "," + Encrypt(key));
                string[] str = { "KD," + getCurrentTimeMillis() + "," + Encrypt(key) };
                outl.push_sample(str);
            }
            if (eventType.Equals("KeyUp"))
            {
                file.WriteLine("KU," + getCurrentTimeMillis() + "," + Encrypt(key));
                string[] str = { "KU," + getCurrentTimeMillis() + "," + Encrypt(key) };
                outl.push_sample(str);
            }
        }

        private void TestForm_FormClosed(object sender, FormClosedEventArgs e)
        {   
            // Not necessary anymore, will stop when application exits
            //mouseHook.Stop();
            //keyboardHook.Stop();

        }

        private void username_Click(object sender, EventArgs e)
        {

        }


        long getCurrentTimeMillis()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

    

        private void start_Click(object sender, EventArgs e)
        {
            string user;
            string pw;
            if (captureStatus == true) MessageBox.Show("Capturer is already running!");
            else
            {
                try
                {
                    usernameString = username.Text;
                    user=usernameString;
                    pw=textBoxPassword.Text;
                    if (!User.login(usernameString,pw)) MessageBox.Show("Invalid username or password!");
                    else
                    {

                       
                        file = new System.IO.StreamWriter(filePath + "\\" + getCurrentTimeMillis() + "_" + usernameString + ".txt");
                        file.WriteLine("# user: " + usernameString + " #");
                        captureStatus = true;
                        mouseHook.Start();
                        keyboardHook.Start();
                        this.winEventProc = new WinEventDelegate(WinEventProc);
                        m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, this.winEventProc, 0, 0, WINEVENT_OUTOFCONTEXT);
                        start.Enabled = false;
                        stop.Enabled = true;
                        User.recordLogin(usernameString);
                        this.Hide();

                        inf = new liblsl.StreamInfo(streamNameBox.Text, chanelTBox.Text, Convert.ToInt32(chanelCountBox.Text), Convert.ToInt32(nstrateBox.Text), liblsl.channel_format_t.cf_string, sourceIDBox.Text);
                        outl = new liblsl.StreamOutlet(inf);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    captureStatus = false;
                }
            }
            
        }

        

        private void stop_Click(object sender, EventArgs e)
        {
            start.Enabled = true;
            stop.Enabled = false;
            if (captureStatus == false) MessageBox.Show("Capturer is not running!");
            else
            {
                file.Close();
                captureStatus = false;
                mouseHook.Stop();
                keyboardHook.Stop();
               
            }
        }




        // DES encrypting
        public static string Encrypt(string originalString)
        {

            byte[] bytes = ASCIIEncoding.ASCII.GetBytes("Z1R@Ci4l");

            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }



        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        const uint WINEVENT_OUTOFCONTEXT = 0;
        const uint EVENT_SYSTEM_FOREGROUND = 3;
        const uint EVENT_SYSTEM_CAPTURESTART = 8;
        const uint EVENT_SYSTEM_CAPTUREEND = 9;
        const uint EVENT_SYSTEM_SCROLLINGSTART = 18;
        const uint EVENT_SYSTEM_SCROLLINGSTEND = 19;
        const uint MOUSEEVENTF_FROMTOUCH = 0xFF515700;


        [DllImport("user32.dll")]
        static extern bool UnhookWinEvent(IntPtr hWinEventHook);
        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            //if (captureStatus)
            //{
                Console.WriteLine(eventType);

                if (eventType == MOUSEEVENTF_FROMTOUCH) Console.WriteLine("fdx!!!!");

                if (eventType == EVENT_SYSTEM_FOREGROUND)
                {
                    StringBuilder sb = new StringBuilder(500);
                    GetWindowText(hwnd, sb, sb.Capacity);
                    file.WriteLine("SW," + getCurrentTimeMillis() + "," + sb.ToString());
                  
                        string[] str = { "SW," + getCurrentTimeMillis() + "," + sb.ToString() };
                        outl.push_sample(str);
                   
                }

                if (eventType == EVENT_SYSTEM_CAPTURESTART)
                {
                    StringBuilder sb = new StringBuilder(500);
                    GetWindowText(hwnd, sb, sb.Capacity);
                    file.WriteLine("CS," + getCurrentTimeMillis() + "," + sb.ToString());
                }

                if (eventType == EVENT_SYSTEM_CAPTUREEND)
                {
                    StringBuilder sb = new StringBuilder(500);
                    GetWindowText(hwnd, sb, sb.Capacity);
                    file.WriteLine("CE," + getCurrentTimeMillis() + "," + sb.ToString());
                }
           // }
        }

        private void signUpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register rg = new Register();
            rg.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("©ISLab 2014\n All Rights Reserved No part of this software or any of its contents may be reproduced, copied, modified or adapted, without the prior written consent of the author, unless otherwise indicated for stand-alone materials");
        }

    }
}
