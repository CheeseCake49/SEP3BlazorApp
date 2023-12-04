using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateUser(UserCreationDTO userCreationDTO);
    Task<IEnumerable<User>> GetAllUsers(string? usernameContains = null);

}