using Lab1.Entities.Undo;

namespace Lab1.Models;

public class AdminPageModel
{
    public ManagerModel ManagerModel { get; set; }
    
    public List<BillCreation> BillCreations { get; set; }
    
    public string LogInfo { get; set; }
}