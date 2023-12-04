using System.Collections;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface ICenterService
{
    Task<Center> CreateCenter(CenterCreationDTO centerCreationDTO);
    Task DeleteCenter(int id);
    Task<List<Center>> GetCentersAsync();
}