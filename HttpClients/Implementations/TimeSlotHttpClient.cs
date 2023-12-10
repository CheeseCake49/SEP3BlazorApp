using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class TimeSlotHttpClient : ITimeSlotService
{
    private readonly HttpClient client;
    
    public TimeSlotHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<TimeSlot> CreateTimeSlot(TimeSlotCreationDTO timeSlotCreationDTO)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/timeslot", timeSlotCreationDTO);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        TimeSlot timeSlot = JsonSerializer.Deserialize<TimeSlot>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return timeSlot;
    }

    public async Task<List<TimeSlot>> GetTimeSlots(int courtId)
    {
        HttpResponseMessage response = await client.GetAsync($"/timeslot/{courtId}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
        
        List<TimeSlot> timeSlots = JsonSerializer.Deserialize<List<TimeSlot>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return timeSlots;
    }
}