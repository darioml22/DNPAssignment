using System.Text.Json;
using ApiContracts;

namespace BlazorApp.Services;

public class HttpUserService : IUserInterface
{
    private readonly HttpClient httpClient;

    public HttpUserService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<UserDto> AddUsernameAsync(CreateUserDto request)
    {
        HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("users", request); 
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        } 
        return JsonSerializer.Deserialize<UserDto>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto request)
    {
        HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("users", request); 
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        } 
        return JsonSerializer.Deserialize<UserDto>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public Task DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetUsersAsync()
    {
        throw new NotImplementedException();
    }
}