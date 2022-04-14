namespace Lab1.Entities.UserCategories;

public class Client : User
{
    public List<Bill>Bills { get; set; }
    public List<Deposit>Deposits { get; set; }
    public List<Credit> Credits { get; set; }
    public List<Plan> Plans { get; set; }
    public int BankId { get; set; }
    public int FactoryId { get; set; }
    
    public bool IsAproved { get; set; }
}