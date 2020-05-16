using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ConsoleApp2.Student st = new ConsoleApp2.Student();
            st.rating = 76;
            string s = st.StudentRating(st.rating);
            Assert.AreEqual("Можна вчитися краще", s);
        }
    }
}
