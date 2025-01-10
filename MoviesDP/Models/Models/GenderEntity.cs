using System.ComponentModel.DataAnnotations;

public enum GenderEntity
{
    [Display(Name = "Unspecified")]
    Unspecified,
    [Display(Name = "Female"),]
    Female,
    [Display(Name = "male")]
    Male
}