using System;
using System.Collections.Generic;
using MDPyramid;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var PD = new ProcessData();

                var r1 = PD.FindMax(getPyramid());
                Assert.AreEqual(1, r1.StepsGroups.Count);
                Assert.AreEqual(16, r1.Sum);

                var r2 = PD.FindMax(getPyramid2());
                Assert.AreEqual(1, r2.StepsGroups.Count);
                Assert.AreEqual(22, r2.Sum);

                var r3 = PD.FindMax(getPyramid3());
                Assert.AreEqual(1, r3.StepsGroups.Count);
                Assert.AreEqual(114, r3.Sum);

                var r4 = PD.FindMax(getPyramid4());
                Assert.AreEqual(2, r4.StepsGroups.Count);
                Assert.AreEqual(20, r4.Sum);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [TestMethod]
        public void Tst()
        {
            var a = 10 % 2 != 0;
        }

        private List<List<int>> getPyramid() //1 8 5 2 = 16
        {
            return new List<List<int>>()
            {
                new List<int>()     { 1 },
                new List<int>()    { 8, 9 },
                new List<int>()  { 1, 5, 9 },
                new List<int>() { 4, 5, 2, 3 }
            };
        }

        private List<List<int>> getPyramid2() //1 8 9 4 = 22
        {
            return new List<List<int>>()
            {
                new List<int>()    { 1 },
                new List<int>()   { 8, 8 },
                new List<int>()  { 9, 5, 9 },
                new List<int>() { 4, 3, 2, 5 }
            };
        }

        private List<List<int>> getPyramid3() //1 8 5 100 = 114
        {
            return new List<List<int>>()
            {
                new List<int>()    { 1 },
                new List<int>()   { 8, 3 },
                new List<int>()  { 9, 5, 9 },
                new List<int>() { 4, 3, 100, 5 }
            };
        }

        private List<List<int>> getPyramid4() //20 (1 8 9 2 || 1 2 9 8)
        {
            return new List<List<int>>()
            {
                new List<int>()    { 1 },
                new List<int>()   { 8, 2 },
                new List<int>()  { 9, 8, 9 },
                new List<int>() { 2, 3, 1, 8 }
            };
        }
    }
}
