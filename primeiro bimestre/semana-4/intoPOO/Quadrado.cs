public class Quadrado
{
    public double Lado { get; set; }
    public double Area { get => Lado * Lado; }
    public double Perimetro { get => 4 * Lado; }
    public Quadrado(double lado) => Lado = lado;
}