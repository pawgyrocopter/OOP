namespace Lab1.Models;

public class CreditModel
{
    public int BillId { get; set; }
    public string BillName { get; set; }
    public string ClientEmail { get; set; }
    public string Duration { get; set; }
    public int Procent { get; set; }
    
   public double Money { get; set; }
    public List<string> Durations { get; set; }
    public List<int> Procents { get; set; }
    public int SelectedCreditInfo { get; set; }
    
    public bool Plan { get; set; }
}