public class Quadrado
{
    private double lado;

    public Quadrado(double lado)
    {
        this.lado = lado;
    }

    public double GetLado()
    {
        return this.lado;
    }

    public void SetLado(double lado)
    {
        this.lado = lado;
    }

    public double Area()
    {
        return lado * lado;
    }

    public double Perimetro()
    {
        return 4 * lado;
    }
}