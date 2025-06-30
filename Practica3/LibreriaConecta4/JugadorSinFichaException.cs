using System;
using System.Runtime.Serialization;

namespace PSS.lhm232.ConectaCuatro
{
    [Serializable]
    public class JugadorSinFichaException : Exception
    {
        public JugadorSinFichaException()
        {
        }

        public JugadorSinFichaException(string message) : base(message)
        {
        }

        public JugadorSinFichaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public JugadorSinFichaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
