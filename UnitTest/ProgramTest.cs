using ConsoleApp4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void SimpleProcessTest()
        {
            const string text = @"1,2,3,4.5
3,5.5,1,7
4, 5.g, p, h
3, 4, 5 , 6";
            var c = Program.ProcessText(text);
            Assert.AreEqual(4, c.lineNumberWithMaxSum);
            Assert.AreEqual(1, c.wrongFormatLineNumbers.Count);
            Assert.AreEqual(3, c.wrongFormatLineNumbers[0]);
        }

        [TestMethod]
        public void DoubleMaxTest()
        {
            const string text = @"1,2,3,4.5
5, 4, 3 ,        6
4, 5.g, p, h
3, 4, 5 , 6";
            var c = Program.ProcessText(text);
            Assert.AreEqual(2, c.lineNumberWithMaxSum);
            Assert.AreEqual(1, c.wrongFormatLineNumbers.Count);
            Assert.AreEqual(3, c.wrongFormatLineNumbers[0]);
        }

        [TestMethod]
        public void WrongLinesTest()
        {
            const string text = @"1,2g,3,4.5
5l, 4, 3 ,        6
4, 5.g, p, h
3..5, 4, 5 , 6";
            var c = Program.ProcessText(text);
            Assert.AreEqual(-1, c.lineNumberWithMaxSum);
            Assert.AreEqual(4, c.wrongFormatLineNumbers.Count);
            
        }

        [TestMethod]
        public void WrongSeparatorTest()
        {
            const string text = @"1`3,2g,3,4.5
5, 4, 3 ,,        6
4, 5.g, p, h
3.5, 4, 5 , 6";
            var c = Program.ProcessText(text);
            Assert.AreEqual(4, c.lineNumberWithMaxSum);
            Assert.AreEqual(3, c.wrongFormatLineNumbers.Count);

        }

        [TestMethod]
        public void EmptyTest()
        {
            Assert.IsNull(Program.ProcessText(""));
            Assert.IsNull(Program.ProcessText("          "));
            Assert.IsNull(Program.ProcessText(@"       

            "));
        }
    }
}
