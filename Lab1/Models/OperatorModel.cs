using Lab1.Entities;
using Lab1.Entities.Other;

namespace Lab1.Models;

public class OperatorModel
{
    public List<TransferModel> TransferModels { get; set; }
    
    public List<RequestMoneyModel> RequestMoniesModels { get; set; }
}