﻿using LabManager.Database;
using LabManager.Models;
using LabManager.Repositories;
using Microsoft.Data.Sqlite;



var databaseConfig = new DatabaseConfig();
var DatabaseSetup= new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processador);
        }
    }

    if(modelAction == "New")
    {
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processador = args[4];

        if (computerRepository.existsById(id))
        {
            Console.WriteLine($"Computer com id {id} ja esta cadastrado"); 
        }
        else
        {
            Console.WriteLine("New computer");
            var computer = new Computer(id, ram, processador);
            computerRepository.Save(computer);
        }
    }
    
    if(modelAction == "Show")
    {
        int id = Convert.ToInt32(args[2]);
        if (computerRepository.existsById(id) == true)
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processador);
        } 
        else
        {
            Console.WriteLine($"Computer com id {id} não existe");
        }
       
    }

    if(modelAction == "Delete")
    {
       int id = Convert.ToInt32(args[2]);
       if (computerRepository.existsById(id) == true)
       {
           computerRepository.Delete(id);
       }
       else
       {
            Console.WriteLine($"Computer com id {id} não existe");
       }
    }

    if(modelAction == "Update")
    {
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processador = args[4];
         
       if (computerRepository.existsById(id) == true)
       {
            var computer = new Computer(id, ram, processador);
            computerRepository.Update(computer); 
       }
       else
       {
            Console.WriteLine($"Computer com id {id} não existe");
       }  
    }
}

if(modelName == "Lab")
{
    if(modelAction == "List")
    {
        
    }

    if(modelAction == "New")
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        Console.WriteLine("New lab");
        int id = Convert.ToInt32(args[2]);
        string num = args[3];
        string nome = args[4];
        string bloco = args[5];
         
        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Lab VALUES($id, $num,  $nome, $bloco);";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$num", num);
        command.Parameters.AddWithValue("$nome", nome);
        command.Parameters.AddWithValue("$bloco", bloco);

        command.ExecuteNonQuery();
        connection.Close();
    }
}