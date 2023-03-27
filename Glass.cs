
namespace BeerPong
{
    public class Glass: VBody
    {
        int id, width, height;
        bool self;
        float minX, maxX, minY, maxY;
        Vec2 pos;
        public VPoint a, b, c, d, e, f, g, h, i, j, k, l;
        List<VPole> poles;
        Random ran = new Random();
        List<Vec2> xp2 = new List<Vec2>();
        PointF[] pts;
        List<PointF> dPts;

        Pen p;
        Pen alarm = new Pen(Color.Red, 10);
        Color color, c1;
        SolidBrush brush;
        //VPole p1, p2, p3, p4, p5, p6, p7, p8, p9, p10;
        public Glass(int x, int y, int id)
        {
            poles = new List<VPole>();
            //Left side of the glass
            a = new VPoint(x, y, id, true);
            b = new VPoint((int)a.Pos.X, (int)a.Pos.Y + 15, id+1, true);
            c = new VPoint((int)b.Pos.X, (int)b.Pos.Y + 15, id+2, true);
            d = new VPoint((int)c.Pos.X, (int)c.Pos.Y + 15, id+3, true);
            e = new VPoint((int)d.Pos.X, (int)d.Pos.Y + 15, id+4, true);
            //right side of the glass
            f = new VPoint((int)a.Pos.X + 45, (int)a.Pos.Y, id+5, true);
            g = new VPoint((int)f.Pos.X, (int)f.Pos.Y + 15, id+6, true);
            h = new VPoint((int)g.Pos.X, (int)g.Pos.Y + 15, id+7, true);
            i = new VPoint((int)h.Pos.X, (int)h.Pos.Y + 15, id+8, true);
            j = new VPoint((int)i.Pos.X, (int)i.Pos.Y + 15, id+9, true);
            //base of the glass
            k = new VPoint((int)e.Pos.X + 15, (int)e.Pos.Y, id+10, true);
            l = new VPoint((int)k.Pos.X + 15, (int)k.Pos.Y, id+11, true);

            a.FromBody = true;
            b.FromBody = true;
            c.FromBody = true;
            d.FromBody = true;
            e.FromBody = true;
            f.FromBody = true;
            g.FromBody = true;
            h.FromBody = true;
            i.FromBody = true;
            j.FromBody = true;
            k.FromBody = true;
            l.FromBody = true;

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

            pts = new PointF[25];
            dPts = new List<PointF>();

            p = new Pen(color, 14);
            p = new Pen(color, a.Radius);
            c1 = Color.FromArgb(ran.Next(128, 256), ran.Next(128, 256), ran.Next(128, 256));
            brush = new SolidBrush(c1);
            color = Color.FromArgb(c1.R - 50, c1.G - 50, c1.B - 50);

        }

        public void BoundingBox()
        {
            minX = float.MaxValue;
            maxX = float.MinValue;
            minY = float.MaxValue;
            maxY = float.MinValue;

            minX = Math.Min(Math.Min(pts[0].X, pts[1].X), Math.Min(pts[2].X, pts[3].X));
            minY = Math.Min(Math.Min(pts[0].Y, pts[1].Y), Math.Min(pts[2].Y, pts[3].Y));

            maxX = Math.Max(Math.Max(pts[0].X, pts[1].X), Math.Max(pts[2].X, pts[3].X));
            maxY = Math.Max(Math.Max(pts[0].Y, pts[1].Y), Math.Max(pts[2].Y, pts[3].Y));
        }

        private void Update(int width, int height)
        {
            a.Update(width, height); b.Update(width, height); c.Update(width, height); d.Update(width, height);
            a.Constraints(width, height); b.Constraints(width, height); c.Constraints(width, height); d.Constraints(width, height);

            for(int i = 0; i < 25; i++)
            {
                poles[i].Update();
            }
            //poles[1].Update(); p2.Update(); p3.Update(); p4.Update(); p5.Update(); p6.Update();

            pts[0] = new PointF(a.Pos.X, a.Pos.Y);
            pts[1] = new PointF(b.Pos.X, b.Pos.Y);
            pts[2] = new PointF(c.Pos.X, c.Pos.Y);
            pts[3] = new PointF(d.Pos.X, d.Pos.Y);

            BoundingBox();
        }
        public void Render(ref Canvas canvas, int width, int height)
        {
            Update(width, height);
            //g.DrawRectangle(Pens.Yellow, mX, mY, Mx - mX, My - mY);

            dPts.Clear();
            dPts.Add(new PointF(pts[0].X - a.Radius, pts[0].Y - a.Radius));
            dPts.Add(new PointF(pts[1].X + a.Radius, pts[1].Y - a.Radius));
            dPts.Add(new PointF(pts[2].X + a.Radius, pts[2].Y + a.Radius));
            dPts.Add(new PointF(pts[3].X - a.Radius, pts[3].Y + a.Radius));

            DrawBody(ref canvas);
        }

        private bool React(ref Canvas canvas, VPoint p)//--------------------------
        {
            if (p == null || p.FromBody)
                return false;

            //g.DrawRectangle(Pens.Blue, mX, mY, Mx - mX, My - mY);//check for collision

            EdgeCollision(canvas.g, p);

            return false;
        }

        public void React(ref Canvas canvas, List<VPoint> pts, int width, int height)//----------------
        {
            Render(ref canvas, width, height);

            for (int p = 0; p < pts.Count; p++)
                React(ref canvas, pts[p]);//*/
        }

        public void EdgeCollision(Graphics g, VPoint p)//---------------------------------
        {
            int index;
            float distace, tmp;
            xp2.Clear();

            distace = float.MaxValue;
            VPole a, b, c, d;

            pos.X = pts[0].X + pts[1].X + pts[2].X + pts[3].X;
            pos.Y = pts[0].Y + pts[1].Y + pts[2].Y + pts[3].Y;

            pos.X /= 4;
            pos.Y /= 4;

            index = -1;

            a = new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[1].X, (int)pts[1].Y));
            b = new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[2].X, (int)pts[2].Y));
            c = new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[3].X, (int)pts[3].Y));
            d = new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[0].X, (int)pts[0].Y));

            FindIntersections(a, p.Pos);
            FindIntersections(b, p.Pos);
            FindIntersections(c, p.Pos);
            FindIntersections(d, p.Pos);

            for (int point = 0; point < xp2.Count; point++)
            {
                tmp = xp2[point].Distance(p.Pos);
                if (tmp < distace)
                {
                    distace = tmp;
                    index = point;
                }
            }

            if (distace < p.Radius + 3)
            {
                g.DrawLine(Pens.AliceBlue, xp2[index].X, xp2[index].Y, p.Pos.X, p.Pos.Y);
                g.DrawPolygon(alarm, pts);

                if (!p.IsPinned)//----------------FALTA CREAR LA REACCIÓN DE LA CAJA MOVIENDO LOS DOS PUNTOS DE MASA CORRESPONDIENTES AL RESORTE
                {
                    Vec2 temp = p.Pos;
                    p.Pos = p.Old + .000001f;
                    p.Old = temp - 1.5f;
                }
            }
        }

        private void FindIntersections(VPole pole, Vec2 p)//--------------------------
        {
            if (Util1.HasIn(pole.P1, pole.P2, p))
            {
                xp2.Add(Util1.GetPointLineIntersection(pole.P1, pole.P2, p));
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