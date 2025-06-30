
using PSS.lhm232.Practica_02;
using System.Collections;

namespace PSS.lhm232.Practica_02
{
    public class Secuencia<T> : IEnumerable<T>, ISecuencia<T>
    {
        public List<T> datos_secuencia;

        public Secuencia()
        {
            datos_secuencia = new List<T>();
        }

        public void Anadir(T item)
        {
            datos_secuencia.Add(item);
        }


        public bool Eliminar(T item)
        {
            return datos_secuencia.Remove(item);
        }
        public bool Contiene(T item)
        {
            return datos_secuencia.Contains(item);
        }

        public void Limpiar()
        {
            datos_secuencia.Clear();
        }
        public int Cuenta
        {
            get { return datos_secuencia.Count; }
        }

        object ISecuencia<T>.datos_secuencia => throw new NotImplementedException();

        public void Ordenar(IComparer<T> comparador)
        {
            datos_secuencia.Sort(comparador);
        }

        public T this[int i]
        {
            get { return datos_secuencia[i]; }
            set { datos_secuencia[i] = value; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = datos_secuencia.Count - 1; i >= 0; i--)
            {
                yield return datos_secuencia[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<T> RecorridoAdelante()
        {
            foreach (var item in datos_secuencia)
            {
                yield return item;
            }

        }
        public IEnumerable<T> RecorridoAtras()
        {
            IList<T> listaI = datos_secuencia;
            foreach (var elemento in listaI.Reverse())
            {
                yield return elemento;
            }
        }
        public IEnumerable<T> RecorridoAscendente<T>()
        {
            List<T> tmp = new List<T>((IEnumerable<T>)datos_secuencia);
            tmp.Sort();

            foreach (var item in tmp)
            {
                yield return item;
            }
        }


        public IEnumerable<T> RecorridoDescendente<T>()
        {
            List<T> tmp = new List<T>((IEnumerable<T>)datos_secuencia);
            tmp.Sort();
            IList<T> listaI = tmp;

            foreach (var item in listaI.Reverse())
            {
                yield return item;
            }
        }
    }
}