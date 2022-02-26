using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class User
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        public string userId;
        public InvoiceSummary invoiceSummary;
        public User(string userId, InvoiceSummary invoiceSummary)
        {
            this.userId = userId;
            this.invoiceSummary = invoiceSummary;
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
            if (!(obj is User))
                return false;
            User inputObj = (User)obj;
            return this.userId == inputObj.userId && this.invoiceSummary.Equals(inputObj.invoiceSummary);
        }
    }
}
