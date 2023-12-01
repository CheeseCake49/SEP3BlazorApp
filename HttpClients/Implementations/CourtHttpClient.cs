using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class CourtHttpClient : ICourtService
{
    private readonly HttpClient client;

    public CourtHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Court> CreateCourt(CourtCreationDTO courtCreationDTO, int centerId)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync($"/court/{centerId}", courtCreationDTO);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        Court court = JsonSerializer.Deserialize<Court>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return court;
    }

    public async Task<List<Court>> GetCourtsAsync(int centerId)
    {
        HttpResponseMessage response = await client.GetAsync($"/court/{centerId}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        List<Court> courts = JsonSerializer.Deserialize<List<Court>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return courts;
    }
}