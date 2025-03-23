using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo, Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = Derecho = null;
    }
}

class ArbolBinario
{
    private Nodo raiz;

    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);

        return nodo;
    }

    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return false;
        if (valor == nodo.Valor)
            return true;
        return valor < nodo.Valor ? BuscarRec(nodo.Izquierdo, valor) : BuscarRec(nodo.Derecho, valor);
    }

    public void InOrden()
    {
        InOrdenRec(raiz);
        Console.WriteLine();
    }

    private void InOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrdenRec(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InOrdenRec(nodo.Derecho);
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- Menú Árbol Binario ---");
            Console.WriteLine("1. Insertar un nodo");
            Console.WriteLine("2. Buscar un nodo");
            Console.WriteLine("3. Recorrido Inorden");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    break;
                case 2:
                    Console.Write("Ingrese el valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "Nodo encontrado" : "Nodo no encontrado");
                    break;
                case 3:
                    Console.WriteLine("Recorrido Inorden: ");
                    arbol.InOrden();
                    break;
                case 4:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        } while (opcion != 4);
    }
}
