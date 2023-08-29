using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class Attendance : ISoftDeleteRepository
	{
		public int Id { get; set; }

		public int? No { get; set; }

		public string? Position { get; set; }

		public string? Name { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

		[ForeignKey("PTSM")]
		public int PTSMId { get; set; }

		public virtual PTSM PTSM { get; set; }
	}
}
