using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace BeerPong
{
    public class Util
    {
        static Util instance;
        float t;

        public static Util Instance
        {
            get
            {
                if (instance == null)
                    instance = new Util();
                return Util.instance;
            }
        }

        public float mapInt(int segment, float start1, float end1, float start2, float end2)
        {
            float mapped;
            mapped = start2 + segment * ((end2 - start2) / (end1 - start1));
            return mapped;

        }
    }
}
