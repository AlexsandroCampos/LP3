using Microsoft.Data.Sqlite;
using Dapper;

namespace Avaliacao3BimLp3.Database;

class DatabaseSetup
{
    private readonly DatabaseConfig _databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateProductTable();
    }

    public void CreateProductTable() 
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Products(
                id int not null primary key,
                name varchar(100) not null,
                price double not null,
                active bool not null
            );
        "); 
        
    }
}