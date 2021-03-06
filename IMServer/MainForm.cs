﻿using Fundation.Core;
using IMServer.custom;
using SocketCommunication.Cache;
using SocketCommunication.Error;
using SocketCommunication.TcpSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IMServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            TcpServer tcpserver = new TcpServer();

            tcpserver.OnError += new EventHandler<ErrorEventArgs>(socketErrorHandler);
            Console.WriteLine(TcpServer.GetServerIpString());
            tcpserver.StartListen(1005);
        }

        private void socketErrorHandler(object sender, ErrorEventArgs e)
        {
            
            ExtConsole.WriteWithColor(e.SocketException.ToString());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CustomConfig.GetSystemParameters();
            LogInterface.Listen(CustomConfig.LogDirectoryName.ToString());
            Console.Write(sizeof(int));
        }

        private void btnViewOnline_Click(object sender, EventArgs e)
        {
            CustomerCollector.ViewToConsole();
        }
    }
}
