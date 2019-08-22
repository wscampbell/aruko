using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class JSONTest
    {
        // example region json
        static string editourBeautifulRegionJSON = @"{  
            ""name"":""Beautiful Region"",
            ""points"":[  
                {  
                    ""lat"":35.04025698454798,
                    ""lng"":135.73188900947574
                },
                {  
                    ""lat"":35.03867580927915,
                    ""lng"":135.7315242290497
                },
                {  
                    ""lat"":35.039150165072655,
                    ""lng"":135.733197927475
                }
            ],
            ""audio"":[  
                ""beautiful-tour.mp3""
            ],
            ""images"":[
                ""mountain.jpg"",
                ""hill.jpeg"",
                ""stream.png""
            ]
        }";

        // second example region json
        static string editourGorgeousRegionJSON = @"{  
            ""name"":""Gorgeous Region"",
            ""points"":[  
                {  
                    ""lat"":36.04025698454798,
                    ""lng"":136.73188900947574
                },
                {  
                    ""lat"":36.03867580927915,
                    ""lng"":136.7315242290497
                },
                {  
                    ""lat"":36.039150165072655,
                    ""lng"":136.733197927475
                }
            ],
            ""audio"":[  
                ""gorgeous-tour.mp3""
            ],
            ""images"":[  
                ""valley.jpg"",
                ""gorge.jpeg""
            ]
        }";

        // full tour json
        static string editourTourJSON = "{\"regions\":[" + editourBeautifulRegionJSON + "," + editourGorgeousRegionJSON + "]}";

        static GPSPolygon beautifulPolygon = new GPSPolygon(new List<GPSPoint>{
            new GPSPoint(35.04025698454798, 135.73188900947574),
            new GPSPoint(35.03867580927915, 135.7315242290497),
            new GPSPoint(35.039150165072655, 135.733197927475)
        }, "Beautiful Region");

        static GPSPolygon streetPolygon = new GPSPolygon(new List<GPSPoint>{
            new GPSPoint(34.98019037699369, 135.96342802047732),
            new GPSPoint(34.981693568638946, 135.96348702907565),
            new GPSPoint(34.981684778124745, 135.96386253833774),
            new GPSPoint(34.98018598165605, 135.9637928009033)
        }, "Street");

        [Test]
        public void deserializeEditourRegionTest()
        {
            EditourRegion editourRegion = JSONHelper.JSONToEditourRegion(editourBeautifulRegionJSON);
            Assert.AreEqual("Beautiful Region", editourRegion.name);
            Assert.AreEqual(3, editourRegion.points.Count);
            Assert.AreEqual(1, editourRegion.audio.Count);
            Assert.AreEqual(3, editourRegion.images.Count);
        }

        [Test]
        public void deserializeEditourTourTest()
        {
            EditourTour editourTour = JSONHelper.JSONToEditourTour(editourTourJSON);
            Assert.AreEqual(2, editourTour.regions.Count);
            Assert.AreEqual("Beautiful Region", editourTour.regions[0].name);
            Assert.AreEqual("Gorgeous Region", editourTour.regions[1].name);
        }

        [Test]
        public void eCoordToGPSPointTest()
        {
            // deserialize the full tour and test the conversion with that
            EditourTour editourTour = JSONHelper.JSONToEditourTour(editourTourJSON);
            List<GPSPoint> gPoints = JSONHelper.editourCoordsToGPSPoints(editourTour.regions[0].points);
            // test for length
            Assert.AreEqual(3, gPoints.Count);
        }

        [Test]
        public void editourTourToGPSPolygonsTest()
        {
            List<GPSPolygon> gPolygons = JSONHelper.editourTourToGPSPolygons("ritsu-tour");
            Assert.AreEqual(2, gPolygons.Count);
            // check if the Creation Core polygon is correct
            Assert.AreEqual(streetPolygon.ToString(), gPolygons[1].ToString());
        }
    }
}
