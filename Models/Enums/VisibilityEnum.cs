using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum VisibilityEnum
    {
        [Display(Name = "Blinding")]
        Blinding,

        [Display(Name = "Foggy")]
        Foggy,

        [Display(Name = "Bright")]
        Bright,

        [Display(Name = "Dark")]
        DarkOut,

        [Display(Name = "Sundown")]
        Sundown,

        [Display(Name = "Sunrise")]
        Sunrise,

        [Display(Name = "Sunset")]
        Sunset
    }
}