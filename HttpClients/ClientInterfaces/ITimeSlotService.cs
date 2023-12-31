using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface ITimeSlotService
{
    Task<TimeSlot> CreateTimeSlot(TimeSlotCreationDTO timeSlotCreationDTO);
    Task<List<TimeSlot>> GetTimeSlots(int courtId);
}