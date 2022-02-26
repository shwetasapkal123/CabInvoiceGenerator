using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    //Custom Exception
    //Inherite CabinvoiceGeneratorexception from exception class
    public class CabInvoiceGeneratorException:Exception
    {
        public ExceptionType exceptionType;
        //enum for declaring custom exception constant
        public enum ExceptionType
        {
            INVALID_TIME,
            INVALID_DISTANCE,
            NULL_RIDES
        }
        //paramaterized constructor for custom exception
        public CabInvoiceGeneratorException(ExceptionType exceptionType,string msg):base(msg)
        {
            this.exceptionType = exceptionType;
        }
    }
}
