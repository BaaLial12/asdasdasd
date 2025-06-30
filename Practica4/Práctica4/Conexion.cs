using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PSS.lhm232.Practica_04
{
    public class Conexion
    {
        private int _id;
        private string _ip;
        private DateTime _fechaInicio;
        private double _duracion;
        private int _usuarioCategoriaId;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        public double Duracion
        {
            get { return _duracion; }
            set { _duracion = value; }
        }
        public int UsuarioCategoriaId
        {
            get { return _usuarioCategoriaId; }
            set { _usuarioCategoriaId = value; }
        }
        public Conexion() { }
    }
}