using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JSONTest
    {
        /*
        static string deadSimpleRegionJSON = @"{
            ""name"":""testname"",
            ""points"":[],
            ""audio"":[],
            ""images""[]
        }";
        */
        static string deadSimpleRegionJSON = "{\"name\":\"testname\",\"points\":[[123.4, 567.8]]}";

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

        static string editourFullJSON = "{\"regions\":[" + editourBeautifulRegionJSON + "," + editourGorgeousRegionJSON + "]}";

        [Test]
        public void JSONTestSimplePasses()
        {
        }

        [Test]
        public void deserializeEditourRegionTest()
        {
            Debug.Log(editourBeautifulRegionJSON);
            EditourRegion editourRegion = JSONHelper.JSONToEditourRegion(editourBeautifulRegionJSON);
            Assert.AreEqual("Beautiful Region", editourRegion.name);
            Assert.AreEqual(3, editourRegion.points.Count);
            Assert.AreEqual(1, editourRegion.audio.Count);
            Assert.AreEqual(3, editourRegion.images.Count);
        }

        [Test]
        public void deadSimpleDeserializeTest()
        {
            Debug.Log(deadSimpleRegionJSON);
            EditourRegion editourRegion = JSONHelper.JSONToEditourRegion(deadSimpleRegionJSON);
            Assert.AreEqual("testname", editourRegion.name);
            //Assert.AreEqual(0, editourRegion.points.Count);
        }

        [Test]
        public void deserializeTestSerializableTest()
        {
            TestSerializable testSerializable = JSONHelper.testSerializable("{\"name\":\"test\",\"num\":1234.5}");
            Assert.AreEqual("test", testSerializable.name);
            Assert.AreEqual(1234.5, testSerializable.num);
        }

        [Test]
        public void literallyJustPrintOutFull()
        {
            Debug.Log(editourFullJSON);
        }
    }
}
