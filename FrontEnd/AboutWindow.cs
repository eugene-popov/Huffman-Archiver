using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class AboutWindow : Form
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void AboutWindow_Load(object sender, EventArgs e)
        {
            var link = new LinkLabel.Link();
            link.LinkData = "https://www.flaticon.com/authors/smashicons";
            linkLabel1.Links.Add(link);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start((string) e.Link.LinkData);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }
    }
}