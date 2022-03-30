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

            double pesoNormalMinimo = altura * altura * 18.5;
            double pesoNormalMaximo = altura * altura * 25;
            double pesoFaltante = pesoNormalMinimo - peso;
            double pesoExcesso = peso - pesoNormalMaximo;
            if(imc < 17 ){
                Console.WriteLine("Está muito abaixo do peso. Deveria receber mais {0} Kg", pesoFaltante);
            }

            else if(imc >= 17 && imc < 18.5 ){
                Console.WriteLine("Está abaixo do peso. Deveria receber mais {0} Kg", pesoFaltante);
            }

            else if(imc >= 18.5 && imc < 25){
                 Console.WriteLine("Está com peso normal");
            }

            else if(imc >= 25 && imc < 30){
                 Console.WriteLine("Está acima do peso. Deveria perder {0} Kg", pesoExcesso);
            }

            else if(imc >= 30 && imc < 35){
                 Console.WriteLine("Está com obsidade I. Deveria perder {0} Kg", pesoExcesso);
            }

            else if(imc >= 35 && imc < 40){
                 Console.WriteLine("Está com obsidade II. Deveria perder {0} Kg", pesoExcesso);
            }

            else {
                 Console.WriteLine("Está com obsidade III. Deveria perder {0} Kg", pesoExcesso);
            }
        }
    }
}