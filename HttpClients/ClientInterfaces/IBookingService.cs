using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookingService
{
    Task<Booking> createBookingAsyncTask(BookingCreationDTO bookingDTO, string username, int centerId, int courtId);
}