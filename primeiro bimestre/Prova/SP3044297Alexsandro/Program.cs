Console.WriteLine("Entre com a base maior do trapézio");
double baseMaior = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Entre com a base menor do trapézio");
double baseMenor = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Entre com o lado 1 do trapézio");
double lado1 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Entre com o lado 2 do trapézio");
double lado2 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Entre com a altura do trapézio");
double altura = Convert.ToDouble(Console.ReadLine());

Trapezio t1 = new Trapezio(baseMaior, baseMenor, lado1, lado2, altura);
Console.WriteLine(t1.ApresentarAreaPerimetro);

