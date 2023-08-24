using System.ComponentModel.DataAnnotations;
using InteractHealthProDatabase.Models.Enums;
using InteractHealthProDatabase.MyTools;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    [Index(nameof(License))]
    public class AccidentVehicle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Accident Details")]
        public AccidentDetail AccidentDetail { get; set; } = null!;

        [Display(Name = "Transport Type")]
        public TransportTypeEnum? TransportType { get; set; }

        [Display(Name = "Driver Position")]
        public DriverPositionEnum? DriverPosition { get; set; }

        [Display(Name = "Make")]
        public string? Make { get; set; }

        [Display(Name = "Model")]
        public string? Model { get; set; }

        [Display(Name = "Year")]
        public int? Year { get; set; }

        [Display(Name = "License Plate")]
        public string? License { get; set; }

        [Display(Name = "Vehicle Owner")]
        public string? VehiclePersName { get; set; }

        [Display(Name = "Number of People in Vehicle")]
        public int? VehicleNoPeople { get; set; }

        [Display(Name = "Other Liable Parties")]
        public string? OtherLiableParties { get; set; }

        [Display(Name = "Drove from scene")]
        public bool DroveFrmScene { get; set; } = false; // Checkbox

        [Display(Name = "Were you wearing a seatbelt?")]
        public bool Seatbelt { get; set; } = false; // Checkbox

        [Display(Name = "Were the airbags deployed?")]
        public bool AirbagDeploy { get; set; } = false; // Checkbox

        [Display(Name = "Were you bracing for impact?")]
        public bool Bracing { get; set; } = false; // Checkbox

        [Display(Name = "Did you anticipate the accident?")]
        public bool Anticipated { get; set; } = false; // Checkbox
        [Display(Name = "MVA Co Name")]
        public string? MvaCoName { get; set; }

        [Display(Name = "MVA Policy Number")]
        public int? MvaPolicyNo { get; set; }

        [Display(Name = "MVA Claim Number")]
        public int? MvaClaimNo { get; set; }

        [Display(Name = "MVA Adjuster")]
        public string? MvaAdjuster { get; set; }

        private string? _mvaTel { get; set; }
        [Display(Name = "MVA Telephone")]
        public string? MvaTel
        {
            get
            {
                return MyFormatter.FormatPhoneNumber(_mvaTel);
            }
            set
            {
                _mvaTel = MyFormatter.Strip(value);
            }
        }

        private string? _mvaFax { get; set; }
        [Display(Name = "MVA Fax")]
        public string? MvaFax
        {
            get
            {
                return MyFormatter.FormatPhoneNumber(_mvaFax);
            }
            set
            {
                _mvaFax = MyFormatter.Strip(value);
            }
        }

        [Display(Name = "MVA Email Address")]
        public string? MvaEmail { get; set; }

        [Display(Name = "MVA Address")]
        public string? MvaAddress { get; set; }

        [Display(Name = "MVA City")]
        public string? MvaCity { get; set; }

        [Display(Name = "MVA Province")]
        public string? MvaProv { get; set; }

        private string? _mvaPC { get; set; }
        [Display(Name = "MVA Postal Code")]
        public string? MvaPC
        {
            get
            {
                return MyFormatter.FormatPostalCode(_mvaPC);
            }
            set
            {
                _mvaPC = MyFormatter.Strip(value);
            }
        }

        [Display(Name = "Insurance Link")]
        public string? InsuranceUrl { get; set; }
    }
}