using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class StopCardRegisterDTO
    {
		public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

		[ForeignKey("Classification")]
		public int ClassificationID { get; set; }

		public string Description { get; set; }
		public int EmpCode { get; set; }

		[ForeignKey("ReportedByPosition")]
		public int ReportedByPositionID { get; set; }

		[ForeignKey("ReportedByName")]
		public int ReportedByNameID { get; set; }

		public string ActionRequired { get; set; }

		[ForeignKey("TypeOfObservationCategory")]
		public int TypeOfObservationCategoryID { get; set; }

		public string Status { get; set; }
		public string StopWorkAuthorityApplied { get; set; }

		[ForeignKey("user")]
		public string userID { get; set; }
	}
}
