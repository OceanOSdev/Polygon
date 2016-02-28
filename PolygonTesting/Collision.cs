using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTesting
{
    public static class GrossGlobalMethods
    {
        /// <summary>
        /// Test whether two line segments intersect. If so, calculate the intersection point.
        /// <see cref="http://stackoverflow.com/a/565282"/>
        /// </summary>
        /// <param name="p">Point to the start point of p.</param>
        /// <param name="p2">Point to the end point of p.</param>
        /// <param name="q">Point to the start point of q.</param>
        /// <param name="q2">Point to the end point of q.</param>
        /// <param name="intersection">The point of intersection, if any.</param>
        /// <param name="considerOverlapAsIntersect">Do we consider overlapping lines as intersecting?
        /// </param>
        /// <returns>True if an intersection point was found.</returns>
        public static bool LineSegementsIntersect(Point p, Point p2, Point q, Point q2,
            out Point intersection, bool considerCollinearOverlapAsIntersect = false)
        {
            if (p == null || p2 == null || q == null || q2 == null)
                throw new ArgumentException("Points cannot be null");


            intersection = new Point();
            Point r = p2 - p;
            Point s = q2 - q;
            double rxs = r.Cross(s);
            double qpxr = (q - p).Cross(r);

            // If r x s = 0 and (q - p) x r = 0, then the two lines are collinear.
            if (Math.Abs(rxs) < double.Epsilon && Math.Abs(qpxr) < double.Epsilon)
            {
                // 1. If either  0 <= (q - p) * r <= r * r or 0 <= (p - q) * s <= * s
                // then the two lines are overlapping,
                if (considerCollinearOverlapAsIntersect)
                    if ((0 <= (q - p) * r && (q - p) * r <= r * r) || (0 <= (p - q) * s && (p - q) * s <= s * s))
                        return true;

                // 2. If neither 0 <= (q - p) * r = r * r nor 0 <= (p - q) * s <= s * s
                // then the two lines are collinear but disjoint.
                // No need to implement this expression, as it follows from the expression above.
                return false;
            }

            // 3. If r x s = 0 and (q - p) x r != 0, then the two lines are parallel and non-intersecting.
            if (rxs == 0 && qpxr !=0)
                return false;

            // t = (q - p) x s / (r x s)
            double t = (q - p).Cross(s) / rxs;

            // u = (q - p) x r / (r x s)

            double u = (q - p).Cross(r) / rxs;

            // 4. If r x s != 0 and 0 <= t <= 1 and 0 <= u <= 1
            // the two line segments meet at the point p + t r = q + u s.
            if (rxs != 0 && (0 <= t && t <= 1) && (0 <= u && u <= 1))
            {
                // We can calculate the intersection point using either t or u.
                intersection = p + t * r;

                // An intersection was found.
                return true;
            }

            // 5. Otherwise, the two line segments are not parallel but do not intersect.
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <param name="intersection"></param>
        /// <param name="considerCollinearOverlapAsIntersect"></param>
        /// <returns></returns>
        public static bool LineSegementsIntersect(Line l1, Line l2, out Point intersection, bool considerCollinearOverlapAsIntersect = false)
        {
            intersection = new Point();
            if (l1.RightMost.Equals(l2.RightMost) || l2.LeftMost.Equals(l1.LeftMost) || l1.RightMost.Equals(l2.LeftMost) || l2.LeftMost.Equals(l1.RightMost))
                return false;
            return LineSegementsIntersect(l1.LeftMost, l1.RightMost, l2.LeftMost, l2.RightMost, out intersection, considerCollinearOverlapAsIntersect);
        }
    }
}
