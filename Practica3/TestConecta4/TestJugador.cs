using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.lhm232.ConectaCuatro
{
    [TestClass]
    public class TestJugador
    {
        [TestMethod]
        public void Constructor_SinParametros_NoNulo()
        {
            Jugador jugador = new Jugador();
            Assert.IsNotNull(jugador);
        }
        [TestMethod]
        public void Constructor_Nombre_EsIgual()
        {
            Jugador jugador = new Jugador("Nombre");
            bool resultado = jugador.Nombre == "Nombre";
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void Constructor_SinParametros_NombreNumerado()
        {
            Jugador jugador = new Jugador();
            bool resultado = jugador.Nombre == "Jugador" + Jugador.NumeroJugadores.ToString();
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void Ficha_ColorAmarillo_ColorEsIgual()
        {
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Amarillo);
            bool resultado = jugador.Ficha.Color == ColorEnum.Amarillo;
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void ColocarFichaPosicion_Valida_EsTrue()
        {
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Amarillo);
            Tablero tablero = new Tablero();
            bool resultado = jugador.ColocarFichaColumna(tablero, 0);
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void ColocarFichaPosicion_Ocupada_EsFalse()
        {
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Amarillo);
            Tablero tablero = new Tablero(1);
            jugador.ColocarFichaColumna(tablero, 0);
            bool resultado = jugador.ColocarFichaColumna(tablero, 0);
            Assert.IsFalse(resultado);
        }
        [TestMethod]
        public void ColocarFichaPosicion_Fuera_EsFalse()
        {
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Amarillo);
            Tablero tablero = new Tablero();
            bool resultado = jugador.ColocarFichaColumna(tablero, 40);
            Assert.IsFalse(resultado);
        }
        [TestMethod]
        [ExpectedException(typeof(Jugador.JugadorSinFichaException))]
        public void Ficha_NoAsignada_Excepcion()
        {
            Jugador jugador = new Jugador();
            bool resultado = jugador.Ficha.Color == ColorEnum.Amarillo;
            Assert.Fail("Se esperaba una excepcion de jugador sin ficha");
        }
        [TestMethod]
        public void Algoritmo_Posicion_IAListo()
        {
            Juego juego = new Juego();
            Jugador listo = new Jugador("IAListo");
            listo.Ficha = new Ficha(ColorEnum.Amarillo);
            listo.AlgoritmoPosicion = Algoritmos.AlgoritmoListo;
            juego.AnnadirJugador(listo);
            listo.ObtenerPosicion(juego, out int columna);
            bool resultado = listo.ColocarFichaColumna(juego.Tablero, columna);
            bool ganador = juego.ObtenerGanador(listo);
            Assert.IsTrue(ganador);
        }
    }
}


