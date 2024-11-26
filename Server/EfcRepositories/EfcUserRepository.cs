using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcRepositories;

public class EfcUserRepository
{
    private readonly AppContext ctx;

    public EfcUserRepository(AppContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<User> AddUser(User user)
    {
        EntityEntry<User> entityEntry = await ctx.Users.AddAsync(user);
        await ctx.SaveChangesAsync(); 
        return entityEntry.Entity;
    }

    public async Task UpdateUser(User user)
    {
        if (!(await ctx.Users.AnyAsync(u => u.Id == user.Id)))
        {
            throw new NotFoundException("User with id {user.Id} not found");
        } 
        ctx.Users.Update(user); await ctx.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        User? existing = await ctx.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (existing == null)
        {
            throw new NotFoundException($"User with id {id} not found");
        } 
        ctx.Users.Remove(existing);
        await ctx.SaveChangesAsync();
    }

    public async Task<User> GetUser(int id)
    {
        User? existing = await ctx.Users.SingleOrDefaultAsync(u => u.Id == id);
        if (existing == null)
        {
            throw new NotFoundException($"User with id {id} not found");
        } 
        return existing; 
    }

    public IQueryable<Entities.User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public List<Entities.User> GetAll()
    {
        public IQueryable<User> GetMany()
        {
            return ctx.Users.AsQueryable();
        }
    }
}