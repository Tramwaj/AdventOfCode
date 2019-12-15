using System;
using System.Collections.Generic;
using System.Text;

namespace Day12
{
    class Moon
    {
        public int x, y, z;
        public int vx = 0, vy = 0, vz = 0;
        public Moon(int inX, int inY, int inZ)
        {
            x = inX;
            y = inY;
            z = inZ;
        }
        public void ChangeV(Moon other)
        {
            if (x < other.x) ++vx;
            if (x > other.x) --vx;
            if (y < other.y) ++vy;
            if (y > other.y) --vy;
            if (z < other.z) ++vz;
            if (z > other.z) --vz;
        }
        public void Move()
        {
            x += vx;
            y += vy;
            z += vz;
        }
        public override string ToString()
        {
            // var ret = new StringBuilder("posx=<x=" + x + " , y=" + y + " , z=" + z + ">, ");
            //ret.Append("vel=<x= " + vx + " y= " + vy + " z= " + vz + ">");
            var ret = new StringBuilder(x.ToString() + y + z);
            ret.Append(vx + vy + +vz);
            return ret.ToString();
        }
        public List<int> ToList()
        {
            var list = new List<int>
            {
                x,
                y,
                z,
                vx,
                vy,
                vz
            };
            return list;
        }
        public int[] ToArray()
        {
            return new int[] { x, y, z, vx, vy, vz };
        }
        public int Energy()
        {
            return (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) * (Math.Abs(vx) + Math.Abs(vy) + Math.Abs(vz));
        }
    }
}
