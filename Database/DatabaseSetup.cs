using Microsoft.Data.Sqlite;
namespace Banco_de_Dados_LP3.Database;

class DatabaseSetup
{

    public DatabaseSetup()
    {
        CreatTableComputer();
        CreatTableLab();
    }

    public void CreatTableComputer()
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Computers(
                id int not null primary key,
                ran varchar(100) not null,
                processor varchar(100) not null
            );
        ";
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void CreatTableLab()
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Lab(
                id int not null primary key,
                ran varchar(100) not null,
                processor varchar(100) not null
            );
        ";
        command.ExecuteNonQuery();
        connection.Close();
    }
}