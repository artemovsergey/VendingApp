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

var app = builder.Build();

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
    "/parsing",
    async () =>
    {
        List<UserParsing> users = new();
        for (int i = 1; i < 20; i++)
        {
            var data = await File.ReadAllTextAsync($"users/{i}.json");
            var user = JsonSerializer.Deserialize<UserParsing>(data, options);
            Console.WriteLine(user!.FullName);
            users.Add(user);
        }

        return users;
    }
);

app.MapControllers();

app.Run();
