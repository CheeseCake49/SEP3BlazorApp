using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface ICourtService
{
    Task <Court> CreateCourt(CourtCreationDTO courtCreationDTO);
    Task<ICollection<Court>> GetCourtsAsync(int centerId);
}