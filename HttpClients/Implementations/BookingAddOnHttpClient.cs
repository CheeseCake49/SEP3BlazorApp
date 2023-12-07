using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.Implementations;

public class BookingAddOnHttpClient : IBookingAddOnService
{
    private readonly HttpClient client;
    
    public BookingAddOnHttpClient(HttpClient client)
    {
        this.client = client;
    }

    public async Task<BookingAddOn> CreateBookingAddOn(BookingAddOnCreationDTO bookingAddOnCreationDTO)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/bookingaddon", bookingAddOnCreationDTO);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        BookingAddOn bookingAddOn = JsonSerializer.Deserialize<BookingAddOn>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return bookingAddOn;
    }
}