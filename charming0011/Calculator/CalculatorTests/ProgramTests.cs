using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void mkformulaTest()
        {
            Program p = new Program();
            string test = Program.mkformula();
            //Assert.Fail();
        }

        [TestMethod()]
        public void SolveTest1()
        {
            string formula = "21+3/1";
            string ans = "21+3/1=24";
            string test = Program.Solve(formula);
            Assert.AreEqual(ans, test);
        }

        [TestMethod()]
        public void FileTest()
        {
            string test = "hahaha";
            Assert.IsTrue(Program.File(test) == test);
            //Assert.Fail();
        }
    }
}