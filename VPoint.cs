using System.Runtime.CompilerServices;

namespace BeerPong
{
    public class VPoint
    {
        bool isPinned = false;
        Vec2 pos, old, vel, gravity;
        float groundFriction = 0.7f;
        public float Mass;
        int id;
        public float radius, diameter, m, friction = 0.97f;
        Color c;
        SolidBrush brush;

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
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; diameter = radius + radius; }
        }

        public bool IsPinned
        {
            get { return isPinned; }
            set { isPinned = value; }
        }

        public VPoint(int x, int y)
        {
            this.id = -1;
            Init(x, y, 0, 0);
        }

        public VPoint(int x, int y, int id)
        {
            this.id = id;
            Init(x, y, 0, 0);
        }

        public VPoint(int x, int y, int id, bool Pinned)
        {
            this.id = id;
            isPinned = Pinned;
            Init(x, y, 0, 0);
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

        public VPoint(int x, int y, float vx, float vy, int id)
        {
            this.id = id;
            Init(x, y, vx, vy);
        }

        public void Init(int x, int y, float vx, float vy)
        {
            pos = new Vec2(x, y);
            old = new Vec2(x, y);

            friction = 0.97f;
            groundFriction = 0.7f;

            gravity = new Vec2(0, 1);

            radius = 5;
            diameter = radius + radius;
            c = Color.Red;
            Mass = 1;
            brush = new SolidBrush(c);
            if (IsPinned)
            {
                Pin();
            }
        }

        public void Pin()
        {
            brush = new SolidBrush(Color.Gray);
            radius = 10;
            diameter = radius + radius;
            isPinned = true;
        }

        public void Update(int width, int height)
        {

            if (isPinned)
                return;

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
            Update(width, height);
            Constraints(width, height);
            g.FillEllipse(brush, pos.X - radius, pos.Y - radius, diameter, diameter);
        }
    }
}