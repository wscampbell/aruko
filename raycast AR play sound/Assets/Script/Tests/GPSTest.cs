using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class GPSTest
    {
        GPSPolygon polygon = new GPSPolygon(new List<GPSPoint>());
        static GPSPoint west = new GPSPoint(-1, 0);
        static GPSPoint east = new GPSPoint(1, 0);
        static GPSPoint north = new GPSPoint(0, 1);
        static GPSPoint south = new GPSPoint(0, -1);
        static GPSPoint center = new GPSPoint(0, 0);

        GPSPolygon triangle = new GPSPolygon(new List<GPSPoint>{
            center, east, north
        });

        GPSPolygon square = new GPSPolygon(new List<GPSPoint>{
            north + east, south + east, south + west, north + west
        });

        GPSPolygon notch = new GPSPolygon(new List<GPSPoint>{
            north + east, south + east, 0.8 * north, south + west, north + west
        });

        // if you want a function to run before, use [SetUp]

        [Test]
        public void orientationClockwiseTest()
        {
            Assert.AreEqual(1, GeometryHelper.orientation(north, center, west));
        }

        [Test]
        public void orientationCounterClockwiseTest()
        {
            Assert.AreEqual(-1, GeometryHelper.orientation(west, center, north));
        }

        [Test]
        public void orientationColinearTest()
        {
            Assert.AreEqual(0, GeometryHelper.orientation(east, west, center));
        }

        [Test]
        public void additionTest()
        {
            Assert.AreEqual(new GPSPoint(1, 1), north + east);
        }

        [Test]
        public void multiplicationTest()
        {
            Assert.AreEqual(new GPSPoint(2, 2), 2 * (new GPSPoint(1, 1)));
        }

        [Test]
        public void orientationColinearDiagonalTest()
        {
            GPSPoint diagonal = new GPSPoint(1, 1);
            Assert.AreEqual(0, GeometryHelper.orientation(center, diagonal, 2 * diagonal));
        }

        [Test]
        public void outsideTriangleTest()
        {
            Assert.False(triangle.encompasses(new GPSPoint(100, 100)));
        }

        [Test]
        public void insideTriangleTest()
        {
            Assert.True(triangle.encompasses(new GPSPoint(0.1, 0.1)));
        }

        [Test]
        public void noIntersectionTest()
        {
            Assert.False(GeometryHelper.intersect(north, west, south, east));
        }

        [Test]
        public void intersectionTest()
        {
            Assert.True(GeometryHelper.intersect(north, south, east, west));
        }

        [Test]
        public void borderIntersectionTest()
        {
            Assert.True(GeometryHelper.intersect(north, south, east, center));
        }

        [Test]
        public void numIntersectionsTestInside()
        {
            Assert.AreEqual(1, triangle.countIntersections(new GPSPoint(0.1, 0.2)));
        }

        [Test]
        public void numIntersectionsTestOutsideCross()
        {
            Assert.AreEqual(2, triangle.countIntersections(new GPSPoint(0.5, -0.2)));
        }

        [Test]
        public void outsideNotchTest()
        {
            Assert.False(notch.encompasses(new GPSPoint(0, 0.1)));
        }

        [Test]
        public void insideNotchTest()
        {
            Assert.True(notch.encompasses(new GPSPoint(0.5, 1)));
        }

    }
}
