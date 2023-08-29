using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
	public class ToolPusherPositionName: ISoftDeleteRepository
    {
		public int Id { get; set; }
		public string Name { get; set; }

		public int EmpCode { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("ToolPusherPosition")]
		public int PositionId { get; set; }
		public virtual ToolPusherPosition ToolPusherPosition { get; set; }
		public virtual List<Accident> Accidents { get; set; }

	}
}
