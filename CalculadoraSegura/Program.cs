using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===Calculadora Segura v3.0===");

        string? opcion = "";

        while (opcion != "5")

        {
            Console.WriteLine("\nElige una operacion:");
            Console.WriteLine("1. Suma (+)");
            Console.WriteLine("2. Resta (-)");
            Console.WriteLine("3. Multiplicacion (*)");
            Console.WriteLine("4. Division (/)");
            Console.WriteLine("5. Salir");
            Console.WriteLine("Opcion: ");

            opcion = Console.ReadLine();

            if (opcion == "5")
            {
                Console.WriteLine("Gracias por usar la calculadora segura v3");
                break;
            }

            if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4")
            {
                Console.WriteLine("Opcion no valida, elige un numero del 1 al 5");
                continue;
            }



            double numero1 = 0;
            double numero2 = 0;

            Console.WriteLine("Ingrese el primer numero:");
            string? input1 = Console.ReadLine();

            if (double.TryParse(input1, out numero1))
            {
                
            }
            else
            {
                Console.WriteLine("Error en el numero 1! Usaremos 0 por defecto");
            }

            Console.WriteLine("Ingrese el segundo numero: ");
            string? input2 = Console.ReadLine();

            if (double.TryParse(input2, out numero2))
            {
                
            }
            else
            {
                Console.WriteLine("Error en el numero 2! Usaremos 0 por defecto");
            }

            double resultado = 0;

            switch (opcion)
            {
                case "1":
                    resultado = numero1 + numero2;
                    Console.WriteLine($"Resultado: {numero1} + {numero2} = {resultado}");
                    break;
                case "2":
                    resultado = numero1 - numero2;
                    Console.WriteLine($"Resultado: {numero1} - {numero2} = {resultado}");
                    break;
                case "3":
                    resultado = numero1 * numero2;
                    Console.WriteLine($"Resultado: {numero1} * {numero2} = {resultado}");
                    break;
                case "4":
                    if (numero2 == 0)
                    {
                        Console.WriteLine("Error no se puede dividir entre 0");
                    }
                    else
                    {
                        resultado = numero1 / numero2;
                        Console.WriteLine($"Resultado: {numero1} / {numero2} = {resultado}");
                    }
                    break;
                default:
                    Console.WriteLine("Opcion de menu no valida");
                    break;

            }

            Console.WriteLine("\n---------------------------------------------");
        }
    }
}