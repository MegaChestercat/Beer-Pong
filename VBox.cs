
namespace BeerPong
{
    public class VBox: VBody
    {
        VPoint a, b, c, d;
        VPole p1, p2, p3, p4, p5, p6;
        Random ran;

        public VBox(Random rnd)
        {
            ran = rnd;
            int x = (int)ran.Next(100, 300);
            int y = (int)ran.Next(100, 300);
            a = new VPoint(100f, 9f, x, y);
            b = new VPoint((int)a.Pos.X + 100, (int)a.Pos.Y);
            c = new VPoint((int)a.Pos.X, (int)a.Pos.Y + 100);
            d = new VPoint((int)b.Pos.X, (int)a.Pos.Y + 100);
            p1 = new VPole(a, b);
            p2 = new VPole(c, d);
            p3 = new VPole(a, c);
            p4 = new VPole(b, d);
            p5 = new VPole(a, d);
            p6 = new VPole(b, c);
        }

        public override void DrawBody(ref Canvas canvas)
        {
            a.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            b.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            c.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            d.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p1.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p2.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p3.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p4.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p5.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p6.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
        }
    }
}