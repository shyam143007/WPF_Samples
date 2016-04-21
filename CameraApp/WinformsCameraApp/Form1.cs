using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

namespace WinformsCameraApp
{
    public partial class Form1 : Form
    {
        VideoCaptureDevice webCam = null;
        FilterInfoCollection webCams = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webCams = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo cam in webCams)
            {
                cmbWebCams.Items.Add(cam.Name);
            }
            cmbWebCams.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webCam.IsRunning)
            {
                webCam.Stop();
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (webCam == null || !webCam.IsRunning)
            {
                webCam = new VideoCaptureDevice(webCams[cmbWebCams.SelectedIndex].MonikerString);
                webCam.NewFrame += WebCam_NewFrame;
                webCam.Start();
                pictureBox1.Image = null;
                pictureBox1.Invalidate();
            }
            else
            {
                webCam.NewFrame -= WebCam_NewFrame;
                webCam.Stop();
            }
        }

        private void WebCam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = eventArgs.Frame.Clone() as System.Drawing.Image;
        }
    }
}
