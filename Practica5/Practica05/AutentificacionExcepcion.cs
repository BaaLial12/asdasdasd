using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using PSS.lhm232.Practica05;

namespace PSS.lhm232.Practica_05
{
    public class AutentificacionExcepcion : Exception
    {
        public CodigoAutentificacion Codigo { get; }

        public AutentificacionExcepcion(string message, CodigoAutentificacion codigo) : base(message)
        {
            Codigo = codigo;
        }
    }
   


}
