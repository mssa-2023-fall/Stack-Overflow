namespace LearnImmutable
{
    [TestClass]
    public class SampleRecordTest
    {
        [TestMethod]
        public void TestEqualParams()
        {
            //Arange
            SampleRecord r1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord r2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //Assert
            Assert.AreEqual(r1, r2);
            Assert.AreNotSame(r1, r2);
        }
        [TestMethod]
        public void TestDiffParams()
        {
            //Arange
            SampleRecord r1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord r2 = new SampleRecord(ParamString: "Tess", ParamInt: 3, ParamDate: new DateTime(2023, 4, 5));

            //Assert
            Assert.AreNotEqual(r1, r2);
            Assert.AreNotSame(r1, r2);
        }
        [TestMethod]
        public void TestSamePosition()
        {
            //Arange
            SampleRecord r1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord r2 = r1;

            //Assert
            Assert.AreEqual(r1, r2);
            Assert.AreSame(r1, r2);
        }
        [TestMethod]
        public void TestRecordByProperty()
        {
            //arrange
            SampleRecord r1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreEqual("Test", r1.ParamString);
            Assert.AreEqual(1, r1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9 , 5), r1.ParamDate);

        }
        [TestMethod]
        public void TestPeople()
        {
            Person pvt = new Person("Leo", "K.");
            Person sgt = new Person("Johnny B.", "Goode");

            Assert.AreNotEqual(pvt, sgt);
        }
    }
}