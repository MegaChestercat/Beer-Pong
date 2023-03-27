namespace BeerPong
{
    public class VPoint
    {
        Vec2 pos, old, vel, gravity;
        float groundFriction = 0.7f;
        public float Mass;
        float radius, diameter, m, friction = 0.97f;
        Color c;
        SolidBrush brush;
        public string position;

        public Vec2 Pos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }

        public VPoint(int x, int y)
        {
            Init(x, y);
        }

        public void Init(int x, int y)
        {
            pos = new Vec2(x, y);
            old = new Vec2(x, y);

            friction = 0.97f;
            groundFriction = 0.7f;

            gravity = new Vec2(0, 0);

            radius = 5;
            diameter = radius + radius;
            c = Color.Red;
            Mass = 1;
            brush = new SolidBrush(c);
        }

        public VPoint(float velX, float velY, int x, int y)
        {
            pos = new Vec2(x, y);
            //old = new Vec2(x, y);

            friction = 0.97f;
            groundFriction = 0.7f;

            gravity = new Vec2(0, 1);

            radius = 5;
            diameter = radius + radius;
            c = Color.Red;
            Mass = 1;
            brush = new SolidBrush(c);

            old = new Vec2(pos.X + velX, pos.Y + velY);
        }

        public void Update(int width, int height)
        {
            vel = (pos - old) * friction;

            if (pos.Y >= height - radius && vel.MagSqr() > 0.000001)
            {
                m = vel.Length();
                vel /= m;
                vel *= (m * groundFriction);
            }

            old = pos;
            pos += vel + gravity;
        }

        public void Constraints(int width, int height)
        {
            if (pos.X > width - radius) pos.X = width - radius;
            if (pos.X < radius) pos.X = radius;
            if (pos.Y > height - radius) pos.Y = height - radius;
            if (pos.Y < radius) pos.Y = radius;
        }

        public void Render(Graphics g, int width, int height)
        {
            //Update(width, height);
            Constraints(width, height);
            g.FillEllipse(brush, pos.X - radius, pos.Y - radius, diameter, diameter);
        }

        public override string ToString()
        {
            string debugg = pos.X.ToString()+", " + pos.Y.ToString();
            return debugg;     
        }
    }
}