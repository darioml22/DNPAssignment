using ApiContracts;

namespace BlazorApp.Services;

public interface ICommentsInterface
{
    public Task<string> AddCommentAsync(CreateCommentDto request);
    public Task UpdateCommentAsync(int id, UpdateCommentDto request);
    public Task DeleteCommentAsync(int id);
    public Task GetCommentByIdAsync(int id);
    public Task GetCommentsAsync();
}