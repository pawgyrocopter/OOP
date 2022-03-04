using Lab1.Entities;

namespace Lab1.Models;

public class RoleModel
{
    public List<Role> Roles { get; set; }
    public int? SelectedRoleId { get; set; }
}