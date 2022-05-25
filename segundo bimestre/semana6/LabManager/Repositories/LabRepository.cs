using LabManager.Repositories;
using LabManager.Models;
using Microsoft.Data.Sqlite;

class LabRepository
{
    public List<Lab> getAll()
    {
        var labs = new List<Lab>(); 
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();


        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Lab;";

         var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var lab = new Lab(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),  reader.GetString(3));
            labs.Add(lab);
        }

        reader.Close();
        connection.Close();

        return labs;
    }
}