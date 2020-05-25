using Credit_Card_OCR.Pages;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Credit_Card_OCR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Mat object to hold image that is taken
        public static Mat img = new Mat();

        //Bool variables to help with the flow of the algorithm
        bool isStream = false;
        bool isImageLoaded = false;

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //Set bool variable to use camera image
            isStream = true;

            //Create a new object for the page
            CameraPage camera = new CameraPage();

            btnCapture.IsEnabled = true;
            btnOCR.IsEnabled = false;

            //Navigate to the new page
            frame.NavigationService.Navigate(camera);
        }

        private void btnOCR_Click(object sender, RoutedEventArgs e)
        {
            if (isImageLoaded == true)
            {
                //If a video stream is currently happening, do the following, else do the last
                if (isStream == true)
                {
                    //Align the video capture image
                    img = AutoAlignment.Align(img);

                    Bitmap bit = img.ToBitmap();

                    //Pass the bitmap image to be displayed
                    imgOutput.Source = ImageUtils.ImageSourceFromBitmap(bit);
                }
                else
                {
                    //Read in the desired image
                    img = OCR.ReadInImage();

                    //Convert the image to a bitmap, then to an image source
                    Bitmap bit = img.ToBitmap();
                    imgOutput.Source = ImageUtils.ImageSourceFromBitmap(bit);
                }

                //Detect the text from the image
                string detectedText = OCR.RecognizeText(img);

                //Create a new list for the output
                List<string> output = new List<string>();

                //Add the detected string to the list
                output.Add(detectedText);

                //Display the list
                lstOutput.ItemsSource = output;
            }
            else
            {
                System.Windows.MessageBox.Show("Please take or import an image");
            }
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            //Create a string to hold the file location
            string fileLocation = string.Empty;

            //Create an openfiledialog object to select a photo
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Images",

                CheckFileExists = true,
                CheckPathExists = true,

                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            //If a photo is selected, do the following
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Get the file location of the photo selected
                fileLocation = dialog.FileName;

                //If the length is greater than one, then use it to read in the image
                if (fileLocation.Length > 1)
                {
                    //Read in the image
                    img = CvInvoke.Imread(fileLocation, ImreadModes.AnyColor);
                }
            }

            //If the file location is greater than one, pass the loaded in image to be displayed
            if (fileLocation.Length > 1)
            {
                //Convert the image to a bitmap, then to an image source
                Bitmap bit = img.ToBitmap();
                imgOutput.Source = ImageUtils.ImageSourceFromBitmap(bit);

                //Declare the bool variable that an image has been loaded
                isImageLoaded = true;
            }
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            CameraPage cameraPage = new CameraPage();

            Bitmap taken = cameraPage.GenerateTakenImage();

            if (taken != null)
            {
                imgOutput.Source = ImageUtils.ImageSourceFromBitmap(taken);
            }

            //Declare that image is used
            isImageLoaded = true;

            //Clear the frame
            frame.Content = null;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //Clear the image
            imgOutput.Source = null;

            //Clear the frame
            frame.Content = null;

            //Empty the list box
            if (lstOutput.Items.Count > 0)
            {
                lstOutput.ItemsSource = null;
            }

            //Set both bool variables to false
            isImageLoaded = false;
            isStream = false;

            //Disable capture button
            btnCapture.IsEnabled = false;
            btnOCR.IsEnabled = true;
        }
    }
}