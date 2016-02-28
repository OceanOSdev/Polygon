using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTesting
{
    public class Point
    {
        readonly double x, y;

        public Point(double x = double.NaN, double y = double.NaN)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            //return (obj as Point?)?.GetHashCode() == this.GetHashCode(); // Im afraid of collisions
            
            if (obj is Point)
            {
                Point other = (Point)obj;
                return Math.Abs(other.X - X) < 1.0e-20 && Math.Abs(other.Y - Y) < 1.0e-20;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) ^ X.GetHashCode();
            hash = (hash * 7) ^ Y.GetHashCode();
            return hash;
        }

        public override string ToString() => $"({X},{Y})";

        /*public static bool operator ==(Point a, Point b)
        {
            return ((object)a != null && (object)b != null) && (a.X == b.X && a.Y == b.Y);
        }

        public static bool operator !=(Point a, Point b)
        {
            return ((object)a != null && (object)b != null) && (a.X != b.X && a.Y != b.Y);
        }*/

        public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);
        public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
        public static double operator *(Point a, Point b) => (a.X * b.X + a.Y * b.Y);
        
        public static Point operator *(double mult, Point a) => new Point(a.X * mult, a.Y * mult);
        public static Point operator *(Point a, double mult) => mult * a;

        public double Cross(Point other) => X * other.Y - Y * other.X;

        public double X { get { return x; } }
        public double Y { get { return y; } }
    }
}
