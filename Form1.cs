using System.Linq;
using System.Runtime.CompilerServices;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace BeerPong
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        List<VPoint> balls;
        List<VBox> boxes;
        VSolver solver;
        List<Glass> glasses;
        Pen backTrajectory;
        Point mouse, trigger;
        bool isMouseDown, isLeftButton;
        int ballID;
        int countdown = 180;
        public int res;
        public int points1, points2 = 0;
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        Random ran;
        int val;



        private readonly KonamiSequence _konamiSequence = new KonamiSequence();
        private readonly America _americaSequence = new America();


        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.bitmap;
            boxes = new List<VBox>();
            glasses = new List<Glass>();
            balls = new List<VPoint>();
            solver = new VSolver(balls);
            backTrajectory = new Pen(Color.FromArgb(155, 250, 176), 10);
            backTrajectory.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            backTrajectory.DashPattern = new float[] { 2.0F, 2.0F, 1.0F, 3.0F };
            canvas.FastClear();
            ran = new Random();
            //level3();

            res = ShowLevelDialog();

            switch (res)
            {
                case 0:
                    level1();
                    break;
                case 1:
                    level1();
                    break;
                case 2:
                    level2();
                    break;

            }
            PCT_CANVAS.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            canvas.FastClear();

            ballID = solver.CheckCollisions(canvas.g, (int)canvas.Width, (int)canvas.Height, mouse, isMouseDown);
            for (int counter = 0; counter < boxes.Count; counter++)
            {
                boxes[counter].React(ref canvas, balls, PCT_CANVAS.Width, PCT_CANVAS.Height);
            }

            for (int counter = 0; counter < glasses.Count; counter++)
            {
                glasses[counter].React(ref canvas, balls, PCT_CANVAS.Width, PCT_CANVAS.Height);
            }

            switch (res)
            {
                case 0:
                case 1:
                    for (int i = 0; i < balls.Count; i++)
                    {
                        if (balls[i].Id > 100)
                        {
                            if ((balls[i].Y < glasses[0].a.Y && balls[i].Y > glasses[0].a.Y - 20) && (balls[i].X >= glasses[0].a.X && balls[i].X <= glasses[0].f.X))
                            {
                                points1 += 20;
                                kosPoints.Text = points1.ToString();
                                balls[i].X = 10;
                                balls[i].Y = 0;


                            }
                            else if ((balls[i].Y < glasses[1].a.Y && balls[i].Y > glasses[1].a.Y - 20) && (balls[i].X >= glasses[1].a.X && balls[i].X <= glasses[1].f.X))
                            {
                                points1 += 27;
                                points2 += 60;
                                tonPoints.Text = points2.ToString();
                                kosPoints.Text = points1.ToString();
                                balls[i].X = 10;
                                balls[i].Y = 0;

                            }
                            else if ((balls[i].Y < glasses[2].a.Y && balls[i].Y > glasses[2].a.Y - 20) && (balls[i].X >= glasses[2].a.X && balls[i].X <= glasses[2].f.X))
                            {
                                points2 += 30;
                                tonPoints.Text = points2.ToString();
                                balls[i].X = 10;
                                balls[i].Y = 0;

                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < balls.Count; i++)
                    {
                        if (balls[i].Id > 142)
                        {
                            if ((balls[i].Y < glasses[0].a.Y && balls[i].Y > glasses[0].a.Y - 20) && (balls[i].X >= glasses[0].a.X && balls[i].X <= glasses[0].f.X))
                            {
                                points2 += 29;
                                tonPoints.Text = points2.ToString();
                                balls[i].X = 10;
                                balls[i].Y = 0;
                            }
                            else if ((balls[i].Y < glasses[1].a.Y && balls[i].Y > glasses[1].a.Y - 20) && (balls[i].X >= glasses[1].a.X && balls[i].X <= glasses[1].f.X))
                            {
                                points1 += 65;
                                points2 += 44;
                                kosPoints.Text = points1.ToString();
                                tonPoints.Text = points2.ToString();
                                balls[i].X = 10;
                                balls[i].Y = 0;
                            }
                            else if ((balls[i].Y < glasses[2].a.Y && balls[i].Y > glasses[2].a.Y - 20) && (balls[i].X >= glasses[2].a.X && balls[i].X <= glasses[2].f.X))
                            {
                                points1 += 33;
                                kosPoints.Text = points1.ToString();
                                balls[i].X = 10;
                                balls[i].Y = 0;
                            }
                        }
                    }
                    break;
            }

            if (isMouseDown && isLeftButton && ballID != -1)
                canvas.g.DrawLine(backTrajectory, balls[ballID].X, balls[ballID].Y, trigger.X, trigger.Y);

            PCT_CANVAS.Invalidate();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_konamiSequence.IsCompletedBy(e.KeyCode))
            {
                MessageBox.Show("Konamiiii");
                _konamiSequence.EasterEgg();
            }
            if (_americaSequence.IsCompletedBy(e.KeyCode))
            {
                MessageBox.Show("Playing CUMBIA DE LAS ÁGUILAS DEL AMÉRICA...");
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                audioFile = new AudioFileReader(@"..\..\..\Resources\america.mp3");
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
        }

        private void PCT_CANVAS_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                trigger = e.Location;
            }
        }

        private void PCT_CANVAS_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (e.Button == MouseButtons.Left && ballID != -1)
            {
                balls[ballID].Old.X = e.Location.X;
                balls[ballID].Old.Y = e.Location.Y;

            }

            ballID = -1;
        }

        private void PCT_CANVAS_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            isLeftButton = (e.Button == MouseButtons.Left);
            if (isLeftButton)
            {
                trigger = e.Location;
            }
            mouse = e.Location;
        }

        private void level1()
        {

            for (int b = 0; b < 14; b++)
                balls.Add(new VPoint(0 + (b * 15), 270, balls.Count, true));

            for (int b = 0; b < 4; b++)
                balls.Add(new VPoint(210 + (b * 15), (int)(canvas.Height * .5f - b * 6), balls.Count, true));


            for (int b = 0; b < 9; b++)
                balls.Add(new VPoint(420 + (b * 15), 122, balls.Count, true));


            for (int b = 0; b < 8; b++)
                balls.Add(new VPoint(800 + (b * 15), (int)(canvas.Height * .5f - b * 6), balls.Count, true));
            for (int b = 0; b < 2; b++)
                balls.Add(new VPoint(800 - (b * 15), 270, balls.Count, true));

            for (int b = 0; b < 2; b++)
                balls.Add(new VPoint(770 - (b * 15), (int)(270 - b * 6), balls.Count, true));

            for (int b = 0; b < 6; b++)
                balls.Add(new VPoint(270 + (b * 15), 430, balls.Count, true));

            for (int b = 0; b < 5; b++)
                balls.Add(new VPoint(550 + (b * 15), (int)(380 + b * 6), balls.Count, true));

            for (int b = 0; b < 3; b++)
                balls.Add(new VPoint(380, 260 + (b * 15), balls.Count, true));

            boxes.Add(new VBox(480, 450, 50, 50, balls.Count, false));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

            boxes.Add(new VBox(610, 450, 50, 50, balls.Count, false));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);



            glasses.Add(new Glass(120, 442, balls.Count, false));

            balls.Add(glasses[glasses.Count - 1].a);
            balls.Add(glasses[glasses.Count - 1].b);
            balls.Add(glasses[glasses.Count - 1].c);
            balls.Add(glasses[glasses.Count - 1].d);
            balls.Add(glasses[glasses.Count - 1].e);
            balls.Add(glasses[glasses.Count - 1].f);
            balls.Add(glasses[glasses.Count - 1].g);
            balls.Add(glasses[glasses.Count - 1].h);
            balls.Add(glasses[glasses.Count - 1].i);
            balls.Add(glasses[glasses.Count - 1].j);
            balls.Add(glasses[glasses.Count - 1].k);
            balls.Add(glasses[glasses.Count - 1].l);


            glasses.Add(new Glass(460, 45, balls.Count, true));
            balls.Add(glasses[glasses.Count - 1].a);
            balls.Add(glasses[glasses.Count - 1].b);
            balls.Add(glasses[glasses.Count - 1].c);
            balls.Add(glasses[glasses.Count - 1].d);
            balls.Add(glasses[glasses.Count - 1].e);
            balls.Add(glasses[glasses.Count - 1].f);
            balls.Add(glasses[glasses.Count - 1].g);
            balls.Add(glasses[glasses.Count - 1].h);
            balls.Add(glasses[glasses.Count - 1].i);
            balls.Add(glasses[glasses.Count - 1].j);
            balls.Add(glasses[glasses.Count - 1].k);
            balls.Add(glasses[glasses.Count - 1].l);

            boxes.Add(new VBox(850, 477, 50, 50, balls.Count, true));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);

            glasses.Add(new Glass(850, 372, balls.Count, true));
            balls.Add(glasses[glasses.Count - 1].a);
            balls.Add(glasses[glasses.Count - 1].b);
            balls.Add(glasses[glasses.Count - 1].c);
            balls.Add(glasses[glasses.Count - 1].d);
            balls.Add(glasses[glasses.Count - 1].e);
            balls.Add(glasses[glasses.Count - 1].f);
            balls.Add(glasses[glasses.Count - 1].g);
            balls.Add(glasses[glasses.Count - 1].h);
            balls.Add(glasses[glasses.Count - 1].i);
            balls.Add(glasses[glasses.Count - 1].j);
            balls.Add(glasses[glasses.Count - 1].k);
            balls.Add(glasses[glasses.Count - 1].l);
        }

        private void level2()
        {
            //Plataforma de recepcion de pelota
            for (int b = 0; b < 2; b++)
                balls.Add(new VPoint(30 + (b * 15), 100, balls.Count, true));
            for (int b = 0; b < 1; b++)
                balls.Add(new VPoint(60 + (b * 15), 85, balls.Count, true));
            for (int b = 0; b < 1; b++)
                balls.Add(new VPoint(10 + (b * 15), 85, balls.Count, true));

            // Estorbos verticales 1

            for (int b = 0; b < 7; b++)
                balls.Add(new VPoint(200, 40 + (b * 15), balls.Count, true));

            for (int b = 0; b < 7; b++)
                balls.Add(new VPoint(200, 200 + (b * 15), balls.Count, true));

            for (int b = 0; b < 7; b++)
                balls.Add(new VPoint(200, 360 + (b * 15), balls.Count, true));


            //Estorbos verticales 2
            for (int b = 0; b < 4; b++)
                balls.Add(new VPoint(400, 230 + (b * 15), balls.Count, true));

            //Estorbos diagonales 


            for (int b = 0; b < 8; b++)
                balls.Add(new VPoint(250 + (b * 15), (int)(canvas.Height * .5f - b * 6) - 50, balls.Count, true));

            for (int b = 0; b < 8; b++)
                balls.Add(new VPoint(250 + (b * 15), (int)(canvas.Height * .5f - b * 6) + 110, balls.Count, true));


            // Estorbo diagonal abajo 
            for (int b = 0; b < 6; b++)
                balls.Add(new VPoint(440 + (b * 15), (int)(330 + b * 15), balls.Count, true));


            //Estorbos horizontales derecha 
            for (int b = 0; b < 9; b++)
                balls.Add(new VPoint(700 + (b * 15), 122, balls.Count, true));

            for (int b = 0; b < 9; b++)
                balls.Add(new VPoint(750 + (b * 15), 250, balls.Count, true));

            //Estorbo vertical grande

            for (int b = 0; b < 20; b++)
                balls.Add(new VPoint(590, 40 + (b * 15), balls.Count, true));




            //Caja 1
            boxes.Add(new VBox(150, 445, 50, 50, balls.Count, false));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
            //Plataforma para caja 1
            for (int b = 0; b < 5; b++)
                balls.Add(new VPoint(55 + (b * 15), 400, balls.Count, true));

            //Vaso 1

            glasses.Add(new Glass(55, 320, balls.Count, true));
            balls.Add(glasses[glasses.Count - 1].a);
            balls.Add(glasses[glasses.Count - 1].b);
            balls.Add(glasses[glasses.Count - 1].c);
            balls.Add(glasses[glasses.Count - 1].d);
            balls.Add(glasses[glasses.Count - 1].e);
            balls.Add(glasses[glasses.Count - 1].f);
            balls.Add(glasses[glasses.Count - 1].g);
            balls.Add(glasses[glasses.Count - 1].h);
            balls.Add(glasses[glasses.Count - 1].i);
            balls.Add(glasses[glasses.Count - 1].j);
            balls.Add(glasses[glasses.Count - 1].k);
            balls.Add(glasses[glasses.Count - 1].l);


            //Caja 2
            boxes.Add(new VBox(600, 477, 50, 50, balls.Count, false));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);


            //Vaso 2
            glasses.Add(new Glass(780, 440, balls.Count, true));
            balls.Add(glasses[glasses.Count - 1].a);
            balls.Add(glasses[glasses.Count - 1].b);
            balls.Add(glasses[glasses.Count - 1].c);
            balls.Add(glasses[glasses.Count - 1].d);
            balls.Add(glasses[glasses.Count - 1].e);
            balls.Add(glasses[glasses.Count - 1].f);
            balls.Add(glasses[glasses.Count - 1].g);
            balls.Add(glasses[glasses.Count - 1].h);
            balls.Add(glasses[glasses.Count - 1].i);
            balls.Add(glasses[glasses.Count - 1].j);
            balls.Add(glasses[glasses.Count - 1].k);
            balls.Add(glasses[glasses.Count - 1].l);

            //Vaso 3
            glasses.Add(new Glass(750, 47, balls.Count, true));
            balls.Add(glasses[glasses.Count - 1].a);
            balls.Add(glasses[glasses.Count - 1].b);
            balls.Add(glasses[glasses.Count - 1].c);
            balls.Add(glasses[glasses.Count - 1].d);
            balls.Add(glasses[glasses.Count - 1].e);
            balls.Add(glasses[glasses.Count - 1].f);
            balls.Add(glasses[glasses.Count - 1].g);
            balls.Add(glasses[glasses.Count - 1].h);
            balls.Add(glasses[glasses.Count - 1].i);
            balls.Add(glasses[glasses.Count - 1].j);
            balls.Add(glasses[glasses.Count - 1].k);
            balls.Add(glasses[glasses.Count - 1].l);

            // Estorbo diagonal abajo vaso 
            for (int b = 0; b < 5; b++)
                balls.Add(new VPoint(700 + (b * 15), (int)(360 + b * 15), balls.Count, true));

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (countdown <= 0)
            {
                PCT_CANVAS.Enabled = false;
                gameTimer.Enabled = false;
                MessageBox.Show("The game has finished \n\nSummary:\n\nKosako Points: " + kosPoints.Text + "\nTonayan Points: " + tonPoints.Text, "Game Over");
                this.Close();
            }
            else
            {
                countdown--;
                timerCounter.Text = countdown.ToString();
            }
        }

        private void start_MouseClick(object sender, MouseEventArgs e)
        {
            PreStartScreen.Visible = false;
            start.Visible = false;
            start.Enabled = false;
            resume.Visible = true;
            resume.Enabled = false;
            pause.Visible = true;
            pause.Enabled = true;
            PCT_CANVAS.Enabled = true;
            lever1.Enabled = true;
            lever1.Visible = true;
            timerCounter.Text = countdown.ToString();
            gameTimer.Enabled = true;
        }

        private void pause_MouseClick(object sender, MouseEventArgs e)
        {
            lever1.Enabled = false;
            resume.Enabled = true;
            pause.Enabled = false;
            PCT_CANVAS.Enabled = false;
            gameTimer.Enabled = false;

            if (outputDevice == null && audioFile == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                audioFile = new AudioFileReader(@"..\..\..\Resources\pause_sound.mp3");
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
            else
            {
                outputDevice.Stop();
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                audioFile = new AudioFileReader(@"..\..\..\Resources\pause_sound.mp3");
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
            
        }

        private void gameTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Mexican Beer Pong \n\nProgrammers: \n\nMario Arturo Sánchez Ruelas, Ruben Dario Suarez Diaz, Hector Emiliano Zepeda Gonzalez\n\n\nDesigners: \n\nMario Arturo Sánchez Ruelas, Ruben Dario Suarez Diaz, Hector Emiliano Zepeda Gonzalez", "Credits");
        }

        public static int ShowLevelDialog()
        {

            Form prompt = new Form();
            prompt.Width = 180;
            prompt.Height = 100;
            FlowLayoutPanel panel = new FlowLayoutPanel();
            ComboBox options = new ComboBox();
            options.Items.Add("Level 1");
            options.Items.Add("Level 2");
            //options.Items.Add("Level 3");
            Button ok = new Button();
            ok.Text = "Continue";
            ok.MouseClick += (sender, e) => { prompt.Close(); };
            panel.Controls.Add(options);
            panel.Controls.Add(ok);
            prompt.Controls.Add(panel);
            prompt.ShowDialog();


            switch (options.SelectedIndex)
            {
                case 0:
                    return 1;
                    break;
                case 1:
                    return 2;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        private void lever1_MouseClick(object sender, MouseEventArgs e)
        {
            balls.Add(new VPoint(e.X, e.Y, balls.Count, 12));
        }

        private void lever1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //balls.RemoveAt(balls.Count - 2);
            val = ran.Next(2 - 1 + 1) + 1;
            if(val == 1)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                audioFile = new AudioFileReader(@"..\..\..\Resources\Yamete.mp3");
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
            else if (val == 2)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                audioFile = new AudioFileReader(@"..\..\..\Resources\Fnaf.mp3");
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lever1_MouseDown(object sender, MouseEventArgs e)
        {
            lever1.Image = Resource1.BTN2;
        }

        private void lever1_MouseUp(object sender, MouseEventArgs e)
        {
            lever1.Image = Resource1.BTN1;
        }

        private void resume_MouseClick(object sender, MouseEventArgs e)
        {
            outputDevice.Stop();
            resume.Enabled = false;
            pause.Enabled = true;
            PCT_CANVAS.Enabled = true;
            lever1.Enabled = true;
            lever1.Visible = true;
            timerCounter.Text = countdown.ToString();
            gameTimer.Enabled = true;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice = null;
            //outputDevice.Dispose();
            //audioFile.Dispose();
            audioFile = null;
            
        }
    }
}