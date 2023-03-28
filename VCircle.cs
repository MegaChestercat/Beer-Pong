using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerPong
{
    public class VCircle
    {
        int radius;
        const float pi = 3.141592f;
        VPole[] circlePoles;
        VPoint[] circlePoints;
        VPoint centerPoint;

        //The Circle will be created with 20 segments.
        //The constructor, creates a Circle with 
        public VCircle(int radius, VPoint position)
        {
            int segments = 10;
            circlePoints = new VPoint[segments];
            for (int i = 0; i < segments; i++)
            {
                float lon = Util.Instance.mapInt(i, 0, segments, 0, pi * 2);
                VPoint point = new VPoint(radius * Convert.ToInt32(Math.Cos(lon)), radius * Convert.ToInt32(Math.Sin(lon))) ;
                point.Pos.Y = radius * (float)Math.Cos(lon)+100;
                point.Pos.X = radius * (float)Math.Sin(lon)+100;
                circlePoints[i] = point;
            }
            centerPoint = new VPoint(100, 100);

            List<VPole> polesList = new List<VPole>();
            for (int i = 0; i < segments; i++)
            {
                VPole p1;

                if(i == segments-1)
                {
                    p1 = new VPole(circlePoints[i], circlePoints[0]);
                }
                else
                {
                    p1 = new VPole(circlePoints[i], circlePoints[i + 1]);
                }
                polesList.Add(p1);
            }

            for (int i = 0; i < segments / 2; i++)
            {
                VPole p1;
                p1 = new VPole(circlePoints[i], circlePoints[segments/2+i]);
                polesList.Add(p1);
            }
            circlePoles = new VPole[polesList.Count];
            for (int i = 0; i< polesList.Count; i++)
            {
                circlePoles[i] = polesList[i];
            }

        }

        public void DrawCircle(Canvas canvas)
        {
            centerPoint.Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            for (int i = 0; i < circlePoints.Length; i++)
            {
                circlePoints[i].Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            }
            for (int i = 0; i < circlePoles.Length; i++)
            {
                circlePoles[i].Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
            }
            
            //circlePoints[0].Render(canvas.g, (int)canvas.Width, (int)canvas.Height);
        }

        public override string ToString()
        {
            
            return circlePoints[0].ToString();
        }
    }
}
