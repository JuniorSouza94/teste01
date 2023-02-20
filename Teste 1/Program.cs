using System;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var opcao = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Digite as medidas dos três lados do triângulo:");
                System.Console.WriteLine();
                Console.Write("Informe o valor do lado 1: ");
                double lado1 = double.Parse(Console.ReadLine());
                Console.Write("Informe o valor do lado 2: ");
                double lado2 = double.Parse(Console.ReadLine());
                Console.Write("Informe o valor do lado 3: ");
                double lado3 = double.Parse(Console.ReadLine());

                if (lado1 < lado2 + lado3 && lado2 < lado1 + lado3 && lado3 < lado1 + lado2)
                {
                    if (lado1 == lado2 && lado2 == lado3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nTriângulo equilátero");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nTriângulo isósceles");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nTriângulo escaleno");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nTriângulo Inválido");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("\nPara sair digite o número [1] e para repetir digite o número [2]");
                opcao = Console.ReadLine();

            } while (opcao != "1");

        }
    }
}
