using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematik_Perspektiv_Projekt
{
    class Vector
    {
        public float x { get; private set; }
        public float y { get; private set; }
        public float z { get; private set; }
        public string name { get; private set; }


        public Vector (float x_cord, float y_cord, float z_cord)
        {
            x = x_cord;
            y = y_cord;
            z = z_cord;
            name = "None";
        }
        public Vector(float x_cord, float y_cord, float z_cord, string vect_name)
        {
            x = x_cord;
            y = y_cord;
            z = z_cord;
            name = vect_name;
        }
        public string print()
        {
            return (name + " = (" + x + " ; " + y + " ; " + z + ")");
        }
        static public Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        static public Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        static public Vector operator /(Vector a, int b)
        {
            return new Vector(a.x/b, a.y/b, a.z/b);
        }

    }
}
