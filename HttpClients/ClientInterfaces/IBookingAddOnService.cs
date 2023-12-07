using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IBookingAddOnService
{
    Task<BookingAddOn> CreateBookingAddOn(BookingAddOnCreationDTO bookingAddOnCreationDTO);
}