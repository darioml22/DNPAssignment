using Entities;
using RepositoryContracts;

namespace InMemoryRepositories;

public class PostInMemoryRepository : IPostRepository
{
    private List<Post> posts;

    public Task AddPost(Post post)
    {
        post.Id = posts.Any()
            ? posts.Max(p => p.Id) + 1
            : 1;
        posts.Add(post);
        return Task.FromResult(post);
    }

    public Task UpdatePost(Post post)
    {
        Post? existingPost = posts.SingleOrDefault(p => p.Id == post.Id);
        if (existingPost == null)
        {
            throw new InvalidOperationException($"Post with id {post.Id} does not exist");
        }
        posts.Remove(existingPost);
        posts.Add(post);
        return Task.CompletedTask;
    }

    public Task DeletePost(Post post)
    {
        Post? postToDelete = posts.SingleOrDefault(p => p.Id == post.Id);
        if (postToDelete == null)
        {
            throw new InvalidOperationException($"Post with id {post.Id} does not exist");
        }
        posts.Remove(postToDelete);
        return Task.CompletedTask;
    }

    public Task<Post> GetPost(int postId)
    {
        Post? post = posts.SingleOrDefault(p => p.Id == postId);
        if (post == null)
        {
            throw new InvalidOperationException($"Post with id {postId} does not exist");
        }
        
        return Task.FromResult(post);
    }

    public IQueryable<Post> GetPosts()
    {
        return posts.AsQueryable();
    }
}