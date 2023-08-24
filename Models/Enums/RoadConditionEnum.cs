using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum RoadConditionEnum
    {
        [Display(Name = "Paved")]
        Paved,

        [Display(Name = "Unpaved")]
        Unpaved,

        [Display(Name = "Dry")]
        Dry,

        [Display(Name = "Clear")]
        Clear,

        [Display(Name = "Icy")]
        Icy,

        [Display(Name = "Slippery")]
        Slippery,

        [Display(Name = "Wet")]
        Wet,

        [Display(Name = "Snowy")]
        Snowy,

        [Display(Name = "Slushy")]
        Slushy,

        [Display(Name = "Flooded")]
        Flooded,

        [Display(Name = "Obstructed with debris/object")]
        Obstructed,

        [Display(Name = "Under Construction")]
        UnderConstruction
    }
}