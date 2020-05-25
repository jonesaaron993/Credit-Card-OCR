using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Credit_Card_OCR.Pages
{
    /// <summary>
    /// Interaction logic for CameraPage.xaml
    /// </summary>
    public partial class CameraPage : Page
    {
        //The video capture stream that holds the video from the camera
        public VideoCapture stream = new VideoCapture(0);

        public CameraPage()
        {
            InitializeComponent();

            //Start grabbing frames from the webcame input
            stream.ImageGrabbed += Capture_ImageGrabbed1;
            stream.Start();
        }

        public Bitmap GenerateTakenImage()
        {
            //Get the taken picture from the video stream
            Image<Bgr, byte> inputImg = CameraConfig.TakePicture(stream);

            //Convert the image to a bitmap
            Bitmap bit = inputImg.ToBitmap();

            return bit;
        }

        private void Capture_ImageGrabbed1(object sender, EventArgs e)
        {
            //Get the frame
            Bitmap frame = CameraConfig.GetFrame(stream);

            //Try catch block to successfuly terminate the thread
            try
            {
                //Pass each frame from the video capture to the output image
                this.Dispatcher.Invoke(() =>
                {
                    webcamOutput.Source = ImageUtils.ImageSourceFromBitmap(frame);
                });
            }
            catch (System.Threading.Tasks.TaskCanceledException)
            {
                //End the thread if its exited early
                this.Dispatcher.InvokeShutdown();
            }
        }
    }
}