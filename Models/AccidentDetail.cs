using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InteractHealthProDatabase.Models.Enums;

namespace InteractHealthProDatabase.Models
{
  public class AccidentDetail
  {

    public int Id { get; set; }

    public Client Client { get; set; } = null!;

    [NotMapped]
    [Display(Name = "Vehicle")]
    public AccidentVehicle? AccidentVehicle { get; set; }


    [NotMapped]
    [Display(Name = "Body Part")]
    public BodyPart? BodyPart { get; set; }

    [Display(Name = "Date & Time of Accident")]
    public DateTime? DateTimeAcc { get; set; }

    [Display(Name = "Medical History Link")]
    public string? MedicalHistoryUrl { get; set; }

    [Display(Name = "Visit Type")]
    public VisitTypeEnum? FMedVisit { get; set; }

    //Conditions during the accident

    [Display(Name = "Weather")]
    public WeatherEnum? Weather { get; set; }

    [Display(Name = "Visibility")]
    public VisibilityEnum? Visibility { get; set; }

    [Display(Name = "Road Condition")]
    public RoadConditionEnum? RoadCondition { get; set; }

    [Display(Name = "Location of Accident")]
    public string? AccidentLocation { get; set; }

    [Display(Name = "Description of Accident")]
    public string? AccidentDesc { get; set; }

    // Police

    [Display(Name = "Name of the Police Officer")]
    public string? PoliceName { get; set; }

    [Display(Name = "Badge Number")]
    public string? PoliceBadgeNo { get; set; }

    [Display(Name = "Department")]
    public string? PoliceDept { get; set; }

    [Display(Name = "Report Date")]
    public DateTime? PoliceReportAccDate { get; set; }

    [Display(Name = "Report Center")]
    public string? PoliceReportCenter { get; set; }

    [Display(Name = "Charge")]
    public bool? PoliceCharge { get; set; }

    // EME

    [Display(Name = "Was there a Police Officer at the scene?")]
    public bool EmeAtScenePolice { get; set; } = false; // Checkbox

    [Display(Name = "Was there an Ambulance at the scene?")]
    public bool EmeAtSceneAmbulance { get; set; } = false; // Checkbox


    [Display(Name = "Were there Fire Fighters at the scene?")]
    public bool EmeAtSceneFirefighters { get; set; } = false; // Checkbox

    [Display(Name = "Was there a Tow Truck at the scene?")]
    public bool EmeAtSceneTowing { get; set; } = false; // Checkbox

    [Display(Name = "No one came")]
    public bool EmeAtSceneNoOneCame { get; set; } = false; // Checkbox

    [Display(Name = "Were you taken by ambulance?")]
    public bool TakeByAmbulance { get; set; } = false; // Radio Yes/No

    public string? Note { get; set; }
  }
}