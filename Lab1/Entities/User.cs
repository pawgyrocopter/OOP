using System.ComponentModel.DataAnnotations;

namespace Lab1.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
}