using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.NetCore.Mensajeria.BL
{
    /// <summary>
    /// Esta interface se encarga de enviar y recibir mensajes.
    /// es para el curso de tópicos
    /// </summary>
    public interface IMensajeria
    {
        /// <summary>
        /// Para enviar el mensaje
        /// </summary>
        /// <param name="elMensaje">Mensaje para enviar</param>
        public void Enviar(Mensaje elMensaje);

        /// <summary>
        /// Para leer los mensajes de un buzón
        /// </summary>
        /// <param name="Propietario">nombre del dueño del recipiente del que se quieren leer los mensajes</param>
        /// <returns>Lista de todos los mensajes del buzón</returns>
        public IList<Mensaje> Leer(string Propietario);

    }
}
