using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using moduls;

namespace UserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = "ste";
            string b = "12";
            int A = 2;
            Autorizacia autorizacia = new Autorizacia();
            int m = autorizacia.Avtorizacia_Click1111111(a, b);
            Assert.AreEqual(A, m);
        }
    }
}
