using System;

public class Biblioteca
{
    private static string[] codigos = new string[100];
    private static string[] titulos = new string[100];
    private static string[] isbns = new string[100];
    private static int[] ediciones = new int[100];
    private static string[] autores = new string[100];
    private static int contadorLibros = 0;

    public static void EjecutarGestionLibros()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menú de Gestión de Libros:");
            Console.WriteLine("1. Agregar un libro");
            Console.WriteLine("2. Mostrar listado de libros");
            Console.WriteLine("3. Buscar libro por código");
            Console.WriteLine("4. Editar información de un libro");
            Console.WriteLine("5. Volver al Menú Principal");
            Console.Write("Elija una opción: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AgregarLibro();
                        break;
                    case 2:
                        MostrarListadoLibros();
                        break;
                    case 3:
                        BuscarLibroPorCodigo();
                        break;
                    case 4:
                        EditarInformacionLibro();
                        break;
                    case 5:
                        return; // Volver al Menu Principal
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }
        }
    }

    private static void AgregarLibro()
    {
        Console.Write("Ingrese el código del libro: ");
        string codigo = Console.ReadLine();           //deja de pensar que verde es un error, aun funciona y eso es lo que cuenta
        Console.Write("Ingrese el título del libro: ");
        string titulo = Console.ReadLine();
        Console.Write("Ingrese el ISBN del libro: ");
        string isbn = Console.ReadLine();
        Console.Write("Ingrese la edición del libro: "); //tiene que ser numero
        int edicion;
        if (int.TryParse(Console.ReadLine(), out edicion))
        {
            Console.Write("Ingrese el autor del libro: ");
            string autor = Console.ReadLine();

            codigos[contadorLibros] = codigo;
            titulos[contadorLibros] = titulo;
            isbns[contadorLibros] = isbn;
            ediciones[contadorLibros] = edicion; // no consolereadline no verde :)
            autores[contadorLibros] = autor;

            contadorLibros++;
        }
        else
        {
            Console.WriteLine("La edición debe ser un número entero.");
        }
    }

    private static void MostrarListadoLibros()
    {
        if (contadorLibros == 0)
        {
            Console.WriteLine("No hay libros registrados en la biblioteca.");
        }
        else
        {
            //UI
            Console.WriteLine("Listado de Libros:");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("| Código | Título                | ISBN         | Autor          |");
            Console.WriteLine("--------------------------------------------------------");
            for (int i = 0; i < contadorLibros; i++)
            {
                Console.WriteLine($"| {codigos[i],-7} | {titulos[i],-22} | {isbns[i],-13} | {autores[i],-15} |");
            }
            Console.WriteLine("--------------------------------------------------------");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private static void BuscarLibroPorCodigo()
    {
        Console.Write("Ingrese el código del libro a buscar: ");
        string codigo = Console.ReadLine();
        int index = Array.IndexOf(codigos, codigo);
        if (index != -1)
        {
            Console.WriteLine("Información del libro:");
            Console.WriteLine($"Código: {codigos[index]}");
            Console.WriteLine($"Título: {titulos[index]}");
            Console.WriteLine($"ISBN: {isbns[index]}");
            Console.WriteLine($"Edición: {ediciones[index]}");
            Console.WriteLine($"Autor: {autores[index]}");
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private static void EditarInformacionLibro()// ojala funcione v3
    {
        Console.Write("Ingrese el código del libro a editar: ");
        string codigo = Console.ReadLine();
        int index = Array.IndexOf(codigos, codigo);
        if (index != -1)
        {
            Console.WriteLine("Editar información del libro:");
            Console.Write("Nuevo título: ");
            titulos[index] = Console.ReadLine();
            Console.Write("Nuevo ISBN: ");
            isbns[index] = Console.ReadLine();
            Console.Write("Nueva edición: ");
            int edicion;
            if (int.TryParse(Console.ReadLine(), out edicion))
            {
                ediciones[index] = edicion;
                Console.Write("Nuevo autor: ");
                autores[index] = Console.ReadLine();
                Console.WriteLine("Información del libro actualizada.");
            }
            else
            {
                Console.WriteLine("La edición debe ser un número entero.");
            }
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");//fuera bueno que aparesca este error pero magicamente desaparece o lo carga y lo cierra imediatamente? porque? Funciona
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
