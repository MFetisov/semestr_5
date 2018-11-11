using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

using System.Diagnostics;
using Emgu.CV.Util;

namespace LicensePlateRecognition
{
   public partial class LicensePlateRecognitionForm : Form
   {
      private LicensePlateDetector _licensePlateDetector;

      public LicensePlateRecognitionForm()
      {
         InitializeComponent();
         _licensePlateDetector = new LicensePlateDetector("");
         Mat m = new Mat("license-plate.jpg");
         UMat um = m.GetUMat(AccessType.ReadWrite);
         imageBox1.Image = um;
         ProcessImage(m);
      }

      private void ProcessImage(IInputOutputArray image)
      {
         Stopwatch watch = Stopwatch.StartNew(); // time the detection process

         List<IInputOutputArray> licensePlateImagesList = new List<IInputOutputArray>();
         List<IInputOutputArray> filteredLicensePlateImagesList = new List<IInputOutputArray>();
         List<RotatedRect> licenseBoxList = new List<RotatedRect>();
         List<string> words = _licensePlateDetector.DetectLicensePlate(
            image,
            licensePlateImagesList,
            filteredLicensePlateImagesList,
            licenseBoxList);

         watch.Stop(); //stop the timer
         processTimeLabel.Text = String.Format("¬рем€ распознавани€: {0} мили-секунды", watch.Elapsed.TotalMilliseconds);

         panel1.Controls.Clear();
         Point startPoint = new Point(10, 10);
         for (int i = 0; i < words.Count; i++)
         {
            Mat dest = new Mat();
            CvInvoke.VConcat(licensePlateImagesList[i], filteredLicensePlateImagesList[i], dest);
            AddLabelAndImage(
               ref startPoint,
               String.Format("Ќомер: {0}", words[i]),
               dest);
            PointF[] verticesF = licenseBoxList[i].GetVertices();
            Point[] vertices = Array.ConvertAll(verticesF, Point.Round);
            using(VectorOfPoint pts = new VectorOfPoint(vertices))
                CvInvoke.Polylines(image, pts, true, new Bgr(Color.Red).MCvScalar,2  );
            
         }

      }

      private void AddLabelAndImage(ref Point startPoint, String labelText, IImage image)
      {
         Label label = new Label();
         panel1.Controls.Add(label);
         label.Text = labelText;
         label.Width = 100;
         label.Height = 30;
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
            Mat img;
            try
            {
               img = CvInvoke.Imread(openFileDialog1.FileName);

            }
            catch
            {
               MessageBox.Show(String.Format("Ќеверный файл {0}", openFileDialog1.FileName));
               return;
            }
            
            UMat uImg = img.GetUMat(AccessType.ReadWrite);

            imageBox1.Image = uImg;
            textBox1.Text = openFileDialog1.FileName;
            ProcessImage(uImg);
         }
      }

        private void LicensePlateRecognitionForm_Load(object sender, EventArgs e)
        {
            StartForm f2 = new StartForm();
            if (!(f2.ShowDialog() == DialogResult.OK)) //форма2 будет открыта раньше, чем форма1
            {
                this.Close(); //если форма2 закроетс€ с неправильным диалогрезалтом, то программу закрываем
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "login" && textBox2.Text == "password") //провер€ем пароль
            this.DialogResult = DialogResult.OK; //в зависимости от результатов проверки устанавливаем DialogResult.OK 
                                                 //else
                                                 //this.DialogResult = DialogResult.Abort; //или DialogResult.Abort
            this.Close(); //и закрываем форму2
        }
    }

}