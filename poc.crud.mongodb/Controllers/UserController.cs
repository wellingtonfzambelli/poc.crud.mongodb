using Microsoft.AspNetCore.Mvc;
using poc.crud.mongodb.Entities;
using poc.crud.mongodb.Services;

namespace poc.crud.mongodb.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class UserController : ControllerBase
{
    private readonly UserServices _userServices;

    public UserController(UserServices userServices) =>
        _userServices = userServices;

    [HttpGet]
    public async Task<IEnumerable<User>> GetAsync(CancellationToken ct) =>
        await _userServices.GetAsync(ct);

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> GetByIdAsync(string id, CancellationToken ct)
    {
        var user = await _userServices.GetByIdAsync(id, ct);

        return user is not null ? Ok(user) : NotFound();
    }

    [HttpPost]
    public async Task<User> CreateAsync(User user, CancellationToken ct)
    {
        await _userServices.CreateAsync(user, ct);
        return user;
    }
}