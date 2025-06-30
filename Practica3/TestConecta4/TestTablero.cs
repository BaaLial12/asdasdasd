using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.lhm232.ConectaCuatro
{
        [TestClass]
        public class TestTablero
        {
        private Ficha ficha;

        [TestMethod]
            public void Constructor_SinParametros_EsNoNulo()
            {
                Tablero tablero = new Tablero();
                Assert.IsNotNull(tablero);
            }

            [TestMethod]
            public void Dimension_TableroSinParametro_EsIgual9()
            {
               Tablero tablero = new Tablero(9);
                bool resultado = tablero.Dimension == 9;
                Assert.IsTrue(resultado);
            }
            [TestMethod]
            public void Dimension_TableroConParametro_DimensionEsIgual()
            {
                Tablero tablero = new Tablero(5);
                bool resultado = tablero.Dimension == 5;
                Assert.IsTrue(resultado);
            }
            [TestMethod]
            public void Indexador_FilaColumna_EsIgual()
            {
                Tablero tablero = new Tablero(9);
                Ficha ficha = new Ficha(ColorEnum.Amarillo);
                tablero[1, 1] = ficha;
                bool resultado = tablero[1, 1].Color == ColorEnum.Amarillo;
                Assert.IsTrue(resultado);
            }
            [TestMethod]
            public void PonerFichaPosicion_PongoFicha_EsIgualColor()
            {
                Tablero tablero = new Tablero(9);
                 Ficha ficha = new Ficha(ColorEnum.Amarillo);
                tablero.PonerFichaColumna(ficha, 0);
                bool resultado = tablero[8, 0].Color == ColorEnum.Amarillo;
                Assert.IsTrue(resultado);
            }
            [TestMethod]
            public void Tablero_PonerFichaPosicionVacia_EsTrue()
            {
                Tablero tablero = new Tablero(9);
                Ficha ficha = new Ficha(ColorEnum.Amarillo);
                bool resultado = tablero.PonerFichaColumna(ficha, 0);
                Assert.IsTrue(resultado);
            }
            [TestMethod]
            public void Tablero_PonerFichaPosicionOcupada_EsFalse()
            {
                Tablero tablero = new Tablero(1);
                Ficha ficha = new Ficha(ColorEnum.Amarillo);
                tablero.PonerFichaColumna(ficha, 0);
                bool resultado = tablero.PonerFichaColumna(ficha, 0);
                Assert.IsFalse(resultado);
            }
            [TestMethod]
            public void Tablero_PonerFichaPosicionFuera_EsFalse()
            {
                Tablero tablero = new Tablero(9);
                Ficha ficha = new Ficha(ColorEnum.Amarillo);
                bool resultado = tablero.PonerFichaColumna(ficha, 40);
                Assert.IsFalse(resultado);
            }
            [TestMethod]
            public void NumeroCasillasOcupadas_TableroNuevo_Es0()
            {
                Tablero tablero = new Tablero(9);
                bool resultado = tablero.NumeroCasillasOcupadas == 0;
                Assert.IsTrue(resultado);
                }
            [TestMethod]
            public void NumeroCasillasOcupadas_Tablero1Ficha_Es1()
            {
                Tablero tablero = new Tablero(9);
                Ficha ficha = new Ficha(ColorEnum.Amarillo);
                tablero.PonerFichaColumna(ficha, 0);
                bool resultado = tablero.NumeroCasillasOcupadas == 1;
                Assert.IsTrue(resultado);
            }
            [TestMethod]
            public void EsFinDeJuego_TableroVacio_False()
            {
                Tablero tablero = new Tablero(9);
                Assert.IsFalse(tablero.TableroLleno);
            }
            [TestMethod]
            public void EsFinDeJuego_TableroLleno_True()
            {
                Tablero tablero = new Tablero(1);
                Ficha ficha = new Ficha(ColorEnum.Amarillo);
                tablero.PonerFichaColumna(ficha, 0);
                Assert.IsTrue(tablero.TableroLleno);
            }

        }


}
