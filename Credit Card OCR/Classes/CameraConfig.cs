using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;

namespace Credit_Card_OCR
{
    /// <summary>
    /// Class that handles all camera controls
    /// </summary>
    class CameraConfig
    {
        /// <summary>
        /// Get the frame of the current video stream
        /// </summary>
        /// <param name="stream">The videocapture stream that holds the video data</param>
        /// <returns>A bitmap image</returns>
        public static Bitmap GetFrame(VideoCapture stream)
        {
            //Mat object to hold each frame of the video stream
            Mat m = new Mat();

            //Get the frame
            stream.Retrieve(m);

            //Convert the frame into a bitmap
            Bitmap frame = m.ToBitmap();

            //Return the bitap
            return frame;
        }

        /// <summary>
        /// Take a picture with the video capture
        /// </summary>
        /// <param name="stream">The video capture stream</param>
        /// <returns>A frame of an image taken</returns>
        public static Image<Bgr, byte> TakePicture(VideoCapture stream)
        {
            //Pause the stream so an image can be taken
            stream.Pause();

            //Query the stream and get the latet fram as an image
            var inputImg = stream.QueryFrame().ToImage<Bgr, byte>();

            //Wait key so video stream can completly stop
            CvInvoke.WaitKey(100);

            //Return the image
            return inputImg;
        }
    }
}