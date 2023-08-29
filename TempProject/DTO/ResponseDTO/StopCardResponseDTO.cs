using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempProject.DTO.ResponseDTO
{
    public class StopCardResponseDTO
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [ForeignKey("Classification")]
        public string Classification { get; set; }

        public string Description { get; set; }
        [ForeignKey("ReportedByPosition")]
        public string ReportedByPosition { get; set; }

        [ForeignKey("ReportedByName")]
        public string ReportedByName { get; set; }

        public string ActionRequired { get; set; }

        [ForeignKey("TypeOfObservationCategory")]
        public string TypeOfObservationCategory { get; set; }

        public string Status { get; set; }
        public string StopWorkAuthorityApplied { get; set; }

        [ForeignKey("user")]
        public string userName { get; set; }
    }
}
