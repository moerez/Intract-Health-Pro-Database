using System.ComponentModel.DataAnnotations;

namespace InteractHealthProDatabase.Models.Enums
{
    public enum TransportTypeEnum
    {
        [Display(Name = "Pedestrian")]
        Pedestrian,

        [Display(Name = "Bicycle")]
        Bicycle,

        [Display(Name = "Car")]
        Car,

        [Display(Name = "SUV")]
        SUV,

        [Display(Name = "Van")]
        Van,

        [Display(Name = "Truck")]
        Truck,

        [Display(Name = "Transport Truck")]
        TransportTruck,

        [Display(Name = "Bus / Public Transportation")]
        PublicTransportation,

        [Display(Name = "Subway")]
        Subway,

        [Display(Name = "Train")]
        Train,

        [Display(Name = "Motorcycle")]
        Motorcycle,

        [Display(Name = "Motocross")]
        Motocross,

        [Display(Name = "4 Wheeler")]
        FourWheeler,

        [Display(Name = "Water Craft")]
        WaterCraft,

        [Display(Name = "Boat")]
        Boat,

        [Display(Name = "Airplane")]
        Airplane,

        [Display(Name = "Other Recreational Vehicle")]
        OtherRecreationalVehicle,

        [Display(Name = "Other Form of Transportation")]
        OtherFormofTransportation,
    }
}