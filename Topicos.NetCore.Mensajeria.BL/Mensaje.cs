using System;

namespace Topicos.NetCore.Mensajeria.BL
{
    /// <summary>
    /// clase para envío de mensajes
    /// </summary>
    public class Mensaje
    {
        public Mensaje()
        {

        }

        public Mensaje(string Remitente, string Destinatario,string Texto)
        {
            this.Remitente = Remitente;
            this.Destinatario = Destinatario;
            this.Texto = Texto;
        }

        /// <summary>
        /// nombre de quien envía el mensaje
        /// </summary>
        public string Remitente;
        /// <summary>
        /// nombre de quien recibe el mensaje
        /// </summary>
        public string Destinatario;
        /// <summary>
        /// cuerpo del mensaje
        /// </summary>
        public string Texto;
    }
}
