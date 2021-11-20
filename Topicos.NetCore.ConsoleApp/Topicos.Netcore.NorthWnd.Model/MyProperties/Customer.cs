using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topicos.Netcore.NorthWnd.Model.MyValidations;

namespace Topicos.Netcore.NorthWnd.Model.MyModels
{
    [MetadataType(typeof (CustomerMetadata))]
    public partial class Customer
    {
        [NotMapped]
        public string FullName { 
            get {
                var elTitle = string.Empty;
                if (this.Title != null)
                {
                    elTitle = this.Title + " ";
                }
                var elFirstName = this.FirstName + " ";
                var elMiddleName = string.Empty;
                if (this.MiddleName != null)
                {
                    elMiddleName = this.MiddleName + " ";
                }
                var elLastName = this.LastName;
                var elSuffix = string.Empty;
                if (this.Suffix != null)
                {
                    elSuffix = " " + this.Suffix;
                }
                var elResultado = $"{elTitle}{elFirstName}{elMiddleName}{elLastName}{elSuffix}";

                return elResultado;
            } set { } }
    }

    public class CustomerMetadata
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public bool NameStyle { get; set; }
        [MaxLength(8)]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string Suffix { get; set; }
        [MaxLength(128)]
        public string CompanyName { get; set; }
        [MaxLength(256)]
        public string SalesPerson { get; set; }
        [MaxLength(50)]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [PrimeNumber(false)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(128)]
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

    }
}
