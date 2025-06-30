using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.lhm232.ConectaCuatro
{
    public delegate bool Calculo(Juego juego, Jugador jugador, out int
columna);
    public static class Algoritmos
    {
        public static bool AlgoritmoHumano(Juego juego, Jugador jugador, out int
       columna)
        {
            string linea = Console.ReadLine();
            columna = int.Parse(linea);
            return true;
        }
        public static bool AlgoritmoListo(Juego juego, Jugador jugador, out int
       columna)
        {
            columna = -1;
            for (int id = 0; id < juego.NumeroJugadores; id++)
            {
                Jugador jugadorTest = juego.ObtenerJugador(id + 1);
                for (int c = 0; c < juego.Tablero.Dimension; c++)
                {
                    Tablero tablero = juego.Tablero.Clonar();
                    int numCasillas = juego.Tablero.NumeroCasillasOcupadas;
                    if (jugadorTest.ColocarFichaColumna(juego.Tablero, c))
                    {
                        if (juego.ObtenerGanador(jugadorTest) && (jugadorTest.Id
                       == jugador.Id))
                        {
                            columna = c;
                            Console.WriteLine(columna);
                            juego.Tablero = tablero;
                            juego.Tablero.NumeroCasillasOcupadas = numCasillas;
                            return true;
                        }
                        else if (juego.ObtenerGanador(jugadorTest))
                        {
                            columna = c;
                        }
                        else if (columna == -1)
                        {
                            columna = c;
                        }
                        juego.Tablero = tablero;
                        juego.Tablero.NumeroCasillasOcupadas = numCasillas;
                    }
                }
            }
            Console.WriteLine(columna);
            return true;
        }
    }
    }
