using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.lhm232.Practica_04;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
namespace PSS.lhm232.Practica_04
{
    [TestClass]
    public class TestsConsultasXMLUsuarios
    {
        private XDocument doc = XDocument.Load("C:\\Users\\paula\\source\\Repos\\2022-pss-lhm232-ual\\Práctica4\\datosXML.xml");

        [TestMethod]
        public void Consulta1Usuarios()
        {
            int categoriaId = 0;
            var usuarios = from usu in doc.Descendants("Usuario")
                           join usucat in doc.Descendants("UsuariosCategorias")
                          on (int)usu.Element("Id") equals (int)usucat.Element("UsuarioId")  where (int)usucat.Element("CategoriaId") == categoriaId orderby (string)usu.Element("NombreUsuario")
                           select new vmNombre
                           {
                               Nombre =
                          ((string)usu.Element("NombreUsuario")).ToUpper()
                           };
            Assert.IsNotNull(usuarios);
        }
        [TestMethod]
        public void Consulta2Usuarios()
        {
            string nombreCategoria = "Profesor";
            var usuarios = from usu in doc.Descendants("Usuario")
                           join usucat in doc.Descendants("UsuariosCategorias")
                          on (int)usu.Element("Id") equals (int)usucat.Element("UsuarioId")
                           join cat in doc.Descendants("Categoria") on
                          (int)usucat.Element("CategoriaId") equals (int)cat.Element("Id")
                           where (string)cat.Element("NombreCategoria") ==
                          nombreCategoria
                           orderby (string)usu.Element("NombreUsuario")
                           select new vmNombre
                           {
                               Nombre =
                          ((string)usu.Element("NombreUsuario")).ToUpper()
                           };
            Assert.IsNotNull(usuarios);
        }
        [TestMethod]
        public void Consulta3Usuarios()
        {
            string cadenaComienzo = "J";
            var usuarios = from usu in doc.Descendants("Usuario")
                           where
                          ((string)usu.Element("NombreUsuario")).StartsWith(cadenaComienzo)
                           select new vmNombre
                           {
                               Nombre =
                          ((string)usu.Element("NombreUsuario")).ToUpper()
                           };
            Assert.IsNotNull(usuarios);
        }
        [TestMethod]
        public void Consulta4Usuarios()
        {
            string cadenaComienzo = "D";
            string categoria = "Alumno";
            var usuariosCategorias = from usu in doc.Descendants("Usuario")
                                     join usucat in
                                    doc.Descendants("UsuariosCategorias") on (int)usu.Element("Id") equals
                                    (int)usucat.Element("UsuarioId")
                                     join cat in doc.Descendants("Categorias")
                                    on (int)usucat.Element("CategoriaId") equals (int)cat.Element("Id")
                                     where
                                    ((string)usu.Element("NombreUsuario")).StartsWith(cadenaComienzo) &&
                                    (string)cat.Element("NombreCategoria") == categoria
                                     orderby
                                    (string)usu.Element("NombreUsuario")
                                     select new vmCategoriaNombre
                                     {
                                         Nombre =
                                    ((string)usu.Element("NombreUsuario")).ToUpper(),
                                         Categoria =
                                    (string)cat.Element("NombreCategoria")
                                     };
            Assert.IsNotNull(usuariosCategorias);
        }
        [TestMethod]
        public void Consulta5Usuarios()
        {
            string ip = "192.168.134.23";
            var resultado = from usu in doc.Descendants("Usuario")
                            join usucat in doc.Descendants("UsuariosCategorias")
                           on (int)usu.Element("Id") equals (int)usucat.Element("UsuarioId")
                            join con in doc.Descendants("Conexiones") on (int)usucat.Element("Id") equals (int)con.Element("UsuarioCategoriaId")
                            where (string)con.Element("IP") == ip
                            select new vmNombre
                            {
                                Nombre =
                           ((string)usu.Element("NombreUsuario")).ToUpper()
                            };
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void Consulta6Usuarios()
        {
            string aplicacion = "Word";
            string email = "Juan.pss - 2@ual.es";
            var resultado = from usu in doc.Descendants("Usuario")
                            join per in doc.Descendants("Personales") on
                           (int)usu.Element("Id") equals (int)per.Element("UsuarioId")
                            join apli in doc.Descendants("Aplicaciones") on
                           (int)usu.Element("AplicacionId") equals (int)apli.Element("Id")
                            where (string)apli.Element("NombreAplicacion") ==
                           aplicacion && (string)per.Element("Email") == email
                            select new vmNombre
                            {
                                Nombre =
                           ((string)usu.Element("NombreUsuario")).ToUpper()
                            };
            Assert.IsNotNull(resultado);
        }
    }
}
