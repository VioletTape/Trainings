using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTestExamples
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        [ExpectedException(typeof(InvalidDataException), ExpectedMessage = "hey!")]
        public void TestMethod1()
        {
            new MyClass().Foo();
        }
    }

    public class MyClass
    {
        public void Foo()
        {
            throw new InvalidDataException("hey!");
        }
    }
}
