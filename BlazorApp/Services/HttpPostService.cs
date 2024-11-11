using System.Text.Json;
using ApiContracts;

namespace BlazorApp.Services;

public class HttpPostService : IPostInterface
{
    private readonly HttpClient httpClient;

    public HttpPostService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<PostDto> AddPostAsync(CreatePostDto request)
    {
        HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("posts", request); 
        string response = await httpResponse.Content.ReadAsStringAsync();
        if (!httpResponse.IsSuccessStatusCode)
        {
            throw new Exception(response);
        } 
        return JsonSerializer.Deserialize<PostDto>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
    }

    public Task UpdatePostAsync(int id, UpdatePostDto request)
    {
        throw new NotImplementedException();
    }

    public Task DeletePostAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task GetPostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetPostsAsync()
    {
        throw new NotImplementedException();
    }
}