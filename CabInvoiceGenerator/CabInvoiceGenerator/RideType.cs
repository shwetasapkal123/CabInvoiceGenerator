using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideType
    {
        //Instance variables
        public int time;
        public double distance;

        //Constructor for initializing distance and time for every ride
        public RideType(int time, double distance)
        {
            this.time = time;
            this.distance = distance;
        }
    }
}
