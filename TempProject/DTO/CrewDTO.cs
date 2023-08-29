using System.ComponentModel;

namespace TempProject.DTO
{
    public class CrewDTO
    {
        public int id { get; set; }

        public string CrewName { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
