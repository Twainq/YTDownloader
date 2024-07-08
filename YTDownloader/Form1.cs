using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            string link = "https://www.youtube.com/watch?v=BF0uf7apZDQ";
            IEnumerable<VideoInfo> videos = DownloadUrlResolver.GetDownloadUrls(link);
            VideoInfo vi = videos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == Convert.ToInt32(360));
            if (vi.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(vi);

            }

            var videoDownload = new VideoDownloader(vi, "D:\\" + vi.Title + vi.VideoExtension);
            videoDownload.DownloadFinished += videoDownload_DownloadFinished;
            videoDownload.Execute();
        }

        void videoDownload_DownloadFinished(object s, EventArgs e)
        {
            MessageBox.Show("Download been finished");
        }
    }
}
