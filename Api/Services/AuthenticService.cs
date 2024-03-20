using System.Linq;
using Api.Data;
using Api.Domain;
using Api.Helpers;
using Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

public interface IAuthentic : ICrudService<Authentic>
{
    Authentic GetByUsername(string username);
    Authentic GetByEmail(string email);

    bool Authorize(string user, string pass);
}

public class AuthenticService : IAuthentic
{

    private readonly SoftLineDbContext _db;

    public AuthenticService(SoftLineDbContext db)
    {
        _db = db;
    }

    public void Add(Authentic entity)
    {
        entity.Password = PasswordHelper.Encrypt(entity.Password);

        _db.Authentic.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var data = _db.Authentic.FirstOrDefault(a => a.Id == id);
        if(data != null)
            _db.Authentic.Remove(data);
        
        _db.SaveChanges();
    }

    public Authentic GetByEmail(string email)
    {
        return _db.Authentic.SingleOrDefault(a => a.Email == email);
    }

    public Authentic GetById(int id)
    {
        return _db.Authentic.SingleOrDefault(a => a.Id == id);
    }

    public Authentic GetByUsername(string username)
    {
        return _db.Authentic.SingleOrDefault(a => a.Username == username);
    }

    public IEnumerable<Authentic> ListAll()
    {
        return _db.Authentic.ToList();
    }

    public void Update(Authentic entity)
    {
        _db.Authentic.Update(entity);
        _db.SaveChanges();
    }

    public bool Authorize(string user, string pass)
    {
        var result = false;
        var authentic = _db.Authentic.FirstOrDefault(a => a.Username == user);

        var passCrypt = PasswordHelper.Encrypt(pass);

        if (authentic == null)
            return result;

        result = passCrypt == authentic.Password;

        return result;
    }
}