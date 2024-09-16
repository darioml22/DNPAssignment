using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class CommentInMemoryRepository : ICommentRepository
{
    private List<Comment> comments= new List<Comment>();

    public async Task<Comment> AddComment(Comment comment)
    {
        comment.Id = comments.Any()
            ? comments.Max(c => c.Id) + 1
            : 1;
        comments.Add(comment);
        return await Task.FromResult(comment);
    }

    public Task UpdateComment(Comment comment)
    {
        Comment? existingComment = comments.SingleOrDefault(c => c.Id == comment.Id);
        if (existingComment == null)
        {
            throw new InvalidOperationException($"Comment with id {comment.Id} does not exist");
        }
        comments.Remove(existingComment);
        comments.Add(comment);
        return Task.CompletedTask;
    }

    public Task DeleteComment(Comment comment)
    {
        Comment? commentToDelete = comments.SingleOrDefault(c => c.Id == comment.Id);
        if (commentToDelete == null)
        {
            throw new InvalidOperationException($"Comment with id {comment.Id} does not exist");
        }
        comments.Remove(commentToDelete);
        return Task.CompletedTask;
    }

    public async Task<Comment> GetComment(int commentId)
    {
        Comment? comment = comments.SingleOrDefault(c => c.Id == commentId);
        if (comment == null)
        {
            throw new InvalidOperationException($"Comment with id {commentId} does not exist");
        }
        
        return await Task.FromResult(comment);
    }

    public IQueryable<Comment> GetComments()
    {
        return comments.AsQueryable();
    }
}