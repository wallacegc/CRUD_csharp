using MySql.Data.MySqlClient;
using System;

public class DatabaseConnection
{
    // String de conexão com o banco de dados
    private readonly string _connectionString = "Server=localhost;Database=crud;User ID=root;Password=;";

    // Método que cria e retorna a conexão com o banco
    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }

    // Método para abrir a conexão
    public MySqlConnection OpenConnection()
    {
        var connection = GetConnection();
        connection.Open();
        return connection;
    }
}