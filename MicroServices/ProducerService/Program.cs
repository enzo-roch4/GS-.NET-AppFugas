using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

class Program
{
    static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "fila.pedidos",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        // Cria um usuário para enviar na fila
        var usuario = new Usuario
        {
            nome = "João da Silva",
            cpf = "12345678900",
            email = "joao@email.com",
            senha = "senha123"
        };

        var message = JsonSerializer.Serialize(usuario);
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: "",
            routingKey: "fila.pedidos",
            basicProperties: null,
            body: body);

        Console.WriteLine("Mensagem enviada para fila:");
        Console.WriteLine(message);
    }
}

public class Usuario
{
    public string nome { get; set; } = string.Empty;
    public string cpf { get; set; } = string.Empty;
    public string email { get; set; } = string.Empty;
    public string senha { get; set; } = string.Empty;
}
