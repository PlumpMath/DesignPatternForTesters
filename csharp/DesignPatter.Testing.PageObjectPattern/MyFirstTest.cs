using NUnit.Framework;

namespace DesignPatter.Testing.PageObjectPattern
{
    [TestFixture]
    public class MyFirstTest
    {
        [Test]
        public void Test()
        {
            int result = 5 + 3;
            Assert.AreEqual(8, result);
        }
    }
}
