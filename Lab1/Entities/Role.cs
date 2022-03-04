using System.ComponentModel.DataAnnotations;
using Lab1.Entities;

namespace Lab1.Entities;

public class Role
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; set; }
    public Role()
    {
        Users = new List<User>();
    }
}