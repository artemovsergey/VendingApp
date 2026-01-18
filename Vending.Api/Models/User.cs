using System;
using System.ComponentModel.DataAnnotations;

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
