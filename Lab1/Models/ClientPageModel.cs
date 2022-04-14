using Lab1.Entities;

namespace Lab1.Models;

public class ClientPageModel
{
    public List<Bank> Banks { get; set; }
    public int? SelectedBankId { get; set; }
    public string BillName { get; set; }
    
    
    public List<Bill> Bills { get; set; }
    
    public List<CreditInfo> CreditInfos { get; set; }
    public int SelectedBillId { get; set; }
    public int TransferMoney { get; set; }
    public int TransferBillId { get; set; }
    
    public List<CreditDisplayModel> CreditDisplayModels { get; set; }
    public int WMoney { get; set; }
}