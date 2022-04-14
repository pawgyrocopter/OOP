namespace Lab1.Entities;

public class Plan
{
    public int Id { get; set; }
    public double Money { get; set; }
    public int BankId { get; set; }
    public int ClientId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}