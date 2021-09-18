using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.Mensajeria.BL.Logica.Acciones
{
    internal class MensajeriaPlana
    {
        /// <summary>
        /// para enviar mensajes
        /// </summary>
        /// <param name="elMensaje">el mensaje enviado</param>
        public void Enviar(Mensaje elMensaje)
        {
            System.Console.WriteLine($"Mensaje de {elMensaje.Remitente} para {elMensaje.Destinatario}: [{elMensaje.Texto}].");
            //Console.WriteLine(string.Format("Mensaje de {0} para {1}: [{2}].", elMensaje.Remitente, elMensaje.Destinatario, elMensaje.Texto));
        }

        /// <summary>
        /// para leer los mensajes
        /// </summary>
        /// <param name="Propietario">nombre del propietario cuyos mensajes deseamos leer</param>
        /// <returns>la lista de los mensajes</returns>
        public IList<Mensaje> Leer(string Propietario)
        {
            List<Mensaje> elResultado = new List<Mensaje> { new Mensaje("Mi", "Ti", "Hola Mundo") };
            return elResultado;
        }

    }
}
