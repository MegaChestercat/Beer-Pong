
namespace BeerPong{
    
    public class VPlatform: VBody
    {
        List<VPoint> balls;

        public VPlatform()
        {
           balls = new List<VPoint>();
        }

        public override void DrawBody(ref Canvas canvas)
        {
            for (int b = 0; b < 25; b++)//stompers265
                balls.Add(new VPoint(0 + (b * 15), (int)(canvas.Height * .2f + b * 2), balls.Count, true));

            for (int b = 0; b < 8; b++)//stompers265
                balls.Add(new VPoint(800 + (b * 15), (int)(canvas.Height * .5f - b * 6), balls.Count, true));

            for(int i = 0; i < balls.Count(); i++)
            {
                balls[i].Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            }
        }
    }
}