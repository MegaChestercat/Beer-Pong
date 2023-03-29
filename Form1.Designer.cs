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
            gameTitle = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            timerCounter = new Label();
            label3 = new Label();
            start = new PictureBox();
            pause = new PictureBox();
            lever1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)start).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pause).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lever1).BeginInit();
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
            PCT_CANVAS.Enabled = false;
            PCT_CANVAS.Location = new Point(14, 110);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(924, 517);
            PCT_CANVAS.TabIndex = 0;
            PCT_CANVAS.TabStop = false;
            PCT_CANVAS.MouseDown += PCT_CANVAS_MouseDown;
            PCT_CANVAS.MouseMove += PCT_CANVAS_MouseMove;
            PCT_CANVAS.MouseUp += PCT_CANVAS_MouseUp;
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
            // gameTitle
            // 
            gameTitle.AutoSize = true;
            gameTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            gameTitle.Location = new Point(353, 9);
            gameTitle.Name = "gameTitle";
            gameTitle.Size = new Size(212, 30);
            gameTitle.TabIndex = 7;
            gameTitle.Text = "Mexican Beer Pong";
            gameTitle.MouseDoubleClick += gameTitle_MouseDoubleClick;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(639, 9);
            label2.Name = "label2";
            label2.Size = new Size(139, 21);
            label2.TabIndex = 10;
            label2.Text = "Remaining Time:";
            // 
            // timerCounter
            // 
            timerCounter.AutoSize = true;
            timerCounter.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            timerCounter.Location = new Point(784, 9);
            timerCounter.Name = "timerCounter";
            timerCounter.Size = new Size(19, 21);
            timerCounter.TabIndex = 11;
            timerCounter.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(820, 9);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 12;
            label3.Text = "seconds";
            // 
            // start
            // 
            start.Image = Resource1.start_button;
            start.Location = new Point(340, 54);
            start.Name = "start";
            start.Size = new Size(119, 36);
            start.SizeMode = PictureBoxSizeMode.StretchImage;
            start.TabIndex = 13;
            start.TabStop = false;
            start.MouseClick += start_MouseClick;
            // 
            // pause
            // 
            pause.Image = Resource1.pause_button;
            pause.Location = new Point(465, 54);
            pause.Name = "pause";
            pause.Size = new Size(119, 36);
            pause.SizeMode = PictureBoxSizeMode.StretchImage;
            pause.TabIndex = 14;
            pause.TabStop = false;
            pause.MouseClick += pause_MouseClick;
            // 
            // lever1
            // 
            lever1.BackColor = Color.DarkGray;
            lever1.Image = Resource1.lever;
            lever1.Location = new Point(14, 258);
            lever1.Name = "lever1";
            lever1.Size = new Size(60, 80);
            lever1.SizeMode = PictureBoxSizeMode.Zoom;
            lever1.TabIndex = 15;
            lever1.TabStop = false;
            lever1.MouseClick += lever1_MouseClick;
            lever1.MouseDoubleClick += lever1_MouseDoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(950, 639);
            Controls.Add(lever1);
            Controls.Add(pause);
            Controls.Add(start);
            Controls.Add(label3);
            Controls.Add(timerCounter);
            Controls.Add(label2);
            Controls.Add(gameTitle);
            Controls.Add(kosPoints);
            Controls.Add(tonPoints);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(KosakoLBL);
            Controls.Add(tonayanLBL);
            Controls.Add(PCT_CANVAS);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)start).EndInit();
            ((System.ComponentModel.ISupportInitialize)pause).EndInit();
            ((System.ComponentModel.ISupportInitialize)lever1).EndInit();
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
        private Label gameTitle;
        private System.Windows.Forms.Timer gameTimer;
        private Label label2;
        private Label timerCounter;
        private Label label3;
        private PictureBox start;
        private PictureBox pause;
        private PictureBox lever1;
    }
}
