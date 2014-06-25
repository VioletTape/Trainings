using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
    

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Ahey!!")]
        public void TestMethod1()
        {
            new MyClass().Foo();
        }
    }

    public class MyClass {
        public void Foo() {
            throw new InvalidDataException("hey!");
        }
    }
}
