public class Conta
{
    public int Codigo { get; }
    public double Saldo { get; private set;}

    public Conta(int codigo)
    {
        Codigo = codigo;
        Saldo = 0.0;
    }

    public void Sacar(double valor)
    {
        if(valor <= 0)
        {
            throw new ArgumentException("Valor não pode ser nulo ou menor do que 0");
        }

        if(valor > Saldo)
        {
            throw new ArgumentException("O valor a ser sacado não pode ser superior ao saldo disponível");
        }
        
        Saldo = Saldo - valor;
    }

    public void Depositar(double valor)
    {
        Saldo = Saldo + valor;
    }

    public void Transferir(double valor, Conta conta)
    {
        if(valor <= 0)
        {
            throw new ArgumentException("Valor não pode ser nulo ou menor do que 0");
        }

        if(valor > Saldo)
        {
            throw new ArgumentException("O valor a ser transferido não pode ser superior ao saldo disponível");
        }

        conta.Depositar(valor);
        this.Sacar(valor);
    }

}