using Domain.Models;
using Infrastructore.Context;
using Infrastructore.Interfaces;
using Infrastructore.Responses;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service):ControllerBase
{
[HttpPost]
public async Task<Response<bool>> Add(Product product)
{
    var res=await service.AddProduct(product);
    return res;
}
[HttpPut]
public async Task<Response<bool>> Update(Product product)
{
    var res=await service.UpdateProduct(product);
    return res;
}
[HttpGet]
public async Task<Response<List<Product>>> GetAll()
{
    var res= await service.GetProducts();
    return res;
}
[HttpGet("get-by-id")]
public async Task<Response<Product>> ById(int id)
{
    var res=await service.GetProductById(id);
    return res;
}
[HttpDelete]
public async Task<Response<bool>> Delete(int id)
{
    var res=await service.DeleteProduct(id);
    return  res;
}
}