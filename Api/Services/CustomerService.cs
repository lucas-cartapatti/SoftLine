using Api.Data;
using Api.Domain;
using Api.Infrastructure;

namespace Api.Services;

public interface ICustomer : ICrudService<Customer>{}

public class CustomerService : ICustomer
{
    private readonly SoftLineDbContext _db;

    public CustomerService(SoftLineDbContext db)
    {
        _db = db;
    }

    public void Add(Customer entity)
    {
        _db.Customer.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var data = _db.Customer.SingleOrDefault(c => c.Id == id);
        
        if(data != null) _db.Customer.Remove(data);
        
        _db.SaveChanges();
    }

    public Customer GetById(int id)
    {
        return _db.Customer.SingleOrDefault(c => c.Id == id);
    }

    public IEnumerable<Customer> ListAll()
    {
        return _db.Customer.ToList();
    }

    public void Update(Customer entity)
    {
        _db.Customer.Update(entity);
        _db.SaveChanges();
    }
}