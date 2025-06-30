namespace PSS.lhm232.Practica_02
{
    public interface IUsuarioView
    {
            string Id { get; set; } 
            string Nombre { get; set; }
            string PalabraPaso { get; set; }
            string Categoria { get; set; }
            bool EsValido { get; set; }
        }

    }
