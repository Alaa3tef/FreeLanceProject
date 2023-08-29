using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class QHSEPositionNameDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int EmpCode { get; set; }

		[ForeignKey("QHSEPosition")]
		public int PositionId { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
	}
}
