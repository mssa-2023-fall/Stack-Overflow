using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Parquet.Serialization;

namespace BinaryWriterTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WritingToBinaryFile()
        {
            //Assign
            Stream s = new FileStream("binary.bin", FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(s);

            char a = 'a';
            string b = "Letter B!";
            decimal c = decimal.MaxValue;
            Int64 d = Int64.MaxValue;
            Int32 e = Int32.MaxValue;

            //Act
            bw.Write(a);
            bw.Write(b);
            bw.Write(c);
            bw.Write(d);
            bw.Write(e);
            bw.Flush();
            //bw.Close();

            //Assert
            //var testFile = new FileInfo("binary.bin");
            //Stream s2 = new FileStream("binary.bin", FileMode.Open);
            s.Position = 0;
            BinaryReader br = new BinaryReader(s);
            Assert.AreEqual(a, br.ReadChar());
            Assert.AreEqual(b, br.ReadString());
            Assert.AreEqual(c, br.ReadDecimal());
            Assert.AreEqual(d, br.ReadInt64());
            Assert.AreEqual(e, br.ReadInt32());
            br.Close();
        }

        [TestMethod]
        public void CopyFileTest()
        {
            string srcFile = @"C:\test\a.png";
            string desFile = @"C:\test\copy-a.png";
            var br = new BinaryReader(new FileStream(srcFile, FileMode.Open));
            var bw = new BinaryWriter(new FileStream(desFile, FileMode.OpenOrCreate));
            bw.Write(br.ReadBytes((int)br.BaseStream.Length));
            bw.Flush();
            bw.Close();
            br.Close();

            var testSource = new BinaryReader(new FileStream(srcFile, FileMode.Open));
            var testDest = new BinaryReader(new FileStream(desFile, FileMode.Open));
            CollectionAssert.AreEqual(
                testSource.ReadBytes((int)testSource.BaseStream.Length), 
                testDest.ReadBytes((int)testDest.BaseStream.Length));
        }

        [DataTestMethod]
        [DataRow(@"1, 1928, 44, ""Emil Jannings"", ""The Last Command, The Way of All Flesh""")]
        //[DataRow(@"1, 1928, 44, ""Emil Jannings"", ""The Last Command The Way of All Flesh""")] //Removed the comma in Movie Name

        public void TestParsingStringToWinner(string input)
        {
            //Assign | Act
            Winner w = new Winner(input);

            //Assert
            Assert.AreEqual(1, w.Index);
            Assert.AreEqual(1928, w.Year);
            Assert.AreEqual(44, w.Age);
            Assert.AreEqual("Emil Jannings", w.Name);
            Assert.AreEqual("The Last Command, The Way of All Flesh", w.Movie);
        }

        [TestMethod]
        public void CreateAListFromCSV()
        {
            //Assign
            List<Winner> actors = new List<Winner>();
            StreamReader sr = new StreamReader(@"C:\test\oscar_age_male.csv");
            string line;
            
            //Act
            sr.ReadLine(); // Skip headers
            while ((line = sr.ReadLine()) != null)
                if(10 < line.Length) actors.Add(new Winner(line));

            //Assert
            Assert.IsNotNull(actors);
            Assert.AreEqual(89, actors.Count);
            Assert.AreEqual(76, actors.Max(w => w.Age));
            Assert.AreEqual(29, actors.Min(w => w.Age));
            Assert.AreEqual(1928, actors.Min(w => w.Year));
            var repeatedActors = actors.GroupBy(actor => actor.Name)
                .Select(g => new { Actor = g.Key, Movies = g.Count() })
                .Where(g => g.Movies > 1)
                .ToList();
            foreach (var a in repeatedActors) Console.WriteLine($"{a.Actor} has {a.Movies} Movies made");
            Assert.AreEqual(9, repeatedActors.Count);

            var sw = new StreamWriter(@"C:\test\top-actors.csv");
            sw.WriteLine($"{"Actor",20}, {"Number of Oscars",20}");
            foreach(var a in repeatedActors) sw.WriteLine($"{a.Actor, 20},{a.Movies, 19}");
            sw.Close();
        }
        [TestMethod]
        public void CreateAList_CSVReader()
        {
            //Assign
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                BadDataFound = null,
                Quote = '"',
                Delimiter = ", ",
            };
            IEnumerable<Winner> records;
            Winner w;
            List<Winner> winners;
            using (var reader = new StreamReader(@"C:\test\oscar_age_male.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                records = csv.GetRecords<Winner>();
                winners = records.ToList();
                w = winners[0];
            }
            ParquetSerializer.SerializeAsync(winners, @"C:\test\winner.parquet").Wait();

            //Assert
            Assert.AreEqual(1, w.Index);
            Assert.AreEqual(1928, w.Year);
            Assert.AreEqual(44, w.Age);
            Assert.AreEqual("Emil Jannings", w.Name);
            Assert.AreEqual("The Last Command, The Way of All Flesh", w.Movie);

        }

        [TestMethod]
        public void DeserializeParquet()
        {
            IList<Winner> winners =
                ParquetSerializer.DeserializeAsync<Winner>(new FileStream(@"C:\test\winner.parquet", FileMode.Open)).Result;
        }
    }
}