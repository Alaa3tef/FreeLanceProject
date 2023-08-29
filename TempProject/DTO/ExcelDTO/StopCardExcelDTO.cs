using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO.ResponseDTO
{
    public class StopCardExcelDTO
	{
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [ForeignKey("Classification")]
        public string Classification { get; set; }

        public string Description { get; set; }

        public string ReportedByPosition { get; set; }


		public string ReportedByName { get; set; }
		public int ReportedByCode { get; set; }

		public string ActionRequired { get; set; }

        [ForeignKey("TypeOfObservationCategory")]
        public string TypeOfObservationCategory { get; set; }

        public string Status { get; set; }
        public string StopWorkAuthorityApplied { get; set; }

        [ForeignKey("user")]
        public string userName { get; set; }
    }
}
