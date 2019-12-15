using System;
using System.Collections.Generic;
using System.Text;

namespace Day12
{
    class MoonSystem : IEquatable<MoonSystem>
    {
        Moon a, b, c, d;
        public MoonSystem(Moon _a, Moon _b, Moon _c, Moon _d)
        {
            a = _a;
            b = _b;
            c = _c;
            d = _d;
        }
        public bool Equals(MoonSystem obj)
        {
            return MoonEqual(a, obj.a)
                && MoonEqual(b, obj.b)
                && MoonEqual(c, obj.c)
                && MoonEqual(d, obj.d);
        }
        private bool MoonEqual(Moon a,Moon b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z &&
                a.vx == b.vx && a.vy == b.vy && a.vz == b.vz;
        }
    }
}
