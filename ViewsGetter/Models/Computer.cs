using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class Computer {
    [HiddenInput]
    public int Id {get;set;}
    [Display(Name = "Nazwa")]
    public string Name {get;set;}

    [RegularExpression("[i][3579]-[1][0-9]{4}")]
    [Required(ErrorMessage = "Please, tell me about your intel proccesor: i5-12400")]
    [Display(Name = "Procesor")]
    public string Processor {get;set;}

    [Required(ErrorMessage = "Please, add some ram")]
    [Display(Name = "Pamięć RAM")]
    public int RamGB {get;set;}
    [Required(ErrorMessage = "Please, check gpu")]
    [Display(Name = "Karta Graficzna")]
    public string Gpu {get;set;}
    [Required(ErrorMessage = "Please, check producer")]
    [Display(Name = "Producent")]
    public string Producer {get;set;}

    [DataType(DataType.Date)]
    [Display(Name = "Rok produkcji")]
    public DateTime YearOfProduction {get;set;}

    [Display(Name = "Kategoria")]
    public Category Category {get;set;}
}