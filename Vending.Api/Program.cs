using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Vending.Api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Public endpoint");
app.MapGet("/secured", () => "Secured endpoint").RequireAuthorization();

var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower, // или SnakeCaseUpper
    PropertyNameCaseInsensitive = true, // Опционально для дополнительной гибкости
};

app.MapGet(
    "/users",
    async (AppDbContext db) =>
    {
        List<User> users = new();
        for (int i = 1; i < 20; i++)
        {
            var data = await File.ReadAllTextAsync($"resources/users/{i}.json");
            var user = JsonSerializer.Deserialize<User>(data, options);
            Console.WriteLine(user!.FullName);
            users.Add(user);
        }

        try
        {
            await db.Users.AddRangeAsync(users);
            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Ошибка сохранения: {ex.InnerException!.Message}");
        }

        return users;
    }
);

app.MapGet(
    "/products",
    async (AppDbContext db) =>
    {
        var data = await File.ReadAllTextAsync("resources/products/products.json");
        var products = JsonSerializer.Deserialize<Product[]>(data, options);
        System.Console.WriteLine(products?.Count());

        try
        {
            await db.Products.AddRangeAsync(products!);
            await db.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Ошибка сохранения: {ex.InnerException!.Message}");
        }
    }
);

app.MapControllers();

app.Run();
