using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        //Variables.
        public double totalFare, avgFare;
        public int numOfRides;
        //Parameterized Constructor
        public InvoiceSummary(int numOfRides, double totalFare)
        {
            this.totalFare = totalFare;
            this.numOfRides = numOfRides;
            this.avgFare = totalFare / numOfRides;
        }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is InvoiceSummary))
                return false;
            InvoiceSummary inputObj = (InvoiceSummary)obj;
            return this.numOfRides == inputObj.numOfRides && this.totalFare == inputObj.totalFare && this.avgFare == inputObj.avgFare;
        }
    }
}
