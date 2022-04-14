namespace Lab1.Models;

public class TransferModel
{
    public int TransferId { get; set; }
    public string FromWho { get; set; }
    public int FromWhoId { get; set; }
    public int FromBillId { get; set; }
    public string ToWho { get; set; }
    public int ToWhoId { get; set; }
    public int ToBillId { get; set; }
}