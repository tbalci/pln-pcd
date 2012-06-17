//----------------------------------------------------------------------------
//  Copyright (C) 2004-2011 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.Util;

namespace WattHourRecognition
{
   /// <summary>
   /// A simple license wattHour detector
   /// </summary>
    public class ProcessedImage
    {
        public Image<Gray, byte> image1 { get; set; }
        public Image<Bgr, byte> image2 { get; set; }
        public Image<Gray, byte> image3 { get; set; }
        public List<String> wattHour { get; set; }
    }
   public class WattHourDetector : DisposableObject
   {
       public ProcessedImage processedImage = new ProcessedImage();
       
      /// <summary>
      /// The OCR engine
      /// </summary>
      private Tesseract _ocr;

      /// <summary>
      /// Create a license wattHour detector
      /// </summary>
      public WattHourDetector()
      {
         //create OCR engine
         _ocr = new Tesseract("tessdata", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_ONLY);
         _ocr.SetVariable("tessedit_char_whitelist", "0123456789");
      }

      /// <summary>
      /// Compute the white pixel mask for the given image. 
      /// A white pixel is a pixel where:  satuation &lt; 40 AND value &gt; 200
      /// </summary>
      /// <param name="image">The color image to find white mask from</param>
      /// <returns>The white pixel mask</returns>
      private static Image<Gray, Byte> GetWhitePixelMask(Image<Bgr, byte> image)
      {
         using (Image<Hsv, Byte> hsv = image.Convert<Hsv, Byte>())
         {
            Image<Gray, Byte>[] channels = hsv.Split();

            try
            {
               //channels[1] is the mask for satuation less than 40, this is the mask for either white or black pixels
               channels[1]._ThresholdBinaryInv(new Gray(40), new Gray(255));

               //channels[2] is the mask for bright pixels
               channels[2]._ThresholdBinary(new Gray(200), new Gray(255));

               CvInvoke.cvAnd(channels[1], channels[2], channels[0], IntPtr.Zero);
            }
            finally
            {
               channels[1].Dispose();
               channels[2].Dispose();
            }
            return channels[0];
         }
      }

      /// <summary>
      /// Detect license wattHour from the given image
      /// </summary>
      /// <param name="img">The image to search license wattHour from</param>
      /// <param name="wattHourImagesList">A list of images where the detected license wattHour regions are stored</param>
      /// <param name="filteredWattHourImagesList">A list of images where the detected license wattHour regions (with noise removed) are stored</param>
      /// <param name="detectedWattHourRegionList">A list where the regions of license wattHour (defined by an MCvBox2D) are stored</param>
      /// <returns>The list of words for each license wattHour</returns>
      //public List<String> DetectWattHour(
      public ProcessedImage DetectWattHour(
         Image<Bgr, byte> img, 
         List<Image<Gray, Byte>> licensePlateImagesList, 
         List<Image<Gray, Byte>> filteredWattHourImagesList, 
         List<MCvBox2D> detectedWattHourRegionList)
      {
         List<String> wattHour = new List<String>();
         using (Image<Gray, byte> gray = img.Convert<Gray, Byte>())
         //using (Image<Gray, byte> gray = GetWhitePixelMask(img)) 

         //using (IntPtr canny = CvInvoke.cvCreateImage(gray.Size, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_16S, 1))
          using (Image<Gray, Byte> canny = new Image<Gray, byte>(gray.Size))
         //using (IntPtr image = CvInvoke.cvCreateImage(new System.Drawing.Size(400, 300), Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_16S, 1)) ;  
         using (
             MemStorage stor = new MemStorage()
             )
         {
     //        Image<Gray, byte> canny = CvInvoke.cvCreateImage(new System.Drawing.Size(400, 300), Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_16S, 1);
           // CvInvoke.cvCanny(gray, canny, 15, 30, 3);
           CvInvoke.cvCanny(gray, canny, 100, 50, 3);
           //CvInvoke.cvLaplace(gray, canny, 3);
             
            Contour<Point> contours = canny.FindContours(
                 Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                 Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE,
                 stor);
           // processedImage.image1 = img.Convert<Gray, Byte>();//ubah ke greyscale
            processedImage.image1 = img.Convert<Gray, Byte>();//ubah ke greyscale
            Image<Gray, Byte> kosong = new Image<Gray, byte>(gray.Size);
            CvInvoke.cvDrawContours(kosong, contours, new MCvScalar(255,0,0), new MCvScalar(0,255,0), 3, 1,  Emgu.CV.CvEnum.LINE_TYPE.CV_AA, new Point(0,0));
            //CvInvoke.cvShowImage("contours", kosong);
             //processedImage.image2 = canny;
            processedImage.wattHour = wattHour;
            FindWattHour(contours, gray, canny, licensePlateImagesList, filteredWattHourImagesList, detectedWattHourRegionList, wattHour);
         }

          //CvInvoke.cvMeanShift(processedImage.image1,)
         //CvInvoke.cvPyrMeanShiftFiltering(processedImage.image1, processedImage.image2, 20, 40, 2, new MCvTermCriteria { type = Emgu.CV.CvEnum.TERMCRIT.CV_TERMCRIT_EPS});
         processedImage.image2 = new Image<Bgr, Byte>(img.Size);
          //CvInvoke.cvPyrMeanShiftFiltering(img, processedImage.image2, 40, 20, 1, new MCvTermCriteria(5, 1));
          //return wattHour;
         return processedImage;
      }

      private static int GetNumberOfChildren(Contour<Point> contours)
      {
         Contour<Point> child = contours.VNext;
         if (child == null) return 0;
         int count = 0;
         while (child != null)
         {
            count++;
            child = child.HNext;
         }
         return count;
      }

      private void FindWattHour(
         Contour<Point> contours, Image<Gray, Byte> gray, Image<Gray, Byte> canny,
         List<Image<Gray, Byte>> wattHourImagesList, List<Image<Gray, Byte>> filteredWattHourImagesList, List<MCvBox2D> detectedWattHourRegionList,
         List<String> wattHour)
      {
         for (; contours != null; contours = contours.HNext)
         {
            int numberOfChildren = GetNumberOfChildren(contours);      
            //if it does not contains any children (charactor), it is not a license wattHour region
            if (numberOfChildren == 0) continue;

            if (contours.Area > 1000)
            {
                //wil
                //if (numberOfChildren < 3)
                //{
                //    //If the contour has less than 3 children, it is not a license wattHour (assuming license wattHour has at least 3 charactor)
                //    //However we should search the children of this contour to see if any of them is a license wattHour
                //    FindWattHour(contours.VNext, gray, canny, wattHourImagesList, filteredWattHourImagesList, detectedWattHourRegionList, wattHour);
                //    continue;
                //}

               MCvBox2D box = contours.GetMinAreaRect();
               if (box.angle < -45.0)
               {
                  float tmp = box.size.Width;
                  box.size.Width = box.size.Height;
                  box.size.Height = tmp;
                  box.angle += 90.0f;
               }
               else if (box.angle > 45.0)
               {
                  float tmp = box.size.Width;
                  box.size.Width = box.size.Height;
                  box.size.Height = tmp;
                  box.angle -= 90.0f;
               }

               double whRatio = (double)box.size.Width / box.size.Height;
             //  if (!(0.0 < whRatio && whRatio < 10.0))
               if (!(2.5 < whRatio && whRatio < 8.0))
               //if (!(2.5 < whRatio && whRatio < 3.0) && !(4.0 < whRatio && whRatio < 8.0))
               {  //if the width height ratio is not in the specific range,it is not a license wattHour 
                  //However we should search the children of this contour to see if any of them is a license wattHour
                  Contour<Point> child = contours.VNext;
                  if (child != null)
                     FindWattHour(child, gray, canny, wattHourImagesList, filteredWattHourImagesList, detectedWattHourRegionList, wattHour);
                  continue;
               }

               using (Image<Gray, Byte> tmp1 = gray.Copy(box))
               //resize the license wattHour such that the front is ~ 10-12. This size of front results in better accuracy from tesseract
               using (Image<Gray, Byte> tmp2 = tmp1.Resize(240, 180, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC, true))
               {
                  //removes some pixels from the edge
                  int edgePixelSize = 7;
                  tmp2.ROI = new Rectangle(new Point(edgePixelSize, edgePixelSize), tmp2.Size - new Size(2 * edgePixelSize, 2 * edgePixelSize));
                  Image<Gray, Byte> plate = tmp2.Copy();
//                 Image<Gray, Byte> wattHour = tmp1.Copy();

                 Image<Gray, Byte> filteredPlate = FilterWattHour(plate);

    //              Tesseract.Charactor[] words;
                  StringBuilder strBuilder = new StringBuilder();
                  using (Image<Gray, Byte> tmp = filteredPlate.Clone())
                 // using (Image<Gray, Byte> tmp = wattHour.Clone())
                  //using (Image<Gray, Byte> tmp = wattHour.Clone().ThresholdBinaryInv(new Gray(120), new Gray(255)))
                  {
                      //Image<Gray, Byte> plateMask = new Image<Gray, byte>(wattHour.Size);
                    //  tmp.SetValue(0,plateMask);
                      //tmp.Erode(1);
                      //tmp.Dilate(1);
                      _ocr.Recognize(tmp);
                    // words = _ocr.GetCharactors();
                     Gray drawColor = new Gray();

                     Tesseract.Charactor[] charactors = _ocr.GetCharactors();
                     foreach (Tesseract.Charactor c in charactors)
                     {
                         plate.Draw(c.Region, drawColor, 1);
                     }
                     //if (words.Length == 0) continue;

                     //for (int i = 0; i < words.Length; i++)
                     //{
                     //    strBuilder.Append(words[i].Text);
                     //}
                  }

                  //wattHour.Add(strBuilder.ToString());
                  wattHour.Add(_ocr.GetText());
                  wattHourImagesList.Add(plate);
                  filteredWattHourImagesList.Add(filteredPlate);
                  detectedWattHourRegionList.Add(box);

               }
            }
         }
      }

      /// <summary>
      /// Filter the license wattHour to remove noise
      /// </summary>
      /// <param name="wattHour">The license wattHour image</param>
      /// <returns>License wattHour image without the noise</returns>
      private static Image<Gray, Byte> FilterWattHour(Image<Gray, Byte> wattHour)
      {
         //Image<Gray, Byte> thresh = wattHour.ThresholdBinaryInv(new Gray(120), new Gray(255));
          Image<Gray, Byte> thresh = wattHour.ThresholdBinary(new Gray(120), new Gray(255));

         //using (Image<Gray, Byte> plateMask = new Image<Gray, byte>(wattHour.Size))
         //using (Image<Gray, Byte> plateCanny = wattHour.Canny(new Gray(100), new Gray(50)))
         //using (MemStorage stor = new MemStorage())
         //{
         //    //plateMask.SetValue(0.0);
         //    //for (
         //    //   Contour<Point> contours = plateCanny.FindContours(
         //    //      Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
         //    //      Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL,
         //    //      stor);
         //    //   contours != null;
         //    //   contours = contours.HNext)
         //    //{
         //    //    Rectangle rect = contours.BoundingRectangle;
         //    //    if (rect.Height > (wattHour.Height >> 1))
         //    //    {
         //    //        rect.X -= 1; rect.Y -= 1; rect.Width += 2; rect.Height += 2;
         //    //        rect.Intersect(wattHour.ROI);

         //    //        plateMask.Draw(rect, new Gray(0.0), -1);
         //    //    }
         //    //}

         //   // thresh.SetValue(0, plateMask);
         //}

       thresh._Erode(1);
       thresh._Dilate(1);

         return thresh;
      }

      protected override void DisposeObject()
      {
         _ocr.Dispose();
      }
   }
}
