// z BAZA
public class EFComputerService : IComputerService
{
    private readonly AppDbContext _context;

    public EFComputerService(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Computer model)
    {
        _context.Computers.Add(ComputerMapper.ToEntity(model));
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        _context.Computers.Remove(new ComputerEntity(){Id = id});
        _context.SaveChanges();
    }

    public List<Computer> GetAll()
    {
        return _context.Computers.Select(e => ComputerMapper.FromEntity(e)).ToList();
    }

    public Computer? GetById(int id)
    {
        var entity = _context.Computers.Find(id);
        return entity == null ? null : ComputerMapper.FromEntity(entity);
    }

    public void Update(Computer model)
    {
        _context.Computers.Update(ComputerMapper.ToEntity(model));
    }
}