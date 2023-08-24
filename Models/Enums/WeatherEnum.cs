using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum WeatherEnum
    {
        [Display(Name = "Sunny")]
        Sunny,

        [Display(Name = "Light Rain")]
        LightRain,

        [Display(Name = "Heavy Rain")]
        HeavyRain,

        [Display(Name = "Snowing")]
        Snowing,

        [Display(Name = "Clear")]
        Clear,

        [Display(Name = "Cloudy")]
        Cloudy,

        [Display(Name = "Foggy")]
        Foggy
    }
}