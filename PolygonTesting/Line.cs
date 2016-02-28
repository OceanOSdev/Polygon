using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTesting
{
    public class Line
    {
        private readonly Point left, right;

        public Line(Point l, Point r)
        {
            if (l.X < r.X)
            {
                left = l;
                right = r;
            }
            else if( l.X > r.X)
            {
                left = r;
                right = l;
            }
            else
            {
                left = (l.Y < r.Y) ? l : r;
                right = (r.Y < l.Y) ? r : l;
            }
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) ^ left.GetHashCode();
            hash = (hash * 7) ^ right.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            Line other = obj as Line;
            if (other != null)
            {
                return other.LeftMost.Equals(LeftMost) && other.RightMost.Equals(RightMost);
            }
            return false;
        }

        public override string ToString() => $"{{{LeftMost.ToString()} : {RightMost.ToString()} }}";

        public static bool operator ==(Line a, Line b) => a.Equals(b);
        public static bool operator !=(Line a, Line b) => !a.Equals(b);


        public Point LeftMost { get { return left; } }
        public Point RightMost { get { return right; } }
    }
}
