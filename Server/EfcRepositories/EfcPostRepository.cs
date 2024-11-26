﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RepositoryContracts;

namespace EfcRepositories;

public class EfcPostRepository : IPostRepository
{
    private readonly AppContext ctx;

    public EfcPostRepository(AppContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<Post> AddPost(Post post)
    {
        EntityEntry<Post> entityEntry = await ctx.Posts.AddAsync(post);
        await ctx.SaveChangesAsync(); 
        return entityEntry.Entity;
    }

    public async Task UpdatePost(Post post)
    {
        if (!(await ctx.Posts.AnyAsync(p => p.Id == post.Id)))
        {
            throw new NotFoundException("Post with id {post.Id} not found");
        } 
        ctx.Posts.Update(post); await ctx.SaveChangesAsync();
    }

    public async Task DeletePost(int id)
    {
        Post? existing = await ctx.Posts.SingleOrDefaultAsync(p => p.Id == id);
        if (existing == null)
        {
            throw new NotFoundException($"Post with id {id} not found");
        } 
        ctx.Posts.Remove(existing);
        await ctx.SaveChangesAsync();
    }

    public async Task<Post> GetPost(int id)
    {
        Post? existing = await ctx.Posts.SingleOrDefaultAsync(p => p.Id == id);
        if (existing == null)
        {
            throw new NotFoundException($"Post with id {id} not found");
        } 
        return existing; 
    }

    public IQueryable<Entities.Post> GetPosts()
    {
        throw new NotImplementedException();
    }

    public List<Entities.Post> GetAll()
    {
        public IQueryable<Post> GetMany()
        {
            return ctx.Posts.AsQueryable();
        }
    }
}