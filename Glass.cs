
namespace BeerPong
{
    public class Glass: VBody
    {
        VPoint a, b, c, d, e, f, g, h, i, j, k, l;
        List<VPole> poles;
        //VPole p1, p2, p3, p4, p5, p6, p7, p8, p9, p10;
        public Glass()
        {
            poles = new List<VPole>();
            //Left side of the glass
            a = new VPoint(300, 60);
            b = new VPoint((int)a.Pos.X, (int)a.Pos.Y + 15);
            c = new VPoint((int)b.Pos.X, (int)b.Pos.Y + 15);
            d = new VPoint((int)c.Pos.X, (int)c.Pos.Y + 15);
            e = new VPoint((int)d.Pos.X, (int)d.Pos.Y + 15);
            //right side of the glass
            f = new VPoint((int)a.Pos.X + 45, (int)a.Pos.Y);
            g = new VPoint((int)f.Pos.X, (int)f.Pos.Y + 15);
            h = new VPoint((int)g.Pos.X, (int)g.Pos.Y + 15);
            i = new VPoint((int)h.Pos.X, (int)h.Pos.Y + 15);
            j = new VPoint((int)i.Pos.X, (int)i.Pos.Y + 15);
            //base of the glass
            k = new VPoint((int)e.Pos.X + 15, (int)e.Pos.Y);
            l = new VPoint((int)k.Pos.X + 15, (int)k.Pos.Y);

            for(int z = 0; z < 100; z++)
            {
                poles.Add(new VPole(a, f));
                poles.Add(new VPole(a, b));
                poles.Add(new VPole(b, c));
                poles.Add(new VPole(c, d));
                poles.Add(new VPole(d, e));
                poles.Add(new VPole(f, g));
                poles.Add(new VPole(c, g));
                poles.Add(new VPole(g, h));
                poles.Add(new VPole(h, i));
                poles.Add(new VPole(i, j));
                poles.Add(new VPole(e, k));
                poles.Add(new VPole(k, l));
                poles.Add(new VPole(l, j));
                poles.Add(new VPole(a, j));
                poles.Add(new VPole(a, i));
                poles.Add(new VPole(a, h));
                poles.Add(new VPole(a, g));
                poles.Add(new VPole(f, b));
                poles.Add(new VPole(f, c));
                poles.Add(new VPole(f, d));
                poles.Add(new VPole(f, e));
                poles.Add(new VPole(a, k));
                poles.Add(new VPole(a, l));
                poles.Add(new VPole(f, k));
                poles.Add(new VPole(f, k));
            }
            
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
            i.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            j.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            k.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            l.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            for (int i = 0; i < poles.Count(); i++)
            {
                poles[i].Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            }
        }
    }
}