using ApiContracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class CommentsController : ControllerBase
{
    private readonly ICommentRepository commentRepo;

    public CommentsController(ICommentRepository commentRepo)
    {
        this.commentRepo = commentRepo;
    }

    [HttpPost]
    public async Task<ActionResult<CreateCommentDto>> AddComment(
        [FromBody] CreateCommentDto request,
        [FromServices] IUserRepository userRepo)
    {
        Comment comment = new(request.Content, request.PostId, request.UserId);
        Comment created = await commentRepo.AddComment(comment);
        return Created($"/Comments/{created.Id}", created);
    }

    [HttpDelete]
    public async Task<IResult> DeleteComment(
        [FromRoute] int id)
    {
        await commentRepo.DeleteComment(id);
        return Results.NoContent();
    }

    [HttpGet]
    public async Task<IResult> GetComment(
        [FromRoute] int id)
    {
        Comment result = await commentRepo.GetComment(id);
        return Results.Ok(result);
    }

    [HttpGet]
    public async Task<IResult> GetComments(
        [FromQuery] string? title)
    {
        List<Comment> comments = commentRepo.GetAll();
        if (!string.IsNullOrWhiteSpace(title))
        {
            comments = comments.Where(p => p.Content.Equals(title)).ToList();
        }
        return Results.Ok(comments);
    }
}

