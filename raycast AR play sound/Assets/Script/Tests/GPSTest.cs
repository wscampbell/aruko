using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GPSTest
    {
        GPSPolygon polygon = new GPSPolygon(new List<GPSPoint>());
        GPSPoint east, west, north, center;

        [SetUp]
        public void before()
        {
            west = new GPSPoint(-1, 0);
            east = new GPSPoint(1, 0);
            north = new GPSPoint(0, 1);
            center = new GPSPoint(0, 0);
        }

        [Test]
        public void orientationClockwiseTest()
        {
            Assert.AreEqual(1, polygon.orientation(north, center, west));
        }

        [Test]
        public void orientationCounterClockwiseTest()
        {
            Assert.AreEqual(-1, polygon.orientation(west, center, north));
        }

        [Test]
        public void orientationColinearTest()
        {
            GPSPoint point0 = new GPSPoint(0, 0);
            GPSPoint point1 = new GPSPoint(1, 1);
            GPSPoint point2 = new GPSPoint(2, 2);
            Assert.AreEqual(0, polygon.orientation(east, west, center));
        }

        [Test]
        public void additionTest()
        {
            Assert.AreEqual(new GPSPoint(1, 1), north + east);
        }
    }
}
