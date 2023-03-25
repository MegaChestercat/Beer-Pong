namespace BeerPong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            PCT_CANVAS = new PictureBox();
            tonayanLBL = new Label();
            KosakoLBL = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            tonPoints = new Label();
            kosPoints = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.BackColor = Color.Black;
            PCT_CANVAS.Location = new Point(14, 110);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(924, 517);
            PCT_CANVAS.TabIndex = 0;
            PCT_CANVAS.TabStop = false;
            // 
            // tonayanLBL
            // 
            tonayanLBL.AutoSize = true;
            tonayanLBL.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            tonayanLBL.Location = new Point(657, 65);
            tonayanLBL.Name = "tonayanLBL";
            tonayanLBL.Size = new Size(157, 25);
            tonayanLBL.TabIndex = 1;
            tonayanLBL.Text = "Tonayan Points: ";
            // 
            // KosakoLBL
            // 
            KosakoLBL.AutoSize = true;
            KosakoLBL.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            KosakoLBL.Location = new Point(137, 65);
            KosakoLBL.Name = "KosakoLBL";
            KosakoLBL.Size = new Size(142, 25);
            KosakoLBL.TabIndex = 2;
            KosakoLBL.Text = "Kosako Points:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resource1.Kosako;
            pictureBox1.Location = new Point(81, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Resource1.Tonayan;
            pictureBox2.Image = Resource1.Tonayan;
            pictureBox2.Location = new Point(601, 44);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 60);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // tonPoints
            // 
            tonPoints.AutoSize = true;
            tonPoints.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            tonPoints.Location = new Point(820, 65);
            tonPoints.Name = "tonPoints";
            tonPoints.Size = new Size(23, 25);
            tonPoints.TabIndex = 5;
            tonPoints.Text = "0";
            // 
            // kosPoints
            // 
            kosPoints.AutoSize = true;
            kosPoints.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            kosPoints.Location = new Point(285, 65);
            kosPoints.Name = "kosPoints";
            kosPoints.Size = new Size(23, 25);
            kosPoints.TabIndex = 6;
            kosPoints.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(353, 9);
            label1.Name = "label1";
            label1.Size = new Size(212, 30);
            label1.TabIndex = 7;
            label1.Text = "Mexican Beer Pong";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(950, 639);
            Controls.Add(label1);
            Controls.Add(kosPoints);
            Controls.Add(tonPoints);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(KosakoLBL);
            Controls.Add(tonayanLBL);
            Controls.Add(PCT_CANVAS);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private PictureBox PCT_CANVAS;
        private Label tonayanLBL;
        private Label KosakoLBL;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label tonPoints;
        private Label kosPoints;
        private Label label1;
    }
}