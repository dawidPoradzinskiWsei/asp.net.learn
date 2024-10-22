using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class Computer {
    [HiddenInput]
    public int id {get;set;}
    public string name {get;set;}

    [RegularExpression("[i][3579]-[1][0-9]{4}")]
    [Required(ErrorMessage = "Please, tell me about your intel proccesor: i5-12400")]
    public string processor {get;set;}

    [Required(ErrorMessage = "Please, add some ram")]
    public int ramGB {get;set;}
    [Required(ErrorMessage = "Please, check gpu")]
    public string gpu {get;set;}
    [Required(ErrorMessage = "Please, check producer")]
    public string producer {get;set;}

    [DataType(DataType.Date)]
    public DateTime yearOfProduction {get;set;}
}