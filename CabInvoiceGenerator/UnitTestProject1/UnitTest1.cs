using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        [TestCategory("CalculateFare")]
        [DataRow(10, 15, 160)]
        public void GivenPositiveTimeAndDateReturnTotalFare(int time, double distance, double expected)
        {
            //Arrange
            CabInvoiceGeneratorCalculateFare calculatefare = new CabInvoiceGeneratorCalculateFare();
            //Act
            double actual = calculatefare.CalculateFare(time, distance);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void GivenInvalidTimeAndDistanceReturnException()
        {
            CabInvoiceGeneratorCalculateFare calculatefare = new CabInvoiceGeneratorCalculateFare();
            var invalidTimeException = Assert.ThrowsException<CabInvoiceGeneratorException>(() => calculatefare.CalculateFare(0, 10));
            Assert.AreEqual(CabInvoiceGeneratorException.ExceptionType.INVALID_TIME, invalidTimeException.exceptionType);
            var invalidDistanceException = Assert.ThrowsException<CabInvoiceGeneratorException>(() => calculatefare.CalculateFare(18, -3));
            Assert.AreEqual(CabInvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, invalidDistanceException.exceptionType);
        }
    }
}
