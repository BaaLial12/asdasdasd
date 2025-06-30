using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.lhm232.Practica_04;

ConsultasUsuarios consultasUsuarios = new ConsultasUsuarios();
ConsultasSobreCategoria consultasSobreCategoria = new ConsultasSobreCategoria();
ConsultasDeAgrupaciones consultasDeAgrupaciones = new ConsultasDeAgrupaciones();
string lectura1 = "";
string lectura2 = "";
int lectura3 = 0;
IEnumerable<vmNombre> resultado;
IEnumerable<vmCategoriaNombre> resultado2;
IEnumerable<IGrouping<string, vmCategoriaNombre>> resultado3;
IEnumerable<vmNombreCantidad> resultado4;
Console.WriteLine("Consultas sobre usuarios.\n");
Console.WriteLine("Usuarios que se han conectado a una aplicación según la categoria cuyo codigo es categoriaId.");
lectura3 = Int32.Parse(Console.ReadLine());
resultado = consultasUsuarios.UsuariosEnCategoria(lectura3);
foreach (var item in resultado)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nUsuarios que se han conectado a una aplicación según la categoria cuyo nombre es nombreCategoria.");
lectura1 = Console.ReadLine();
resultado = consultasUsuarios.UsuariosEnCategoria(lectura1);
foreach (var item in resultado)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nUsuarios cuyo nombre comienza por cadenaComienzo.");
lectura1 = Console.ReadLine();
resultado = consultasUsuarios.UsuariosConNombreComienza(lectura1);
foreach (var item in resultado)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nUsuarios cuyo nombre comienza por cadenaComienzo que pertenecen a una categoria dada.");
lectura1 = Console.ReadLine();
lectura2 = Console.ReadLine();
resultado2 = consultasUsuarios.UsuariosConNombreComienzaEnCategoria(lectura1,
lectura2);
foreach (var item in resultado2)
{
    Console.WriteLine(item.Nombre + " " + item.Categoria);
}
Console.WriteLine("\nUsuarios conectados desde una IP.");
lectura1 = Console.ReadLine();
resultado = consultasUsuarios.UsuariosConectadosIP(lectura1);
foreach (var item in resultado)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nEncuentra el nombre del usuario de una aplicación dada a través de su e - mail.");
lectura1 = Console.ReadLine();
lectura2 = Console.ReadLine();
resultado = consultasUsuarios.EncontrarUsuarioAppEmail(lectura1, lectura2);
foreach (var item in resultado)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nConsultas sobre categorias.");
Console.WriteLine("\nLista de pares (Categoria,Usuario) para una aplicación dada.");
lectura1 = Console.ReadLine();
resultado2 = consultasSobreCategoria.ListaParCategoriaUsuarioParaApp(lectura1);
foreach (var item in resultado2)
{
    Console.WriteLine(item.Nombre + " " + item.Categoria);
}
Console.WriteLine("\nLista de Usuarios agrupados en lista de categorias (un mismo usuario puede estar en dos categorias).");
resultado3 = consultasSobreCategoria.AgrupacionUsuariosCategorias();
foreach (var item in resultado3)
{
    Console.WriteLine(item.Key);
}
Console.WriteLine("\nRelacion de Usuarios agrupados en categorias ordenadas éstas en orden descendente alfabéticamente.");
resultado2 = consultasSobreCategoria.AgrupacionUsuariosCategoriasOrdenadas();
foreach (var item in resultado2)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nDevuelve nombre de la categoria con más usurios y el numerode usuarios.");
resultado2 = consultasSobreCategoria.CategoriaMaximoNumeroUsuarios();
foreach (var item in resultado2)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nTodas las categorias de usuarios para una aplicación dada.");
lectura1 = Console.ReadLine();
resultado2 = consultasSobreCategoria.TodasCategoriasApp(lectura1);
foreach (var item in resultado2)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nLista de Categoria/Aplicación para un usuario dado.");
lectura1 = Console.ReadLine();
resultado2 = consultasSobreCategoria.CategoriasAplicacionParaUsuario(lectura1);
foreach (var item in resultado2)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nConsultas sobre agrupaciones.");
Console.WriteLine("\n¿Desde que IP ha habido más conexiones y cuantas para una categoria dada ? ");
lectura1 = Console.ReadLine();
resultado4 = consultasDeAgrupaciones.IPconMasConexionesSegunCategoria(lectura1);
foreach (var item in resultado4)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nSecuencia de pares (usuarios, suma total duración de conexion) ordenados de mayor a menor duración.");
resultado4 = consultasDeAgrupaciones.UsuarioSumaDuracionConexiones();
foreach (var item in resultado4)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nSecuencia de pares (usuarios, suma total de duración de conexiones) ordenados de menor a mayor duración.");
resultado4 = consultasDeAgrupaciones.UsuarioSumaDuracionConexionesNulos();
foreach (var item in resultado4)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nRelacion de usuarios cuya suma total de duración de conexión sea superior a la media.");
resultado4 = consultasDeAgrupaciones.UsuariosSumaDuracionMayorMedia();
foreach (var item in resultado4)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nRelacion de aplicaciones y su respectiva suma de tiempos deconexión de todos los usuarios.");
resultado4 = consultasDeAgrupaciones.AplicacionesMasUsadas();
foreach (var item in resultado4)
{
    Console.WriteLine(item.Nombre);
}
Console.WriteLine("\nRelacion de aplicaciones y su respectiva suma de tiempos deconexión de todos los usuarios(ordenas de mayor a menor).");
resultado4 = consultasDeAgrupaciones.AplicacionesMasUsadasOrdenadas();
foreach (var item in resultado4)
{
    Console.WriteLine(item.Nombre);
}