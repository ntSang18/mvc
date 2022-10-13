using MVC.Models;

namespace MVC.Services
{
  public interface IProductService
  {
    List<Product> getProducts();

    Product? GetProductById(int id);

    void CreateProduct(Product product);

    void EditProduct(Product product);

    void DeleteProduct(int id);

    List<Category> GetCategories();
  }
}