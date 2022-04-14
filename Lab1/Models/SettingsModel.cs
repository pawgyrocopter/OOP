using Lab1.Entities;

namespace Lab1.Models;

public class SettingsModel
{
    public List<Role>Roles { get; set; }
    public int? SelectedRoleId { get; set; }

    public List<Bank> Banks { get; set; }
    public int? SelectedBankId { get; set; }
    
    public List<Factory> Factories { get; set; }
    public int? SelectedFactoryId { get; set; }
    
}