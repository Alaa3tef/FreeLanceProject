using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class DriverExcelDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string PhoneNumber { get; set; }
		[Column(TypeName = "date")]
		public DateTime LicenceExpireData { get; set; }

		public string LicenceNumber { get; set; }
	}
}
