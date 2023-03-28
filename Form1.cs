namespace BeerPong
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        //VPoint a, b, c, d;
        //VPole pole, pole2;
        List<VPoint> balls;
        //Random rnd;
        List<VBox> boxes;
        VSolver solver;
        List<Glass> glasses;
        Pen backTrajectory;
        Projectile theBall;
        Point mouse, trigger;
        bool isMouseDown, isLeftButton;
        int ballID;
        int countdown = 120;
        Vec2 startPos;
        


        private readonly KonamiSequence _konamiSequence = new KonamiSequence();

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            startPos = new Vec2(100, 100);
            theBall= new Projectile(startPos);

            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.bitmap;
            boxes = new List<VBox>();//new VBox(100, 150, 50, 50, 1);
            glasses = new List<Glass>();//new Glass();
            balls = new List<VPoint>();
            solver = new VSolver(balls);
            backTrajectory = new Pen(Color.FromArgb(155, 250, 176), 10);
            //rnd = new Random();
            canvas.FastClear();

            level1();

            //solver = new VSolver();
            /*
            a = new VPoint(rnd.Next(150, 500), rnd.Next(150, 400));
            b = new VPoint(rnd.Next(150, 500), rnd.Next(150, 400));
            c = new VPoint((int)a.Pos.X, (int)a.Pos.Y);
            d = new VPoint((int)c.Pos.X + 80, (int)a.Pos.Y);
            pole = new VPole(a, b);
            pole2 = new VPole(c, d);*/
            //box.DrawBody(ref canvas);
            boxes.Add(new VBox(200, 150, 50, 50, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);


            /*
            glasses.Add(new Glass());
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
            */
            //glass.DrawBody(ref canvas);
            //platform.DrawBody(ref canvas);
            /*
            pole.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            a.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            b.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            c.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            d.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);*/
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

            boxes.Add(new VBox(200, 150, 50, 50, balls.Count));
            balls.Add(boxes[boxes.Count - 1].a);
            balls.Add(boxes[boxes.Count - 1].b);
            balls.Add(boxes[boxes.Count - 1].c);
            balls.Add(boxes[boxes.Count - 1].d);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
                        canvas.FastClear();
            
            ballID = solver.CheckCollisions(canvas.g, (int)canvas.Width, (int)canvas.Height, mouse, isMouseDown);
            theBall.lilbol.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            for (int counter = 0; counter < boxes.Count; counter++)
            {
                boxes[counter].React(ref canvas, balls, PCT_CANVAS.Width, PCT_CANVAS.Height);
            }
            //box.DrawBody(ref canvas);
            //glass.DrawBody(ref canvas);
            //platform.DrawBody(ref canvas);

            if (isMouseDown && isLeftButton && ballID != -1)
                canvas.g.DrawLine(backTrajectory, balls[ballID].X, balls[ballID].Y, trigger.X, trigger.Y);
            /*
            pole.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            a.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            b.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            c.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            d.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);*/
            PCT_CANVAS.Invalidate();
        }

        private void PCT_CANVAS_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);

            int xCoordinate = Cursor.Position.X;
            int yCoordinate = Cursor.Position.Y;

            if (isInside((int)theBall.lilbol.Pos.X, (int)theBall.lilbol.Pos.Y, (int)theBall.lilbol.radius, xCoordinate, yCoordinate))
            {
                Cursor.Current = Cursors.Hand;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isInside((int)theBall.lilbol.Pos.X, (int)theBall.lilbol.Pos.Y, (int)theBall.lilbol.radius, e.X - PCT_CANVAS.Location.X, e.Y - PCT_CANVAS.Location.Y))
            {
                Cursor.Current = Cursors.Hand;
                theBall.selected = true;
            }
            else
            {
                theBall.selected = false;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (theBall.selected)
            {

            }
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

        static bool isInside(int circle_x, int circle_y,
                                  int rad, int x, int y)
        {
            // Compare radius of circle with
            // distance of its center from
            // given point
            if ((x - circle_x) * (x - circle_x) +
                (y - circle_y) * (y - circle_y) <= rad * rad)
                return true;
            else
                return false;
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
    }
}