using Microsoft.AspNetCore.Mvc;
using Vending.Api.Data;
using Vending.Api.Dto;

namespace Vending.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AppDbContext db) : ControllerBase
{
    [HttpPost]
    public IActionResult Auth(LoginRequest request)
    {
        var user = db
            .UsersParsing.Where(u => u.Login == request.Login && u.Password == u.Password)
            .FirstOrDefault();

        return user != null ? Ok(user) : NotFound("Неправильный логин или пароль");
    }
}
