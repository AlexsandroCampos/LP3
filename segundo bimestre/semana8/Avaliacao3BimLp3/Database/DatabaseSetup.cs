using Microsoft.Data.Sqlite;
using Dapper;

namespace Avaliacao3BimLp3.Database;

class DatabaseSetup
{
    private readonly DatabaseConfig _databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
        CreateStudentTable();
    }

    public void CreateStudentTable() 
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute(@"
            CREATE TABLE IF NOT EXISTS Students(
                registration varchar(100) not null primary key,
                name varchar(100) not null,
                city varchar(100) not null,
                former bool not null
            );
        "); 
        
    }
}