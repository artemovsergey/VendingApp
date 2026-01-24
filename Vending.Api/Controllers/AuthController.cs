using Microsoft.AspNetCore.Http.HttpResults;
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
            .Users.Where(u => u.Login == request.Login && u.Password == u.Password)
            .FirstOrDefault();

        if (user == null)
            return NotFound("Нет такого пользователя");

        bool valid = BCrypt.Net.BCrypt.Verify(request.Password, user!.Password);

        return valid ? Ok(user) : NotFound("Неправильный логин или пароль");
    }
}
