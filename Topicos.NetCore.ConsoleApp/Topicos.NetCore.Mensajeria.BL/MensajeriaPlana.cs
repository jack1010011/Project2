using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.Mensajeria.BL
{
    public class MensajeriaPlana : IMensajeria
    {

        public void Enviar(Mensaje elMensaje)
        {
            var laAccion = new Logica.Acciones.MensajeriaPlana();
            laAccion.Enviar(elMensaje);
        }

        public IList<Mensaje> Leer(string Propietario)
        {
            var laAccion = new Logica.Acciones.MensajeriaPlana();
            var elResultado = laAccion.Leer(Propietario);
            return elResultado;
        }
    }
}
