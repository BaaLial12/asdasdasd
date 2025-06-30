using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.lhm232.Practica05
{

    /// <summary>
    /// Tipo de dato Enumerado con los distintos campos que integran el registro
    /// </summary>
    public enum CamposRegistro { Id, Nombre, PalabraPaso, Categoria, EsValido };
    public class FormatoRegistro
    {
        /// <summary>
        /// Array de CamposRegistro que contiene la secuencia ordenada de los campos 
        /// </summary>
        private CamposRegistro[] _camposRegistro;
        public CamposRegistro[] CamposRegistro
        {
            get { return _camposRegistro; }
            set { _camposRegistro = value; }
        }
        /// <summary>
        /// En el constructor se estable la secuencia de campos ordenada
        /// </summary>
        /// <param name="camposRegistro">array con la secuencia de los campos</param>
        public FormatoRegistro(CamposRegistro[] camposRegistro)
        {
            _camposRegistro = camposRegistro;
        }
    }
}
