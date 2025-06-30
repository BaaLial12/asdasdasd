using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using PSS.lhm232.Practica_05;

namespace PSS.lhm232.Practica05
{
    public interface IAutentificacion
    {
        CodigoAutentificacion EsUsuarioAutentificado(string id, string PalabraPaso);
        bool ModificarUsuario(string id, IUsuarioView user);
        bool InsertarUsuario(IUsuarioView user);
        bool EliminarUsuario(string id);
        IUsuarioView ObtenerUsuario(string id);
        void GuardarDatos();
    }


}
