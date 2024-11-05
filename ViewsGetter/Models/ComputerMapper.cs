public class ComputerMapper
{
    public static ComputerEntity ToEntity(Computer arg)
    {
        return new ComputerEntity()
        {
            Id = arg.Id,
            Category = arg.Category,
            Gpu = arg.Gpu,
            Name = arg.Name,
            Processor = arg.Processor,
            Producer = arg.Producer,
            RamGB = arg.RamGB,
            YearOfProduction = arg.YearOfProduction,
        };
    }

    public static Computer FromEntity(ComputerEntity arg)
    {
        return new Computer()
        {
            Id = arg.Id,
            Category = arg.Category,
            Gpu = arg.Gpu,
            Name = arg.Name,
            Processor = arg.Processor,
            Producer = arg.Producer,
            RamGB = arg.RamGB,
            YearOfProduction = arg.YearOfProduction,
        };
    }
}