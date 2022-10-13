using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
  public class Product
  {
    public int Id { get; set; }

    public String Name { get; set; }

    public String? Slug { get; set; }

    public int Price { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
  }
}