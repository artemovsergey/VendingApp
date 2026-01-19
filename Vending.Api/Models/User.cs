using System;
using System.ComponentModel.DataAnnotations;

public class UserParsing
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsManager { get; set; }
    public bool IsEngineer { get; set; }
    public string Phone { get; set; } = string.Empty;
    public bool IsOperator { get; set; }
    public string Role { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class User
{
    public int Id { get; set; }
    public string FIO { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public Role Role { get; set; } = Role.None;
}

public enum Role
{
    None = 0,
    Administrator = 1,
    Operator = 2,
    TechSpecialist = 3,
    LogicSpecialist = 4,
    Analitic = 5,
}
