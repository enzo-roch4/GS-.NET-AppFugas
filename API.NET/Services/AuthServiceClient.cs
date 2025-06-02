using System.Net.Http;
using System.Threading.Tasks;

public class AuthServiceClient
{
    private readonly HttpClient _httpClient;

    public AuthServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> ValidarEmailAsync(string email)
    {
        // Exemplo de URL externa (pode simular com JSONPlaceholder ou sua própria API fake)
        var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users?email={email}");
        return response.IsSuccessStatusCode;
    }
}
