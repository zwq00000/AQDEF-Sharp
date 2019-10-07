using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQDEF.Sharp.Models;
using AQDEF.Sharp.Parses;
using NUnit.Framework;
using Assert = Xunit.Assert;

namespace AQDEF.Tests {
    public class AQDEFParseTests {
        private AqdefObjectModel parse(String dfq) {
            var parser = new AqdefParser();
            return parser.parse(dfq);
        }

        [Test]
        public void TestParse() {
            AqdefObjectModel model = parse(Samples.dfqWithString);

            PartEntries entries = model.getPartEntries(1);
            Assert.True(entries.getValue<string>("K1001") == "part",
                "K-key entries of type String are parsed correctly");
            Console.WriteLine($"{entries}  Count:{entries.Count}");
        }
    }
}
