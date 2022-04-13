Conta c1 = new Conta(1);
Conta c2 = new Conta(2);

c2.Depositar(200.0);
c2.Sacar(50.0);
c2.Transferir(150.0, c1);
Console.WriteLine(c2.Codigo);
Console.WriteLine(c2.Saldo);

c1.Depositar(1000.0);
c1.Sacar(200.0);
Console.WriteLine(c1.Codigo);
Console.WriteLine(c1.Saldo);

