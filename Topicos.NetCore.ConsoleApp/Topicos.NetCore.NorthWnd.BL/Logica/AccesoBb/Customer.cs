using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.Netcore.NorthWnd.BL.Logica.AccesoBd
{
    public class Customer
    {
        private static Model.MyModels.AdventureWorksLT2019Context elContexto = new Model.MyModels.AdventureWorksLT2019Context();

        public Model.MyModels.Customer BuscarPorId (int customerId)
        {
            Model.MyModels.Customer resultado;
            // resultado = elContexto.Customers.Find(customerId);
            resultado = elContexto.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            return resultado;
        }

        public IList<Model.MyModels.Customer> BuscarPorNombreAproximadoDelStateProvince (string nombreAproximadoDelPais)
        {
            IList<Model.MyModels.Customer> resultado;
            using (var _elContexto = new Model.MyModels.AdventureWorksLT2019Context())
            {
                var laConsulta = _elContexto.Customers.Include(c => c.CustomerAddresses).ThenInclude(ca => ca.Address).Where(c => c.CustomerAddresses.Any(ca => ca.Address.StateProvince.Contains(nombreAproximadoDelPais))).OrderByDescending(c => c.Phone);
                resultado = laConsulta.ToList();
            }
            return resultado;
        }

        public IList<Model.MyModels.Customer> BuscarPorNombreAproximadoConErrores(string nombreAproximado)
        {
            IList<Model.MyModels.Customer> resultado;
            using (var _elContexto = new Model.MyModels.AdventureWorksLT2019Context())
            {
                resultado = _elContexto.Customers.Where(c => c.FullName.Contains(nombreAproximado)).OrderByDescending(c => c.Phone).ToList();
            }
            return resultado;
        }

        public IList<Model.MyModels.Customer> BuscarPorNombreAproximado(string nombreAproximado)
        {
            IList<Model.MyModels.Customer> temporal;
            using (var _elContexto = new Model.MyModels.AdventureWorksLT2019Context())
            {
                temporal = _elContexto.Customers.OrderByDescending(c => c.Phone).ToList().Where(c => c.FullName.Contains(nombreAproximado)).ToList();
            }
            var resultado = temporal;
            return resultado;
        }


    }
}
