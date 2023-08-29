using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TempProject.Enum;
using TempProject.Models;

namespace TempProject.DTO.ResponseDTO
{
    public class JMPResponseDTO
    {
        public int Id { get; set; }

        public int JournyNumber { get; set; }

        public string? NightDrivingReason { get; set; }

        public string? QHSEManagerMustApprove { get; set; }

        public DateTime Date { get; set; }

        public string Destination { get; set; }

        public string Company { get; set; }

        public double SpeedLimit { get; set; }

        public double Distance { get; set; }
        public string PurposeOfJourny { get; set; }




        public string ReachBeforeDark { get; set; }

        public string CommunicationMethod { get; set; }

        public string JournyManagerName { get; set; }

        public string ManagerNumber { get; set; }

        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public DateTime DriverLicenceExpireDate { get; set; }
        public string DriverLicenceNumber { get; set; }

        public string InspectionVechile { get; set; }

        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; }

        public double Time { get; set; }

        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string VehicleColor { get; set; }
        public int VehiclePassengerNumber { get; set; }

        public DateTime VehicleLicenceExpireData { get; set; }

        public string VehicleLicenceNumber { get; set; }


        [Column(TypeName = "date")]
        public DateTime EstimatedArriveDate { get; set; }

        public TimeSpan EstimatedArriveTime { get; set; }

        public string RestLocationNames { get; set; }


        public string RouteName { get; set; }
        //public List<string>? passengerNames { get; set; }
        //public List<string>? passengerTelephones { get; set; }

        public List<Passenger>? Passengers { get; set; }

		public string notifyStatus { get; set; }

		public DateTime EnterTime { get; set; }

		public DateTime ArrivalTime { get; set; }

		[DefaultValue(false)]
		public bool ArrivalStatus { get; set; }

		public string userName { get; set; }
    }
}
