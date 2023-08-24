using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum GenderEnum
    {
        Male,
        Female,
        Other,
        [Display(Name = "Prefer Not To Say")]
        PreferNotToSay
    }
}