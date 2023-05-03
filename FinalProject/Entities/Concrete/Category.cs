

using System.ComponentModel.DataAnnotations;
using Core.Entities;

public class Category : IEntity
{
   [Key] public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}