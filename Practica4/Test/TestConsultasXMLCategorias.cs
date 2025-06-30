using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
namespace PSS.lhm232.Practica_04
{
    [TestClass]
    public class TestsConsultasXMLCategorias
    {
        private XDocument doc = XDocument.Load("C:\\Users\\paula\\source\\Repos\\2022-pss-lhm232-ual\\Práctica4\\datosXML.xml");
        [TestMethod]
    public void Consulta1Categorias()
        {
            string aplicacion = "Word";
            var resultado = from usu in doc.Descendants("Usuario")
                            join apli in doc.Descendants("Aplicaciones") on
                           (int)usu.Element("AplicacionId") equals (int)apli.Element("Id")
                            join cat in doc.Descendants("Categorias") on
                           (int)apli.Element("Id") equals (int)cat.Element("AplicacionId")
                            where (string)apli.Element("NombreAplicacion") ==
                           aplicacion
                            orderby (string)cat.Element("NombreCategoria")
                            select new vmCategoriaNombre
                            {
                                Nombre = (string)usu.Element("NombreUsuario"),
                                Categoria =
                           (string)cat.Element("NombreCategoria")
                            };
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void Consulta2Categorias()
        {
            var resultado = from usu in doc.Descendants("Usuario")
                            join usucat in doc.Descendants("UsuariosCategorias")
                           on (int)usu.Element("Id") equals (int)usucat.Element("UsuarioId")
                            join cat in doc.Descendants("Categorias") on
                           (int)usucat.Element("CategoriaId") equals (int)cat.Element("Id")
                            group new vmCategoriaNombre
                            {
                                Nombre = (string)usu.Element("NombreUsuario"),
                                Categoria =
                           (string)cat.Element("NombreCategoria")
                            }
                            by (string)cat.Element("NombreCategoria") into g
                            orderby g.Key
                            select g;
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void Consulta3Categorias()
        {
            var resultado = (from usu in doc.Descendants("Usuario")
                             join usucat in
                            doc.Descendants("UsuariosCategorias") on (int)usu.Element("Id") equals
                            (int)usucat.Element("UsuarioId")
                             join cat in doc.Descendants("Categorias") on
                            (int)usucat.Element("CategoriaId") equals (int)cat.Element("Id")
                             select new vmCategoriaNombre
                             {
                                 Nombre = (string)usu.Element("NombreUsuario"),
                                 Categoria =
                            (string)cat.Element("NombreCategoria")
                             }).OrderByDescending(e => e.Categoria);
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void Consulta5Categorias()
        {
            string aplicacion = "Word";
            var resultado = from app in doc.Descendants("Aplicaciones")
                            join cat in doc.Descendants("Categorias") on
                           (int)app.Element("Id") equals (int)cat.Element("AplicacionId")
                            where (string)app.Element("NombreAplicacion") == aplicacion
                            orderby (string)cat.Element("NombreCategoria")
                            select new vmCategoriaNombre
                            {
                                Categoria =
                           (string)cat.Element("NombreCategoria"),
                                Nombre = (string)app.Element("NombreAplicacion")
                            };
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void Consulta6Categorias()
        {
            string usuario = "Maria";

            var resultado = from usu in doc.Descendants("Usuarios")
                            join app in doc.Descendants("Aplicaciones") on
                           (int)usu.Element("AplicacionId") equals (int)app.Element("Id")
                            join cat in doc.Descendants("Categorias") on
                           (int)app.Element("Id") equals (int)cat.Element("AplicacionId")
                            where (string)usu.Element("NombreUsuario") == usuario
                            orderby (string)cat.Element("NombreCategoria")
                            select new vmCategoriaNombre
                            {
                                Categoria =
                           (string)cat.Element("NombreCategoria"),
                                Nombre = (string)app.Element("NombreAplicacion")
                            };
            Assert.IsNotNull(resultado);
        }
    }

    internal class vmCategoriaNombre
    {
        public string Categoria { get; set; }
        public string Nombre { get; set; }
    }
}