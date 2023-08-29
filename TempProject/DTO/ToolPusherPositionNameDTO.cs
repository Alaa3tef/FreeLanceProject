using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class ToolPusherPositionNameDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int EmpCode { get; set; }

		[DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("ToolPusherPosition")]
		public int PositionId { get; set; }

	}
}
