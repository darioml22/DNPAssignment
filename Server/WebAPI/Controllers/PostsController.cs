using ApiContracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class PostsController : ControllerBase
{
    private readonly IPostRepository postRepo;

    public PostsController(IPostRepository postRepo)
    {
        this.postRepo = postRepo;
    }

    [HttpPost]
    public async Task<ActionResult<CreatePostDto>> AddPost(
        [FromBody] CreatePostDto request,
        [FromServices] IUserRepository userRepo)
    {
        Post post = new(request.Title, request.Content, request.UserId);
        Post created = await postRepo.AddPost(post);
        return Created($"/Posts/{created.Id}", created);
    }

    [HttpDelete]
    public async Task<IResult> DeletePost(
        [FromRoute] int id)
    {
        await postRepo.DeletePost(id);
        return Results.NoContent();
    }

    [HttpGet]
    public async Task<IResult> GetPost(
        [FromRoute] int id)
    {
        Post result = await postRepo.GetPost(id);
        return Results.Ok(result);
    }

    [HttpGet]
    public async Task<IResult> GetPosts(
        [FromQuery] string? title)
    {
        List<Post> posts = postRepo.GetAll();
        if (!string.IsNullOrWhiteSpace(title))
        {
            posts = posts.Where(p => p.Title == title).ToList();
        }
        return Results.Ok(posts);
    }
}