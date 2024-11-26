using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcRepositories;

public class EfcCommentRepository
{
    private readonly AppContext ctx;

    public EfcCommentRepository(AppContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<Comment> AddComment(Comment comment)
    {
        EntityEntry<Comment> entityEntry = await ctx.Comments.AddAsync(comment);
        await ctx.SaveChangesAsync(); 
        return entityEntry.Entity;
    }

    public async Task UpdateComment(Comment comment)
    {
        if (!(await ctx.Comments.AnyAsync(c => c.Id == comment.Id)))
        {
            throw new NotFoundException("Comment with id {comment.Id} not found");
        } 
        ctx.Comments.Update(comment); await ctx.SaveChangesAsync();
    }

    public async Task DeleteComment(int id)
    {
        Comment? existing = await ctx.Comments.SingleOrDefaultAsync(c => c.Id == id);
        if (existing == null)
        {
            throw new NotFoundException($"Comment with id {id} not found");
        } 
        ctx.Comments.Remove(existing);
        await ctx.SaveChangesAsync();
    }

    public async Task<Comment> GetComment(int id)
    {
        Comment? existing = await ctx.Comments.SingleOrDefaultAsync(c => c.Id == id);
        if (existing == null)
        {
            throw new NotFoundException($"Comment with id {id} not found");
        } 
        return existing; 
    }

    public IQueryable<Entities.Comment> GetComments()
    {
        throw new NotImplementedException();
    }

    public List<Entities.Comment> GetAll()
    {
        public IQueryable<Comment> GetMany()
        {
            return ctx.Comments.AsQueryable();
        }
    }
}