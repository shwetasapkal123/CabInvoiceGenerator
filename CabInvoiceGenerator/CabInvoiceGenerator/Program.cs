using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WEL-COME to Cab Service");

            CabInvoiceGeneratorCalculateFare cabInvoiceGenerator = new CabInvoiceGeneratorCalculateFare(CabInvoiceGeneratorCalculateFare.Ride.NORMAL);
            double calculatedFare=cabInvoiceGenerator.CalculateFare(10, 25);
            Console.WriteLine(calculatedFare);

            RideType[] multiRides = { new RideType(20, 15), new RideType(20, 25) };
            Console.WriteLine("Aggregate total fare is: ");
            Console.Write(cabInvoiceGenerator.MultipleRide(multiRides));
            Console.ReadLine();
        }
    }
}
