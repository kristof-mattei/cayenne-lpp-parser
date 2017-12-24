using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parser.Tests
{
    using System.Collections.Generic;
    using SensorReadings;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var hex = "03 67 01 10 05 67 00 FF".Replace(" ", "");

            List<IBase> list = Class1.Convert(hex);

            Assert.IsInstanceOfType(list[0], typeof(TemperatureSensor));
            Assert.IsInstanceOfType(list[1], typeof(TemperatureSensor));

            Assert.
        }
    }
}
