using Microsoft.VisualStudio.TestTools.UnitTesting;

using PSS.lhm232.Practica_02;

namespace PSS.lhm232.Practica
{
    [TestClass]
    public class TestComparadorPropiedad
    {
        [TestMethod]
        public void TestComparadorNotNull()
        {
            ComparadorPropiedad<UsuarioView> comparador = new ComparadorPropiedad<UsuarioView>("Id");
            Assert.IsNotNull(comparador);

           
        }
        [TestMethod]
        public void TestComparadorPropiedadCanBeNull()
        {
            ComparadorPropiedad<UsuarioView> comparador = new ComparadorPropiedad<UsuarioView>("Id");
            Assert.IsNull(comparador.nombrePropiedad);
        }



        [TestMethod]
        public void TestComparadorObjetos()
        {
            var usuario1 = new UsuarioView(0, "Usuario1", "pss", "categoria1", true);
            var usuario2 = new UsuarioView(0, "Usuario1", "pss2", null, true);
            var comparador = new ComparadorPropiedad<UsuarioView>("Id");
            int resultado = comparador.Compare(
                usuario1,
                usuario2
            );

            Assert.IsTrue(resultado == 0);

            comparador.nombrePropiedad = "Nombre";

            resultado = comparador.Compare(
                usuario1,
                usuario2
            );

            comparador.nombrePropiedad = "Categoria";

            resultado = comparador.Compare(
                usuario1,
                usuario2
            );

            Assert.IsTrue(resultado == 1);


            comparador.nombrePropiedad = "EsValido";

            resultado = comparador.Compare(
                usuario1,
                usuario2
            );

            Assert.IsTrue(resultado == 0);
        }
    }
}
