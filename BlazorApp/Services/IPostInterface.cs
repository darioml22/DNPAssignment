using ApiContracts;

namespace BlazorApp.Services;

public interface IPostInterface
{
    public Task<PostDto> AddPostAsync(CreatePostDto request);
    public Task UpdatePostAsync(int id, UpdatePostDto request);
    public Task DeletePostAsync(int id);
    public Task GetPostByIdAsync(int id);
    public Task GetPostsAsync();
}