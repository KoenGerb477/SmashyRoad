using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmashyRoad
{
    internal class Car
    {
        public int x;
        public int y;
        public int size;
        _3DPoint[] shapePoints = new _3DPoint[8];
        public PointF[] drawPoints = new PointF[8];
        public float direction;
        public int speed = +14;
        public int maxSpeed = 15;
        string type;

        public bool living = true;

        SolidBrush brush1;
        SolidBrush brush2;
        SolidBrush brush3;

        int lightFlashingCounter = 0;

        //remove later
        public float crossProduct;

        public Car(int x, int y, float direction, string type, Car player)
        {
            this.size = 100;
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.type = type;

            if (type == "police")
            {
                brush1 = new SolidBrush(Color.Red);
                brush2 = new SolidBrush(Color.Blue);
                brush3 = new SolidBrush(Color.Black);
            }
            else if (type == "player")
            {
                if (Form1.carSelected == "car1")
                {
                    brush1 = new SolidBrush(Color.FromArgb(255, 0, 0, 200));
                    brush2 = new SolidBrush(Color.FromArgb(255, 0, 0, 225));
                    brush3 = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
                }
                else if (Form1.carSelected == "car2")
                {
                    brush1 = new SolidBrush(Color.FromArgb(255, 200, 0, 0));
                    brush2 = new SolidBrush(Color.FromArgb(255, 225, 0, 0));
                    brush3 = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
                }
                else if (Form1.carSelected == "car3")
                {
                    brush1 = new SolidBrush(Color.FromArgb(255, 0, 200, 0));
                    brush2 = new SolidBrush(Color.FromArgb(255, 0, 225, 0));
                    brush3 = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
                }
                else if (Form1.carSelected == "car4")
                {
                    brush1 = new SolidBrush(Color.FromArgb(255, 255, 215, 102));
                    brush2 = new SolidBrush(Color.FromArgb(255, 255, 220, 97));
                    brush3 = new SolidBrush(Color.FromArgb(255, 255, 210, 107));
                }
                else if (Form1.carSelected == "car5")
                {
                    brush1 = new SolidBrush(Color.FromArgb(255, 128, 0, 128));
                    brush2 = new SolidBrush(Color.FromArgb(255, 120, 0, 136));
                    brush3 = new SolidBrush(Color.FromArgb(255, 136, 0, 120));
                }
                else if (Form1.carSelected == "car6")
                {
                    brush1 = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
                    brush2 = new SolidBrush(Color.FromArgb(255, 250, 250, 250));
                    brush3 = new SolidBrush(Color.FromArgb(255, 245, 245, 245));
                }
            }

            MakeListOfPoints();
            InterpretPoints();
        }

        void MakeListOfPoints()
        {
            float _3D_Direction = direction - (float)Math.PI / 4;

            if (_3D_Direction < 0)
            {
                _3D_Direction += (float)Math.PI * 2;
            }

            shapePoints[0] = new _3DPoint(0, 0, 0);
            shapePoints[1] = new _3DPoint(0, 0, size / 2);
            shapePoints[2] = new _3DPoint(size / 2 * (float)Math.Sin(-_3D_Direction), size / 2 * (float)Math.Cos(-_3D_Direction), size / 2);
            shapePoints[3] = new _3DPoint(size / 2 * (float)Math.Sin(-_3D_Direction), size / 2 * (float)Math.Cos(-_3D_Direction), 0);
            shapePoints[4] = new _3DPoint(size * (float)Math.Cos(_3D_Direction), size * (float)Math.Sin(_3D_Direction), 0);
            shapePoints[5] = new _3DPoint(size * (float)Math.Cos(_3D_Direction), size * (float)Math.Sin(_3D_Direction), size / 2);
            shapePoints[6] = new _3DPoint((float)(Math.Sqrt(Math.Pow(size / 2, 2) + Math.Pow(size, 2)) * Math.Cos(_3D_Direction + Math.Atan(0.5))), (float)(Math.Sqrt(Math.Pow(size / 2, 2) + Math.Pow(size, 2)) * Math.Sin(_3D_Direction + Math.Atan(0.5))), size / 2); //d ^ 2 = (size / 2)^2 + size ^ 2
            shapePoints[7] = new _3DPoint((float)(Math.Sqrt(Math.Pow(size / 2, 2) + Math.Pow(size, 2)) * Math.Cos(_3D_Direction + Math.Atan(0.5))), (float)(Math.Sqrt(Math.Pow(size / 2, 2) + Math.Pow(size, 2)) * Math.Sin(_3D_Direction + Math.Atan(0.5))), 0);//d^2 = (size / 2)^2 + size ^ 2

        }

        void InterpretPoints()
        {
            for (int i = 0; i < shapePoints.Length; i++)
            {
                drawPoints[i] = new PointF((float)(x + shapePoints[i].x * Math.PI / 4 - shapePoints[i].y * Math.PI / 4), (float)(y - shapePoints[i].x * Math.PI / 4 - shapePoints[i].y * Math.PI / 4 - shapePoints[i].z));
            }
        }

        public void Draw(PaintEventArgs e)
        {
            MakeListOfPoints();
            InterpretPoints();

            if (direction > Math.PI * 2)
            {
                direction -= (float)Math.PI * 2;
            }
            else if (direction < 0)
            {
                direction += (float)Math.PI * 2;
            }

            PointF[] smallSide = new PointF[4];
            PointF[] bigSide = new PointF[4];

            //far side and right side
            if (direction > Math.PI * 3 / 2 && direction < Math.PI * 2)
            {
                smallSide[0] = drawPoints[4];
                smallSide[1] = drawPoints[5];
                smallSide[2] = drawPoints[6];
                smallSide[3] = drawPoints[7];

                bigSide[0] = drawPoints[0];
                bigSide[1] = drawPoints[1];
                bigSide[2] = drawPoints[5];
                bigSide[3] = drawPoints[4];
            }
            //left side and far side
            else if (direction > Math.PI / 2 && direction < Math.PI)
            {
                smallSide[0] = drawPoints[0];
                smallSide[1] = drawPoints[1];
                smallSide[2] = drawPoints[2];
                smallSide[3] = drawPoints[3];

                bigSide[0] = drawPoints[2];
                bigSide[1] = drawPoints[3];
                bigSide[2] = drawPoints[7];
                bigSide[3] = drawPoints[6];
            }
            //front and left side
            else if (direction > Math.PI && direction < Math.PI * 3 / 2)
            {
                smallSide[0] = drawPoints[4];
                smallSide[1] = drawPoints[5];
                smallSide[2] = drawPoints[6];
                smallSide[3] = drawPoints[7];

                bigSide[0] = drawPoints[2];
                bigSide[1] = drawPoints[3];
                bigSide[2] = drawPoints[7];
                bigSide[3] = drawPoints[6];
            }
            //front and right side
            else if (direction > 0 || direction < Math.PI / 2)
            {
                smallSide[0] = drawPoints[0];
                smallSide[1] = drawPoints[1];
                smallSide[2] = drawPoints[2];
                smallSide[3] = drawPoints[3];

                bigSide[0] = drawPoints[0];
                bigSide[1] = drawPoints[1];
                bigSide[2] = drawPoints[5];
                bigSide[3] = drawPoints[4];
            }

            if (type == "police" && lightFlashingCounter % 10 == 0)
            {
                SolidBrush tempBrush = brush1;
                brush1 = brush2;
                brush2 = brush3;
                brush3 = tempBrush;
            }
            if (type == "police")
            {
                lightFlashingCounter++;
            }

            PointF[] top = { drawPoints[1], drawPoints[2], drawPoints[6], drawPoints[5] };

            e.Graphics.FillPolygon(brush1, smallSide);
            e.Graphics.FillPolygon(brush2, bigSide);
            e.Graphics.FillPolygon(brush3, top);
        }

        public void Move(Car player)
        {
            float xSpeed = 0, ySpeed = 0;

            if (living)
            {
                Vector toPlayer = new Vector(player.x - x, player.y - y);
                Vector police = new Vector((float)(-speed * Math.Cos(direction)), (float)(speed * Math.Sin(direction)));
                crossProduct = police.CrossProduct(toPlayer, police);

                if (crossProduct < -500)
                {
                    direction -= 0.1f;
                }
                else if (crossProduct > 500)
                {
                    direction += 0.1f;
                }

                xSpeed = (float)(this.speed * Math.Cos(direction));
                ySpeed = (float)(this.speed * Math.Sin(direction));
            }

            xSpeed += (float)(player.speed * Math.Cos(player.direction));
            ySpeed += (float)(player.speed * Math.Sin(player.direction));

            y += Convert.ToInt32(ySpeed);
            x -= Convert.ToInt32(xSpeed);
        }

        public bool CheckCollision(Car player)
        {
            List<PointF> playerVertices = new List<PointF>
            {
                new PointF(player.drawPoints[0].X, player.drawPoints[0].Y),
                new PointF(player.drawPoints[3].X, player.drawPoints[3].Y),
                new PointF(player.drawPoints[4].X, player.drawPoints[4].Y),
                new PointF(player.drawPoints[7].X, player.drawPoints[7].Y)
            };

            Polygon playerPoly = new Polygon(playerVertices);

            List<PointF> policeVertices = new List<PointF>
            {
                new PointF(drawPoints[0].X, drawPoints[0].Y),
                new PointF(drawPoints[3].X, drawPoints[3].Y),
                new PointF(drawPoints[4].X, drawPoints[4].Y),
                new PointF(drawPoints[7].X, drawPoints[7].Y)
            };

            Polygon policePoly = new Polygon(policeVertices);

            bool isCollision = Polygon.CheckCollision(playerPoly, policePoly);

            if (isCollision)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Collide()
        {
            brush1.Color = Color.Black;
            brush2.Color = Color.Black;
            brush3.Color = Color.Black;

            living = false;

            if (type == "player")
            {
                GameScreen.playerDead = true;
            }
        }
    }

    #region polygon
    public class Polygon
    {
        public List<PointF> Vertices { get; set; }

        public Polygon(List<PointF> vertices)
        {
            Vertices = vertices;
        }

        // Method to get all edges of the polygon
        public List<PointF> GetEdges()
        {
            List<PointF> edges = new List<PointF>();
            for (int i = 0; i < Vertices.Count; i++)
            {
                PointF p1 = Vertices[i];
                PointF p2 = Vertices[(i + 1) % Vertices.Count];
                edges.Add(new PointF(p2.X - p1.X, p2.Y - p1.Y));
            }
            return edges;
        }

        // Method to project polygon on an axis and return the minimum and maximum values
        public (float min, float max) ProjectOnAxis(PointF axis)
        {
            float min = float.MaxValue;
            float max = float.MinValue;

            foreach (var vertex in Vertices)
            {
                float projection = (vertex.X * axis.X + vertex.Y * axis.Y) / (float)Math.Sqrt(axis.X * axis.X + axis.Y * axis.Y);
                if (projection < min)
                    min = projection;
                if (projection > max)
                    max = projection;
            }
            return (min, max);
        }

        // Method to check if two projections overlap
        public static bool ProjectionsOverlap((float min, float max) proj1, (float min, float max) proj2)
        {
            return !(proj1.max < proj2.min || proj2.max < proj1.min);
        }

        // Method to check for collision between two polygons using SAT
        public static bool CheckCollision(Polygon poly1, Polygon poly2)
        {
            List<PointF> edges = new List<PointF>();
            edges.AddRange(poly1.GetEdges());
            edges.AddRange(poly2.GetEdges());

            foreach (var edge in edges)
            {
                PointF axis = new PointF(-edge.Y, edge.X); // Perpendicular axis
                var proj1 = poly1.ProjectOnAxis(axis);
                var proj2 = poly2.ProjectOnAxis(axis);

                if (!ProjectionsOverlap(proj1, proj2))
                {
                    return false; // Separating axis found, no collision
                }
            }
            return true; // No separating axis found, collision detected
        }
    }
    #endregion
}
