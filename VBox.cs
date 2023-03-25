
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BeerPong
{
    public class VBox: VBody
    {
        int id, width, height;
        Vec2 pos;
        VPoint a, b, c, d;
        VPole p1, p2, p3, p4, p5, p6;
        Random ran = new Random();

        public VBox(int x, int y, int width, int height, int id)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            pos = new Vec2(x, y);
            
            a = new VPoint(x - (width / 2), y - (height / 2), ran.Next(5), ran.Next(-2, 2), id);
            b = new VPoint(x + (width / 2), y - (height / 2), id + 1);
            c = new VPoint(x + (width / 2), y + (height / 2), id + 2);
            d = new VPoint(x - (width / 2), y + (height / 2), id + 3);
            p1 = new VPole(a, b);
            p2 = new VPole(c, d);
            p3 = new VPole(a, c);
            p4 = new VPole(b, d);
            p5 = new VPole(a, d);
            p6 = new VPole(b, c);
        }

        public override void DrawBody(ref Canvas canvas)
        {
            a.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            b.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            c.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            d.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p1.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p2.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p3.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p4.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p5.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            p6.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
        }
    }
}