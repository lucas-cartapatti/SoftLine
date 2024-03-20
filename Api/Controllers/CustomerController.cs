using Api.Domain;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomer _customer;

    public CustomerController(ICustomer customer)
    {
        _customer = customer;
    }

    [HttpGet("Get")]
    public CustomerModel Get(int id)
    {
        var result = _customer.GetById(id);

        var resultModel = new CustomerModel
        {
            Id = result.Id,
            CompanyName = result.CompanyName,
            TradeName = result.TradeName,
            Location = result.Location,
            Document = result.Document,
            Active = result.Active
        };

        return resultModel;
    }

    [HttpGet("List")]
    public IEnumerable<CustomerModel> ListAll()
    {
        var result = _customer.ListAll().ToList();

        var resultModel = result.Select(c => new CustomerModel
        {
            Id = c.Id,
            CompanyName = c.CompanyName,
            TradeName = c.TradeName,
            Location = c.Location,
            Document = c.Document,
            Active = c.Active 
        });

        return resultModel;
    }

    [HttpPost("NewCustomer")]
    public ActionResult Post(CustomerModel model)
    {
        try
        {    
            var entity = new Customer
            {
                CompanyName = model.CompanyName,
                TradeName = model.TradeName,
                Document = model.Document,
                Location = model.Location,
                Active = model.Active
            };

            _customer.Add(entity);
            return new JsonResult(HttpStatusCode.OK);   
        }
        catch (System.Exception)
        {
            return new JsonResult(HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("Update")]
    public ActionResult Put(CustomerModel model)
    {

        try
        {
            var entity = new Customer{
                Id = model.Id,
                CompanyName = model.CompanyName,
                TradeName = model.TradeName,
                Location = model.Location,
                Document = model.Document,
                Active = model.Active
            };

            _customer.Update(entity);
            return new JsonResult(HttpStatusCode.OK);
        }
        catch (System.Exception)
        {
            return new JsonResult(HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("Delete")]
    public ActionResult Delete(int id){

        try
        {
            _customer.Delete(id);
            return new JsonResult(HttpStatusCode.OK);
        }
        catch (System.Exception)
        {
            return new JsonResult(HttpStatusCode.InternalServerError);
        }

    }
}