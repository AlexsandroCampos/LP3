using System;

namespace EstudoDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o seu nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o seu sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.WriteLine("Digite a nota 1: ");
            double nota1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite a nota 2: ");
            double nota2 = Convert.ToDouble(Console.ReadLine());

            double media = (nota1+nota2)/2;
            
            Console.WriteLine("A média é: {0}", media);

            Console.WriteLine("Olá, " + nome + " " + sobrenome);
            Console.WriteLine("Olá, {0} {1}", nome, sobrenome);
        }
    }
}
