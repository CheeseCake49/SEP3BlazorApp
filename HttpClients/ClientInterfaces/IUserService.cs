using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateUser(UserCreationDTO userCreationDTO);
    Task<List<User>> GetAllUsers();
    Task<List<User>> GetCenterAdminsAsync(int centerId);

}