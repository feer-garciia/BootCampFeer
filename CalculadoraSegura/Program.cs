using System;
using System.Net;

class Program
{

    static double ObtenerNumero(string mensaje)
        {
            double numero = 0;
            Console.Write(mensaje);
            string? input = Console.ReadLine();
            if (!double.TryParse(input, out numero))
            {
                Console.WriteLine("Valor incorrecto! Usare 0 en su lugar");
            }
            return numero;
        }

    static double Suma(double numero1, double numero2)
    {
        double resultado = 0;
        resultado = numero1 + numero2;
        Console.WriteLine($"Tu suma es {numero1} + {numero2} = {resultado}");
        return resultado;
    }

    static double Resta(double numero1, double numero2)
    {
        double resultado = 0;
        resultado = numero1 - numero2;
        Console.WriteLine ($"Tu resta es {numero1} - {numero2} = {resultado}");
        return resultado;
    }

    static double Multiplicacion(double numero1, double numero2)
    {
        double resultado = 0;
        resultado = numero1 * numero2;
        Console.WriteLine($"Tu multiplicacion es {numero1} + {numero2} = {resultado}");
        return resultado;
    }
    
    static double Division(double numero1, double numero2)
    {
        double resultado = 0;
        resultado = numero1 / numero2;
        if (numero2 == 0)
        {
            Console.WriteLine("No se puede divir entre 0");
        }
        else
        {
            Console.WriteLine($"Tu division es {numero1} / {numero2} = {resultado}");
        }
        return resultado;
        
    }

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

            double numero1 = ObtenerNumero("Ingresa el primer número: ");
            double numero2 = ObtenerNumero("Ingresa el segundo numero: ");

            //double resultado = 0;

            switch (opcion)
            {
                case "1":
                    Suma(numero1, numero2);
                    break;
                case "2":
                    Resta(numero1, numero2);
                    break;
                case "3":
                    Multiplicacion(numero1, numero2);
                    break;
                case "4":
                    Division(numero1, numero2);
                    break;
                default:
                    Console.WriteLine("Opcion de menu no valida");
                    break;

            }

            Console.WriteLine("\n---------------------------------------------");
        }
    }
}