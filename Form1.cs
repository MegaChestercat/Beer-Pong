namespace BeerPong
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        VPoint a, b, c, d;
        VPole pole, pole2;
        Random rnd;
        VBox box;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            canvas.FastClear();
            //box.DrawBox(ref canvas);
            circle.DrawCircle(canvas);
            label1.Text = circle.ToString();
            PCT_CANVAS.Invalidate();
            //timer1.Enabled= false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        VCircle circle;

        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.bitmap;

            rnd = new Random();
            canvas.FastClear();

            box = new VBox(rnd);
            circle = new VCircle(70, new VPoint(100, 100));

            Init();
        }

        private void Init()
        {
        }
    }
}