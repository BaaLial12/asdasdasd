using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.lhm232.Practica_02;

namespace PSS.lhm232.Practica
{

    [TestClass]
    public class RecorridoSecuenciaTest
    {
        UsuarioView A = new UsuarioView(0, "Usuario1", "palabraPaso1", "cat1", true);
        UsuarioView B = new UsuarioView(1, "Usuario2", "palabraPaso2", "cat4", true);
        UsuarioView C = new UsuarioView(2, "Usuario3", "palabraPaso1", "cat3", false);
        UsuarioView D = new UsuarioView(3, "Usuario5", "palabraPaso3", "cat1", true);

        [TestMethod]
        public void TestListaNotNull()
        {
            ISecuencia<UsuarioView> secuencia = new Secuencia<UsuarioView>();
            Assert.IsNotNull(secuencia);
           
        }

        [TestMethod]
        public void TestRecorridoAdelante()
        {
            List<UsuarioView> expected = new List<UsuarioView> { B, C, A, D };
            Secuencia<UsuarioView> lista = new Secuencia<UsuarioView>();
            int i = 0;

            lista.Anadir(B);
            lista.Anadir(C);
            lista.Anadir(A);
            lista.Anadir(D);

            foreach (UsuarioView elemento in lista.RecorridoAdelante())
            {
                Assert.AreEqual(elemento, expected[i]);
                i++;
            }
        }

        [TestMethod]
        public void TestRecorridoAtras()
        {
            List<UsuarioView> expected = new List<UsuarioView> { D, A, C, B };
            Secuencia<UsuarioView> lista = new Secuencia<UsuarioView>();
            int i = 0;

            lista.Anadir(B);
            lista.Anadir(C);
            lista.Anadir(A);
            lista.Anadir(D);

            foreach (UsuarioView elemento in lista.RecorridoAtras())
            {
                Assert.AreEqual(elemento, expected[i]);
                i++;
            }
        }

        [TestMethod]
        public void TestRecorridoAscendente()
        {
            List<UsuarioView> expected = new List<UsuarioView> { A, B, C, D };
            Secuencia<UsuarioView> lista = new Secuencia<UsuarioView>();
            int i = 0;

            lista.Anadir(B);
            lista.Anadir(C);
            lista.Anadir(A);
            lista.Anadir(D);

            foreach (UsuarioView elemento in lista.RecorridoAscendente<UsuarioView>())
            {
                Assert.AreEqual(elemento, expected[i]);
                i++;
            }
        }

        [TestMethod]
        public void TestRecorridoDescendente()
        {
            List<UsuarioView> expected = new List<UsuarioView> { D, C, B, A };
            Secuencia<UsuarioView> lista = new Secuencia<UsuarioView>();
            int i = 0;

            lista.Anadir(B);
            lista.Anadir(C);
            lista.Anadir(A);
            lista.Anadir(D);

            foreach (UsuarioView elemento in lista.RecorridoDescendente<UsuarioView>())
            {
                Assert.AreEqual(elemento, expected[i]);
                i++;
            }
        }
    }

}