using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Radiation_Logger
{
    public partial class About_Radiation_Logger : Form
    {
        public About_Radiation_Logger()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void About_Radiation_Logger_Load(object sender, EventArgs e)
        {
            var aboutLink = new LinkLabel.Link {LinkData = "http://radiohobbystore.com/"};
            linkLabel1.Links.Add(aboutLink);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
