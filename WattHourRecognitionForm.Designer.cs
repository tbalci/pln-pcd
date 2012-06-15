namespace WattHourRecognition
{
   partial class WattHourRecognitionForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.panel1 = new System.Windows.Forms.Panel();
          this.imageBox4 = new Emgu.CV.UI.ImageBox();
          this.imageBox3 = new Emgu.CV.UI.ImageBox();
          this.imageBox2 = new Emgu.CV.UI.ImageBox();
          this.imageBox1 = new Emgu.CV.UI.ImageBox();
          this.panel2 = new System.Windows.Forms.Panel();
          this.processTimeLabel = new System.Windows.Forms.Label();
          this.informationLabel = new System.Windows.Forms.Label();
          this.textBox1 = new System.Windows.Forms.TextBox();
          this.button1 = new System.Windows.Forms.Button();
          this.label1 = new System.Windows.Forms.Label();
          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
          this.panel2.SuspendLayout();
          this.SuspendLayout();
          // 
          // splitContainer1
          // 
          this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer1.Location = new System.Drawing.Point(0, 0);
          this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
          this.splitContainer1.Name = "splitContainer1";
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this.panel1);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.imageBox4);
          this.splitContainer1.Panel2.Controls.Add(this.imageBox3);
          this.splitContainer1.Panel2.Controls.Add(this.imageBox2);
          this.splitContainer1.Panel2.Controls.Add(this.imageBox1);
          this.splitContainer1.Panel2.Controls.Add(this.panel2);
          this.splitContainer1.Size = new System.Drawing.Size(1048, 712);
          this.splitContainer1.SplitterDistance = 285;
          this.splitContainer1.SplitterWidth = 5;
          this.splitContainer1.TabIndex = 0;
          // 
          // panel1
          // 
          this.panel1.AutoScroll = true;
          this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel1.Location = new System.Drawing.Point(0, 0);
          this.panel1.Margin = new System.Windows.Forms.Padding(4);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(285, 712);
          this.panel1.TabIndex = 0;
          this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
          // 
          // imageBox4
          // 
          this.imageBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.imageBox4.Location = new System.Drawing.Point(381, 372);
          this.imageBox4.Margin = new System.Windows.Forms.Padding(4);
          this.imageBox4.Name = "imageBox4";
          this.imageBox4.Size = new System.Drawing.Size(368, 327);
          this.imageBox4.TabIndex = 7;
          this.imageBox4.TabStop = false;
          // 
          // imageBox3
          // 
          this.imageBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.imageBox3.Location = new System.Drawing.Point(4, 372);
          this.imageBox3.Margin = new System.Windows.Forms.Padding(4);
          this.imageBox3.Name = "imageBox3";
          this.imageBox3.Size = new System.Drawing.Size(369, 327);
          this.imageBox3.TabIndex = 6;
          this.imageBox3.TabStop = false;
          // 
          // imageBox2
          // 
          this.imageBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.imageBox2.Location = new System.Drawing.Point(381, 41);
          this.imageBox2.Margin = new System.Windows.Forms.Padding(4);
          this.imageBox2.Name = "imageBox2";
          this.imageBox2.Size = new System.Drawing.Size(368, 323);
          this.imageBox2.TabIndex = 5;
          this.imageBox2.TabStop = false;
          this.imageBox2.Click += new System.EventHandler(this.imageBox2_Click);
          // 
          // imageBox1
          // 
          this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this.imageBox1.Location = new System.Drawing.Point(4, 42);
          this.imageBox1.Margin = new System.Windows.Forms.Padding(4);
          this.imageBox1.Name = "imageBox1";
          this.imageBox1.Size = new System.Drawing.Size(369, 322);
          this.imageBox1.TabIndex = 4;
          this.imageBox1.TabStop = false;
          this.imageBox1.Click += new System.EventHandler(this.imageBox1_Click);
          // 
          // panel2
          // 
          this.panel2.Controls.Add(this.processTimeLabel);
          this.panel2.Controls.Add(this.informationLabel);
          this.panel2.Controls.Add(this.textBox1);
          this.panel2.Controls.Add(this.button1);
          this.panel2.Controls.Add(this.label1);
          this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
          this.panel2.Location = new System.Drawing.Point(0, 0);
          this.panel2.Margin = new System.Windows.Forms.Padding(4);
          this.panel2.Name = "panel2";
          this.panel2.Size = new System.Drawing.Size(758, 44);
          this.panel2.TabIndex = 3;
          // 
          // processTimeLabel
          // 
          this.processTimeLabel.AutoSize = true;
          this.processTimeLabel.Location = new System.Drawing.Point(45, 66);
          this.processTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
          this.processTimeLabel.Name = "processTimeLabel";
          this.processTimeLabel.Size = new System.Drawing.Size(0, 17);
          this.processTimeLabel.TabIndex = 4;
          // 
          // informationLabel
          // 
          this.informationLabel.AutoSize = true;
          this.informationLabel.Location = new System.Drawing.Point(36, 68);
          this.informationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
          this.informationLabel.Name = "informationLabel";
          this.informationLabel.Size = new System.Drawing.Size(0, 17);
          this.informationLabel.TabIndex = 3;
          // 
          // textBox1
          // 
          this.textBox1.Location = new System.Drawing.Point(97, 11);
          this.textBox1.Margin = new System.Windows.Forms.Padding(4);
          this.textBox1.Name = "textBox1";
          this.textBox1.ReadOnly = true;
          this.textBox1.Size = new System.Drawing.Size(380, 22);
          this.textBox1.TabIndex = 2;
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(485, 8);
          this.button1.Margin = new System.Windows.Forms.Padding(4);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(100, 28);
          this.button1.TabIndex = 1;
          this.button1.Text = "Load Image";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(36, 15);
          this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(34, 17);
          this.label1.TabIndex = 0;
          this.label1.Text = "File:";
          // 
          // openFileDialog1
          // 
          this.openFileDialog1.FileName = "openFileDialog1";
          // 
          // WattHourRecognitionForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(1048, 712);
          this.Controls.Add(this.splitContainer1);
          this.Margin = new System.Windows.Forms.Padding(4);
          this.Name = "WattHourRecognitionForm";
          this.Text = "License Plate Recognition";
          this.Load += new System.EventHandler(this.LicensePlateRecognitionForm_Load);
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel2.ResumeLayout(false);
          this.splitContainer1.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.imageBox4)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.imageBox3)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
          this.panel2.ResumeLayout(false);
          this.panel2.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Panel panel1;
      private Emgu.CV.UI.ImageBox imageBox1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label informationLabel;
      private System.Windows.Forms.Label processTimeLabel;
      private Emgu.CV.UI.ImageBox imageBox2;
      private Emgu.CV.UI.ImageBox imageBox4;
      private Emgu.CV.UI.ImageBox imageBox3;
   }
}