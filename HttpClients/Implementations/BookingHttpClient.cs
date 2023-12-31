using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class BookingHttpClient : IBookingService
{
    private readonly HttpClient client;
    
    public BookingHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<Booking> CreateBooking(BookingCreationDTO bookingCreationDTO)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/booking", bookingCreationDTO);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Booking booking = JsonSerializer.Deserialize<Booking>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return booking;
    }
}