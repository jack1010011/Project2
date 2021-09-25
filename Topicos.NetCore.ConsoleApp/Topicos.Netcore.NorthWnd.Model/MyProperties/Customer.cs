using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.Netcore.NorthWnd.Model.MyModels
{
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
                var elLastName = this.LastName + " ";
                var elSuffix = string.Empty;
                if (this.Suffix != null)
                {
                    elSuffix = this.Suffix;
                }
                var elResultado = $"{elTitle}{elFirstName}{elMiddleName}{elLastName}{elSuffix}";

                return elResultado;
            } set { } }
    }
}
