using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PSS.lhm232.Practica_04
{
    public class Aplicacion
    {
        private int _id;
        private string _nombreAplicacion;
        private string _path;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string NombreAplicacion
        {
            get { return _nombreAplicacion; }
            set { _nombreAplicacion = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }
}
    