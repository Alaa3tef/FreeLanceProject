using System.ComponentModel;
using TempProject.Repository;

namespace TempProject.Models
{
	public class Classification : ISoftDeleteRepository
    {
		public int Id { get; set; }
		public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public virtual List<StopCardRegister> StopCardRegisters { get; set; }

	}
}
