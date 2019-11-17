using NUnit.Framework;
using Optional;

namespace OptionalUnitTests
{
    public class OptionalTests
    {
        
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestIfPresent1()
        {
            Optional<string> test = Optional<string>.Of("test");
            
            test.IfPresent(val => Assert.AreEqual("test", val));
        }
        [Test]
        public void TestIfPresent2()
        {
            Optional<string> test = Optional<string>.Of("test");

            test.IfPresent(() => Assert.Pass("IfPresent execute the callback"));

            Assert.Fail("IsPresent didnt executed the callback");
        }
        [Test]
        public void TestIfPresent3()
        {
            Optional<string> test = Optional<string>.Empty();

            test.IfPresent(() => Assert.Fail()).OrElse(() => Assert.Pass());
        }
    }
}