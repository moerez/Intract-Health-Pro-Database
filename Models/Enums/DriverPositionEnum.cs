using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum DriverPositionEnum
    {
        [Display(Name = "Driver")]
        Driver,

        [Display(Name = "Passenger Front")]
        PassengerFront,

        [Display(Name = "Rear Passenger Right")]
        RearPassengerRight,

        [Display(Name = "Rear Passenger Left")]
        RearPassengerLeft,

        [Display(Name = "Rear Passenger Middle")]
        RearPassengerMiddle,

        [Display(Name = "Other")]
        Other,

        [Display(Name = "None")]
        None
    }
}