using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public bool IsManager { get; set; }
    public bool IsEngineer { get; set; }
    public bool IsOperator { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
