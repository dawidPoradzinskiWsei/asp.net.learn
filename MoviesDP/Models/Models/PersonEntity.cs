using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MoviesDP.Models.Movies;

public class PersonEntity
{
    [HiddenInput]
    [Key]
    public int PersonId { get; set; }
    [HiddenInput]
    public int MovieId { get; set; }
    [Display(Name = "Character name")]
    [Required(ErrorMessage = "Character name is required")]
    public string? CharacterName { get; set; }
    [Display(Name = "Person name")]
    [Required(ErrorMessage = "Person name is required")]
    public string? PersonName { get; set; }
    [Display(Name = "Gender")]
    public GenderEntity Gender{ get;set; }
    [Display(Name = "Cast order")]
    [Range(0, int.MaxValue, ErrorMessage = "Cast order must be not lower than 0")]
    public int? CastOrder { get; set; }
}