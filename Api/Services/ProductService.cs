using Api.Data;
using Api.Domain;
using Api.Infrastructure;

namespace Api.Services;

public interface IProduct : ICrudService<Product>{}

public class ProductService : IProduct{
    private readonly SoftLineDbContext _db;
    public ProductService(SoftLineDbContext db)
    {
        _db = db;
    }

    public void Add(Product entity)
    {
        _db.Product.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var data = _db.Product.SingleOrDefault(p => p.Id == id);

        if(data != null) _db.Product.Remove(data);

        _db.SaveChanges();
    }

    public Product GetById(int id)
    {
        return _db.Product.SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> ListAll()
    {
        return _db.Product.ToList();
    }

    public void Update(Product entity)
    {
        _db.Product.Update(entity);
        _db.SaveChanges();
    }
}