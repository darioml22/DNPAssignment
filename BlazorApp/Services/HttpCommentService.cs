using ApiContracts;

namespace BlazorApp.Services;

public class HttpCommentService : ICommentsInterface
{
    public Task<string> AddCommentAsync(CreateCommentDto request)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCommentAsync(int id, UpdateCommentDto request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCommentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetCommentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task GetCommentsAsync()
    {
        throw new NotImplementedException();
    }
}