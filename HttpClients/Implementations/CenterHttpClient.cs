using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class CenterHttpClient : ICenterService
{
    private readonly HttpClient client;

    public CenterHttpClient(HttpClient client)
    {
        this.client = client;
    }


    public async Task<Center> CreateCenter(CenterCreationDTO centerCreationDTO)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/center", centerCreationDTO);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }


        Center center = JsonSerializer.Deserialize<Center>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return center;
    }

    public async Task<ICollection<Center>> GetCentersAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/center");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Center> centers = JsonSerializer.Deserialize<ICollection<Center>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return centers;
    }
}