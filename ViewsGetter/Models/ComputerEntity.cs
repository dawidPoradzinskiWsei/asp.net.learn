using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("computers")]
public class ComputerEntity
{
 
    public int Id {get;set;}
    
    [Required]
    [MinLength(2)]
    public string Name {get;set;}

    [Required]
    public string Processor {get;set;}

    [Required]
    public int RamGB {get;set;}
    [Required]
    public string Gpu {get;set;}
    [Required]
    public string Producer {get;set;}

    public DateTime YearOfProduction {get;set;}

    public Category Category {get;set;}

    public DateTime Created {get;set;}

    public int OrganzationId {get;set;}
    public OrganzationEntity? Organzation {get;set;}
}