using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers
{
  public class ProductController : Controller
  {

    private readonly IProductService _iProductService;
    public ProductController(IProductService iProductService)
    {
      _iProductService = iProductService;
    }
    public IActionResult Index()
    {
      return View(_iProductService.getProducts());
    }

    public IActionResult Create()
    {
      var categories = _iProductService.GetCategories();
      return View(categories);
    }

    public IActionResult Save(Product product)
    {
      Console.Write(product.Id);
      if (product.Id == 0)
      {
        _iProductService.CreateProduct(product);
      }
      else
      {
        _iProductService.EditProduct(product);
      }
      return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
      var categories = _iProductService.GetCategories();
      var product = _iProductService.GetProductById(id);
      if (product == null) return RedirectToAction("Create");
      ViewBag.Product = product;
      return View(categories);
    }

    public IActionResult Delete(int id)
    {
      _iProductService.DeleteProduct(id);
      return RedirectToAction("Index");
    }
  }
}