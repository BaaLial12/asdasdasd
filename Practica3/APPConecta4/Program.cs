using APPConecta4;
using PSS.lhm232.ConectaCuatro;
using System.Data;

Juego juego = new Juego();
Jugador jugador1 = new Jugador("Jugador 1");
jugador1.Ficha = new Ficha(ColorEnum.Amarillo);
juego.AnnadirJugador(jugador1);

Jugador jugador2 = new Jugador("Jugador 2");
jugador2.Ficha = new Ficha(ColorEnum.Negro);
juego.AnnadirJugador(jugador2);

bool hayGanador = false;
Jugador jugadorGanador = null;

var rnd = new Random(DateTime.Now.Millisecond);
int id = rnd.Next(2) + 1;

do
{
    bool posicionVal = false;
    do
    {
        jugadorGanador = juego.ObtenerJugador(id);
        Console.WriteLine(jugadorGanador.Nombre + ConectaCuatroResource.InputCol);
        if (jugadorGanador.ObtenerPosicion(juego, out int columna))
            posicionVal = jugadorGanador.ColocarFichaColumna(juego.Tablero,columna);
        if (!posicionVal)
            Console.WriteLine(ConectaCuatroResource.InvalidColumn);
    } while (!posicionVal);
    id = (id % 2) + 1;
    hayGanador = juego.ObtenerGanador(jugadorGanador);
} while (!juego.FinJuego() && !hayGanador);
if (hayGanador)
{
    Console.WriteLine(ConectaCuatroResource.Winner + jugadorGanador.Nombre);
}
else
{
    Console.WriteLine(ConectaCuatroResource.NoWin);
}
Console.ReadLine();
