using Npgsql;
using Dapper;
using Domain.Models;
using System.Net;
using Infrastructore.Context;
using Infrastructore.Responses;
using Infrastructore.Interfaces;

namespace Infrastructore.Services;

public class ProductService(DapperContext _context) : IProductService
{
    public async Task<Response<bool>> AddProduct(Product product)
    {
      using var context=_context.Connection();
      string cmd="insert into products(name,description,price,stockquantity,categoryname,createddate)values(@Name,@Description,@Price,@StockQuantity,@CategoryName,@CreatedDate)";
      var res=await context.ExecuteAsync(cmd,product);
      if(res==0)return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
      return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> DeleteProduct(int id)
    {
      using var context=_context.Connection();
      string cmd="delete from products where id=@ProductId";
      var res=await context.ExecuteAsync(cmd,new {id=id});
      if(res==0)return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
      return new Response<bool>(res>0);
    }

    public async Task<Response<Product>> GetProductById(int id)
    {
      using var context=_context.Connection();
      string cmd="select * from products where id=@ProductId";
      var res=await context.QueryFirstOrDefaultAsync(cmd,new {id=id});
      if(res==null)return new Response<Product>(HttpStatusCode.NotFound,"Client Eror!");
      return new Response<Product>(res);
    }

    public async Task<Response<List<Product>>> GetProducts()
    {
      using var context=_context.Connection();
      string cmd="select * from products";
      var res=(await context.QueryAsync<Product>(cmd)).ToList();
      if(res==null)return new Response<List<Product>>(HttpStatusCode.NotFound,"Client Eror!");
      return new Response<List<Product>>(res);
    }

    public async Task<Response<bool>> UpdateProduct(Product product)
    {
      using var context=_context.Connection();
      string cmd="update  products set id=@ProductId,name=@Name,description=@Description,price=@Price,stockquantity=@StockQuantity,categoryname=@CategoryName,createddate=@CreatedDate";
      var res=await context.ExecuteAsync(cmd,product);
      if(res==0)return new Response<bool>(HttpStatusCode.NotFound,"Client Eror!");
      return new Response<bool>(res>0);
    }

    public async Task<Response<bool>> Export()
    {
     using var context=_context.Connection();
     string path="C:\\Intel\\products.txt"
    }
}
