using Api.Domain;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProduct _product;
    public ProductController(IProduct product)
    {
        _product = product;
    }

    [HttpGet("Get")]
    public ProductModel Get(int id)
    {
        var result  = _product.GetById(id);
        
        var resultModel = new ProductModel
        {
            Id = result.Id,
            Description = result.Description,
            Code = result.Code,
            Price = result.Price,
            GrossWeight = result.GrossWeight,
            NetWeight = result.NetWeight
        };

        return resultModel;
    }

    [HttpGet("List")]
    public IEnumerable<ProductModel> ListAll()
    {
        var result = _product.ListAll().ToList();

        var resultModel = result.Select(p => new ProductModel
        {
            Id = p.Id,
            Description = p.Description,
            Code = p.Code,
            Price = p.Price,
            GrossWeight = p.GrossWeight,
            NetWeight = p.NetWeight
        });

        return resultModel.ToList();

    }

    [HttpPost("NewProduct")]
    public ActionResult Post(ProductModel model) 
    {
        try
        {
            var entity = new Product
            {
                Description = model.Description,
                Code = model.Code,
                Price = model.Price,
                GrossWeight = model.GrossWeight,
                NetWeight = model.NetWeight
            };

            _product.Add(entity);
            return new JsonResult(HttpStatusCode.OK);
        }
        catch (System.Exception)
        {
            return new JsonResult(HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("Update")]
    public ActionResult Put(ProductModel model)
    {
        try
        {
            var entity = new Product
            {
                Id = model.Id,
                Description = model.Description,
                Code = model.Code,
                Price = model.Price,
                GrossWeight = model.GrossWeight,
                NetWeight = model.NetWeight
            };

            _product.Update(entity);
            return new JsonResult(HttpStatusCode.OK);
        }
        catch (Exception)
        {
            return new JsonResult(HttpStatusCode.InternalServerError);
        }

    }

    [HttpDelete("Delete")]
    public ActionResult Delete(int id)
    {
        try
        {
            _product.Delete(id);
            return new JsonResult(HttpStatusCode.OK);
        }
        catch (Exception)
        {
            return new JsonResult(HttpStatusCode.InternalServerError);
        }
    }

}