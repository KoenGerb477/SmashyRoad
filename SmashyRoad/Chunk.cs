using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmashyRoad
{
    internal class Chunk
    {
        public int size;
        public float x;
        public float y;
        public SolidBrush brush;
        public PointF[] points = new PointF[4];
        public PointF[] roadPoints = new PointF[12];

        public Chunk(float _x, float _y, SolidBrush _brush) 
        {
            size = 4000;
            x = _x;
            y = _y;
            brush = _brush;

            points[0] = new PointF(x, y);
            points[1] = new PointF(x + size / 2, y - size / 2);
            points[2] = new PointF(x + size, y);
            points[3] = new PointF(x + size / 2, y + size / 2);

            roadPoints[0] = new PointF(x + size * 3/ 16, y + size * 3/16);
            roadPoints[1] = new PointF(x + size * 6/16, y);
            roadPoints[2] = new PointF(x + size * 3/16, y - size * 3/16);
            roadPoints[3] = new PointF(x + size * 5 /16, y - size * 5/16);
            roadPoints[4] = new PointF(x + size / 2, y - size * 1/8);
            roadPoints[5] = new PointF(x + size * 11/16, y - size * 5/16);
            roadPoints[6] = new PointF(x + size * 13/16, y - size * 3/16);
            roadPoints[7] = new PointF(x + size *10/16, y);
            roadPoints[8] = new PointF(x + size * 13/16, y + size * 3 / 16);
            roadPoints[9] = new PointF(x + size * 11 / 16, y + size * 5 / 16);
            roadPoints[10] = new PointF(x + size / 2, y + size * 1 / 8);
            roadPoints[11] = new PointF(x + size * 5 / 16, y + size * 5 / 16);
        }

        public void Move(float angle, int speed)
        {
            float xSpeed = (float)(speed * Math.Cos(angle));
            float ySpeed = (float)(speed * Math.Sin(angle));

            for (int i = 0; i < points.Length; i++)
            {
                points[i].Y += ySpeed;
                points[i].X -= xSpeed;
            }

            for (int i = 0; i < roadPoints.Length; i++)
            {
                roadPoints[i].Y += ySpeed;
                roadPoints[i].X -= xSpeed;
            }

            x  = points[0].X; y = points[0].Y;
        }

        public bool IsPointInPolygon(PointF[] polygon, PointF point)
        {
            int polygonLength = polygon.Length, i = 0;
            bool isInside = false;

            // Loop through each edge of the polygon
            for (i = 0; i < polygonLength; i++)
            {
                // Get the current vertex and the next vertex
                PointF vertex1 = polygon[i];
                PointF vertex2 = polygon[(i + 1) % polygonLength];

                // Check if the point is inside the edge's vertical range
                if (point.Y > Math.Min(vertex1.Y, vertex2.Y) && point.Y <= Math.Max(vertex1.Y, vertex2.Y) && point.X <= Math.Max(vertex1.X, vertex2.X))
                {
                    // Check if the edge is not horizontal
                    if (vertex1.Y != vertex2.Y)
                    {
                        // Calculate the intersection of the edge with the horizontal ray
                        float xIntersection = (point.Y - vertex1.Y) * (vertex2.X - vertex1.X) / (vertex2.Y - vertex1.Y) + vertex1.X;

                        // Check if the point is to the left of the intersection
                        if (vertex1.X == vertex2.X || point.X <= xIntersection)
                        {
                            // Toggle the inside/outside state
                            isInside = !isInside;
                        }
                    }
                }
            }

            return isInside;
        }
    }
}
