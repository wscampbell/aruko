using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JSONTest
    {
        static string editourRegionJSON = @"{  
            ""name"":""Beautiful Region"",
            ""points"":[  
                [  
                    35.04025698454798,
                    135.73188900947574
                ],
                [  
                    35.03867580927915,
                    135.7315242290497
                ],
                [  
                    35.039150165072655,
                    135.733197927475
                ],
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

        static string editourFullJSON = "abc123:" + editourRegionJSON;

        [Test]
        public void JSONTestSimplePasses()
        {
        }

        [Test]
        public void deserializeEditourRegionTest()
        {
            EditourRegion editourRegion = JSONHelper.JSONToEditourRegion(editourRegionJSON);
            Assert.Equals("Beautiful Region", editourRegion.name);
        }
    }
}
