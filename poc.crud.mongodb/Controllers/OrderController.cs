using Microsoft.AspNetCore.Mvc;
using poc.crud.mongodb.Entities;
using poc.crud.mongodb.Services;

namespace poc.crud.mongodb.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class OrderController : ControllerBase
{
    private readonly OrderServices _orderServices;

    public OrderController(OrderServices orderServices) =>
        _orderServices = orderServices;

    [HttpGet]
    public async Task<IEnumerable<Order>> GetAsync(CancellationToken ct) =>
        await _orderServices.GetAsync(ct);

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> GetByIdAsync(string id, CancellationToken ct)
    {
        var order = await _orderServices.GetByIdAsync(id, ct);

        return order is not null ? Ok(order) : NotFound();
    }

    [HttpPost]
    public async Task<Order> CreateAsync(Order order, CancellationToken ct)
    {
        await _orderServices.CreateAsync(order, ct);
        return order;
    }
}