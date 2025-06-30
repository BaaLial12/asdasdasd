using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static PSS.lhm232.ConectaCuatro.Ficha;

namespace PSS.lhm232.ConectaCuatro
{
    [TestClass]
    public class TestJuego
    {
        [TestMethod]
        public void Constructor_SinParametros_NoNulo()
        {
            Juego juego = new Juego();
            Assert.IsNotNull(juego);
        }
        [TestMethod]
        public void AnnadirJugador_ParametroNombreJugador_NumeroJugadoresEs1()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador("Nombre Jugador");
            juego.AnnadirJugador(jugador);
            bool resultado = juego.NumeroJugadores == 1;
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void ObtenerJugador_NombreJugador_EsElMismo()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador("A");
            juego.AnnadirJugador(jugador1);
            Jugador jugadorDiccionario = juego.ObtenerJugador("A");
            bool resultado = jugadorDiccionario == jugador1;
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        [ExpectedException(typeof(NombreJugadorDuplicadoException))]
        public void AnadirJugador_NombreJugadorExiste_SaltaException()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador("A");
            juego.AnnadirJugador(jugador1);
            Jugador jugador2 = new Jugador("A");
            juego.AnnadirJugador(jugador2);
            Assert.Fail("No se ha lanzado la excepcion correspondiente");
        }
        [TestMethod]
        public void ObtenerJugador_IdJugador_EsElMismo()
        {
            Juego juegoID = new Juego();
            Jugador jugador = new Jugador("A");
            juegoID.AnnadirJugador(jugador);
            Jugador jugadorObtenido = juegoID.ObtenerJugador(1);
            bool resultado = jugadorObtenido.Id == 1;
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void ObtenerGanador_Vertical_Jugador1()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador("A");
            jugador.Ficha = new Ficha(ColorEnum.Amarillo);
            juego.AnnadirJugador(jugador);
            jugador.ColocarFichaColumna(juego.Tablero, 0);
            jugador.ColocarFichaColumna(juego.Tablero, 0);
            jugador.ColocarFichaColumna(juego.Tablero, 0);
            jugador.ColocarFichaColumna(juego.Tablero, 0);
            bool resultado = juego.ObtenerGanador(jugador);
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void ObtenerGanador_Horizontal_Jugador1()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador("A");
            jugador.Ficha = new Ficha(ColorEnum.Amarillo);
            juego.AnnadirJugador(jugador);
            jugador.ColocarFichaColumna(juego.Tablero, 0);
            jugador.ColocarFichaColumna(juego.Tablero, 1);
            jugador.ColocarFichaColumna(juego.Tablero, 2);
            jugador.ColocarFichaColumna(juego.Tablero, 3);
            bool resultado = juego.ObtenerGanador(jugador);
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void ObtenerGanador_DiagonalDer_Jugador1()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador("A");
            jugador.Ficha = new Ficha(ColorEnum.Amarillo);
            juego.AnnadirJugador(jugador);
            juego.Tablero[5, 0] = jugador.Ficha;
            juego.Tablero[6, 1] = jugador.Ficha;
            juego.Tablero[7, 2] = jugador.Ficha;
            juego.Tablero[8, 3] = jugador.Ficha;
            bool resultado = juego.ObtenerGanador(jugador);
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void ObtenerGanador_DiagonalIzq_Jugador1()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador("A");
            jugador.Ficha = new Ficha(ColorEnum.Amarillo);
            juego.AnnadirJugador(jugador);
            juego.Tablero[5, 3] = jugador.Ficha;
            juego.Tablero[6, 2] = jugador.Ficha;
            juego.Tablero[7, 1] = jugador.Ficha;
            juego.Tablero[8, 0] = jugador.Ficha;
            bool resultado = juego.ObtenerGanador(jugador);
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void ObtenerGanador_NoHayGanador()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador("A");
            jugador1.Ficha = new Ficha(ColorEnum.Amarillo);
            juego.AnnadirJugador(jugador1);
            Jugador jugador2 = new Jugador("B");
            jugador2.Ficha = new Ficha(ColorEnum.Negro);
            juego.AnnadirJugador(jugador2);
            jugador1.ColocarFichaColumna(juego.Tablero, 0);
            jugador1.ColocarFichaColumna(juego.Tablero, 0);
            jugador2.ColocarFichaColumna(juego.Tablero, 0);
            jugador1.ColocarFichaColumna(juego.Tablero, 0);
            bool resultado = juego.ObtenerGanador(jugador1);
            Assert.IsFalse(resultado);
        }
        [TestMethod]
        public void Juego_TableroLleno_true()
        {
            Juego juego = new Juego(1);
            Jugador jugador1 = new Jugador("A");
            jugador1.Ficha = new Ficha(ColorEnum.Amarillo);
            juego.AnnadirJugador(jugador1);
            jugador1.ColocarFichaColumna(juego.Tablero, 0);
            bool resultado = juego.FinJuego();
            Assert.IsTrue(resultado);
        }







    }
}


