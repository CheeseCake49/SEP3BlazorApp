using System.Net.Http.Json;
using System.Text;
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

    public async Task DeleteCenter(int id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"/center/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<List<Center>> GetCentersAsync()
    {
        HttpResponseMessage response = await client.GetAsync("/center");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        List<Center> centers = JsonSerializer.Deserialize<List<Center>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return centers;
    }

    public async Task<Center> UpdateAsync(CenterUpdatingDTO dto)
    {
        string dtoAsJson = JsonSerializer.Serialize(dto);
        Console.WriteLine($"JSON Payload: {dtoAsJson}");
        StringContent body = new StringContent(dtoAsJson, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PatchAsync("/center", body);
        
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {  
            throw new Exception(content);
        }
        
        Center center = JsonSerializer.Deserialize<Center>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return center;
    }

    public async Task<Center?> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/center/{id}");
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

    public async Task<string> AddCenterAdminAsync(CenterAdminDTO dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync($"/center/{dto.centerId}/admins", dto);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Console.WriteLine(content);

        CenterAdminDTO newAdmin = JsonSerializer.Deserialize<CenterAdminDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return newAdmin.username;
    }
}