public interface IComputerService {
    void Add(Computer model);
    void Update(Computer model);

    void Delete(int id);
    List<Computer> GetAll();

    Computer? GetById(int id);
}