using ApiContracts;

namespace BlazorApp.Services;

public interface IUserInterface
{
    public Task<UserDto> AddUsernameAsync(CreateUserDto request);
    public Task<UserDto> UpdateUserAsync(int id, UpdateUserDto request);
    public Task DeleteUserAsync(int id);
    public Task GetUserByIdAsync(int id);
    public Task GetUsersAsync();
}