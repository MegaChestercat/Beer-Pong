﻿namespace BeerPong
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.tonayanLBL = new System.Windows.Forms.Label();
            this.KosakoLBL = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tonPoints = new System.Windows.Forms.Label();
            this.kosPoints = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.startBTN = new System.Windows.Forms.Button();
            this.pauseBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timerCounter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BackColor = System.Drawing.Color.Black;
            this.PCT_CANVAS.Enabled = false;
            this.PCT_CANVAS.Location = new System.Drawing.Point(20, 183);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1320, 862);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // tonayanLBL
            // 
            this.tonayanLBL.AutoSize = true;
            this.tonayanLBL.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tonayanLBL.Location = new System.Drawing.Point(939, 108);
            this.tonayanLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tonayanLBL.Name = "tonayanLBL";
            this.tonayanLBL.Size = new System.Drawing.Size(202, 32);
            this.tonayanLBL.TabIndex = 1;
            this.tonayanLBL.Text = "Tonayan Points: ";
            // 
            // KosakoLBL
            // 
            this.KosakoLBL.AutoSize = true;
            this.KosakoLBL.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.KosakoLBL.Location = new System.Drawing.Point(196, 108);
            this.KosakoLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.KosakoLBL.Name = "KosakoLBL";
            this.KosakoLBL.Size = new System.Drawing.Size(182, 32);
            this.KosakoLBL.TabIndex = 2;
            this.KosakoLBL.Text = "Kosako Points:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BeerPong.Resource1.Kosako;
            this.pictureBox1.Location = new System.Drawing.Point(116, 73);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::BeerPong.Resource1.Tonayan;
            this.pictureBox2.Image = global::BeerPong.Resource1.Tonayan;
            this.pictureBox2.Location = new System.Drawing.Point(859, 73);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(86, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // tonPoints
            // 
            this.tonPoints.AutoSize = true;
            this.tonPoints.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tonPoints.Location = new System.Drawing.Point(1171, 108);
            this.tonPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tonPoints.Name = "tonPoints";
            this.tonPoints.Size = new System.Drawing.Size(28, 32);
            this.tonPoints.TabIndex = 5;
            this.tonPoints.Text = "0";
            // 
            // kosPoints
            // 
            this.kosPoints.AutoSize = true;
            this.kosPoints.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kosPoints.Location = new System.Drawing.Point(407, 108);
            this.kosPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kosPoints.Name = "kosPoints";
            this.kosPoints.Size = new System.Drawing.Size(28, 32);
            this.kosPoints.TabIndex = 6;
            this.kosPoints.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(504, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 37);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mexican Beer Pong";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            // 
            // startBTN
            // 
            this.startBTN.Location = new System.Drawing.Point(533, 108);
            this.startBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startBTN.Name = "startBTN";
            this.startBTN.Size = new System.Drawing.Size(107, 38);
            this.startBTN.TabIndex = 8;
            this.startBTN.Text = "Play Game";
            this.startBTN.UseVisualStyleBackColor = true;
            // 
            // pauseBTN
            // 
            this.pauseBTN.Location = new System.Drawing.Point(649, 108);
            this.pauseBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pauseBTN.Name = "pauseBTN";
            this.pauseBTN.Size = new System.Drawing.Size(136, 38);
            this.pauseBTN.TabIndex = 9;
            this.pauseBTN.Text = "Pause Game";
            this.pauseBTN.UseVisualStyleBackColor = true;
            this.pauseBTN.Click += new System.EventHandler(this.pauseBTN_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(913, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Remaining Time:";
            // 
            // timerCounter
            // 
            this.timerCounter.AutoSize = true;
            this.timerCounter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timerCounter.Location = new System.Drawing.Point(1120, 15);
            this.timerCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timerCounter.Name = "timerCounter";
            this.timerCounter.Size = new System.Drawing.Size(24, 28);
            this.timerCounter.TabIndex = 11;
            this.timerCounter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1171, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "seconds";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1357, 1055);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timerCounter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pauseBTN);
            this.Controls.Add(this.startBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kosPoints);
            this.Controls.Add(this.tonPoints);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.KosakoLBL);
            this.Controls.Add(this.tonayanLBL);
            this.Controls.Add(this.PCT_CANVAS);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Timer gameTimer;
        private Button startBTN;
        private Button pauseBTN;
        private Label label2;
        private Label timerCounter;
        private Label label3;
    }
}