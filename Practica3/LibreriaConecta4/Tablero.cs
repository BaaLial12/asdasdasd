namespace PSS.lhm232.ConectaCuatro
{
    public class Tablero
    {
         private int _dimension = 9;

            public int Dimension { get { return _dimension; } }
            public int NumeroCasillasOcupadas { get; set; }
            public bool TableroLleno
            {
                get
                {
                    return NumeroCasillasOcupadas >= _dimension * _dimension;
                }
            }
            private Ficha[,] _casillas;

            public Ficha this[int fila, int columna]
            {
                get { return _casillas[fila, columna]; }
                set { _casillas[fila, columna] = value; }
            }
            public Tablero() : this(9) { }
            public Tablero(int dimension)
            {
                _casillas = new Ficha[dimension, dimension];
                _dimension = dimension;
            }
            public bool PonerFichaColumna(Ficha ficha, int columna)
            {
                if (columna < _dimension && columna >= 0)
                {
                    for (int fila = Dimension - 1; fila >= 0; fila--)
                    {
                        if (this[fila, columna] == null)
                        {
                            this[fila, columna] = ficha;
                            this.NumeroCasillasOcupadas++;
                            return true;
                        }
                    }
                }
                return false;
            }

            public bool PonerFichaPosicion(object ficha, Posicion posicion)
            {
                return posicion.Fila < Dimension && posicion.Columna < Dimension;
            }
            public Tablero Clonar()
            {
                Tablero clon = new Tablero(this.Dimension);
                for (int i = 0; i < clon.Dimension; i++)
                {
                    for (int j = 0; j < clon.Dimension; j++)
                    {
                        clon[i, j] = this[i, j];
                    }
                }
                return clon;
            }
        }
    }
