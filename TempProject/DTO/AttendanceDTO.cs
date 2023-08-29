using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.Models
{
	public class AttendanceDTO
	{
		public int Id { get; set; }

		public int? No { get; set; }

		public string? Position { get; set; }

		public string? Name { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

		public int PTSMId { get; set; }

	}
}
