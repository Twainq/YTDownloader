using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using YoutubeExtractor;

namespace YTDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Download();
        }
        void Download()
        {
            try
            {
                var youTube = YouTube.Default;
                var video = youTube.GetVideo(txtUrl.Text);
                File.WriteAllBytes(@"" + txtPath.Text + video.FullName, video.GetBytes());
                Check(@"" + txtPath.Text + video.FullName);
            }catch (Exception ex)
            {
                MessageBox.Show("Ops! Error... Enter a correct url");
            }
        }

        void Check(string txtUrl)
        {
            if (File.Exists(txtUrl))
            {
                MessageBox.Show("Download been finished");
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

    }
}
