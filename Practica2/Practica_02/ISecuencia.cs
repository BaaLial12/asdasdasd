namespace PSS.lhm232.Practica_02;

public interface ISecuencia<T>
{
    void Anadir(T item); 
    bool Eliminar(T item);
    bool Contiene(T item);
    void Limpiar(); 
    int Cuenta { get; }
    object datos_secuencia { get; }

    void Ordenar(IComparer<T> comparador); 
    T this[int i] { get; set; } 
}