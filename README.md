# CreditCardOCR

Created in C# using the wrapper of Opencv called Emgucv, this repo was created as a side project of mine to practice computer vison and character recognition.

**Important:** In order to successfully compile and run each solution, you **MUST** download and install the Emgu.CV.runtime.windows nuget package. If the error persists, just restart your IDE.

<p align="center">
  <img src="https://github.com/CodeBoiz/Credit-Card-OCR/blob/master/Credit%20Card%20OCR/Images/creditCard.png"/>
</p>

All contours found with bounding boxes created.

<p align="center">
  <img src="https://aaronsprogrammingblog.files.wordpress.com/2020/04/allboxesdrawn.png"/>
</p>

Bounding Boxes Sorted.

<p align="center">
  <img src="https://aaronsprogrammingblog.files.wordpress.com/2020/04/finalboxesdrawn.png"/>
</p>

The current GUI layout

<p align="center">
  <img src="https://aaronsprogrammingblog.files.wordpress.com/2020/07/mainwindow.png"/>
</p>

The output of the detected characters 

<p align="center">
  <img src="https://aaronsprogrammingblog.files.wordpress.com/2020/04/application.png"/>
</p>

**CURRENT STATE:** Added support for a camera and can take photo with the said camera.

**TODO:** Detect a credit card in a photo taken from the camera, and sort through the image to only include credit card numbers.


All code under the MIT Licence.
