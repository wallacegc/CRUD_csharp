using MySql.Data.MySqlClient;
using System;

public class DatabaseConnection
{
    // Connection string to the database
    private readonly string _connectionString = "Server=localhost;Database=crud;User ID=root;Password=;";

    // Method that creates and returns the connection to the database
    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }

    // Method to open the connection
    public MySqlConnection OpenConnection()
    {
        var connection = GetConnection();
        connection.Open();
        return connection;
    }
}