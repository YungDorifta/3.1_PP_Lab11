using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Лаб_11;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //тест операнда + (прибавление целого числа)
        [TestMethod]
        public void TestMethod1()
        {
            Arr Actual = new Arr(new int[] { 10, -5, 4, 19 });
            Actual = Actual + 3;
            Arr Expected = new Arr(new int[] { 13, -2, 7, 22 });
            Assert.AreEqual<Arr>(Expected, Actual, "Результат не соответствует ожидаемому.");
        }

        //тест операнда - (разница двух массивов)
        [TestMethod]
        public void TestMethod2()
        {
            Arr A = new Arr(new int[] { 10, -5, 4, 19 });
            Arr B = new Arr(new int[] { -8, 11 });
            Arr Actual;
            Actual = A - B;
            Arr Expected = new Arr(new int[] { 18, -16, 4, 19 });
            Assert.AreEqual<Arr>(Expected, Actual, "Результат не соответствует ожидаемому.");
        }
        
        //тест метода, заданного по варианту
        [TestMethod]
        public void TestMethod3()
        {
            Arr A = new Arr(new int[] { 33, -1, -9, -10, 0 });
            A.the_variant_method();
            Arr Actual = A;
            Arr Expected = new Arr(new int[] { -33, 1, 9, 10, 0 });
            Assert.AreEqual<Arr>(Expected, Actual, "Результат не соответствует ожидаемому.");
        }
    }
}
