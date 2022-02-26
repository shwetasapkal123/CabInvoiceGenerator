using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceGeneratorCalculateFare
    {
        public const int MinimumFare = 5;
        public const int CostPerKM = 10;
        public const int CostPerMinute = 1;
        //Method to calculate Fare for single ride
        public double CalculateFare(int time, double distance)
        {
            double totalFare = 0;
            try
            {
                if (time <= 0)
                    throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.INVALID_TIME, "Invalid Time");

                if (distance <= 0)
                    throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                //Formula for calculating Fare for single ride
                totalFare=(distance*CostPerKM)+(time*CostPerMinute);
                return totalFare;
            }
            catch(CabInvoiceGeneratorException excpt)
            {
                throw excpt;
            }
        }
        // UC2 - Method to calculate agreegate fare for multiple rides
        public double CalculateAgreegateFare(RideType[] rides)
        {
            double totalFare = 0;
            if (rides.Length == 0)
                throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.NULL_RIDES, "No Ride Found");
            foreach (var ride in rides)
                totalFare += CalculateFare(ride.time, ride.distance);

            double agreegateFare = Math.Max(totalFare, MinimumFare);
            return agreegateFare;
        }
    }
}
