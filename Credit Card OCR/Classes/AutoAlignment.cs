using Emgu.CV;
using Emgu.CV.CvEnum;

namespace Credit_Card_OCR
{
    /// <summary>
    /// Align an image of a credit card for better OCR detection
    /// </summary>
    class AutoAlignment
    { 
        /// <summary>
        /// Get the image from a path
        /// </summary>
        /// <param name="path">The path to the image</param>
        /// <returns>A mat objefct</returns>
        public static Mat GetImage(string path)
        {
            Mat img = CvInvoke.Imread(path, ImreadModes.AnyColor);

            return img;
        }

        /// <summary>
        /// Align an image taken by the user for better OCR readability
        /// </summary>
        /// <param name="inputImage">The image taken with a camera</param>
        /// <returns>An aligned image</returns>
        public static Mat Align(Mat inputImage)
        {
            //Code for this feature will be implemented in v3.0

            //Return the found templete
            return inputImage;
        }
    }
}