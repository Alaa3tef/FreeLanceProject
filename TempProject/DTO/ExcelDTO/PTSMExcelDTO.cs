using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.Models
{
	public class PTSMExcelDTO
	{
		public int Id { get; set; }

		public int RigNumber { get; set; }

		public TimeSpan Time { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public string TrainerName { get; set; }

		public int NumsofTrainees { get; set; }

		public string SubjectTitle { get; set; }

		public string SubjectContent { get; set; }


		public string UserName { set; get; }

		public int No1 { get; set; }
		public string Position1 { get; set; }
		public string Name1 { get; set; }

		public int No2 { get; set; }
		public string Position2 { get; set; }
		public string Name2 { get; set; }

		public int No3 { get; set; }
		public string Position3 { get; set; }
		public string Name3 { get; set; }
		public int No4 { get; set; }
		public string Position4 { get; set; }
		public string Name4 { get; set; }

		public int No5 { get; set; }
		public string Position5 { get; set; }
		public string Name5 { get; set; }

	}
}
