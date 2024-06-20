using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashyRoad
{
    internal class _3DPoint
    {
        public float x;
        public float y;
        public float z;

        public _3DPoint(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public void RotatePoint(double radians, PointF pivot)
        {
            var cosTheta = Math.Cos(radians);
            var sinTheta = Math.Sin(radians);

            x = (float)(cosTheta * (x - pivot.X) - sinTheta * (y - pivot.Y) + pivot.X);
            y = (float)(sinTheta * (x - pivot.X) + cosTheta * (y - pivot.Y) + pivot.Y);
        }
    }
}