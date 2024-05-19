using DevicesMonitoring.Entities;
using DevicesMonitoring.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevicesMonitoring.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CreateUser : ControllerBase
{
    private readonly MyDbContext _context;
    public CreateUser(MyDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Create()
    {

        var user = new UserModel();
        try
        {
        _context.users.Add(user);
            _context.SaveChanges();
        return Ok("teste");

        }catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }
}
