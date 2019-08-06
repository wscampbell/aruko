using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class GPSTest
    {
        GPSPolygon polygon = new GPSPolygon(new List<GPSPoint>());
        static GPSPoint east, west, north, south, center;


        GPSPolygon triangle = new GPSPolygon(new List<GPSPoint>{
            center, east, north
        });

        [SetUp]
        public void before()
        {
            west = new GPSPoint(-1, 0);
            east = new GPSPoint(1, 0);
            north = new GPSPoint(0, 1);
            south = new GPSPoint(0, -1);
            center = new GPSPoint(0, 0);
        }

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
            Assert.False(GeometryHelper.inside(triangle, new GPSPoint(100, 100)));
        }

        [Test]
        public void insideTriangleTest()
        {
            Assert.True(GeometryHelper.inside(triangle, new GPSPoint(0.1, 0.1)));
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
        public void numIntersectionsTest()
        {
            Assert.AreEqual(1, GeometryHelper.countIntersections(triangle, new GPSPoint(0.1, 0.2)));
        }
        // TODO throw error when two or more points are coincident
    }
}
