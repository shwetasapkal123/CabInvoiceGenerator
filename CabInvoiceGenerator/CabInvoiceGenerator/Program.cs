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

            CabInvoiceGeneratorCalculateFare cabInvoiceGenerator = new CabInvoiceGeneratorCalculateFare();
            double calculatedFare=cabInvoiceGenerator.CalculateFare(0, 25);
            Console.WriteLine(calculatedFare);
            Console.ReadLine();
        }
    }
}
