
using AspNetCoreGeneratedDocument;

//BEZ BAZY
class MemoryComputerService : IComputerService
{
    static Dictionary<int, Computer> _computers = new();
    public void Add(Computer model)
    {
        int id = _computers.Keys.Count != 0 ? _computers.Keys.Max() : 0;
        model.Id = id + 1;
        _computers.Add(model.Id, model);
    }

    public void Delete(int id)
    {
        _computers.Remove(id);
    }

    public List<Computer> GetAll()
    {
        return _computers.Values.ToList();
    }

    public Computer? GetById(int id)
    {
        return _computers[id];
    }

    public List<OrganzationEntity> GetOrganizations()
    {
        throw new NotImplementedException();
    }

    public void Update(Computer model)
    {
        if(_computers.ContainsKey(model.Id)) {
            _computers[model.Id] = model;
        }
    }
}