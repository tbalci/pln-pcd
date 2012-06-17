//----------------------------------------------------------------------------
//  Copyright (C) 2004-2011 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;

using System.Diagnostics;

namespace WattHourRecognition
{
   public partial class WattHourRecognitionForm : Form
   {
      private WattHourDetector _WattHourDetector;
      //class ProcessedImage
      //{
      //    public Image<Gray, byte> image1 { get; set; }
      //    public Image<Bgr, byte> image2 { get; set; }
      //    public Image<Bgr, byte> image3 { get; set; }
      //    public List<String> wattHour { get; set; }
      //}

      public WattHourRecognitionForm()
      {
         InitializeComponent();
         _WattHourDetector = new WattHourDetector();

         //ProcessImage(new Image<Bgr, byte>("license-wattHour.jpg"));
      }

      private void ProcessImage(Image<Bgr, byte> image)
      {
         Stopwatch watch = Stopwatch.StartNew(); // time the detection process

         List<Image<Gray, Byte>> wattHourImagesList = new List<Image<Gray, byte>>();
         List<Image<Gray, Byte>> filteredWattHourImagesList = new List<Image<Gray, byte>>();
         List<MCvBox2D> wattHourBoxList = new List<MCvBox2D>();
        // List<string> words = _WattHourDetector.DetectWattHour(
         
         ProcessedImage processedImage = _WattHourDetector.DetectWattHour(
            image,
            wattHourImagesList,
            filteredWattHourImagesList,
            wattHourBoxList);
         List<string> words = processedImage.wattHour;
         watch.Stop(); //stop the timer
         processTimeLabel.Text = String.Format("Watt Hour Recognition time: {0} milli-seconds", watch.Elapsed.TotalMilliseconds);

         panel1.Controls.Clear();
         Image<Bgr, byte> imageMarked = image.Clone();
         Point startPoint = new Point(10, 10);

         for (int i = 0; i < words.Count; i++)
         {
             AddLabelAndImage(
                ref startPoint,
                String.Format("Watt Hour: {0}", words[i].Trim()),
                wattHourImagesList[i].ConcateVertical(filteredWattHourImagesList[i]));
             imageMarked.Draw(wattHourBoxList[i], new Bgr(Color.Red), 2);
         }
         imageBox1.Image = image;
         imageBox2.Image = processedImage.image1;
         imageBox3.Image = processedImage.image1.Canny(new Gray(100), new Gray(50));
         imageBox4.Image = imageMarked;
      }

      private void AddLabelAndImage(ref Point startPoint, String labelText, IImage image)
      {
         Label label = new Label();
         panel1.Controls.Add(label);
         label.Text = labelText;
         label.Width = 200;
         label.Height = 100;
         label.Location = startPoint;
         startPoint.Y += label.Height;

         ImageBox box = new ImageBox();
         panel1.Controls.Add(box);
         box.ClientSize = image.Size;
         box.Image = image;
         box.Location = startPoint;
         startPoint.Y += box.Height + 10;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         DialogResult result = openFileDialog1.ShowDialog();
         if (result == DialogResult.OK)
         {
            Image<Bgr, Byte> img;
            try
            {
               img = new Image<Bgr, byte>(openFileDialog1.FileName);
               imageBox1.Image = img;
            }
            catch
            {
               MessageBox.Show(String.Format("Invalide File: {0}", openFileDialog1.FileName));
               return;
            }
            ProcessImage(img);
         }
      }

      private void panel1_Paint(object sender, PaintEventArgs e)
      {

      }

      private void imageBox1_Click(object sender, EventArgs e)
      {

      }

      private void LicensePlateRecognitionForm_Load(object sender, EventArgs e)
      {

      }

      private void imageBox2_Click(object sender, EventArgs e)
      {

      }
   }

}