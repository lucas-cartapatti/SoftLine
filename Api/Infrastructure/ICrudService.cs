namespace Api.Infrastructure;

public interface ICrudService<T>
{
    public T GetById(int id);

    public IEnumerable<T> ListAll();

    public void Add(T entity);

    public void Update(T entity);

    public void Delete(int id);

}