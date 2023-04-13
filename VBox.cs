
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BeerPong
{
    public class VBox: VBody
    {
        int id, width, height;
        bool self;
        float minX, maxX, minY, maxY;
        Vec2 pos;
        public VPoint a, b, c, d;
        VPole p1, p2, p3, p4, p5, p6;
        Random ran = new Random();
        List<Vec2> xp2 = new List<Vec2>();
        PointF[] pts;
        List<PointF> dPts;

        Pen p;
        Pen alarm = new Pen(Color.Red, 10);
        Color color, c1;
        SolidBrush brush;

        public VBox(int x, int y, int width, int height, int id, bool pin)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            pos = new Vec2(x, y);
            
            a = new VPoint(x - (width / 2), y - (height / 2), ran.Next(5), ran.Next(-2, 2), id, pin);
            b = new VPoint(x + (width / 2), y - (height / 2), id + 1, pin);
            c = new VPoint(x + (width / 2), y + (height / 2), id + 2, pin);
            d = new VPoint(x - (width / 2), y + (height / 2), id + 3, pin);
            p1 = new VPole(a, b);
            p2 = new VPole(c, d);
            p3 = new VPole(a, c);
            p4 = new VPole(b, d);
            p5 = new VPole(a, d);
            p6 = new VPole(b, c);

            a.FromBody = true;
            b.FromBody = true;
            c.FromBody = true;
            d.FromBody = true;

            pts = new PointF[4];
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

            p1.Update(); p2.Update(); p3.Update(); p4.Update(); p5.Update(); p6.Update();

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
            p.Width = a.Diameter;
            //canvas.g.FillPolygon(brush, pts);
            canvas.g.DrawPolygon(p, pts);
            p.Width = 10;
            canvas.g.DrawLine(p, pts[3].X, pts[3].Y, pts[1].X, pts[1].Y);
            canvas.g.DrawLine(p, pts[2].X, pts[2].Y, pts[0].X, pts[0].Y);

            p = new Pen(Color.FromArgb(color.R - 65, color.G - 55, color.B - 55), 8);//4
            canvas.g.DrawLine(p, pts[3].X, pts[3].Y, pts[0].X, pts[0].Y);
            canvas.g.DrawLines(p, pts);//*/

            color = Color.FromArgb(c1.R - 55, c1.G - 55, c1.B - 55);
            p = new Pen(color, 1);//6

            canvas.g.DrawLine(p, pts[3].X, pts[3].Y, pts[1].X, pts[1].Y);
            canvas.g.DrawLine(p, pts[2].X, pts[2].Y, pts[0].X, pts[0].Y);
            canvas.g.DrawLine(p, pts[3].X, pts[3].Y, pts[0].X, pts[0].Y);
            canvas.g.DrawLines(p, pts);//*/
        }
    }
}