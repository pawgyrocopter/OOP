using System.ComponentModel.DataAnnotations;

namespace Lab1.Models;

public class UserModel
{
    public string? Name { get; set; }
    public int? RoleId { get; set; }
}