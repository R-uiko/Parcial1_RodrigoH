using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Ejercicio 1: Costo de llamadas telefónicas internacionales");
            Console.WriteLine("2. Ejercicio 2: Gestión de libros en una biblioteca");
            Console.WriteLine("3. Salir");
            Console.Write("Elija una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    EjercicioCostoLlamadas();
                    break;
                case 2:
                    Biblioteca.EjecutarGestionLibros();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void EjercicioCostoLlamadas()
    {
        int[] claves = { 12, 15, 18, 19, 23 };
        string[] zonas = { "America del norte", "America central", "America del sur", "Europa", "Asia" };
        double[] precios = { 2, 2.2, 4.5, 3.5, 6 };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 1: Costo de llamadas telefónicas internacionales");
            Console.WriteLine("Clave  Zona                Precio por Minuto");
            Console.WriteLine("--------------------------------------------");
            for (int i = 0; i < claves.Length; i++)
            {
                Console.WriteLine($"{claves[i],-6} {zonas[i],-20} {precios[i],-18:C}");
            }
            Console.WriteLine("--------------------------------------------");

            Console.Write("Ingrese la clave de la zona (12, 15, 18, 19, 23): ");
            int clave = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el número de minutos: ");
            int minutos = int.Parse(Console.ReadLine());

            double costo = CalcularCostoLlamada(clave, minutos, claves, precios);
            Console.WriteLine($"El costo de la llamada es: {costo:C}");

            Console.WriteLine("¿Desea calcular otro costo? (S/N)");
            string respuesta = Console.ReadLine();
            if (respuesta.ToUpper() != "S")
            {
                break;
            }
        }
    }

    static double CalcularCostoLlamada(int clave, int minutos, int[] claves, double[] precios)
    {
        double costo = 0;
        int index = Array.IndexOf(claves, clave);
        if (index != -1)
        {
            costo = minutos * precios[index];
        }
        return costo;
    }
}
