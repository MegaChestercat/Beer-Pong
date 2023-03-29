
using System.Diagnostics.Metrics;

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
        PointF[] pts, orderedPts;
        List<PointF> dPts;

        Pen p;
        Pen alarm = new Pen(Color.Red, 10);
        Color color, c1;
        SolidBrush brush;
        //VPole p1, p2, p3, p4, p5, p6, p7, p8, p9, p10;
        public Glass(int x, int y, int id)
        {
            poles = new List<VPole>();
            this.id = id;

            pos = new Vec2(x, y);

            //Left side of the glass
            a = new VPoint(x, y, id);
            b = new VPoint((int)a.Pos.X, (int)a.Pos.Y + 15, id+1);
            c = new VPoint((int)b.Pos.X, (int)b.Pos.Y + 15, id+2);
            d = new VPoint((int)c.Pos.X, (int)c.Pos.Y + 15, id+3);
            e = new VPoint((int)d.Pos.X, (int)d.Pos.Y + 15, id+4);
            //right side of the glass
            f = new VPoint((int)a.Pos.X + 45, (int)a.Pos.Y, id+5);
            g = new VPoint((int)f.Pos.X, (int)f.Pos.Y + 15, id+6);
            h = new VPoint((int)g.Pos.X, (int)g.Pos.Y + 15, id+7);
            i = new VPoint((int)h.Pos.X, (int)h.Pos.Y + 15, id+8);
            j = new VPoint((int)i.Pos.X, (int)i.Pos.Y + 15, id+9);
            //base of the glass
            k = new VPoint((int)e.Pos.X + 15, (int)e.Pos.Y, id+10);
            l = new VPoint((int)k.Pos.X + 15, (int)k.Pos.Y, id+11);

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

            Init(a, b, c, d, e, f, g, h, i, j, k, l);

        }

        private void Init(VPoint a, VPoint b, VPoint c, VPoint d, VPoint e, VPoint f, VPoint g, VPoint h, VPoint i, VPoint j, VPoint k, VPoint l)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
            this.i = i;
            this.j = j;
            this.k = k;
            this.l = l;

            pts = new PointF[12];
            orderedPts = new PointF[12];

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
            poles.Add(new VPole(f, l));

            poles.Add(new VPole(b, f));
            poles.Add(new VPole(b, g));
            poles.Add(new VPole(b, h));
            poles.Add(new VPole(b, i));
            poles.Add(new VPole(b, j));
            poles.Add(new VPole(b, k));
            poles.Add(new VPole(b, l));

            poles.Add(new VPole(c, f));
            poles.Add(new VPole(c, g));
            poles.Add(new VPole(c, h));
            poles.Add(new VPole(c, i));
            poles.Add(new VPole(c, j));
            poles.Add(new VPole(c, k));
            poles.Add(new VPole(c, l));

            poles.Add(new VPole(d, f));
            poles.Add(new VPole(d, g));
            poles.Add(new VPole(d, h));
            poles.Add(new VPole(d, i));
            poles.Add(new VPole(d, j));
            poles.Add(new VPole(d, k));
            poles.Add(new VPole(d, l));

            poles.Add(new VPole(e, f));
            poles.Add(new VPole(e, g));
            poles.Add(new VPole(e, h));
            poles.Add(new VPole(e, i));
            poles.Add(new VPole(e, j));
            poles.Add(new VPole(e, k));
            poles.Add(new VPole(e, l));

            poles.Add(new VPole(a, b));
            poles.Add(new VPole(b, c));
            poles.Add(new VPole(c, d));
            poles.Add(new VPole(d, e));
            poles.Add(new VPole(f, g));
            poles.Add(new VPole(g, h));
            poles.Add(new VPole(h, i));
            poles.Add(new VPole(i, j));
            poles.Add(new VPole(a, f));
            poles.Add(new VPole(e, k));
            poles.Add(new VPole(k, l));
            poles.Add(new VPole(l, j));


            c1 = Color.FromArgb(ran.Next(128, 256), ran.Next(128, 256), ran.Next(128, 256));
            brush = new SolidBrush(c1);
            color = Color.FromArgb(c1.R - 50, c1.G - 50, c1.B - 50);

            p = new Pen(color, 9);
            //p = new Pen(color, a.Radius);

            dPts = new List<PointF>();
        }

        public void BoundingBox()
        {
            minX = float.MaxValue;
            maxX = float.MinValue;
            minY = float.MaxValue;
            maxY = float.MinValue;

            minX = Math.Min(Math.Min(Math.Min(Math.Min(pts[0].X, pts[1].X), Math.Min(pts[2].X, pts[3].X)), Math.Min(Math.Min(pts[4].X, pts[5].X), Math.Min(pts[6].X, pts[7].X))), Math.Min(Math.Min(pts[8].X, pts[9].X), Math.Min(pts[10].X, pts[11].X)));
            minY = Math.Min(Math.Min(Math.Min(Math.Min(pts[0].Y, pts[1].Y), Math.Min(pts[2].Y, pts[3].Y)), Math.Min(Math.Min(pts[4].Y, pts[5].Y), Math.Min(pts[6].Y, pts[7].Y))), Math.Min(Math.Min(pts[8].Y, pts[9].Y), Math.Min(pts[10].Y, pts[11].Y)));

            maxX = Math.Max(Math.Max(Math.Max(Math.Max(pts[0].X, pts[1].X), Math.Max(pts[2].X, pts[3].X)), Math.Max(Math.Max(pts[4].X, pts[5].X), Math.Max(pts[6].X, pts[7].X))), Math.Max(Math.Max(pts[8].X, pts[9].X), Math.Max(pts[10].X, pts[11].X)));
            maxY = Math.Max(Math.Max(Math.Max(Math.Max(pts[0].Y, pts[1].Y), Math.Max(pts[2].Y, pts[3].Y)), Math.Max(Math.Max(pts[4].Y, pts[5].Y), Math.Max(pts[6].Y, pts[7].Y))), Math.Max(Math.Max(pts[8].Y, pts[9].Y), Math.Max(pts[10].Y, pts[11].Y)));
        }

        private void Update(int width, int height)
        {
            a.Update(width, height); b.Update(width, height); c.Update(width, height); d.Update(width, height); e.Update(width, height); f.Update(width, height); g.Update(width, height); h.Update(width, height); i.Update(width, height); j.Update(width, height); k.Update(width, height); l.Update(width, height);
            a.Constraints(width, height); b.Constraints(width, height); c.Constraints(width, height); d.Constraints(width, height); e.Constraints(width, height); f.Constraints(width, height); g.Constraints(width, height); h.Constraints(width, height); i.Constraints(width, height); j.Constraints(width, height); k.Constraints(width, height); l.Constraints(width, height);

            for (int i = 0; i < 25; i++)
            {
                poles[i].Update();
            }
            //poles[1].Update(); p2.Update(); p3.Update(); p4.Update(); p5.Update(); p6.Update();

            pts[0] = new PointF(a.Pos.X, a.Pos.Y);
            pts[1] = new PointF(b.Pos.X, b.Pos.Y);
            pts[2] = new PointF(c.Pos.X, c.Pos.Y);
            pts[3] = new PointF(d.Pos.X, d.Pos.Y);
            pts[4] = new PointF(e.Pos.X, e.Pos.Y);
            pts[5] = new PointF(f.Pos.X, f.Pos.Y);
            pts[6] = new PointF(g.Pos.X, g.Pos.Y);
            pts[7] = new PointF(h.Pos.X, h.Pos.Y);
            pts[8] = new PointF(i.Pos.X, i.Pos.Y);
            pts[9] = new PointF(j.Pos.X, j.Pos.Y);
            pts[10] = new PointF(k.Pos.X, k.Pos.Y);
            pts[11] = new PointF(l.Pos.X, l.Pos.Y);

            orderedPts[0] = pts[0];
            orderedPts[1] = pts[1];
            orderedPts[2] = pts[0];
            orderedPts[3] = pts[1];
            orderedPts[4] = pts[4];
            orderedPts[5] = pts[10];
            orderedPts[6] = pts[11];
            orderedPts[7] = pts[9];
            orderedPts[8] = pts[8];
            orderedPts[9] = pts[7];
            orderedPts[10] = pts[6];
            orderedPts[11] = pts[5];

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
            dPts.Add(new PointF(pts[4].X - a.Radius, pts[4].Y - a.Radius));
            dPts.Add(new PointF(pts[5].X + a.Radius, pts[5].Y - a.Radius));
            dPts.Add(new PointF(pts[6].X + a.Radius, pts[6].Y + a.Radius));
            dPts.Add(new PointF(pts[7].X - a.Radius, pts[7].Y + a.Radius));
            dPts.Add(new PointF(pts[8].X - a.Radius, pts[8].Y - a.Radius));
            dPts.Add(new PointF(pts[9].X + a.Radius, pts[9].Y - a.Radius));
            dPts.Add(new PointF(pts[10].X + a.Radius, pts[10].Y + a.Radius));
            dPts.Add(new PointF(pts[11].X - a.Radius, pts[11].Y + a.Radius));

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
            //int index;
            float distace, tmp;
            xp2.Clear();

            distace = float.MaxValue;
            List<VPole> colPoles = new List<VPole>();

            pos.X = pts[0].X + pts[1].X + pts[2].X + pts[3].X + pts[4].X + pts[5].X + pts[6].X + pts[7].X + pts[8].X + pts[9].X + pts[10].X + pts[11].X;
            pos.Y = pts[0].Y + pts[1].Y + pts[2].Y + pts[3].Y + pts[4].Y + pts[5].Y + pts[6].Y + pts[7].Y + pts[8].Y + pts[9].Y + pts[10].Y + pts[11].Y;

            pos.X /= 12;
            pos.Y /= 12;

            //index = -1;

            
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[5].X, (int)pts[5].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[1].X, (int)pts[1].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[2].X, (int)pts[2].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[3].X, (int)pts[3].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[4].X, (int)pts[4].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[6].X, (int)pts[6].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[6].X, (int)pts[6].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[6].X, (int)pts[6].Y), new VPoint((int)pts[7].X, (int)pts[7].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[7].X, (int)pts[7].Y), new VPoint((int)pts[8].X, (int)pts[8].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[8].X, (int)pts[8].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[10].X, (int)pts[10].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[10].X, (int)pts[10].Y), new VPoint((int)pts[11].X, (int)pts[11].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[11].X, (int)pts[11].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[8].X, (int)pts[8].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[7].X, (int)pts[7].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[6].X, (int)pts[6].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[1].X, (int)pts[1].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[2].X, (int)pts[2].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[3].X, (int)pts[3].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[4].X, (int)pts[4].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[10].X, (int)pts[10].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[11].X, (int)pts[11].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[10].X, (int)pts[10].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[11].X, (int)pts[11].Y)));

            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[5].X, (int)pts[5].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[6].X, (int)pts[6].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[7].X, (int)pts[7].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[8].X, (int)pts[8].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[10].X, (int)pts[10].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[11].X, (int)pts[11].Y)));

            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[5].X, (int)pts[5].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[6].X, (int)pts[6].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[7].X, (int)pts[7].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[8].X, (int)pts[8].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[10].X, (int)pts[10].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[11].X, (int)pts[11].Y)));

            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[5].X, (int)pts[5].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[6].X, (int)pts[6].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[7].X, (int)pts[7].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[8].X, (int)pts[8].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[10].X, (int)pts[10].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[11].X, (int)pts[11].Y)));

            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[5].X, (int)pts[5].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[6].X, (int)pts[6].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[7].X, (int)pts[7].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[8].X, (int)pts[8].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[10].X, (int)pts[10].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[11].X, (int)pts[11].Y)));


            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[1].X, (int)pts[1].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[1].X, (int)pts[1].Y), new VPoint((int)pts[2].X, (int)pts[2].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[2].X, (int)pts[2].Y), new VPoint((int)pts[3].X, (int)pts[3].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[3].X, (int)pts[3].Y), new VPoint((int)pts[4].X, (int)pts[4].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[5].X, (int)pts[5].Y), new VPoint((int)pts[6].X, (int)pts[6].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[6].X, (int)pts[6].Y), new VPoint((int)pts[7].X, (int)pts[7].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[7].X, (int)pts[7].Y), new VPoint((int)pts[8].X, (int)pts[8].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[8].X, (int)pts[8].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[0].X, (int)pts[0].Y), new VPoint((int)pts[5].X, (int)pts[5].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[4].X, (int)pts[4].Y), new VPoint((int)pts[10].X, (int)pts[10].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[10].X, (int)pts[10].Y), new VPoint((int)pts[11].X, (int)pts[11].Y)));
            colPoles.Add(new VPole(new VPoint((int)pts[11].X, (int)pts[11].Y), new VPoint((int)pts[9].X, (int)pts[9].Y)));


            for (int count = 0; count < colPoles.Count; count++)
            {
                FindIntersections(colPoles[count], p.Pos);
            }

            for (int point = 0; point < xp2.Count; point++)
            {
                tmp = xp2[point].Distance(p.Pos);
                if (tmp < distace)
                {
                    distace = tmp;
                    //index = point;
                }
            }

            if (distace < p.Radius + 3)
            {
                //g.DrawLine(Pens.AliceBlue, xp2[index].X, xp2[index].Y, p.Pos.X, p.Pos.Y);
                //g.DrawPolygon(alarm, pts);

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
            //p.Width = a.Diameter;
            canvas.g.DrawPolygon(p, orderedPts);
            //canvas.g.FillPolygon(brush, orderedPts);
            //canvas.g.DrawImage(Resource1.red_glass, pts[0].X, pts[0].Y, 45, 60);
        }
    }
}