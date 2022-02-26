using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class CabInvoiceGeneratorCalculateFare
    {
        Dictionary<string, InvoiceSummary> invoiceService = new Dictionary<string, InvoiceSummary>();
        public Ride ride;
        public readonly int MINIMUM_COST;
        public readonly int MINIMUM_COST_PER_KM;
        public readonly int MAXIMUM_COST_PER_MIN;
        //Constructor For Initializing Data as Per RideType.
        public CabInvoiceGeneratorCalculateFare(Ride type)
        {
            this.ride = type;
            try
            {
                //Initializing Data for Normal RideType
                if (this.ride.Equals(Ride.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.MAXIMUM_COST_PER_MIN = 1;
                    this.MINIMUM_COST = 5;
                }
                //Initializing Data for Premium RideType
                if (this.ride.Equals(Ride.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.MAXIMUM_COST_PER_MIN = 2;
                    this.MINIMUM_COST = 20;
                }
            }
            //Exception Catching
            catch (CabInvoiceGeneratorException)
            {
                throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.INVALID_RIDETYPES, "Invaid Ride Type");
            }
        }
        //Method to calculate Fare for single ride
        public double CalculateFare(int time, double distance)
        {
            if (distance <= 0)
                throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, "Distance Cann't be Negative");
            if (time <= 0)
                throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.INVALID_TIME, "Time Cann't be Negative");
            double totalFare = distance * MINIMUM_COST_PER_KM + time * MAXIMUM_COST_PER_MIN;
            //Return Max amount as Fare form total and Minimum Fare.
            return Math.Max(totalFare, MINIMUM_COST);
        }
        // UC2 - Method to calculate agreegate fare for multiple rides
        //Multiple Ride Fare Calculation
        public double MultipleRide(RideType[] rides)
        {
            double totalFare = 0;
            //check Condition for Null Ride and Ride Length.
            if (rides == null || rides.Length == 0)
                throw new CabInvoiceGeneratorException(CabInvoiceGeneratorException.ExceptionType.NULL_RIDES, "Null Ride");
            foreach (RideType ride in rides)
            {
                totalFare += CalculateFare(ride.time, ride.distance);
            }
            return Math.Max(totalFare, MINIMUM_COST);
        }
        //Method to Genetare Enhanced Invoice.
        public InvoiceSummary EnhancedInvoice(RideType[] rides)
        {
            double result = MultipleRide(rides);
            return new InvoiceSummary(rides.Length, result);
        }
        //Method to Get Invoice For a user
        public User InvoiceService(RideType[] rides, string userId)
        {
            InvoiceSummary result = EnhancedInvoice(rides);
            return new User(userId, result);
        }
        //RideType Enum
        public enum Ride
        {
            NORMAL,
            PREMIUM,
        }
    }
}
