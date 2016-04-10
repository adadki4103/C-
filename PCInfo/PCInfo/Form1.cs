// Author: Adam Adkins
// Created: 2-1-2016

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using EASendMailObjLib;


namespace PCInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        { InitializeComponent(); }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e){ }
        private void button1_Click(object sender, EventArgs e)
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            // Get Machine Name
            label5.Text = Environment.MachineName;
	        // Get Machine IP
            label6.Text = myIP;
            // Get Domain SITE Name
            label7.Text = Environment.GetEnvironmentVariable("SITE");
            // Get User Name
            label8.Text = Environment.UserName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userName = Environment.UserName;
            string machineName = Environment.MachineName;
            string hostName = Dns.GetHostName();
            string machineUserName = Environment.UserName;
            string machineIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            string machineSiteName = Environment.GetEnvironmentVariable("SITE");
            string machineMessage = Environment.NewLine + "Computer Name: " + machineName + Environment.NewLine + "IP: " + machineIP + Environment.NewLine + "Domain SITE Name: " + machineSiteName + Environment.NewLine + "User Name: " + machineUserName;
            string from = (machineName + "@ung.edu");
            string sub = (machineUserName + "'s PC Information.");
            string mchMsg = (machineMessage);
            // Email Receipient 
            string to = ("adadki4103@ung.edu");

            MailMessage msg = new MailMessage();
            msg.Subject = (machineUserName+"'s PC Information.");
            msg.Body = (machineMessage);
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.ung.edu";
            client.Port = 25;
            client.Send(from,to,sub,mchMsg);
            MessageBox.Show("Message Sent!","Thank You");
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = ("");
            label6.Text = ("");
            label7.Text = ("");
            label8.Text = ("");
            label9.Text = ("");
        }
    }
}
