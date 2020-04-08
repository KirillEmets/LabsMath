using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public class Vector2
    {
        public float x, y;

        public Vector2(float _x, float _y)
        {
            x = _x;
            y = _y;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        public static Vector2 operator *(Vector2 v1, float n)
        {
            return new Vector2(v1.x * n, v1.y * n);
        }
        public static Vector2 operator *(float n, Vector2 v1)
        {
            return new Vector2(v1.x * n, v1.y * n);
        }
        public static Vector2 operator /(Vector2 v1, float n)
        {
            return new Vector2(v1.x / n, v1.y / n);
        }
        public static Vector2 operator /(float n, Vector2 v1)
        {
            return new Vector2(v1.x / n, v1.y / n);
        }

        public float length
        {
            get { return (float)Math.Sqrt(x * x + y * y); }
        }

        public Vector2 normalized
        {
            get { return this / length; }
        }

        public Vector2 turnOn(float angle)
        {
            return new Vector2(
                (float)(Math.Cos(angle) * x - Math.Sin(angle) * y),
                (float)(Math.Sin(angle) * x + Math.Cos(angle) * y));
        }

        public Point point
        {
            get { return new Point((int)x, (int)y); }
        }

        public static Vector2 FromPoint(Point p)
        {
            return new Vector2(p.X, p.Y);
        }
    }
}
