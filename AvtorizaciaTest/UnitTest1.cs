using Microsoft.VisualStudio.TestTools.UnitTesting;
using moduls;

namespace AvtorizaciaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = "ste";
            string b = "123";
            int A = 4;
            Autorizacia autorizacia = new Autorizacia();
            int m = autorizacia.Avtorizacia_Click1111111(a,b);
            Assert.AreEqual(A, m);

        }
    }
}
