using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class ReportedByName: ISoftDeleteRepository
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int EmpCode { get; set; }


		[DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public virtual List<StopCardRegister> StopCardRegisters { get; set; }
		[ForeignKey("ReportedByPosition")]
		public int PositionId { get; set; }
		public virtual ReportedByPosition ReportedByPosition { get; set; }



	}
}
