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
            Organzation = arg.Organization,
            OrganzationId = arg.OrganizationId
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
            Organization = arg.Organzation,
            OrganizationId = arg.OrganzationId
        };
    }
}