using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class CabInvoiceTestCases
    {
        //Arrange
        //public CabInvoiceGeneratorCalculateFare calculatefare;

        //[TestInitialize]
        //public void SetUp()
        //{
        //   double fareCalculated = calculatefare.CalculateFare(10, 15);
        //}
        [TestMethod]
        [TestCategory("CalculateFare")]
        [DataRow(10,15,160)]
        public void GivenPositiveTimeAndDateReturnTotalFare(int time,double distance,double expected)
        {
            //Arrange
            CabInvoiceGeneratorCalculateFare calculatefare=new CabInvoiceGeneratorCalculateFare();
         //Act
         double actual=calculatefare.CalculateFare(time,distance);

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
