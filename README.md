# CreditCardOCR

Created in C# using the wrapper of Opencv called Emgucv, this repo was created as a side project of mine to practice computer vison and character recognition.

**Important:** In order to successfuly compile and run each solution, you **MUST** download and install the Emgu.CV.runtime.windows nuget package. If error persists, just restart your IDE.

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

The detected characters outputed.

<p align="center">
  <img src="https://aaronsprogrammingblog.files.wordpress.com/2020/04/application.png"/>
</p>

**CURRENT STATE:** Have added support for a camera and can take photo with the said camera.

**TODO:** Detect credit card in photo taken from camera, and sort through the image to only include credit card numbers.


All code under the MIT Licence.
