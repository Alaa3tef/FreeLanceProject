using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
    public class Accident : ISoftDeleteRepository
    {
        public int Id {  get; set; }
        
		[ForeignKey("Rig")]
        public int RigId { get; set; }
        
		public virtual Rig Rig { get; set; }
        
		public TimeSpan TimeOfEvent { get; set;}

        [Column(TypeName = "date")]
        public DateTime DateOfEvent { get; set;}
		
		[ForeignKey("TypeOfInjury")]
		public int TypeOfInjuryID { get; set; }
		
		public virtual TypeOfInjury TypeOfInjury { get; set; }
		[ForeignKey("ViolationCategory")]
		public int ViolationCategoryId { get; set; }
		
		public virtual ViolationCategory ViolationCategory  { get; set; }
		
		[ForeignKey("AccidentCauses")]
		public int AccidentCausesId { get; set; }
		
		public virtual AccidentCauses AccidentCauses { get; set; }
		
		[ForeignKey("PreventionCategory")]
		public int PreventionCategoryId { get; set; }
		
		public virtual PreventionCategory PreventionCategory { get; set; }
		
		[ForeignKey("ClassificationOfAccident")]
		public int ClassificationOfAccidentId { get; set; }
		
		public virtual ClassificationOfAccident ClassificationOfAccident { get; set; }
        
		public string AccidentLocation { get; set;}
		
		[ForeignKey("QHSEPositionName")]
		public int QHSEPositionNameId { get; set; }

		public int QHSEEmpCode { get; set; }

		public int PusherEmpCode { get; set; }

		public virtual QHSEPositionName QHSEPositionName  { get; set; }


		[ForeignKey("ToolPusherPositionName")]
		public int ToolPusherPositionNameId { get; set; }
		
		public virtual ToolPusherPositionName ToolPusherPositionName   { get; set; }
        
		public string DrillerName { get; set;}
        
		public string DescriptionOfTheEvent { get; set; }
		
		[ForeignKey("ToolPusherPosition")]
		public int ToolPusherPositionId { get; set; }
		
		public virtual ToolPusherPosition ToolPusherPosition { get; set; }
		 
		[ForeignKey("QHSEPosition")]
        public int QHSEPositionId { get; set; }
        
		public virtual QHSEPosition QHSEPosition { get; set; }
        
		public string ImmediateActionType { get; set;}
        
		public string DirectCauses { get; set; }
        
		public string RootCauses { get; set;}
        
		public string Recommendations { get; set; }
        
		public string Pictures { get; set;}
		
		[ForeignKey("user")]
		public string userID { get; set; }
		
		public virtual IdentityUser user { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
