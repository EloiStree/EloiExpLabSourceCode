using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Team.Brieux
{
    class Coordonate
    {
        public Coordonate (float X1, float Y1, float Z1)
        {
            X = X1;
            Y = Y1;
            Z = Z1;
        }

        float x = 0;
        float y = 0;
        float z = 0;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
    }
}
