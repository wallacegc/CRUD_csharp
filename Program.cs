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
    }
}