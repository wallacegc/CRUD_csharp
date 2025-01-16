using MySql.Data.MySqlClient;
using System;

public class ClientService
{
    private DatabaseConnection _databaseConnection;

    public ClientService()
    {
        _databaseConnection = new DatabaseConnection();
    }

    // Method to insert a client into the database
    public void InsertClient(string name, string dateCreated)
    {
        using (var connection = _databaseConnection.OpenConnection())
        {
            try
            {
                string query = "INSERT INTO clients (name, created) VALUES (@name, @dateCreated)";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@dateCreated", dateCreated);

                    // Execute the SQL command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Client successfully registered!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to register the client.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Method to get all clients from the database
    public List<Client> GetAllClients()
    {
        var clients = new List<Client>();

        using (var connection = _databaseConnection.OpenConnection())
        {
            try
            {
                string query = "SELECT id, name, created FROM clients";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var client = new Client
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name"),
                                DateCreated = reader.GetDateTime("created")
                            };
                            clients.Add(client);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return clients;
    }
}
