using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Client Registration");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");

        var clientService = new ClientService();
        clientService.InsertClient(name, dateCreated);

        // Display the registered data
        Console.WriteLine("\nClient registered:");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Registration Date: {dateCreated}");

        // Exibir a lista de todos os clientes cadastrados
        Console.WriteLine("\nList of Registered Clients:");
        var clients = clientService.GetAllClients();

        foreach (var client in clients)
        {
            Console.WriteLine($"Id: {client.Id}, Name: {client.Name}, Registration Date: {client.DateCreated}");
        }
    }
}