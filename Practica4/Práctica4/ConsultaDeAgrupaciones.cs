using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PSS.lhm232.Practica_04
{
    public class ConsultasDeAgrupaciones
    {
        public UserData _datos;
        public ConsultasDeAgrupaciones()
        {
            _datos = new UserData();
            _datos.CargarDatos();
        }
        
        public IEnumerable<vmNombreCantidad>IPconMasConexionesSegunCategoria(string nombreCategoria)
        {
            var resultado = (from cat in _datos.Categorias
                             join usucat in _datos.UsuariosCategorias on cat.Id
                            equals usucat.CategoriaId
                             join con in _datos.Conexiones on usucat.Id equals
                            con.UsuarioCategoriaId
                             where cat.NombreCategoria == nombreCategoria
                             group con.Id by con.IP into g
                             orderby g.Count() descending
                             select new vmNombreCantidad
                             {
                                 Nombre = g.Key,
                                 Cantidad = g.Count()
                             }).First();
            yield return resultado;
        }
        
        public IEnumerable<vmNombreCantidad> UsuarioSumaDuracionConexiones()
        {
            var resultado = from usu in _datos.Usuarios
                            join usucat in _datos.UsuariosCategorias on usu.Id
                           equals usucat.UsuarioId
                            join con in _datos.Conexiones on usucat.Id equals con.UsuarioCategoriaId
                            group con.Duracion
                            by usu into g
                            orderby g.Sum() descending
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key.NombreUsuario,
                                Cantidad = g.Sum()
                            };
            return resultado;
        }
        
        public IEnumerable<vmNombreCantidad> UsuarioSumaDuracionConexionesNulos()
        {
            var query = from user in _datos.Usuarios
                        join userCat in _datos.UsuariosCategorias
                        on user.Id equals userCat.UsuarioId
                        join con in _datos.Conexiones on userCat.Id equals
                       con.UsuarioCategoriaId
                        into gp
                        from y_d in gp.DefaultIfEmpty()
                        group y_d by user
            into grouped
                        select new vmNombreCantidad
                        {
                            Nombre = grouped.Key.NombreUsuario,
                            Cantidad = grouped.Sum(d => d == null ? 0 :
                           d.Duracion)
                        };
            return query;
        }
       

        public IEnumerable<vmNombreCantidad> UsuariosSumaDuracionMayorMedia()
        {
            var subconsulta = UsuarioSumaDuracionConexionesNulos();
            var resultado = from resul in subconsulta
                            where resul.Cantidad > subconsulta.Average(e =>e.Cantidad)
                            select resul;
            return resultado;
        }
     
        public IEnumerable<vmNombreCantidad> AplicacionesMasUsadas()
        {
            var resultado = from app in _datos.Aplicaciones
                            join usu in _datos.Usuarios on app.Id equals
                           usu.AplicacionId
                            join usucat in _datos.UsuariosCategorias on usu.Id
                           equals usucat.UsuarioId
                            join con in _datos.Conexiones on usucat.Id equals
                           con.UsuarioCategoriaId
                            group con.Duracion
                            by app.NombreAplicacion
            into g
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key,
                                Cantidad = g.Sum()
                            };
            return resultado;
        }
      
        public IEnumerable<vmNombreCantidad> AplicacionesMasUsadasOrdenadas()
        {
            var resultado = from app in _datos.Aplicaciones
                            join usu in _datos.Usuarios on app.Id equals
                           usu.AplicacionId
                            join usucat in _datos.UsuariosCategorias on usu.Id
                           equals usucat.UsuarioId
                            join con in _datos.Conexiones on usucat.Id equals
                           con.UsuarioCategoriaId
                            group con.Duracion
                            by app.NombreAplicacion
            into g
                            orderby g.Sum() descending
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key,
                                Cantidad = g.Sum()
                            };
            return resultado;
        }
    }
}