using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Repository;

namespace TempProject.Models
{
    public class Vehicle: ISoftDeleteRepository
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }

        public int PassengerNumber { get; set; }

		[Column(TypeName = "date")]
		public DateTime LicenceExpireData { get; set; }

		public string LicenceNumber { get; set; }
		[DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public virtual List<JMP> JMPs { get; set; }
    }
}
