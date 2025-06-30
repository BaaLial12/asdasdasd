using PSS.lhm232.Practica_04;

internal class APPCrearXML
{
    private static void Main(string[] args)
    {
        var userData = new UserData();
        userData.CargarDatos();
        userData.GuardarEnArchivo();
        Console.WriteLine("Se ha guardado el archivo");
        Console.ReadLine();
    }
}