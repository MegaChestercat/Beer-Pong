using System.Linq;
using System.Runtime.CompilerServices;

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
        int countdown = 120;
        public int res;
        public int points1, points2 = 0;



        private readonly KonamiSequence _konamiSequence = new KonamiSequence();

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
            level1();
            /*
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
                case 3:
                    level3();
                    break;

            }*/
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

            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].Id > 54)
                {
                    if (balls[i].Y >= glasses[0].a.Y - 20 && (balls[i].X >= glasses[0].a.X && balls[i].X <= glasses[0].f.X))
                    {
                        points1 += 2;
                        kosPoints.Text = points1.ToString();
                        balls.Remove(balls[i]);

                    }
                }
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

            for (int b = 0; b < 9; b++)
                balls.Add(new VPoint(420 + (b * 15), 122, balls.Count, true));

            for (int b = 0; b < 8; b++)
                balls.Add(new VPoint(800 + (b * 15), (int)(canvas.Height * .5f - b * 6), balls.Count, true));

            for (int b = 0; b < 5; b++)
                balls.Add(new VPoint(550 + (b * 15), (int)(380 + b * 6), balls.Count, true));

            for (int b = 0; b < 3; b++)
                balls.Add(new VPoint(380, 260 + (b * 15), balls.Count, true));
            
            boxes.Add(new VBox(480, 450, 50, 50, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);



            glasses.Add(new Glass(120, 450, balls.Count));

            balls.Add(glasses[0].a);
            balls.Add(glasses[0].b);
            balls.Add(glasses[0].c);
            balls.Add(glasses[0].d);
            balls.Add(glasses[0].e);
            balls.Add(glasses[0].f);
            balls.Add(glasses[0].g);
            balls.Add(glasses[0].h);
            balls.Add(glasses[0].i);
            balls.Add(glasses[0].j);
            balls.Add(glasses[0].k);
            balls.Add(glasses[0].l);

            
            glasses.Add(new Glass(100, 120, balls.Count));
            balls.Add(glasses[1].a);
            balls.Add(glasses[1].b);
            balls.Add(glasses[1].c);
            balls.Add(glasses[1].d);
            balls.Add(glasses[1].e);
            balls.Add(glasses[1].f);
            balls.Add(glasses[1].g);
            balls.Add(glasses[1].h);
            balls.Add(glasses[1].i);
            balls.Add(glasses[1].j);
            balls.Add(glasses[1].k);
            balls.Add(glasses[1].l);
        }

        private void level2()
        {
            for (int b = 0; b < 14; b++)
                balls.Add(new VPoint(0 + (b * 15), 270, balls.Count, true));

            for (int b = 0; b < 9; b++)
                balls.Add(new VPoint(420 + (b * 15), 122, balls.Count, true));

            for (int b = 0; b < 8; b++)
                balls.Add(new VPoint(800 + (b * 15), (int)(canvas.Height * .5f - b * 6), balls.Count, true));

            for (int b = 0; b < 5; b++)
                balls.Add(new VPoint(550 + (b * 15), (int)(380 + b * 6), balls.Count, true));

            for (int b = 0; b < 3; b++)
                balls.Add(new VPoint(380, 260 + (b * 15), balls.Count, true));

            boxes.Add(new VBox(200, 150, 50, 50, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
        }
        private void level3()
        {
            glasses.Add(new Glass(100, 120, balls.Count));
            balls.Add(glasses[glasses.Count-1].a);
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

            for (int b = 0; b < 14; b++)
                balls.Add(new VPoint(0 + (b * 15), 270, balls.Count, true));

            for (int b = 0; b < 9; b++)
                balls.Add(new VPoint(420 + (b * 15), 122, balls.Count, true));

            for (int b = 0; b < 8; b++)
                balls.Add(new VPoint(800 + (b * 15), (int)(canvas.Height * .5f - b * 6), balls.Count, true));

            for (int b = 0; b < 5; b++)
                balls.Add(new VPoint(550 + (b * 15), (int)(380 + b * 6), balls.Count, true));

            for (int b = 0; b < 3; b++)
                balls.Add(new VPoint(380, 260 + (b * 15), balls.Count, true));

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
            start.Enabled = false;
            pause.Enabled = true;
            PCT_CANVAS.Enabled = true;
            timerCounter.Text = countdown.ToString();
            gameTimer.Enabled = true;
        }

        private void pause_MouseClick(object sender, MouseEventArgs e)
        {
            start.Enabled = true;
            pause.Enabled = false;
            PCT_CANVAS.Enabled = false;
            gameTimer.Enabled = false;
        }

        private void gameTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Mexican Beer Pong \n\nProgrammers: \n\nMario Arturo Sánchez Ruelas \n\n\nDesigners: \n\nMario Arturo Sánchez Ruelas", "Credits");
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
            options.Items.Add("Level 3");
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
                case 2:
                    return 3;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        private void lever1_MouseClick(object sender, MouseEventArgs e)
        {
            balls.Add(new VPoint(e.X, e.Y, balls.Count));
        }

        private void lever1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //balls.RemoveAt(balls.Count - 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}