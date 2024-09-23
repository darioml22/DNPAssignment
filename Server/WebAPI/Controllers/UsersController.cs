using ApiContracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]

public class UsersController : ControllerBase
{
    private readonly IUserRepository userRepo;

    public UsersController(IUserRepository userRepo)
    {
        this.userRepo = userRepo;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserDto>> AddUser(
        [FromBody] CreateUserDto request,
        [FromServices] IUserRepository userRepo)
    {
        User user = new(request.Id, request.Username, request.Password);
        User created = await userRepo.AddUser(user);
        return Created($"/Users/{created.Id}", created);
    }

    [HttpDelete]
    public async Task<IResult> DeleteUser(
        [FromRoute] int id)
    {
        await userRepo.RemoveUser(id);
        return Results.NoContent();
    }

    [HttpGet]
    public async Task<IResult> GetUser(
        [FromRoute] int id)
    {
        User result = await userRepo.GetUser(id);
        return Results.Ok(result);
    }

    [HttpGet]
    public async Task<IResult> GetUsers(
        [FromQuery] string? title)
    {
        List<User> users = userRepo.GetAll();
        if (!string.IsNullOrWhiteSpace(title))
        {
            users = users.Where(p => p.Username == title).ToList();
        }
        return Results.Ok(users);
    }
}