namespace BeerPong
{
    public class VPole
    {
        VPoint a, b;
        float stiffness, damp, length, tot, m1, m2, dis, diff;
        Vec2 dxy, offset;
        Pen brush;

        public VPole(VPoint a, VPoint b)
        {
            this.a = a;
            this.b = b;
            stiffness = 25f;
            damp = 0.05f;
            length = a.Pos.Distance(b.Pos);
            brush = new Pen(Color.Green);
            tot = a.Mass + b.Mass;
            m1 = b.Mass / tot;
            m2 = a.Mass / tot;

        }

        public void Update()
        {
            dxy = b.Pos - a.Pos;
            dis = dxy.Length();
            diff = stiffness * (length - dis) / dis;
            offset = dxy * diff * damp;
            a.Pos -= offset * m1;
            b.Pos += offset * m2;
        }

        public void Render(Graphics g, int width, int height)
        {
            Update();
            g.DrawLine(brush, a.Pos.X, a.Pos.Y, b.Pos.X, b.Pos.Y);

        }
    }

}