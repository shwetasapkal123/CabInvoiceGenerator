using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class CabInvoiceTestCases
    {
        [TestMethod]
        [TestCategory("CalculateFare")]
        [DataRow(10,15,160)]        //time distance expected
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
        // TC2.1 - Given multiple rides should return aggregate fare
        [TestMethod]
        [TestCategory("Multiple Rides")]
        public void GivenMultipleRidesReturnAggregateFare()
        {
            //Arrange
            CabInvoiceGeneratorCalculateFare calculateMulRidefare = new CabInvoiceGeneratorCalculateFare();
            double actual, expected = 320;
            RideType[] cabRides = { new RideType(10, 15), new RideType(10, 15) };
            //Act
            actual = calculateMulRidefare.CalculateAgreegateFare(cabRides);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        // TC2.2 - given no rides return custom exception
        [TestMethod]
        [TestCategory("Multiple Rides")]
        public void GivenNoRidesReturnCustomException()
        {
            CabInvoiceGeneratorCalculateFare calculateMulRidefare = new CabInvoiceGeneratorCalculateFare();
            RideType[] cabRides = { };
            var nullRidesException = Assert.ThrowsException<CabInvoiceGeneratorException>(() => calculateMulRidefare.CalculateAgreegateFare(cabRides));
            Assert.AreEqual(CabInvoiceGeneratorException.ExceptionType.NULL_RIDES, nullRidesException.exceptionType);
        }
    }
}
