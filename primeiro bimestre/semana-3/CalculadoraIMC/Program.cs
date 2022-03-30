using System;

namespace CalculadoraIMC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com o seu nome");
            string nome = Console.ReadLine();

            Console.WriteLine("Entre com sua altura em metros. Ex: 1,65");
            float altura = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Entre com o seu peso em Kg. Ex: 67,7");
            float peso = Convert.ToSingle(Console.ReadLine());

            double imc = peso / (altura * altura);

            Console.WriteLine("{0}, sua altura é {1} e seu peso {2}", nome, altura, peso);

            Console.WriteLine("Seu IMC é {0}", imc);
        }
    }
}
