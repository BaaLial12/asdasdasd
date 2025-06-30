using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PSS.lhm232.Practica_04
{
    public class ConsultasSobreCategoria
    {
        public UserData _datos;
        public ConsultasSobreCategoria()
        {
            _datos = new UserData();
            _datos.CargarDatos();
        }
      
        public IEnumerable<vmCategoriaNombre> ListaParCategoriaUsuarioParaApp(string aplicacion)
        {
            var resultado = from usu in _datos.Usuarios
                            join apli in _datos.Aplicaciones on usu.AplicacionId
                           equals apli.Id
                            join cat in _datos.Categorias on apli.Id equals
                           cat.AplicacionId
                            where apli.NombreAplicacion == aplicacion
                            orderby cat.NombreCategoria
                            select new vmCategoriaNombre
                            {
                                Nombre = usu.NombreUsuario,
                                Categoria = cat.NombreCategoria
                            };
            return resultado;
        }
       
         public IEnumerable<IGrouping<string, vmCategoriaNombre>>AgrupacionUsuariosCategorias()
        {
            var resultado = from usu in _datos.Usuarios
                            join usucat in _datos.UsuariosCategorias on usu.Id
                           equals usucat.UsuarioId
                            join cat in _datos.Categorias on usucat.CategoriaId
equals cat.Id
                            group new vmCategoriaNombre
                            {
                                Nombre = usu.NombreUsuario,
                                Categoria = cat.NombreCategoria
                            }
                            by cat.NombreCategoria into g
                            orderby g.Key
                            select g;
            return resultado;
        }
       
        public IEnumerable<vmCategoriaNombre>AgrupacionUsuariosCategoriasOrdenadas()
        {
            var resultado = (from usu in _datos.Usuarios
                             join usucat in _datos.UsuariosCategorias on usu.Id
                            equals usucat.UsuarioId
                             join cat in _datos.Categorias on usucat.CategoriaId
                            equals cat.Id
                             select new vmCategoriaNombre
                             {
                                 Nombre = usu.NombreUsuario,
                                 Categoria = cat.NombreCategoria
                             }).OrderByDescending(e => e.Categoria);
            return resultado;
        }
      
        public IEnumerable<vmCategoriaNombre> CategoriaMaximoNumeroUsuarios()
        {
            var resultado = (from cat in _datos.Categorias
                             join usucat in _datos.UsuariosCategorias on cat.Id
                            equals usucat.CategoriaId
                             group usucat.UsuarioId
                             by cat.NombreCategoria into g
                             orderby g.Count() descending
                             select new vmCategoriaNombre
                             {
                                 Categoria = g.Key,
                                 Nombre = g.Count().ToString()
                             }).First();
            List<vmCategoriaNombre> lista = new List<vmCategoriaNombre>();
            lista.Add(resultado);
            return lista;
        }
       
        public IEnumerable<vmCategoriaNombre> TodasCategoriasApp(string aplicacion)
        {
            var resultado = from app in _datos.Aplicaciones
                            join cat in _datos.Categorias on app.Id equals
                           cat.AplicacionId
                            where app.NombreAplicacion == aplicacion
                            orderby cat.NombreCategoria
                            select new vmCategoriaNombre
                            {
                                Categoria = cat.NombreCategoria,
                                Nombre = app.NombreAplicacion
                            };
            return resultado;
        }
     
        public IEnumerable<vmCategoriaNombre>CategoriasAplicacionParaUsuario(string usuario)
        {
            var resultado = from usu in _datos.Usuarios
                            join app in _datos.Aplicaciones on usu.AplicacionId
                           equals app.Id
                            join cat in _datos.Categorias on app.Id equals
                           cat.AplicacionId
                            where usu.NombreUsuario == usuario
                            orderby cat.NombreCategoria
                            select new vmCategoriaNombre
                            {
                                Categoria = cat.NombreCategoria,
                                Nombre = app.NombreAplicacion
                            };
            return resultado;
        }
    }
}
