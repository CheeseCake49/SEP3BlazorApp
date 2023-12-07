using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookingService
{
    Task<Booking> CreateBooking(BookingCreationDTO bookingCreationDTO);
}