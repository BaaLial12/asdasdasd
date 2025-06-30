using System.Diagnostics;
namespace PSS.lhm232.ConectaCuatro
{
    public class Jugador
    {
        public static int NumeroJugadores = 0;
        public string Nombre { get; }
        private Ficha _ficha;
        public bool Humano = true;

        public int Id { get; }
        public Calculo AlgoritmoPosicion;
        public Ficha Ficha
        {
            get
            {
                if (_ficha == null) throw new JugadorSinFichaException("El jugador no tiene una ficha asignada.");
                else return _ficha;
            }
            set
            {
                _ficha = value;
            }
        }
        public Jugador(string nombre)
        {
            NumeroJugadores++;
            Id = NumeroJugadores;
            Nombre = nombre;
        }
        public Jugador(string nombre, bool humano)
        {
            NumeroJugadores++;
            Id = NumeroJugadores;
            Nombre = nombre;
            Humano = humano;
        }
        public Jugador()
        {
            NumeroJugadores++;
            Id = NumeroJugadores;
            Nombre = "Jugador" + NumeroJugadores.ToString();
        }
        public bool ColocarFichaColumna(Tablero tablero, int columna)
        {
            return tablero.PonerFichaColumna(this.Ficha, columna);
        }
        public bool ObtenerPosicion(Juego juego, out int columna)
        {
            return AlgoritmoPosicion(juego, this, out columna);
        }
        public class JugadorSinFichaException : Exception
        {
            public JugadorSinFichaException(string mensaje) : base(mensaje) { }
        }
    }

    }