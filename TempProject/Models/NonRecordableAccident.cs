using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
    public class NonRecordableAccident : ISoftDeleteRepository
    {
        public int Id { get; set; }

        public string AccidentType { get; set; }

		[DefaultValue(false)]
		public bool IsDeleted { get; set; }

	}
}
