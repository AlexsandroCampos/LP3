using Avaliacao3BimLp3.Database;
using Avaliacao3BimLp3.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Avaliacao3BimLp3.Repositories;

public class StudentRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public StudentRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public Student Save(Student student)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Students VALUES(@Registration, @Name, @City, @Former) ", student);

        return student;
    }

    public void Delete(string registration)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("DELETE FROM Students WHERE registration = @Registration", new { @Registration = registration });
    }

    public void MarkAsFormed(string registration)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("UPDATE Students SET former=true WHERE registration=@Registration", new { @Registration = registration });
    }

    public List<Student> GetAll()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.Query<Student>("SELECT * FROM Students").ToList();
    }

    public List<Student> GetAllFormed()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.Query<Student>("SELECT * FROM Students Where former=true").ToList();
    }

    public List<Student> GetAllStudentByCity(string city)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.Query<Student>("SELECT * FROM Students Where city LIKE @City", new {@City = city+'%'}).ToList();
    }

    public List<Student> GetAllByCities(string[] cities)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.Query<Student>("SELECT * FROM Students Where city IN @City", new {@City = cities}).ToList();
    }

    public List<CountStudentGroupByAttribute> CountByCities()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.Query<CountStudentGroupByAttribute>("SELECT city AS attributeName, COUNT(registration) AS studentNumber FROM Students GROUP BY city").ToList();
    }

    public List<CountStudentGroupByAttribute> CountByFormed()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.Query<CountStudentGroupByAttribute>("SELECT former AS attributeName, COUNT(registration) AS studentNumber FROM Students Group By former").ToList();
    }

    public bool ExistsByRegistration(string registration)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        return connection.ExecuteScalar<bool>("SELECT COUNT(registration) FROM Students WHERE registration = @Registration", new { @Registration = registration});
    }
}