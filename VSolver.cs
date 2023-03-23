
namespace BeerPong
{
    public class VSolver
    {
        VPoint p1, p2;
        Vec2 axis, n;
        float dist, delta1, delta2;
        List<VPoint> pts;

        public VSolver(List<VPoint> pts)
        {
            this.pts = pts;
        }

        private void CheckCollisions(Graphics g, int Width, int Height)
        {
            for(int s = 0; s < pts.Count; s++)
            {
                for(int p = s+1; p < pts.Count; p++)
                {
                    p1 = pts[s];
                    p1 = pts[p];
                    axis = p1.Pos - p2.Pos;
                    dist = axis.Length();
                    if (dist < (p1.radius + p2.radius))
                    {
                        n = axis / dist;
                        delta1 = p1.radius - dist;
                        delta2 = p2.radius - dist;
                        p1.Pos -= 0.5f * delta1 * n;
                        p2.Pos += 0.5f * delta2 * n;
                    }
                }
            }
        }
    }
}