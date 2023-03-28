using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerPong
{
    public class Projectile
    {
        public VPoint lilbol;
        public bool selected;
        Color color;
        public Projectile(Vec2 startPos)
        {
            color = Color.Yellow;
            lilbol = new VPoint((int)startPos.X, (int)startPos.Y, color);
            selected = false;
        }

        public void WhenSelected()
        {
            color = Color.Lavender;
            lilbol.c = color;
        }
        //public void 
    }
}
