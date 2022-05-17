
using Banco_de_Dados_LP3.Models;
using Microsoft.Data.Sqlite;

namespace Banco_de_Dados_LP3.Repositories;

class ComputerRepository
{
    public List<Computer> GetAll()
    {
        var Computers = new List<Computer>();

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers;";
        
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var computer = new Computer(
                reader.GetInt32(0), 
                reader.GetString(1), 
                reader.GetString(2)
            );
            Computers.Add(computer);

        }
        connection.Close();

        return Computers;
    }
}