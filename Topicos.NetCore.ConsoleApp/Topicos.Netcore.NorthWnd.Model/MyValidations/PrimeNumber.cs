using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.Netcore.NorthWnd.Model.MyValidations
{
    public class PrimeNumber : ValidationAttribute
    {
        bool _DebeSerPrimo = true;
        public PrimeNumber()
        {

        }
        public PrimeNumber(bool deseoQueSeaPrimo)
        {
            _DebeSerPrimo = deseoQueSeaPrimo;
        }
        public override bool IsValid(object value)
        {
            bool elResultado = RealizarValidacionNumeroPrimo (value);
            if (_DebeSerPrimo && elResultado == true)
                return true;
            if (! _DebeSerPrimo && elResultado == false)
                return true;
            return false;
        }

        public bool RealizarValidacionNumeroPrimo(object value)
        {
            string elNumeroDeTelefono = ConvertirObjectAString(value);
            int elNumeroParaValidar = ObtenerNumeroParaValidar(elNumeroDeTelefono);
            bool elNumeroEsValido = EsNumeroPrimo(elNumeroParaValidar);
            return elNumeroEsValido;
        }

        public string ConvertirObjectAString(object objElNumeroDeTelefono)
        {
            string elNumeroDeTelefono = string.Empty;
            elNumeroDeTelefono = Convert.ToString(objElNumeroDeTelefono);
            return elNumeroDeTelefono;
        }

        public int ObtenerNumeroParaValidar(string elNumeroDeTelefono)
        {
            int resultado = 0;
            string laSeccionParaConvertir = elNumeroDeTelefono.Substring(0, 3);
            resultado = Convert.ToInt32(laSeccionParaConvertir);
            return resultado;
        }
        public bool EsNumeroPrimo (int elNumero)
        {
            bool esPrimo = (elNumero % 2 != 0);
            if (esPrimo)
            {
                int i = 3;
                int elLimite = elNumero / 2;
                while (esPrimo && i < elLimite)
                {
                    esPrimo = (elNumero % i != 0);
                    i += 2;
                }
            }
            return esPrimo;
        }
    }
}
