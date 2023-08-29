using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class StopCardRegister: ISoftDeleteRepository
    {
		public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
		[ForeignKey("Classification")]
		public int ClassificationID { get; set; }
		public virtual Classification Classification { get; set; }
		public string Description { get; set; }
		public int EmpCode { get; set; }

		[ForeignKey("ReportedByPosition")]
		public int ReportedByPositionID { get; set; }
		public virtual ReportedByPosition ReportedByPosition { get; set; }
		[ForeignKey("ReportedByName")]
		public int ReportedByNameID { get; set; }
		public virtual ReportedByName ReportedByName { get; set; }
		public string ActionRequired { get; set; }
		[ForeignKey("TypeOfObservationCategory")]
		public int TypeOfObservationCategoryID { get; set; }
		public virtual TypeOfObservationCategory TypeOfObservationCategory { get; set; }
		public string Status { get; set; }
		public string StopWorkAuthorityApplied { get; set; }
		[ForeignKey("user")]
		public string userID { get; set; }
		public virtual IdentityUser user { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
