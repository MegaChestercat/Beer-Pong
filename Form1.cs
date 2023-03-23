namespace BeerPong
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        VPoint a, b, c, d;
        VPole pole, pole2;
        Random rnd;
        VBox box;
        Glass glass;

        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.bitmap;

            rnd = new Random();
            canvas.FastClear();

            box = new VBox(rnd);
            glass = new Glass();
            /*
            a = new VPoint(rnd.Next(150, 500), rnd.Next(150, 400));
            b = new VPoint(rnd.Next(150, 500), rnd.Next(150, 400));
            c = new VPoint((int)a.Pos.X, (int)a.Pos.Y);
            d = new VPoint((int)c.Pos.X + 80, (int)a.Pos.Y);
            pole = new VPole(a, b);
            pole2 = new VPole(c, d);*/

            Init();
        }

        private void Init()
        {
            box.DrawBody(ref canvas);
            glass.DrawBody(ref canvas);
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
            box.DrawBody(ref canvas);
            glass.DrawBody(ref canvas);
            /*
            pole.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            a.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            b.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            c.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);
            d.Render(canvas.g, PCT_CANVAS.Width, PCT_CANVAS.Height);*/
            PCT_CANVAS.Invalidate();
        }
    }
}