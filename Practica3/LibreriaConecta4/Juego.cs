namespace PSS.lhm232.ConectaCuatro
{
    public class NombreJugadorDuplicadoException : Exception
    {
        public NombreJugadorDuplicadoException()
        {
        }
        public NombreJugadorDuplicadoException(string? message) : base(message)
        {
        }
        public NombreJugadorDuplicadoException(string? message, Exception?
       innerException) : base(message, innerException)
        {
        }
    }
        public class Juego
    {
        
        private Dictionary<string, Jugador> Jugadores = new Dictionary<string,
        Jugador>();
        public Tablero Tablero { get; set; }
        public int NumeroJugadores {  get {  return Jugadores.Count; } }
        public Juego()
        {
            Tablero = new Tablero();

        }
        public Juego(int dimension)
        {
            Tablero = new Tablero(dimension);
        }

        public void AnnadirJugador(Jugador jugador)
        {
            try
            {
                Jugadores.Add(jugador.Nombre, jugador);
            }
            catch (Exception ex)
            {
                throw new NombreJugadorDuplicadoException("El nombre del jugador" +  jugador.Nombre + "ya existe"); 
            }
        

         }
            public Jugador ObtenerJugador(string nombre)
            {
                return Jugadores[nombre];
            }
          public Jugador ObtenerJugador(int idJugador)
        {
            foreach (Jugador jugador in Jugadores.Values)
            {
                if (jugador.Id == idJugador)
                    return Jugadores[jugador.Nombre];
            }
            throw new IndexOutOfRangeException("Id jugador no existe " + idJugador);
            }
            public bool ObtenerGanador(Jugador ultimoJugador)
            {
                bool diagonalDer = ComprobarDiagonalDer(ultimoJugador);
                bool diagonalIzq = ComprobarDiagonalIzq(ultimoJugador);
                bool vertical = ComprobarVertical(ultimoJugador);
                bool horizontal = ComprobarHorizontal(ultimoJugador);
                if (diagonalDer || diagonalIzq || vertical || horizontal) return
               true;
                else return false;
            }
        private bool ComprobarDiagonalDer(Jugador jugador)
        {
            ColorEnum color = jugador.Ficha.Color;
            bool[] posiciones = new bool[4];
            int dimension = Tablero.Dimension;
            for (int i = 0; i < posiciones.Length; i++)
            {
                posiciones[i] = false;
            }
            for (int i = 0; i < dimension - 3; i++)
            {
                for (int j = 0; j < dimension - 3; j++)
                {
                    Ficha ficha = Tablero[i, j];
                    if (ficha == null) continue;
                    if (ficha.Color == color)
                    {
                        posiciones[0] = true;
                        posiciones[1] = (Tablero[i + 1, j + 1] == null) ? false : (Tablero[i + 1, j + 1].Color == color);
                        posiciones[2] = (Tablero[i + 2, j + 2] == null) ? false : (Tablero[i + 2, j + 2].Color == color);
                        posiciones[3] = (Tablero[i + 3, j + 3] == null) ? false : (Tablero[i + 3, j + 3].Color == color);
                    }
                    if (posiciones[0] && posiciones[1] && posiciones[2] && posiciones[3])
                        return true;
                }
            }
            return false;
        }
        private bool ComprobarDiagonalIzq(Jugador jugador)
        {
            ColorEnum color = jugador.Ficha.Color;
            bool[] posiciones = new bool[4];
            int dimension = Tablero.Dimension;
            for (int i = 0; i < posiciones.Length; i++)
            {
                posiciones[i] = false;
            }
            for (int i = 0; i < dimension - 3; i++)
            {
                for (int j = dimension - 1; j >= 2; j--)
                {
                    Ficha ficha = Tablero[i, j];
                    if (ficha == null) continue;
                    if (ficha.Color == color)
                    {
                        posiciones[0] = true;
                        posiciones[1] = (Tablero[i + 1, j - 1] == null) ? false: (Tablero[i + 1, j - 1].Color == color);
                        posiciones[2] = (Tablero[i + 2, j - 2] == null) ? false : (Tablero[i + 2, j - 2].Color == color);
                        posiciones[3] = (Tablero[i + 3, j - 3] == null) ? false: (Tablero[i + 3, j - 3].Color == color);
                    }
                    if (posiciones[0] && posiciones[1] && posiciones[2] &&
                   posiciones[3])
                        return true;
                }
            }
            return false;
        }
            private bool ComprobarVertical(Jugador jugador)
            {
                ColorEnum color = jugador.Ficha.Color;
                bool[] posiciones = new bool[4];
                int dimension = Tablero.Dimension;
                for (int i = 0; i < posiciones.Length; i++)
                {
                    posiciones[i] = false;
                }
                for (int i = 0; i < dimension - 3; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        Ficha ficha = Tablero[i, j];
                        if (ficha == null) continue;
                        if (ficha.Color == color)
                        {
                            posiciones[0] = true;
                            posiciones[1] = (Tablero[i + 1, j] == null) ? false :(Tablero[i + 1, j].Color == color);
                            posiciones[2] = (Tablero[i + 2, j] == null) ? false : (Tablero[i + 2, j].Color == color);
                            posiciones[3] = (Tablero[i + 3, j] == null) ? false : (Tablero[i + 3, j].Color == color);
                        }
                        if (posiciones[0] && posiciones[1] && posiciones[2] &&
                       posiciones[3])
                            return true;
                    }
                }
                return false;
            }
        private bool ComprobarHorizontal(Jugador jugador)
        {
            ColorEnum color = jugador.Ficha.Color;
            bool[] posiciones = new bool[4];
            int dimension = Tablero.Dimension;
            for (int i = 0; i < posiciones.Length; i++)
            {
                posiciones[i] = false;
            }
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension - 3; j++)
                {
                    Ficha ficha = Tablero[i, j];
                    if (ficha == null) continue;
                    if (ficha.Color == color)
                    {
                        posiciones[0] = true;
                        posiciones[1] = (Tablero[i, j + 1] == null) ? false :(Tablero[i, j + 1].Color == color);
                        posiciones[2] = (Tablero[i, j + 2] == null) ? false : (Tablero[i, j + 2].Color == color);
                        posiciones[3] = (Tablero[i, j + 3] == null) ? false : (Tablero[i, j + 3].Color == color);
                    }
                    if (posiciones[0] && posiciones[1] && posiciones[2] &&
                   posiciones[3])
                        return true;
                }
            }
            return false;
        }
        public bool FinJuego()
        {
            return Tablero.TableroLleno;
        }


    }
            }