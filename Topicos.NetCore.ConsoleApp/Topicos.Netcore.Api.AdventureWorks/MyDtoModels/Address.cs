using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Topicos.Netcore.Api.AdventureWorks.MyDtoModels
{
    public partial class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryRegion { get; set; }
        public string PostalCode { get; set; }
    }
}
