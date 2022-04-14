using Lab1.Entities.UserCategories;

namespace Lab1.Entities.Other;

public class RequestMoney
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    
    public Bill Bill { get; set; }
    public int BillId { get; set; }
    
    public bool IsAproved { get; set; }
    
}