using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;
    
    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> CreateUser(UserCreationDTO userCreationDTO)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/user", userCreationDTO);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }


        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
    
    public async Task<List<User>> GetAllUsers()
    {
        string uri = "/user";
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<User> users = JsonSerializer.Deserialize<List<User>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return users;
    }

    public async Task<List<User>> GetCenterAdminsAsync(int centerId)
    {
        HttpResponseMessage response = await client.GetAsync($"/user/admins/{centerId}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        List<User>? admins = JsonSerializer.Deserialize<List<User>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return admins ?? new List<User>();
    }   
    
}