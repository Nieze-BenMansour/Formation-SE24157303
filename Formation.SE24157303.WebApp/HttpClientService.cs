namespace Formation.SE24157303.WebApp;

using Formation.SE24157303.Contracts.DTOs.Clients;
using System.Net.Http.Json;

public class HttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GetClientResponse>> GetClientsAsync()
    {

        return await _httpClient.GetFromJsonAsync<List<GetClientResponse>>("https://localhost:7209/api/Client");
        
    }

    public async Task<GetClientResponse> GetClientAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<GetClientResponse>($"client/{id}");
    }

    public async Task CreateClientAsync(CreateClientRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("client", request);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateClientAsync(int id, UpdateClientRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"client/{id}", request);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteClientAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"clients/{id}");
        response.EnsureSuccessStatusCode();
    }
}
