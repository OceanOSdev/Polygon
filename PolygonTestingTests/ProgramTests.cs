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
        public void IsPolygonTest()
        {
            Line[] lines = new Line[]
            {
                new Line(new Point(3, 7), new Point(7, 13)),
                new Line(new Point(7, 13), new Point(13, 4)),
                new Line(new Point(13, 4), new Point(4, 11)),
                new Line(new Point(4, 11), new Point(11, 3))
            };



            Assert.IsFalse(Program.IsPolygon(lines));
        }

        [TestMethod()]
        public void IsPolygonTestSquare()
        {
            Line[] square = new Line[]
            {
                new Line(new Point(0, 0), new Point(1, 0)),
                new Line(new Point(1, 0), new Point(1, 1)),
                new Line(new Point(1, 1), new Point(0, 1)),
                new Line(new Point(0, 1), new Point(0, 0))
            };

            Assert.IsTrue(Program.IsPolygon(square));

        }

        [TestMethod()]
        public void IsPolygonTestPentagon()
        {
            Line[] pentagon = new Line[]
            {
                new Line(new Point(0, 0), new Point(-1, 1)),
                new Line(new Point(-1, 1), new Point(1, 2)),
                new Line(new Point(1, 2), new Point(2, 1)),
                new Line(new Point(2, 1), new Point(1, 0)),
                new Line(new Point(1, 0), new Point(0, 0))
            };

            Assert.IsTrue(Program.IsPolygon(pentagon));

        }

        [TestMethod()]
        public void IsPolygonTestHexagon()
        {
            Line[] hexagon = new Line[]
            {
                new Line(new Point(0,0), new Point(-1,1)),
                new Line(new Point(-1,1), new Point(0,2)),
                new Line(new Point(0,2), new Point(1,2)),
                new Line(new Point(1,2), new Point(2,1)),
                new Line(new Point(2,1), new Point(1,0)),
                new Line(new Point(1,0), new Point(0,0))
            };

            Assert.IsTrue(Program.IsPolygon(hexagon));

        }

        [TestMethod()]
        public void IsPolygonTestSeptagon()
        {
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
            Assert.IsTrue(Program.IsPolygon(septagon));


        }

        [TestMethod()]
        public void IsPolygonTestVSLogo()
        {
            Line[] VSLogo = new Line[]
            {
                new Line(new Point(0,0), new Point(0,1)),
                new Line(new Point(0,1), new Point(2,0)),
                new Line(new Point(2,0), new Point(2,1)),
                new Line(new Point(2,1), new Point(0,0))
            };
            Assert.IsFalse(Program.IsPolygon(VSLogo));

        }
    }
}