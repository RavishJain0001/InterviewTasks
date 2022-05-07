using KPMG.Interview.TaskThree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KPMG.Interview.Tests.TaskThree
{
    [TestClass]
    public class ChallengeThreeTests
    {
        [TestMethod]
        public void GetValue_Tests()
        {
            var challThree = new ChallengeThree();
            var value = challThree.GetValue("{\"a\":{\"b\":{\"c\":\"d\"}}}", "a/b/c");

            Assert.AreEqual("\"d\"", value);
        }

        [TestMethod]
        public void GetValue_Tests_NestedValue()
        {
            var challThree = new ChallengeThree();
            var value = challThree.GetValue("{\"a\":{\"b\":{\"c\":\"d\"}}}", "a/b");

            Assert.AreEqual("{\"c\":\"d\"}", value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetValue_Tests_NullParameters()
        {
            var challThree = new ChallengeThree();
            var value = challThree.GetValue("", "a/b");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetValue_Tests_InvalidParameters()
        {
            var challThree = new ChallengeThree();
            var value = challThree.GetValue("{\"a\":{\"b\":{\"c\":\"d\"}}}", "a/y");
        }
    }
}