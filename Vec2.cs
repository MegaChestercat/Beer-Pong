namespace BeerPong
{
    public class Vec2
    {
        public float X, Y;
        public Vec2(float x, float y)
        {
            this.X = x;
            this.Y = y;

            Color c = Color.FromArgb(255, 65, 255);
        }

        public static Vec2 operator -(Vec2 v)
        {
            return new Vec2(-v.X, -v.Y);
        }

        public static Vec2 operator +(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X + b.X, a.Y + b.Y);
        }

        public static Vec2 operator -(Vec2 a, Vec2 b)
        {
            return new Vec2(a.X - b.X, a.Y - b.Y);
        }

        public static Vec2 operator *(float a, Vec2 v)
        {
            return new Vec2(a * v.X, a * v.Y);
        }

        public static Vec2 operator *(Vec2 v, float a)
        {
            return new Vec2(a * v.X, a * v.Y);
        }

        public static Vec2 operator /(Vec2 v, float a)
        {
            return new Vec2(v.X / a, v.Y / a);
        }

        public float MagSqr()
        {
            return (X * X) + (Y * Y);
        }

        public float Length()
        {
            return (float)Math.Sqrt((X * X) + (Y * Y));
        }

        public float Distance(Vec2 a)
        {
            return (float)Math.Sqrt(Math.Pow(X - a.X, 2) + Math.Pow(Y - a.Y, 2));
        }
    }
}