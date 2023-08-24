using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace InteractHealthProDatabase.Models
{
    public class BodyPart
    {
        public int Id { get; set; }

        
        public Client Client { get; set; } = null!;

        [Display(Name = "Concussion")]
        public bool Concussion { get; set; }

        [Display(Name = "Fracture")]
        public bool Fracture { get; set; }

        [Display(Name = "Disc Herniation")]
        public bool DiscHerniation { get; set; }

        [Display(Name = "Notes")]
        public string? GeneralNotes { get; set; }

        [Display(Name = "Head Right")]
        public bool HeadR { get; set; }

        [Display(Name = "Head Left")]
        public bool HeadL { get; set; }

        [Display(Name = "Head Front")]
        public bool HeadF { get; set; }

        [Display(Name = "Head Back")]
        public bool HeadB { get; set; }

        [Display(Name = "Face Right")]
        public bool FaceR { get; set; }

        [Display(Name = "Face Left")]
        public bool FaceL { get; set; }

        [Display(Name = "Jaw")]
        public bool Jaw { get; set; }

        [Display(Name = "Teeth")]
        public bool Teeth { get; set; }

        [Display(Name = "Notes")]
        public string? HeadNotes { get; set; }

        [Display(Name = "Neck")]
        public bool Neck { get; set; }

        [Display(Name = "Upper Back")]
        public bool UpBack { get; set; }

        [Display(Name = "Upper Back Right")]
        public bool UpBackR { get; set; }
        [Display(Name = "Upper Back Left")]
        public bool UpBackL { get; set; }

        [Display(Name = "Mid Back")]
        public bool MidBack { get; set; }

        [Display(Name = "Mid Back Right")]
        public bool MidBackR { get; set; }

        [Display(Name = "Mid Back Left")]
        public bool MidBackL { get; set; }

        [Display(Name = "Lower Back")]
        public bool LowBack { get; set; }

        [Display(Name = "Lower Back Right")]
        public bool LowBackR { get; set; }

        [Display(Name = "Lower Back Left")]
        public bool LowBackL { get; set; }

        [Display(Name = "Shoulder Right")]
        public bool ShoulderR { get; set; }

        [Display(Name = "Shoulder Left")]
        public bool ShoulderL { get; set; }

        [Display(Name = "Notes")]
        public string? NeckAndBackNotes { get; set; }

        [Display(Name = "Upper Arm Right")]
        public bool UpArmR { get; set; }

        [Display(Name = "Upper Arm Left")]
        public bool UpArmL { get; set; }

        [Display(Name = "Elbow Right")]
        public bool ElbowR { get; set; }

        [Display(Name = "Elbow Left")]
        public bool ElbowL { get; set; }

        [Display(Name = "Forearm Right")]
        public bool ForearmR { get; set; }

        [Display(Name = "Forearm Left")]
        public bool ForearmL { get; set; }

        [Display(Name = "Wrist Right")]
        public bool WristR { get; set; }

        [Display(Name = "Wrist Left")]
        public bool WristL { get; set; }

        [Display(Name = "Hand Right")]
        public bool HandR { get; set; }

        [Display(Name = "Hand Left")]
        public bool HandL { get; set; }

        [Display(Name = "Fingers Right")]
        public bool FingersR { get; set; }

        [Display(Name = "Fingers Left")]
        public bool FingersL { get; set; }

        [Display(Name = "Notes")]
        public string? ArmNotes { get; set; }

        [Display(Name = "Chest Right")]
        public bool ChestR { get; set; }

        [Display(Name = "Chest Left")]
        public bool ChestL { get; set; }

        [Display(Name = "Ribs Right")]
        public bool RibsR { get; set; }

        [Display(Name = "Ribs Left")]
        public bool RibsL { get; set; }

        [Display(Name = "Buttocks Right")]
        public bool ButtocksR { get; set; }

        [Display(Name = "Buttocks Left")]
        public bool ButtocksL { get; set; }

        [Display(Name = "Notes")]
        public string? TorsoNotes { get; set; }

        [Display(Name = "Hip Right")]
        public bool HipR { get; set; }

        [Display(Name = "Hip Left")]
        public bool HipL { get; set; }

        [Display(Name = "Thigh Right")]
        public bool ThighR { get; set; }

        [Display(Name = "Thigh Left")]
        public bool ThighL { get; set; }

        [Display(Name = "Upper Leg Right")]
        public bool UpLegR { get; set; }

        [Display(Name = "Upper Leg Left")]
        public bool UpLegL { get; set; }

        [Display(Name = "Lower Leg Right")]
        public bool LowLegRt { get; set; }

        [Display(Name = "Lower Leg Left")]
        public bool LowLegR { get; set; }

        [Display(Name = "Knee Right")]
        public bool KneeR { get; set; }

        [Display(Name = "Knee Left")]
        public bool KneeL { get; set; }

        [Display(Name = "Ankle Right")]
        public bool AnkleR { get; set; }

        [Display(Name = "Ankle Left")]
        public bool AnkleL { get; set; }

        [Display(Name = "Foot Right")]
        public bool FootR { get; set; }

        [Display(Name = "Foot Left")]
        public bool FootL { get; set; }

        [Display(Name = "Toes Right")]
        public bool ToesR { get; set; }

        [Display(Name = "Toes Left")]
        public bool ToesL { get; set; }

        [Display(Name = "Notes")]
        public string? LegNotes { get; set; }

        [Display(Name = "Tingling in Right Arm/Hand/Fingers")]
        public bool TingRArm { get; set; }

        [Display(Name = "Tingling in Left Arm/Hand/Fingers")]
        public bool TingLArm { get; set; }

        [Display(Name = "Numbness Right Hand/Fingers")]
        public bool NumbRHand { get; set; }

        [Display(Name = "Numbness Left Hand/Fingers")]
        public bool NumbLHand { get; set; }

        [Display(Name = "Radiating Pain in Right Arm/Hand/Fingers")]
        public bool PainRArm { get; set; }

        [Display(Name = "Radiating Pain in Left Arm/Hand/Fingers")]
        public bool PainLArm { get; set; }

        [Display(Name = "Tingling in Right Leg/Foot")]
        public bool TingRLeg { get; set; }

        [Display(Name = "Tingling in Left Leg/Foot")]
        public bool TingLLeg { get; set; }

        [Display(Name = "Numbness in Right Leg/Foot")]
        public bool NumbRLeg { get; set; }

        [Display(Name = "Numbness in Right Leg/Foot")]
        public bool NumbLLeg { get; set; }

        [Display(Name = "Radiating Pain in Right Leg/Foot")]
        public bool PainRLeg { get; set; }

        [Display(Name = "Radiating Pain in Left Leg/Foot")]
        public bool PainLLeg { get; set; }

        [Display(Name = "Notes")]
        public string? OtherNotes { get; set; }
    }
}
