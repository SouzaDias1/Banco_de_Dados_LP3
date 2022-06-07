es (13 sloc)  313 Bytes
   
// namespace Banco_de_Dados_LP3.Models;

class Computer
{
    public int Id {get ; set; }
    public string Ram { get; set; }
    public string Processador { get; set; }  

    public Computer (int id, string ram, string processador)
    {
        Id = id;
        Ram = ram; 
        Processador = processador;
    }
    
}