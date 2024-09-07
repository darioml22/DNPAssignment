using Entities;

namespace RepositoryContracts;

public interface IPostRepository
{
    Task AddPost(Post post);
    Task UpdatePost(Post post);
    Task DeletePost(Post post);
    Task<Post> GetPost(int id);
    IQueryable<Post> GetPosts();
}