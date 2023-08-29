using System.ComponentModel;

namespace TempProject.DTO
{
    public class DrillDTO
    {
        public int id { get; set; }

        public string DrillType { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
