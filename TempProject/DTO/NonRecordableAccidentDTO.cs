using System.ComponentModel;

namespace TempProject.DTO
{
    public class NonRecordableAccidentDTO
    {
        public int id { get; set; }

        public string AccidentType { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
