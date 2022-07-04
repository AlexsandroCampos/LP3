using Avaliacao3BimLp3.Database;
using Avaliacao3BimLp3.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Avaliacao3BimLp3.Repositories;

class ProductRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public ProductRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    // Insere um produto na tabela
    public Product Save(Product product)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Products  VALUES(@Id, @Name, @Price, @Active) ", product);

        return product;
    }
    // // Deleta um produto na tabela
    public void Delete(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("DELETE FROM Products  WHERE id = @Id", new {Id = id});
    }
    // // Habilita um produto
    // public void Enable(int id);
    // // Desabilita um produto
    // public void Disable(int id);
    // // Retorna todos os produtos
    public List<Product> GetAll()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.Query<Product>("SELECT * FROM Products").ToList();
    }
    // // Retorna os produtos dentro de um intervalo de preço
    // public List<Product> GetAllWithPriceBetween(double initialPrice, double endPrice);
    // // Retorna os produtos com preço acima de um preço especificado
    // public List<Product> GetAllWithPriceHigherThan(double price);
    // // Retorna os produtos com preço abaixo de um preço especificado
    // public List<Product> GetAllWithPriceLowerThan(double price);
    // // Retorna a média dos preços dos produtos
    // public double GetAveragePrice();
    public bool ExistsById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.ExecuteScalar<bool>("SELECT Count(id) FROM Products WHERE id = @Id", new {Id = id});
    }

}