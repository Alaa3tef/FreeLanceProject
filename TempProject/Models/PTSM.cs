using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class PTSM : ISoftDeleteRepository
	{
		public int Id { get; set; }

		[ForeignKey("Rig")]
		public int RigId { get; set; }

		public virtual Rig Rig { get; set; }

		public TimeSpan Time { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public string TrainerName { get; set; }

		public int NumsofTrainees { get; set; }

		public string SubjectTitle { get; set; }

		public string SubjectContent { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

		[ForeignKey("user")]
		public string UserId { set; get; }

		public virtual IdentityUser user { get; set; }

		public virtual List<Attendance>? Attendances { get; set; }
	}
}
