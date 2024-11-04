using System.ComponentModel.DataAnnotations;

public enum Category {
    [Display(Name = "Biurowe")]
    business,
    [Display(Name = "Do domu"),]
    home,
    [Display(Name = "Dla graczy")]
    games
}