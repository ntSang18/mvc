using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Services
{
  public class ProductService : IProductService
  {
    private readonly DataContext _context;
    public ProductService(DataContext context)
    {
      _context = context;
    }

    public List<Product> getProducts()
    {
      return _context.Products
      .Include(p => p.Category)
      .ToList();
    }

    public List<Category> GetCategories()
    {
      return _context.Categories.ToList();
    }

    public Product? GetProductById(int id)
    {
      return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void CreateProduct(Product product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
      var existedProduct = GetProductById(id);
      if (existedProduct == null)
      {
        return;
      }
      _context.Products.Remove(existedProduct);
      _context.SaveChanges();
    }

    public void EditProduct(Product product)
    {
      var existedProduct = GetProductById(product.Id);
      if (existedProduct == null) return;
      existedProduct.Name = product.Name;
      existedProduct.Slug = product.Slug;
      existedProduct.Price = product.Price;
      existedProduct.Quantity = product.Quantity;
      existedProduct.CategoryId = product.CategoryId;
      _context.Products.Update(existedProduct);
      _context.SaveChanges();
    }
  }
}