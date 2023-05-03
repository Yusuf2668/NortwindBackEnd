

using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete;

public class Customer : IEntity
{
     [Key] public string CostumerID { get; set; }
    public string ContactName { get; set; }
    public string CompanyName { get; set; }
    public string City { get; set; }
}