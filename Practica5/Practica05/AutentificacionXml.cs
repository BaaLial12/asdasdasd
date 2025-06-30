using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using PSS.lhm232.Practica_05;

namespace PSS.lhm232.Practica05
{
    public class AutentificacionXml : IAutentificacion
    {
        private string _xmlFilename;
        private XDocument _xmlDocument;
        private IUsuarioView _usuarioAutentificado;

        public AutentificacionXml(string xmlFile)
        {
            _xmlFilename = xmlFile;
            if (!File.Exists(_xmlFilename))
            {
                throw new AutentificacionExcepcion("El fichero " + xmlFile + " no existe.", CodigoAutentificacion.ErrorDatos);
            }

            try
            {
                _xmlDocument = XDocument.Load(_xmlFilename);
            }
            catch
            {
                throw new AutentificacionExcepcion("Error al acceder al archivo Xml", CodigoAutentificacion.ErrorDatos);
            }
        }

        public bool EliminarUsuario(string id)
        {
            try
            {
                XElement usuxml = (from usu in _xmlDocument.Elements("Usuarios").Elements("Usuario")
                                   where usu.Attribute("Id").Value == id
                                   select usu).First();
                usuxml.Remove();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CodigoAutentificacion EsUsuarioAutentificado(string id, string PalabraPaso)
        {
            IUsuarioView usu = ObtenerUsuario(id);
            if (usu.PalabraPaso != PalabraPaso)
                return CodigoAutentificacion.ErrorPalabraPaso;
            if (!usu.EsValido)
                return CodigoAutentificacion.AccesoInvalido;
            return CodigoAutentificacion.AccesoCorrecto;
        }

        public void GuardarDatos()
        {
            try
            {
                _xmlDocument.Save(_xmlFilename);
            }
            catch (Exception)
            {
                // Manejar la excepción adecuadamente
            }
        }

        public bool InsertarUsuario(IUsuarioView user)
        {
            try
            {
                IUsuarioView usu = ObtenerUsuario(user.Id);
                return false;
            }
            catch (AutentificacionExcepcion)
            {
                XElement usuxml = new XElement("Usuario",
                    new XAttribute("Id", user.Id),
                    new XElement("Nombre", user.Nombre),
                    new XElement("PalabraPaso", user.PalabraPaso),
                    new XElement("Categoria", user.Categoria),
                    new XElement("EsValido", user.EsValido));
                _xmlDocument.Element("Usuarios").Add(usuxml);
                return true;
            }
        }

        public IUsuarioView ObtenerUsuario(string id)
        {
            if (_xmlDocument is null)
            {
                throw new AutentificacionExcepcion("El fichero de datos no se encuentra", CodigoAutentificacion.ErrorDatos);
            }

            try
            {
                var resul = from usu in _xmlDocument.Elements("Usuarios").Elements("Usuario")
                            where usu.Attribute("Id").Value == id
                            select new UsuarioView
                            {
                                Id = usu.Attribute("Id").Value,
                                Nombre = usu.Element("Nombre").Value,
                                PalabraPaso = usu.Element("PalabraPaso").Value,
                                Categoria = usu.Element("Categoria").Value,
                                EsValido = bool.Parse(usu.Element("EsValido").Value)
                            };
                return resul.First();
            }
            catch
            {
                throw new AutentificacionExcepcion("El Id de usuario no existe", CodigoAutentificacion.ErrorIdUsuario);
            }
        }

        public bool ModificarUsuario(string id, IUsuarioView user)
        {
            try
            {
                XElement usuxml = (from usu in _xmlDocument.Elements("Usuarios").Elements("Usuario")
                                   where usu.Attribute("Id").Value == id
                                   select usu).First();
                usuxml.SetElementValue("Nombre", user.Nombre);
                usuxml.SetElementValue("PalabraPaso", user.PalabraPaso);
                usuxml.SetElementValue("Categoria", user.Categoria);
                usuxml.SetElementValue("EsValido", user.EsValido);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
