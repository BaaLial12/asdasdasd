using PSS.lhm232.Practica_05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.lhm232.Practica05
{
    class AutentificacionTextFile
    {
        private FormatoRegistro _formatoRegistro;
        private string _textFile;
        private string _finCampo;
        private Dictionary<string, IUsuarioView> _diccionarioUsuarios;
        /// <summary>
        /// Constructor sobre cargado, en el que se especifica: nombre del archivo que contienlas
        ///lineas de texto querepresentan a cada Usuario,
        /// el orden de los campos que constituye la información del usuario, y la cadena separadora.
        /// </summary>
        /// <param name="textFile">nombre del archivo de texto</param>
        /// <param name="formatoRegistro">Descripcion del formato del registro (orden de los  campos en cada linea del archivo de texto)</param>
        /// <param name="finCampo">cadena que determina la separación entre campos</param>
     public AutentificacionTextFile(string textFile, FormatoRegistro formatoRegistro, string finCampo)
            {
                this._formatoRegistro = formatoRegistro;
                this._textFile = textFile;
                this._finCampo = finCampo;
            this._diccionarioUsuarios = new Dictionary<string, IUsuarioView>();
            if ((_textFile != null) && File.Exists(_textFile))

            {
                using (var fs = File.OpenRead(textFile))

                {
                    StreamReader _srTextFile = new StreamReader(fs);
                    string reg = null;
                    while ((reg = _srTextFile.ReadLine()) != null)

                    {
                        IUsuarioView user = Decodificar(reg);
                        try

                        {
                            _diccionarioUsuarios.Add(user.Id, user);

                        }
                        catch

                        {
                            throw new AutentificacionExcepcion("Id " + user.Id + " ya existe.",CodigoAutentificacion.ErrorDatos);

                        }

                    }

                }

            }
            else
                throw new AutentificacionExcepcion("El fichero " + textFile + " no existe.",
                                                   CodigoAutentificacion.ErrorDatos);

        }
        private IUsuarioView Decodificar(string lineaFichero)

        {
            IUsuarioView user = new UsuarioView();
            int indexCampo = 0;
            int i = 0;
            bool hayError = false;

            string[] trozos = lineaFichero.Split(_finCampo.ToCharArray());
            for (i = 0; i < trozos.Count(); i++)

            {
                CamposRegistro campo = _formatoRegistro.CamposRegistro[i];
                switch (campo)

                {
                    case CamposRegistro.Id:

                        {
                            user.Id = trozos[i];
                            break;

                        }
                    case CamposRegistro.Nombre:

                        {
                            user.Nombre = trozos[i];
                            break;

                        }
                    case CamposRegistro.PalabraPaso:

                        {
                            user.PalabraPaso = trozos[i];
                            break;

                        }
                    case CamposRegistro.Categoria:

                        {
                            user.Categoria = trozos[i];
                            break;
                           }
                    case CamposRegistro.EsValido:
                        {
                            if (trozos[i].ToUpper() == "TRUE")
                                user.EsValido = true;
                            else
                                user.EsValido = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return user;
        }
        public CodigoAutentificacion EsUsuarioAutentificado(string id, string PalabraPaso)
        {
            IUsuarioView usuario = ObtenerUsuario(id);
            if (usuario == null)
                return CodigoAutentificacion.ErrorIdUsuario;
            if (usuario.PalabraPaso != PalabraPaso)
            {
                if (usuario.EsValido)
                    return CodigoAutentificacion.ErrorPalabraPaso;
                return CodigoAutentificacion.ErrorPalabraPaso |
               CodigoAutentificacion.AccesoInvalido;
            }
            if (usuario.EsValido)
                return CodigoAutentificacion.AccesoCorrecto;
            return CodigoAutentificacion.AccesoInvalido;

        }
        public IUsuarioView ObtenerUsuario(string id)

        {
            if (_diccionarioUsuarios.ContainsKey(id))
                return _diccionarioUsuarios[id];
            return null;

        }
        public bool ModificarUsuario(string id, IUsuarioView user)

        {
            if (_diccionarioUsuarios == null)
                return false;
            if (_diccionarioUsuarios.ContainsKey(id))

            {
                //el usuario si existe
                _diccionarioUsuarios[id] = user;
                GuardarDatos();
                return true;

            }
            else
                return false;

        }
        public bool InsertarUsuario(IUsuarioView user)

        {
            if (_diccionarioUsuarios.ContainsKey(user.Id))
                return false;
            _diccionarioUsuarios.Add(user.Id, user);
            GuardarDatos();
            return true;

        }
        public bool EliminarUsuario(string id)

        {
            if (!_diccionarioUsuarios.ContainsKey(id))
                return false;
            _diccionarioUsuarios.Remove(id);
            GuardarDatos();
            return true;

        }
        public void GuardarDatos()

        {
            try

            {
                using (StreamWriter sw = new StreamWriter(_textFile))

                {
                    foreach (KeyValuePair<string, IUsuarioView> usu in _diccionarioUsuarios)

                    {
                        string cadena = Codificar(usu.Value);
                        sw.WriteLine(cadena);

                    }

                }

            }
            catch (Exception e)

            {
                Console.WriteLine(e.Message);

            }

        }
        private string Codificar(IUsuarioView user)
        {
            string cadena;
            cadena = "";
            for (int j = 0; j < _formatoRegistro.CamposRegistro.Length; j++)
            {
                switch (_formatoRegistro.CamposRegistro[j])
                {
                    case CamposRegistro.Id: cadena = cadena + user.Id; break;
                    case CamposRegistro.Nombre: cadena = cadena + user.Nombre; break;
                    case CamposRegistro.PalabraPaso: cadena = cadena + user.PalabraPaso; break;
                    case CamposRegistro.Categoria: cadena = cadena + user.Categoria; break;
                    case CamposRegistro.EsValido: cadena = cadena + user.EsValido; break;
                }
                if (j < _formatoRegistro.CamposRegistro.Length - 1)
                    cadena = cadena + _finCampo;
            }
            return cadena;
        }
    }
}

