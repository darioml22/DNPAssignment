using Entities;

namespace RepositoryContracts;

public interface IPostRepository
{
    Task<Post> AddPost(Post post);
    Task UpdatePost(Post post);
    Task DeletePost(int id);
    Task<Post> GetPost(int id);
    IQueryable<Post> GetPosts();
    List<Post> GetAll();
}