
namespace BeerPong
{
    public class Glass: VBody
    {
        VPoint a, b, c, d, e, f, g, h;
        VPole p1, p2, p3, p4, p5, p6, p7, p8, p9, p10;
        public Glass()
        {
            a = new VPoint(150, 60);
            b = new VPoint((int)a.Pos.X + 25, (int)a.Pos.Y + 25);
            c = new VPoint((int)a.Pos.X + 50, (int)a.Pos.Y);
            d = new VPoint((int)a.Pos.X, (int)a.Pos.Y + 50);
            e = new VPoint((int)a.Pos.X, (int)a.Pos.Y + 100);
            f = new VPoint((int)e.Pos.X + 25, (int)e.Pos.Y);
            g = new VPoint((int)c.Pos.X, (int)c.Pos.Y + 50);
            h = new VPoint((int)c.Pos.X, (int)c.Pos.Y + 100);

            p1 = new VPole(a, b);
            p2 = new VPole(b, c);
            p3 = new VPole(a, d);
            p4 = new VPole(d, e);
            p5 = new VPole(e, f);
            p6 = new VPole(c, g);
            p7 = new VPole(g, h);
            p8 = new VPole(f, h);
            p9 = new VPole(d, h);
            p10 = new VPole(e, g);
        }

        public override void DrawBody(ref Canvas canvas)
        {
            a.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            b.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            c.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            d.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            e.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            f.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            g.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            h.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p1.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p2.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p3.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p4.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p5.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p6.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p7.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p8.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p9.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p10.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
        }
    }
}