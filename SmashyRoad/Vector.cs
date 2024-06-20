using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashyRoad
{
    internal class Vector
    {
        public float x;
        public float y;

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        //method to add vectors together
        public Vector Add(Vector v2)
        {
            //(x1 + x2, y1 + y2)
            return new Vector(x + v2.x, y + v2.y);
        }

        //method to multiply vectors by a scalar
        public Vector Multiply(float scalar)
        {
            //(x * a, y * a)
            return new Vector(x * scalar, y * scalar);
        }

        public float CrossProduct(Vector v, Vector w)
        {
            float zVal = v.x * w.y - v.y * w.x;

            return zVal;
        }

        public float GetMagnitude(Vector v)
        {
            float magnitude = (float)(Math.Sqrt(Math.Pow(v.x, 2) + Math.Pow(v.y, 2)));
            return magnitude;
        }

        public float DotProduct(Vector v, Vector b)
        {
            float dotProduct = v.x * b.x + v.y * b.y;
            float dotProductAngle = (float)(Math.Acos(dotProduct / (v.GetMagnitude(v) + b.GetMagnitude(b))));
            return dotProductAngle;
        }
    }
}
