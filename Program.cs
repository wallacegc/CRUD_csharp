using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Cadastro de Clientes");

        Console.Write("Nome: ");
        string name = Console.ReadLine();

        string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");

        var clienteService = new ClienteService();
        clienteService.InserirCliente(name, dateCreated);

        // Exibir os dados cadastrados
        Console.WriteLine("\nCliente cadastrado:");
        Console.WriteLine($"Nome: {name}");
        Console.WriteLine($"Data de Cadastro: {dateCreated}");    }
}