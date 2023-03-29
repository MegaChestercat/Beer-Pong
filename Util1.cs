
namespace BeerPong
{
    public class Util1
    {
        public static Vec2 GetPointLineIntersection(Vec2 p1, Vec2 p2, Vec2 p3)
        {
            Vec2 v = new Vec2(p2.X - p1.X, p2.Y - p1.Y);
            Vec2 w = new Vec2(p3.X - p1.X, p3.Y - p1.Y);

            float len_v = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            if (len_v == 0)
            {
                return null; 
            }
            Vec2 n = new Vec2(v.X / len_v, v.Y / len_v);
            float dist = w.X * n.X + w.Y * n.Y;

            if (dist < 0 || dist > len_v)
            {
                return null; 
            }

            return new Vec2(p1.X + n.X * dist, p1.Y + n.Y * dist);
        }//*/

        public static bool HasIn(Vec2 p1, Vec2 p2, Vec2 p3)
        {
            Vec2 v = new Vec2(p2.X - p1.X, p2.Y - p1.Y);
            Vec2 w = new Vec2(p3.X - p1.X, p3.Y - p1.Y);

            float len_v = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            if (len_v == 0)
            {
                return false; 
            }
            Vec2 n = new Vec2(v.X / len_v, v.Y / len_v);
            float dist = w.X * n.X + w.Y * n.Y;

            if (dist < 0 || dist > len_v)
            {
                return false; 
            }

            return true;
        }
    }
}