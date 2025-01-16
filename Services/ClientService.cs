using MySql.Data.MySqlClient;
using System;

public class ClienteService
{
    private DatabaseConnection _databaseConnection;

    public ClienteService()
    {
        _databaseConnection = new DatabaseConnection();
    }

    // Método para inserir um cliente no banco de dados
    public void InserirCliente(string name, string dateCreated)
    {
        using (var connection = _databaseConnection.OpenConnection())
        {
            try
            {
                // Comando SQL para inserir os dados
                string query = "INSERT INTO users (name, created) VALUES (@name, @dateCreated)";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    // Definir parâmetros
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@dateCreated", dateCreated);

                    // Executar o comando SQL
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Cliente cadastrado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Falha ao cadastrar o cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
