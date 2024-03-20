using System;
using System.Net;
using System.Text;
using Api.Domain;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticController : ControllerBase
{
    private readonly IAuthentic _authentic;

    public AuthenticController(IAuthentic authentic)
    {
        _authentic = authentic;
    }

    [HttpGet("Get")]
    public AuthenticModel Get(int id)
    {
        var result = _authentic.GetById(id);

        var resultModel = new AuthenticModel{
            Id = result.Id,
            Username = result.Username,
            Password = result.Password,
            Email = result.Email,
            Active = result.Active,
            DateCreation = result.DateCreation
        };

        return resultModel;
    }

    [HttpGet("ListAll")]
    public IEnumerable<AuthenticModel> ListAll()
    {
        var result = _authentic.ListAll().ToList();

        var resultModel = result.Select(a => new AuthenticModel
        {
            Id = a.Id,
            Username = a.Username,
            Password = a.Password,
            Email = a.Email,
            Active = a.Active,
            DateCreation = a.DateCreation
        });

        return resultModel;
    }

    [HttpPost("NewUser")]
    public ActionResult Add(AuthenticModel model)
    {
        try
        {
            var entity = new Authentic{
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Active = model.Active,
                DateCreation = DateTime.Now
            };

            _authentic.Add(entity);
            return new JsonResult(HttpStatusCode.OK);
        }
        catch (System.Exception)
        {
            return new  JsonResult(HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("Update")]
    public ActionResult Update(AuthenticModel model)
    {
        try
        {
            var entity = new Authentic{
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Active = model.Active,
                DateCreation = (DateTime)model.DateCreation
            };

            _authentic.Update(entity);
            return new JsonResult(HttpStatusCode.OK);
        }
        catch (System.Exception)
        {
            return new JsonResult(HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("Delete")]
    public ActionResult Delete(int id)
    {
        try
        {
            _authentic.Delete(id);

            return new JsonResult(HttpStatusCode.OK);
        }
        catch (System.Exception)
        {
            return new JsonResult(HttpStatusCode.InternalServerError);
        }
    }

    [HttpPost("Login")]
    public ActionResult Authorize(string user,string pass){
        
        var status = HttpStatusCode.NotFound;
        
        try
        {
            var result = _authentic.Authorize(user,pass);

            if(result)
                status = HttpStatusCode.OK;

            return new JsonResult(status);
        }
        catch (System.Exception)
        {
            status = HttpStatusCode.Unauthorized;
            return new JsonResult(status);
        }
    }
}