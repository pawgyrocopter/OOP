using Lab1.Entities;
using Lab1.Entities.Other;
using Lab1.Entities.UserCategories;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Models;

public class RequestMoneyModel
{
    public RequestMoney RequestMoney { get; set; }
    
    public Factory Factory { get; set; }
    
}