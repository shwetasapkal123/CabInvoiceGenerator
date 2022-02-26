using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static CabInvoiceGenerator.CabInvoiceGeneratorCalculateFare;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest
    {
        [TestClass]
        public class InvoiceGeneratorTest
        {
            public CabInvoiceGeneratorCalculateFare premium;
            public CabInvoiceGeneratorCalculateFare normal;
            [TestInitialize]
            public void Setup()
            {
                normal = new CabInvoiceGeneratorCalculateFare(Ride.NORMAL);
                premium = new CabInvoiceGeneratorCalculateFare(Ride.PREMIUM);
            }
            /* Test Methods For UC-1 And Uc-5
             * RideType- NORMAL And PREMIUM.
             */
            [TestMethod]
            [TestCategory("NormalRideFare")]
            public void GivenDistanceAndTime_ShouldReturnTotalFareForNormalRide()
            {
                double excepted = 25.0;
                double distance = 2.0;
                int time = 5;
                CabInvoiceGeneratorCalculateFare invoice = new CabInvoiceGeneratorCalculateFare(Ride.NORMAL);
                double fare = invoice.CalculateFare(time, distance);
                Assert.AreEqual(excepted, fare);
            }
            [TestMethod]
            [TestCategory("PremiumRideFare")]
            public void GivenDistanceAndTime_ShouldReturnTotalFareForPremiumRide()
            {
                double excepted = 40.0;
                double distance = 2.0;
                int time = 5;
                CabInvoiceGeneratorCalculateFare invoice = new CabInvoiceGeneratorCalculateFare(Ride.PREMIUM);
                double fare = invoice.CalculateFare(time, distance);
                Assert.AreEqual(excepted, fare);
            }
            [TestMethod]
            [TestCategory("NegativeDistanceValue")]
            public void GivenNegativeDistance_ShouldReturnInvalidDistanceException()
            {
                string expected = "Distance Cann't be Negative";
                double distance = -1.0;
                int time = 5;
                try
                {
                    double fare = normal.CalculateFare(time, distance);
                }
                catch (CabInvoiceGeneratorException ex)
                {
                    Assert.AreEqual(expected, ex.Message);
                }
            }
            [TestMethod]
            [TestCategory("NegativeTimeValue")]
            public void GivenNegativeTime_ShouldReturnInvalidTimeException()
            {
                string expected = "Time Cann't be Negative";
                double distance = 3.0;
                int time = -5;
                try
                {
                    double fare = premium.CalculateFare(time, distance);
                }
                catch (CabInvoiceGeneratorException ex)
                {
                    Assert.AreEqual(expected, ex.Message);
                }
            }
            /* Test Methods For UC-2
             * Multiple Ride
             */
            [TestMethod]
            [TestCategory("MltipleRideFareForNormalRideType")]
            public void GivenMultipleRide_ShouldReturnTotalAggregateFareForNormalRide()
            {
                RideType[] rides = { new RideType(5, 3.0), new RideType(10, 4.0) };
                double expected = 85.0;
                double actual = normal.MultipleRide(rides);
                Assert.AreEqual(expected, actual);
            }
            [TestMethod]
            [TestCategory("MltipleRideFareForPremiumRideType")]
            public void GivenMultipleRide_ShouldReturnTotalAggregateFareForPremiumRide()
            {
                RideType[] rides = { new RideType(5, 2.0), new RideType(10, 3.0) };
                double expected = 105.0;
                double actual = premium.MultipleRide(rides);
                Assert.AreEqual(expected, actual);
            }
            [TestMethod]
            [TestCategory("NullRide")]
            public void GivenNullRide_ShouldReturnNullRideException()
            {
                RideType[] rides = { };
                string expected = "Null Ride";
                try
                {
                    double actual = premium.MultipleRide(rides);
                }
                catch (CabInvoiceGeneratorException ex)
                {
                    Assert.AreEqual(expected, ex.Message);
                }
            }
            //UC4
            [TestMethod]
            [TestCategory("Enhanced Invoice For Normal Ride")]
            public void GivenUserId_ShouldReturnInvoiceForUser()
            {
                RideType[] rides = { new RideType(5,3.0), new RideType(10,4.0) };
                double totalfare = 85.0;
                InvoiceSummary invoiceSummary = new InvoiceSummary(rides.Length, totalfare);
                User expected = new User("Shweta", invoiceSummary);
                User actual = normal.InvoiceService(rides, "Shweta");
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
