using NUnit.Framework;

namespace TaskSystemApiTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Method intentionally left empty.
        }

        [Test]
        public void Test1()
        {
            var one = 1;
            Assert.That(one, Is.EqualTo(1).Within(0.0001));
        }
    }
}