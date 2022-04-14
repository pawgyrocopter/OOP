namespace Lab1.Models;

public class CreditDisplayModel
{
    public int Id { get; set; }
    public int Procent { get; set; }
    public double Money { get; set; }
    public int BillId { get; set; }
    public string BankName { get; set; }
    public string EndTime { get; set; }
    public string StartTime { get; set; }
}