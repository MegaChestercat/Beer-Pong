
using static System.Windows.Forms.DataFormats;
using System.Net;

namespace BeerPong
{
    public class VSolver
    {
        VPoint p1, p2;
        Vec2 axis, n, res;
        float dist, dif;
        List<VPoint> pts;

        public VSolver(List<VPoint> pts)
        {
            this.pts = pts;
        }

        public int CheckCollisions(Graphics g, int Width, int Height, Point mouse, bool isMouseDown)
        {
            int id = -1;

            for(int s = 0; s < pts.Count; s++)
            {
                for(int p = s; p < pts.Count; p++)
                {
                    p1 = pts[s];
                    p2 = pts[p];

                    if (p1.Id == p2.Id)// BY ID
                        continue;

                    if (p1.IsPinned && p2.IsPinned)
                        continue;

                    axis = p1.Pos - p2.Pos;
                    dist = axis.Length();

                    if (dist < (p1.radius + p2.radius))
                    {
                        dif = (dist - (p1.Radius + p2.Radius)) * .5f;
                        n = axis / dist; 
                        res = dif * n;

                        if (!p1.IsPinned)
                            if (p2.IsPinned)
                                p1.Pos -= res * 2;
                            else
                                p1.Pos -= res;

                        if (!p2.IsPinned)
                            if (p1.IsPinned)
                                p2.Pos += res * 2;
                            else
                                p2.Pos += res;
                    }
                }

                if (isMouseDown)// para seleccionar el punto de masa a mover escogiendo su ID 
                    if (Math.Abs((p1.X - mouse.X) * (p1.X - mouse.X) + (p1.Y - mouse.Y) * (p1.Y - mouse.Y)) <= ((p1.Radius) * (p1.Radius)))
                        id = p1.Id;

                p1.Render(g, Width, Height);
            }
            return id;
        }
    }
}