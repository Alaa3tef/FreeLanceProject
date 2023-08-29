using System.ComponentModel;

namespace TempProject.DTO
{
	public class RigDTO
    {
		public int Id { get; set; }
		public int Number { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
	}
}
