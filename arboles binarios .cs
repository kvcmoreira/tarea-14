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

    public void PreOrden()
    {
        PreOrdenRec(raiz);
        Console.WriteLine();
    }

    private void PreOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreOrdenRec(nodo.Izquierdo);
            PreOrdenRec(nodo.Derecho);
        }
    }

    public void PostOrden()
    {
        PostOrdenRec(raiz);
        Console.WriteLine();
    }

    private void PostOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrdenRec(nodo.Izquierdo);
            PostOrdenRec(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    public int EncontrarMinimo()
    {
        Nodo actual = raiz;
        while (actual.Izquierdo != null)
            actual = actual.Izquierdo;
        return actual.Valor;
    }

    public int EncontrarMaximo()
    {
        Nodo actual = raiz;
        while (actual.Derecho != null)
            actual = actual.Derecho;
        return actual.Valor;
    }

    public int Altura()
    {
        return AlturaRec(raiz);
    }

    private int AlturaRec(Nodo nodo)
    {
        if (nodo == null)
            return -1;
        return Math.Max(AlturaRec(nodo.Izquierdo), AlturaRec(nodo.Derecho)) + 1;
    }

    public int ContarNodos()
    {
        return ContarNodosRec(raiz);
    }

    private int ContarNodosRec(Nodo nodo)
    {
        if (nodo == null)
            return 0;
        return 1 + ContarNodosRec(nodo.Izquierdo) + ContarNodosRec(nodo.Derecho);
    }

    public int ContarHojas()
    {
        return ContarHojasRec(raiz);
    }

    private int ContarHojasRec(Nodo nodo)
    {
        if (nodo == null)
            return 0;
        if (nodo.Izquierdo == null && nodo.Derecho == null)
            return 1;
        return ContarHojasRec(nodo.Izquierdo) + ContarHojasRec(nodo.Derecho);
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
            Console.WriteLine("4. Recorrido Preorden");
            Console.WriteLine("5. Recorrido Postorden");
            Console.WriteLine("6. Encontrar mínimo");
            Console.WriteLine("7. Encontrar máximo");
            Console.WriteLine("8. Calcular altura");
            Console.WriteLine("9. Contar nodos");
            Console.WriteLine("10. Contar hojas");
            Console.WriteLine("11. Salir");
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
                    Console.WriteLine("Recorrido Preorden: ");
                    arbol.PreOrden();
                    break;
                case 5:
                    Console.WriteLine("Recorrido Postorden: ");
                    arbol.PostOrden();
                    break;
                case 6:
                    Console.WriteLine("Mínimo valor: " + arbol.EncontrarMinimo());
                    break;
                case 7:
                    Console.WriteLine("Máximo valor: " + arbol.EncontrarMaximo());
                    break;
                case 8:
                    Console.WriteLine("Altura del árbol: " + arbol.Altura());
                    break;
                case 9:
                    Console.WriteLine("Número total de nodos: " + arbol.ContarNodos());
                    break;
                case 10:
                    Console.WriteLine("Número de hojas: " + arbol.ContarHojas());
                    break;
                case 11:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        } while (opcion != 11);
    }
}
