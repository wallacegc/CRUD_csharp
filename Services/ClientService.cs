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
                // SQL command to insert the data
                string query = "INSERT INTO users (name, created) VALUES (@name, @dateCreated)";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Define parameters
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
}
