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

            //Check if the frame taken is null
            //if it is, that means that no camera is connected,
            //so output that to the user and end the subscription
            if (frame == null)
            {
                MessageBox.Show("There is no camera connected");
                stream.ImageGrabbed -= Capture_ImageGrabbed1;
            }
            else
            {
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

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            //Start grabbing frames from the webcam input
            stream.ImageGrabbed += Capture_ImageGrabbed1;
            stream.Start();
        }
    }
}
