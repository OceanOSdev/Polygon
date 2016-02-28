using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonTesting.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void isPolygonTest()
        {
            Line[] lines = new Line[] {
                new Line(new Point(3,7), new Point(7,13)),
                new Line(new Point(7,13), new Point(13,4)),
                new Line(new Point(13,4), new Point(4,11)),
                new Line(new Point(4,11), new Point(11,3))
            };

            Line[] square = new Line[]
            {
                new Line(new Point(0,0), new Point(1,0)),
                new Line(new Point(1,0), new Point(1,1)),
                new Line(new Point(1,1), new Point(0,1)),
                new Line(new Point(0,1), new Point(0,0))
            };

            Line[] pentagon = new Line[]
            {
                new Line(new Point(0,0), new Point(-1,1)),
                new Line(new Point(-1,1), new Point(1,2)),
                new Line(new Point(1,2), new Point(2,1)),
                new Line(new Point(2,1), new Point(1,0)),
                new Line(new Point(1,0), new Point(0,0))
            };

            Line[] hexagon = new Line[]
            {
                new Line(new Point(0,0), new Point(-1,1)),
                new Line(new Point(-1,1), new Point(0,2)),
                new Line(new Point(0,2), new Point(1,2)),
                new Line(new Point(1,2), new Point(2,1)),
                new Line(new Point(2,1), new Point(1,0)),
                new Line(new Point(1,0), new Point(0,0))
            };

            Line[] septagon = new Line[]
            {
                new Line(new Point(0,0), new Point(-2,1)),
                new Line(new Point(-2,1), new Point(-1,2)),
                new Line(new Point(-1,2), new Point(0,3)),
                new Line(new Point(0,3), new Point(1,2)),
                new Line(new Point(1,2), new Point (2,1)),
                new Line(new Point(2,1), new Point(1,0)),
                new Line(new Point(1,0), new Point(0,0))
            };

            Line[] VSLogo = new Line[]
            {
                new Line(new Point(0,0), new Point(0,1)),
                new Line(new Point(0,1), new Point(2,0)),
                new Line(new Point(2,0), new Point(2,1)),
                new Line(new Point(2,1), new Point(0,0))
            };

            Assert.IsTrue(Program.isPolygon(square));
            Assert.IsTrue(Program.isPolygon(pentagon));
            Assert.IsTrue(Program.isPolygon(hexagon));
            Assert.IsTrue(Program.isPolygon(septagon));
            Assert.IsFalse(Program.isPolygon(lines));
            Assert.IsFalse(Program.isPolygon(VSLogo));
        }
    }
}