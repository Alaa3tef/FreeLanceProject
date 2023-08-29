using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Models;

namespace TempProject.DTO
{
	public class JMPDTO
    {
		public int Id { get; set; }

		public int JournyNumber { get; set; }

		public string? NightDrivingReason { get; set; }

		public string? QHSEManagerMustApprove { get; set; }

		[Column(TypeName = "date")]
		public DateTime Date { get; set; }

		public string Destination { get; set; }

		public string Company { get; set; }

		public double SpeedLimit { get; set; }

		public double Distance { get; set; }
		public string PurposeOfJourny { get; set; }


        public string ManagerNumber { get; set; }


        public string ReachBeforeDark { get; set; }

		public int CommunicationID { get; set; }

		public string JournyManagerName { get; set; }

		public int DriverNameId { get; set; }

		public string InspectionVechile { get; set; }

		public string Status { get; set; }

		[Column(TypeName = "date")]
		public DateTime DepartureDate { get; set; }

		public double Time { get; set; }

		public int VehicleId { get; set; }


		[Column(TypeName = "date")]
		public DateTime EstimatedArriveDate { get; set; }

		public TimeSpan EstimatedArriveTime { get; set; }

		public string RestLocationNames { get; set; }


		public int RouteNameID { get; set; }

		public string? PassengerName1 { get; set; }
		public string? PassengerName2 { get; set; }
		public string? PassengerName3 { get; set; }
		public string? PassengerName4 { get; set; }
		public string? PassengerPhone1 { get; set; }
		public string? PassengerPhone2 { get; set; }
		public string? PassengerPhone3 { get; set; }
		public string? PassengerPhone4 { get; set; }


		public string userID { get; set; }

		public DateTime EnterTime { get; set; }

		public DateTime ArrivalTime { get; set; }
		//public string notifyStatus { get; set; }


		[DefaultValue(false)]
		public bool ArrivalStatus { get; set; }
	}
}
