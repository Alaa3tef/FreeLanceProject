using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO.ResponseDTO
{
    public class AccidentExcelDTO
	{
        public int id { get; set; }
        public int Rig { get; set; }
        public TimeSpan TimeOfEvent { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfEvent { get; set; }
        public string TypeOfInjury { get; set; }
        public string ViolationCategory { get; set; }
        public string AccidentCauses { get; set; }
        public string PreventionCategory { get; set; }
        public string ClassificationOfAccident { get; set; }
        public string AccidentLocation { get; set; }
		public string QHSEName { get; set; }
		public string ToolPusherName { get; set; }
		public int QHSECode { get; set; }
		public int ToolPusherCode { get; set; }
		public string DrillerName { get; set; }
        public string DescriptionOfTheEvent { get; set; }
        public string ToolPusherPosition { get; set; }
        public string QHSEPosition { get; set; }
        public string ImmediateActionType { get; set; }
        public string DirectCauses { get; set; }
        public string RootCauses { get; set; }
        public string Recommendations { get; set; }
        public string userName { get; set; }
        public string Pictures { get; set; }

    }
}
