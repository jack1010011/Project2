using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Netcore.Api.AdventureWorks.MyDtoModels
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public bool NameStyle { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string CustomerAddressesAddressType { get; set; }
        public IList<Address> CustomerAddressesAddress { get; set; }

    }
}
