using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.lhm232.Practica_04
{
    public class ConsultasUsuarios
    {
        private UserData _datos;

        public string NombreCategoria { get; private set; }

        public ConsultasUsuarios()
        {
            _datos = new UserData();
            _datos.CargarDatos();
        }
      
        public IEnumerable<vmNombre> UsuariosEnCategoria(int categoriaId)
        {
            var usuarios = from usu in _datos.Usuarios
                           join usucat in _datos.UsuariosCategorias on usu.Id
                          equals usucat.UsuarioId
                           where usucat.CategoriaId == categoriaId
                           orderby usu.NombreUsuario
                           select new vmNombre
                           {
                               Nombre = usu.NombreUsuario.ToUpper()
                           };
            return usuarios;
        }
       
        
       
        public IEnumerable<vmNombre> UsuariosConNombreComienza(string
       cadenaComienzo)
        {
            var usuarios = from usu in _datos.Usuarios
                           where usu.NombreUsuario.StartsWith(cadenaComienzo)
                           select new vmNombre
                           {
                               Nombre = usu.NombreUsuario.ToUpper()
                           };
            return usuarios;
        }
        

    public IEnumerable<vmCategoriaNombre>UsuariosConNombreComienzaEnCategoria(string cadenaComienzo, string categoria)
        {
            var usuariosCategorias = from usu in _datos.Usuarios join usucat in _datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId join cat in _datos.Categorias on usucat.CategoriaId equals cat.Id  where usu.NombreUsuario.StartsWith(cadenaComienzo) && cat.NombreCategoria == categoria orderby usu.NombreUsuario
                                     select new vmCategoriaNombre
                                     {
                                         Nombre = usu.NombreUsuario.ToUpper(),
                                         Categoria = cat.NombreCategoria
                                     };
            return usuariosCategorias;
        }
       
        public IEnumerable<vmNombre> UsuariosConectadosIP(string ip)
        {
            var resultado = from usu in _datos.Usuarios
                            join usucat in _datos.UsuariosCategorias on usu.Id
                           equals usucat.UsuarioId
                            join con in _datos.Conexiones on usucat.Id equals
                           con.UsuarioCategoriaId
                            where con.IP == ip
                            select new vmNombre
                            {
                                Nombre = usu.NombreUsuario.ToUpper()
                            };
            return resultado;
        }
       
         public IEnumerable<vmNombre> EncontrarUsuarioAppEmail(string aplicacion,string email)
        {
            var resultado = from usu in _datos.Usuarios
                            join per in _datos.Personales on usu.Id equals
                           per.UsuarioId
                            join apli in _datos.Aplicaciones on usu.AplicacionId
                           equals apli.Id
                            where apli.NombreAplicacion == aplicacion &&
                           per.Email == email
                            select new vmNombre
                            {
                                Nombre = usu.NombreUsuario.ToUpper()
                            };
            return resultado;
        }

        public IEnumerable<vmNombre> UsuariosEnCategoria(string? lectura1)
        {
            throw new NotImplementedException();
        }
    }
}
    
