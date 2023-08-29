using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO
{
	public class ToolPusherPositionNameExcelDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int EmpCode { get; set; }
		public string Position { get; set; }

	}
}
