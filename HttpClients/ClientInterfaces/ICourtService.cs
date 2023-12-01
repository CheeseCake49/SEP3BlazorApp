using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface ICourtService
{
    Task <Court> CreateCourt(CourtCreationDTO courtCreationDTO, int centerId);
    Task<List<Court>> GetCourtsAsync(int centerId);
}