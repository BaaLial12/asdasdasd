namespace PSS.lhm232.ConectaCuatro
{
    public class Ficha
    {
        public ColorEnum _color;
        public ColorEnum Color { get { return _color; } }
        public Ficha() { 
        }
        public Ficha(ColorEnum color)
        {
            _color = color;
        }
    }
    public enum ColorEnum
    {
        SinColor, Amarillo, Negro
    }
}