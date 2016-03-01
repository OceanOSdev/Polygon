using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            //Console.WriteLine(isPolygon(VSLogo));
            Console.ReadKey();
        }

        /// <summary>
        /// Huzzah I finally got this working!!!
        /// </summary>
        /// <param name="lines">The array of lines that make up the polygon</param>
        /// <returns></returns>
        public static bool IsPolygon(Line[] lines)
        {
            lines = lines.OrderBy(x => x.LeftMost.X).ThenBy(x => x.RightMost.X).ToArray();
            List<bool> bIntersects = new List<bool>();
            if (lines.Length < 1)
                throw new ArgumentException("Line array is empty (or you somehow got a negative array, in which case, what?");
            Point pHeap = new Point(); // used for the output param in intersect
            List<Line> lineQueue = new List<Line>();
            lineQueue.Add(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                if (lineQueue.Count != 0)
                {
                    if (lines[i].LeftMost.X >= lineQueue[0].RightMost.X)
                    {
                        lineQueue.RemoveAt(0);
                    }

                    bIntersects.AddRange(lineQueue.Select(x => GrossGlobalMethods.LineSegementsIntersect(x, lines[i], out pHeap)));
                   
                }
                lineQueue.Add(lines[i]);
                
            }
            return !bIntersects.Contains(true);
        }


    }

    

    
}
