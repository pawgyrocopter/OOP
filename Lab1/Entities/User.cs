using System.ComponentModel.DataAnnotations;
using Lab1.Models;

namespace Lab1.Entities;

public class User
{
    [Key] public int Id { get; set; }
    public string? FirstName { get; set; }

    public string? SecondName { get; set; }
    public string? LastName { get; set; }
    public string? SeriesAndPassportNumber { get; set; }
    public string? IdentificationNumber { get; set; }
    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }

    public int? RoleId { get; set; }
    public Role Role { get; set; }
}