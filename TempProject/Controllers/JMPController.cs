using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics.Metrics;
using System.Globalization;
using TempProject.DTO;
using TempProject.DTO.ExcelDTO;
using TempProject.DTO.Notification;
using TempProject.DTO.ResponseDTO;
using TempProject.Enum;
using TempProject.Hubs;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	//[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class JMPController : ControllerBase
    {
		public IRepository<JMP> JMPRepo { get; set; }
		public IRepository<Passenger> PassengerRepo { get; set; }
		public IRepository<JMP_Passenger> JMP_PassengerRepo { get; set; }

		IHubContext<NotificationHub, INotificationHub> NotificationHub;
		IHubContext<ArrivalNotificationHub, IArrivalNotificationHub> ArrivalNotificationHub;

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

		public IJMPRepository jMPRepository { get; set; }

		public JMPController(IRepository<Passenger> _PassengerRepo,Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,IHubContext<NotificationHub, INotificationHub> _NotificationHub, IHubContext<ArrivalNotificationHub, IArrivalNotificationHub> _ArrivalNotificationHub, IJMPRepository _jMPRepository, IRepository<JMP> _JMPRepo, IRepository<JMP_Passenger> _JMP_PassengerRepo)
		{
			this.JMPRepo = _JMPRepo;
			this.PassengerRepo = _PassengerRepo;
			JMP_PassengerRepo = _JMP_PassengerRepo;
            jMPRepository = _jMPRepository;
			NotificationHub = _NotificationHub;
            ArrivalNotificationHub = _ArrivalNotificationHub;
			userManager = _userManager;
		}

        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<JMP> temp = jMPRepository.getall();
            List<JMPResponseDTO> newTemp = new List<JMPResponseDTO>();
            foreach (JMP JMP in temp)
            {
                JMPResponseDTO JMPDTO = new JMPResponseDTO();
                JMPDTO.Id = JMP.Id;
                JMPDTO.JournyNumber = JMP.JournyNumber;
                JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
                JMPDTO.JournyManagerName = JMP.JournyManagerName;
                JMPDTO.Date = JMP.Date;
                JMPDTO.Time = JMP.Time;
                JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
                JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
                JMPDTO.Destination = JMP.Destination;
                JMPDTO.DepartureDate = JMP.DepartureDate;
                JMPDTO.DriverName = JMP.DriverName.Name;
                JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
                JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
                JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
                JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
                JMPDTO.Company = JMP.Company;
                JMPDTO.SpeedLimit = JMP.SpeedLimit;
                JMPDTO.Distance = JMP.Distance;
                JMPDTO.VehicleNumber = JMP.Vehicle.Number;
                JMPDTO.VehicleColor = JMP.Vehicle.Color;
                JMPDTO.VehicleType = JMP.Vehicle.Type;
                JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
                JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
                JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
                JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
                JMPDTO.RouteName = JMP.RouteName.Name;
                JMPDTO.RestLocationNames = JMP.RestLocationNames;
                JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
                JMPDTO.ManagerNumber = JMP.ManagerNumber;
                JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
				JMPDTO.InspectionVechile = JMP.InspectionVechile;
				JMPDTO.EnterTime = JMP.EnterTime;
				JMPDTO.notifyStatus = JMP.notifyStatus.ToString();
				JMPDTO.Status = JMP.Status;
				JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
				JMPDTO.ArrivalTime = JMP.ArrivalTime; 
                JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
                JMPDTO.userName = JMP.user.UserName;

                newTemp.Add(JMPDTO);
            }
            if (newTemp != null)
            {

                result.Statescode = 200;
                result.Data = newTemp;
                result.Message = "Success";

                return result;
            }

            result.Statescode = 404;
            result.Message = "data not found";
            return result;

        }

		[HttpGet("GetAllForExcel")]
		public ActionResult<ResultDTO> GetAllForExcel()
		{

			ResultDTO result = new ResultDTO();

			List<JMP> temp = jMPRepository.getall();
			List<JMPExcelDTO> newTemp = new List<JMPExcelDTO>();
			foreach (JMP JMP in temp)
			{
				JMPExcelDTO JMPDTO = new JMPExcelDTO();
				JMPDTO.Id = JMP.Id;
				JMPDTO.JournyNumber = JMP.JournyNumber;
				JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
				JMPDTO.JournyManagerName = JMP.JournyManagerName;
				JMPDTO.Date = JMP.Date;
				JMPDTO.Time = JMP.Time;
				JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
				JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
				JMPDTO.Destination = JMP.Destination;
				JMPDTO.DepartureDate = JMP.DepartureDate;
				JMPDTO.DriverName = JMP.DriverName.Name;
				JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
				JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
				JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
				JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
				JMPDTO.Company = JMP.Company;
				JMPDTO.SpeedLimit = JMP.SpeedLimit;
				JMPDTO.Distance = JMP.Distance;
				JMPDTO.VehicleNumber = JMP.Vehicle.Number;
				JMPDTO.VehicleColor = JMP.Vehicle.Color;
				JMPDTO.VehicleType = JMP.Vehicle.Type;
				JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
				JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
				JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
				JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
				JMPDTO.RouteName = JMP.RouteName.Name;
				JMPDTO.RestLocationNames = JMP.RestLocationNames;
				JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
				JMPDTO.ManagerNumber = JMP.ManagerNumber;
				JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
				JMPDTO.InspectionVechile = JMP.InspectionVechile;
				JMPDTO.EnterTime = JMP.EnterTime;
				JMPDTO.notifyStatus = JMP.notifyStatus.ToString();
				JMPDTO.Status = JMP.Status;
				JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
				JMPDTO.ArrivalTime = JMP.ArrivalTime;
				JMPDTO.userName = JMP.user.UserName;
				JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => new PassengerExcelDTO { PassengerName = jp.Passenger.Name, PassengerTelephone = jp.Passenger.Telephone }).ToList();

				newTemp.Add(JMPDTO);
			}
			if (newTemp != null)
			{

				result.Statescode = 200;
				result.Data = newTemp;
				result.Message = "Success";

				return result;
			}

			result.Statescode = 404;
			result.Message = "data not found";
			return result;

		}

		[HttpGet("ByPage/{page:int}")]
		public PageResult<JMPResponseDTO> GettAllStoCardsByPage(int? page, int pagesize = 10)
		{
			List<JMP> temp = jMPRepository.getall();
			List<JMPResponseDTO> newTemp = new List<JMPResponseDTO>();
			foreach (JMP JMP in temp)
			{
				JMPResponseDTO JMPDTO = new JMPResponseDTO();
				JMPDTO.Id = JMP.Id;
				JMPDTO.JournyNumber = JMP.JournyNumber;
				JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
				JMPDTO.JournyManagerName = JMP.JournyManagerName;
				JMPDTO.Date = JMP.Date;
				JMPDTO.Time = JMP.Time;
				JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
				JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
				JMPDTO.Destination = JMP.Destination;
				JMPDTO.DepartureDate = JMP.DepartureDate;
				JMPDTO.DriverName = JMP.DriverName.Name;
				JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
				JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
				JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
				JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
				JMPDTO.Company = JMP.Company;
				JMPDTO.SpeedLimit = JMP.SpeedLimit;
				JMPDTO.Distance = JMP.Distance;
				JMPDTO.VehicleNumber = JMP.Vehicle.Number;
				JMPDTO.VehicleColor = JMP.Vehicle.Color;
				JMPDTO.VehicleType = JMP.Vehicle.Type;
				JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
				JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
				JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
				JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
				JMPDTO.RouteName = JMP.RouteName.Name;
				JMPDTO.RestLocationNames = JMP.RestLocationNames;
				JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
				JMPDTO.ManagerNumber = JMP.ManagerNumber;
				JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
				JMPDTO.InspectionVechile = JMP.InspectionVechile;
				JMPDTO.EnterTime = JMP.EnterTime;
				JMPDTO.notifyStatus = JMP.notifyStatus.ToString();
				JMPDTO.Status = JMP.Status;
				JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
				JMPDTO.ArrivalTime = JMP.ArrivalTime; JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
				JMPDTO.userName = JMP.user.UserName;

				newTemp.Add(JMPDTO);
			}

			float countDetails = jMPRepository.getall().Count();
			var result = new PageResult<JMPResponseDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}

		//[HttpGet("notifyStatus")]
		//public ActionResult<ResultDTO> GetnotifyStatus()
		//{

		//	ResultDTO result = new ResultDTO();

		//	List<JMP> temp = jMPRepository.getall().Where(jm=>jm.notifyStatus==0).ToList();
		//	List<JMPResponseDTO> newTemp = new List<JMPResponseDTO>();
		//	foreach (JMP JMP in temp)
		//	{
		//		JMPResponseDTO JMPDTO = new JMPResponseDTO();
		//		JMPDTO.Id = JMP.Id;
		//		JMPDTO.JournyNumber = JMP.JournyNumber;
		//		JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
		//		JMPDTO.JournyManagerName = JMP.JournyManagerName;
		//		JMPDTO.Date = JMP.Date;
		//		JMPDTO.Time = JMP.Time;
		//		JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
		//		JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
		//		JMPDTO.Destination = JMP.Destination;
		//		JMPDTO.DepartureDate = JMP.DepartureDate;
		//		JMPDTO.DriverName = JMP.DriverName.Name;
		//		JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
		//		JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
		//		JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
		//		JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
		//		JMPDTO.Company = JMP.Company;
		//		JMPDTO.SpeedLimit = JMP.SpeedLimit;
		//		JMPDTO.Distance = JMP.Distance;
		//		JMPDTO.VehicleNumber = JMP.Vehicle.Number;
		//		JMPDTO.VehicleColor = JMP.Vehicle.Color;
		//		JMPDTO.VehicleType = JMP.Vehicle.Type;
		//		JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
		//		JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
		//		JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
		//		JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
		//		JMPDTO.RouteName = JMP.RouteName.Name;
		//		JMPDTO.RestLocationNames = JMP.RestLocationNames;
		//		JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
		//		JMPDTO.ManagerNumber = JMP.ManagerNumber;
		//		JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
		//		JMPDTO.InspectionVechile = JMP.InspectionVechile;
		//		JMPDTO.EnterTime = JMP.EnterTime;
		//		JMPDTO.notifyStatus = JMP.notifyStatus.ToString();
		//		JMPDTO.Status = JMP.Status;
		//		//JMPDTO.passengerNames = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger.Name).ToList();
		//		//JMPDTO.passengerTelephones = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger.Telephone).ToList();
		//		JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
		//		JMPDTO.userName = JMP.user.UserName;

		//		newTemp.Add(JMPDTO);
		//	}
		//	if (newTemp != null)
		//	{

		//		result.Statescode = 200;
		//		result.Data = newTemp;
		//		result.Message = "Success";

		//		return result;
		//	}

		//	result.Statescode = 404;
		//	result.Message = "data not found";
		//	return result;

		//}

		[HttpGet("notifyStatus/{page:int}")]
		public PageResult<JMPResponseDTO> GetnotifyStatus(int? page, int pagesize = 10)
		{
			List<JMP> temp = jMPRepository.getall().Where(jm => jm.notifyStatus == 0).OrderByDescending(jm => jm.Id).ToList();
			List<JMPResponseDTO> newTemp = new List<JMPResponseDTO>();
			foreach (JMP JMP in temp)
			{
				JMPResponseDTO JMPDTO = new JMPResponseDTO();
				JMPDTO.Id = JMP.Id;
				JMPDTO.JournyNumber = JMP.JournyNumber;
				JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
				JMPDTO.JournyManagerName = JMP.JournyManagerName;
				JMPDTO.Date = JMP.Date;
				JMPDTO.Time = JMP.Time;
				JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
				JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
				JMPDTO.Destination = JMP.Destination;
				JMPDTO.DepartureDate = JMP.DepartureDate;
				JMPDTO.DriverName = JMP.DriverName.Name;
				JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
				JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
				JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
				JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
				JMPDTO.Company = JMP.Company;
				JMPDTO.SpeedLimit = JMP.SpeedLimit;
				JMPDTO.Distance = JMP.Distance;
				JMPDTO.VehicleNumber = JMP.Vehicle.Number;
				JMPDTO.VehicleColor = JMP.Vehicle.Color;
				JMPDTO.VehicleType = JMP.Vehicle.Type;
				JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
				JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
				JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
				JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
				JMPDTO.RouteName = JMP.RouteName.Name;
				JMPDTO.RestLocationNames = JMP.RestLocationNames;
				JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
				JMPDTO.ManagerNumber = JMP.ManagerNumber;
				JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
				JMPDTO.InspectionVechile = JMP.InspectionVechile;
				JMPDTO.EnterTime = JMP.EnterTime;
				JMPDTO.notifyStatus = JMP.notifyStatus.ToString();
				JMPDTO.Status = JMP.Status;
				JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
				JMPDTO.ArrivalTime = JMP.ArrivalTime;
				JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
				JMPDTO.userName = JMP.user.UserName;

				newTemp.Add(JMPDTO);
			}

			float countDetails = jMPRepository.getall().Where(jm => jm.notifyStatus == 0).OrderByDescending(jm => jm.Id).Count();
			var result = new PageResult<JMPResponseDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;

		}

		[HttpGet("ID/{ID:int}")]
		public ActionResult<ResultDTO> GetByIDWithoutData(int ID)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				JMP JMP = JMPRepo.getall().FirstOrDefault(a => a.Id == ID);
				JMPDTO JMPDTO = new JMPDTO();
				JMPDTO.Id = JMP.Id;
                JMPDTO.JournyNumber = JMP.JournyNumber;
				JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
				JMPDTO.JournyManagerName = JMP.JournyManagerName;
				JMPDTO.Date = JMP.Date;
				JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
				JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
				JMPDTO.Destination = JMP.Destination;
				JMPDTO.DepartureDate = JMP.DepartureDate;
				JMPDTO.DriverNameId = JMP.DriverNameId;
				JMPDTO.CommunicationID = JMP.CommunicationID;
				JMPDTO.Company = JMP.Company;
				JMPDTO.SpeedLimit = JMP.SpeedLimit;
				JMPDTO.Distance = JMP.Distance;
				JMPDTO.VehicleId = JMP.VehicleId;
				JMPDTO.InspectionVechile = JMP.InspectionVechile;
				JMPDTO.Status = JMP.Status;
				JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
				JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
				JMPDTO.ManagerNumber = JMP.ManagerNumber;
				JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
				JMPDTO.RouteNameID = JMP.RouteNameID;
				JMPDTO.RestLocationNames = JMP.RestLocationNames;
                JMPDTO.Time = JMP.Time;
				JMPDTO.EnterTime = JMP.EnterTime;
				JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
				JMPDTO.ArrivalTime = JMP.ArrivalTime;

				List<JMP_Passenger> orgjMP_Passengers = JMP_PassengerRepo.getall().Where(jm => jm.JMPID == ID).ToList();

				if (orgjMP_Passengers.Count() == 4)
				{
					Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
					JMPDTO.PassengerName1 = Passenger1.Name;
					JMPDTO.PassengerPhone1 = Passenger1.Telephone;

					Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
					JMPDTO.PassengerName2 = Passenger2.Name;
					JMPDTO.PassengerPhone2 = Passenger2.Telephone;

					Passenger Passenger3 = PassengerRepo.getbyid(orgjMP_Passengers[2].PassengerID);
					JMPDTO.PassengerName3 = Passenger3.Name;
					JMPDTO.PassengerPhone3 = Passenger3.Telephone;

					Passenger Passenger4 = PassengerRepo.getbyid(orgjMP_Passengers[3].PassengerID);
					JMPDTO.PassengerName4 = Passenger4.Name;
					JMPDTO.PassengerPhone4 = Passenger4.Telephone;
				}
				else if (orgjMP_Passengers.Count() == 3)
				{
					Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
					JMPDTO.PassengerName1 = Passenger1.Name;
					JMPDTO.PassengerPhone1 = Passenger1.Telephone;

					Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
					JMPDTO.PassengerName2 = Passenger2.Name;
					JMPDTO.PassengerPhone2 = Passenger2.Telephone;

					Passenger Passenger3 = PassengerRepo.getbyid(orgjMP_Passengers[2].PassengerID);
					JMPDTO.PassengerName3 = Passenger3.Name;
					JMPDTO.PassengerPhone3 = Passenger3.Telephone;
				}
				else if (orgjMP_Passengers.Count() == 2)
				{
					Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
					JMPDTO.PassengerName1 = Passenger1.Name;
					JMPDTO.PassengerPhone1 = Passenger1.Telephone;

					Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
					JMPDTO.PassengerName2 = Passenger2.Name;
					JMPDTO.PassengerPhone2 = Passenger2.Telephone;
				}
				else if (orgjMP_Passengers.Count() == 1)
				{
					Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
					JMPDTO.PassengerName1 = Passenger1.Name;
					JMPDTO.PassengerPhone1 = Passenger1.Telephone;
				}

				JMPDTO.userID = JMP.userID;



				result.Message = "Success";
				result.Data = JMPDTO;
				result.Statescode = 200;
				return result;
			}
			catch (Exception ex)
			{
				result.Message = "Error Not Find";
				result.Statescode = 404;
				return result;
			}
		}

		[HttpGet("{ID:int}")]
        public ActionResult<ResultDTO> GetByID(int ID)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                JMPResponseDTO JMPDTO = new JMPResponseDTO();
                JMP JMP = jMPRepository.getall().FirstOrDefault(j=>j.Id==ID);
                JMPDTO.Id = JMP.Id;
                JMPDTO.JournyNumber = JMP.JournyNumber;
                JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
                JMPDTO.JournyManagerName = JMP.JournyManagerName;
                JMPDTO.Date = JMP.Date;
                JMPDTO.Time = JMP.Time;
                JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
                JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
                JMPDTO.Destination = JMP.Destination;
                JMPDTO.DepartureDate = JMP.DepartureDate;
                JMPDTO.DriverName = JMP.DriverName.Name;
                JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
                JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
                JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
                JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
                JMPDTO.Company = JMP.Company;
                JMPDTO.SpeedLimit = JMP.SpeedLimit;
                JMPDTO.Distance = JMP.Distance;
                JMPDTO.ManagerNumber = JMP.ManagerNumber;
                JMPDTO.VehicleNumber = JMP.Vehicle.Number;
                JMPDTO.VehicleColor = JMP.Vehicle.Color;
                JMPDTO.VehicleType = JMP.Vehicle.Type;
                JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
                JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
                JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
                JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
                JMPDTO.RouteName = JMP.RouteName.Name;
                JMPDTO.RestLocationNames = JMP.RestLocationNames;
                JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
                JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
                JMPDTO.InspectionVechile = JMP.InspectionVechile;
                JMPDTO.Status = JMP.Status;
				JMPDTO.EnterTime = JMP.EnterTime;
				JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
				JMPDTO.ArrivalTime = JMP.ArrivalTime;
				JMPDTO.notifyStatus = JMP.notifyStatus.ToString(); 
                JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
                JMPDTO.userName = JMP.user.UserName;


                result.Data = JMPDTO;
                result.Statescode = 200;
                result.Message = "Success";


                return result;
            }
            catch (Exception ex)
            {
                result.Message = "Error Not Find";
                result.Statescode = 404;
                return result;
            }
        }

        [HttpGet("Edit/{EditID:int}")]
        public ActionResult<ResultDTO> GetByEditID(int EditID)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                JMP jmp = JMPRepo.getall().FirstOrDefault(a => a.Id == EditID);
                JMPDTO JMPDTO = new JMPDTO();
                JMPDTO.Id = jmp.Id;
                JMPDTO.JournyNumber = jmp.JournyNumber;
                JMPDTO.PurposeOfJourny = jmp.PurposeOfJourny;
                JMPDTO.JournyManagerName = jmp.JournyManagerName;
                JMPDTO.Date = jmp.Date;
                JMPDTO.EstimatedArriveDate = jmp.EstimatedArriveDate;
                JMPDTO.EstimatedArriveTime = jmp.EstimatedArriveTime;
                JMPDTO.Destination = jmp.Destination;
                JMPDTO.DepartureDate = jmp.DepartureDate;
                JMPDTO.DriverNameId = jmp.DriverNameId;
                JMPDTO.CommunicationID = jmp.CommunicationID;
                JMPDTO.Company = jmp.Company;
                JMPDTO.SpeedLimit = jmp.SpeedLimit;
                JMPDTO.Distance = jmp.Distance;
                JMPDTO.VehicleId = jmp.VehicleId;
                JMPDTO.InspectionVechile = jmp.InspectionVechile;
                JMPDTO.Status = jmp.Status;
                JMPDTO.NightDrivingReason = jmp.NightDrivingReason;
                JMPDTO.QHSEManagerMustApprove = jmp.QHSEManagerMustApprove;
                JMPDTO.ManagerNumber = jmp.ManagerNumber;
                //JMPDTO.passengerID = JMP_PassengerRepo.getall().Where(jm=>jm.JMPID==jmp.Id).Select(jm=>jm.PassengerID).ToList();
				JMPDTO.EnterTime = jmp.EnterTime;
				JMPDTO.ArrivalStatus = jmp.ArrivalStatus;
				JMPDTO.ArrivalTime = jmp.ArrivalTime;
				//JMPDTO.notifyStatus = jmp.notifyStatus.ToString();
				JMPDTO.ReachBeforeDark = jmp.ReachBeforeDark;
                JMPDTO.RouteNameID = jmp.RouteNameID;
                JMPDTO.RestLocationNames = jmp.RestLocationNames;
                JMPDTO.Time = jmp.Time;
                JMPDTO.userID = jmp.userID;

                result.Message = "Success";
                result.Data = JMPDTO;
                result.Statescode = 200;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = "Error Not Find";
                result.Statescode = 404;
                return result;
            }
        }

        //Check the Code work ??

        [HttpPut("{id:int}")]
        public ActionResult<ResultDTO> Put(int id, JMPDTO newJMP) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    JMP orgJMP = JMPRepo.getbyid(id);
                    newJMP.Id = orgJMP.Id;
                    orgJMP.PurposeOfJourny = newJMP.PurposeOfJourny;
                    orgJMP.JournyManagerName = newJMP.JournyManagerName;
                    orgJMP.Date = newJMP.Date;
                    orgJMP.EstimatedArriveDate = newJMP.EstimatedArriveDate;
                    orgJMP.EstimatedArriveTime = newJMP.EstimatedArriveTime;
                    orgJMP.Destination = newJMP.Destination;
                    orgJMP.DepartureDate = newJMP.DepartureDate;
                    orgJMP.DriverNameId = newJMP.DriverNameId;
                    orgJMP.CommunicationID = newJMP.CommunicationID;
                    orgJMP.Company = newJMP.Company;
                    orgJMP.SpeedLimit = newJMP.SpeedLimit;
                    orgJMP.Distance = newJMP.Distance;
                    orgJMP.VehicleId = newJMP.VehicleId;
                    orgJMP.InspectionVechile = newJMP.InspectionVechile;
                    orgJMP.Status = newJMP.Status;
                    orgJMP.NightDrivingReason = newJMP.NightDrivingReason;
                    orgJMP.QHSEManagerMustApprove = newJMP.QHSEManagerMustApprove;
                    orgJMP.ManagerNumber = newJMP.ManagerNumber;
                    orgJMP.EnterTime = DateTime.Now;
					orgJMP.ReachBeforeDark = newJMP.ReachBeforeDark;
                    orgJMP.RouteNameID = newJMP.RouteNameID;
                    orgJMP.RestLocationNames = newJMP.RestLocationNames;
                    orgJMP.Time = newJMP.Time;
                    //orgJMP.userID = newJMP.userID;


                    JMPRepo.update(orgJMP);


                    List<JMP_Passenger> orgjMP_Passengers = JMP_PassengerRepo.getall().Where(jm=>jm.JMPID== orgJMP.Id).ToList();

					if (orgjMP_Passengers.Count() == 4)
					{
						if(!string.IsNullOrEmpty(newJMP.PassengerName1))
						{
							Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
							Passenger1.Name = newJMP.PassengerName1;
							Passenger1.Telephone = newJMP.PassengerPhone1;
							PassengerRepo.update(Passenger1);
						}
						else if(string.IsNullOrEmpty(newJMP.PassengerName1))
						{
							Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
							Passenger1.IsDeleted = true;
							PassengerRepo.update(Passenger1);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[0].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName2))
						{
							Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
							Passenger2.Name = newJMP.PassengerName2;
							Passenger2.Telephone = newJMP.PassengerPhone2;
							PassengerRepo.update(Passenger2);
						}
						else if (string.IsNullOrEmpty(newJMP.PassengerName2))
						{
							Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
							Passenger2.IsDeleted = true;
							PassengerRepo.update(Passenger2);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[1].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}


						if(!string.IsNullOrEmpty(newJMP.PassengerName3))
						{
							Passenger Passenger3 = PassengerRepo.getbyid(orgjMP_Passengers[2].PassengerID);
							Passenger3.Name = newJMP.PassengerName3;
							Passenger3.Telephone = newJMP.PassengerPhone3;
							PassengerRepo.update(Passenger3);

						}else if(string.IsNullOrEmpty(newJMP.PassengerName3))
						{
							Passenger Passenger3 = PassengerRepo.getbyid(orgjMP_Passengers[2].PassengerID);
							Passenger3.IsDeleted = true;
							PassengerRepo.update(Passenger3);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[2].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName4))
						{
							Passenger Passenger4 = PassengerRepo.getbyid(orgjMP_Passengers[3].PassengerID);
							Passenger4.Name = newJMP.PassengerName4;
							Passenger4.Telephone = newJMP.PassengerPhone4;
							PassengerRepo.update(Passenger4);
						}else if(string.IsNullOrEmpty(newJMP.PassengerName4) && string.IsNullOrEmpty(newJMP.PassengerPhone4))
						{
							Passenger Passenger4 = PassengerRepo.getbyid(orgjMP_Passengers[3].PassengerID);
							Passenger4.IsDeleted = true;
							PassengerRepo.update(Passenger4);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[3].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}

					}
					else if (orgjMP_Passengers.Count() == 3)
					{
						if (!string.IsNullOrEmpty(newJMP.PassengerName1))
						{
							Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
							Passenger1.Name = newJMP.PassengerName1;
							Passenger1.Telephone = newJMP.PassengerPhone1;
							PassengerRepo.update(Passenger1);
						}
						else if (string.IsNullOrEmpty(newJMP.PassengerName1))
						{
							Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
							Passenger1.IsDeleted = true;
							PassengerRepo.update(Passenger1);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[0].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName2))
						{
							Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
							Passenger2.Name = newJMP.PassengerName2;
							Passenger2.Telephone = newJMP.PassengerPhone2;
							PassengerRepo.update(Passenger2);
						}
						else if (string.IsNullOrEmpty(newJMP.PassengerName2))
						{
							Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
							Passenger2.IsDeleted = true;
							PassengerRepo.update(Passenger2);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[1].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}


						if (!string.IsNullOrEmpty(newJMP.PassengerName3))
						{
							Passenger Passenger3 = PassengerRepo.getbyid(orgjMP_Passengers[2].PassengerID);
							Passenger3.Name = newJMP.PassengerName3;
							Passenger3.Telephone = newJMP.PassengerPhone3;
							PassengerRepo.update(Passenger3);

						}
						else if (string.IsNullOrEmpty(newJMP.PassengerName3))
						{
							Passenger Passenger3 = PassengerRepo.getbyid(orgjMP_Passengers[2].PassengerID);
							Passenger3.IsDeleted = true;
							PassengerRepo.update(Passenger3);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[2].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName4))
						{
							Passenger Passenger = new Passenger();
							Passenger.Name = newJMP.PassengerName4;
							Passenger.Telephone = newJMP.PassengerPhone4;
							PassengerRepo.create(Passenger);
							JMP_Passenger jMP_Passenger = new JMP_Passenger();
							jMP_Passenger.PassengerID = Passenger.Id;
							jMP_Passenger.JMPID = orgJMP.Id;
							JMP_PassengerRepo.create(jMP_Passenger);
						}
					}
					else if (orgjMP_Passengers.Count() == 2)
					{
						if (!string.IsNullOrEmpty(newJMP.PassengerName1))
						{
							Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
							Passenger1.Name = newJMP.PassengerName1;
							Passenger1.Telephone = newJMP.PassengerPhone1;
							PassengerRepo.update(Passenger1);
						}
						else if (string.IsNullOrEmpty(newJMP.PassengerName1))
						{
							Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
							Passenger1.IsDeleted = true;
							PassengerRepo.update(Passenger1);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[0].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName2))
						{
							Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
							Passenger2.Name = newJMP.PassengerName2;
							Passenger2.Telephone = newJMP.PassengerPhone2;
							PassengerRepo.update(Passenger2);
						}
						else if (string.IsNullOrEmpty(newJMP.PassengerName2))
						{
							Passenger Passenger2 = PassengerRepo.getbyid(orgjMP_Passengers[1].PassengerID);
							Passenger2.IsDeleted = true;
							PassengerRepo.update(Passenger2);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[1].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName3))
						{
							Passenger Passenger = new Passenger();
							Passenger.Name = newJMP.PassengerName3;
							Passenger.Telephone = newJMP.PassengerPhone3;
							PassengerRepo.create(Passenger);
							JMP_Passenger jMP_Passenger = new JMP_Passenger();
							jMP_Passenger.PassengerID = Passenger.Id;
							jMP_Passenger.JMPID = orgJMP.Id;
							JMP_PassengerRepo.create(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName4))
						{
							Passenger Passenger = new Passenger();
							Passenger.Name = newJMP.PassengerName4;
							Passenger.Telephone = newJMP.PassengerPhone4;
							PassengerRepo.create(Passenger);
							JMP_Passenger jMP_Passenger = new JMP_Passenger();
							jMP_Passenger.PassengerID = Passenger.Id;
							jMP_Passenger.JMPID = orgJMP.Id;
							JMP_PassengerRepo.create(jMP_Passenger);
						}
					}
					else if (orgjMP_Passengers.Count() == 1)
					{
						if (!string.IsNullOrEmpty(newJMP.PassengerName1))
						{
							Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
							Passenger1.Name = newJMP.PassengerName1;
							Passenger1.Telephone = newJMP.PassengerPhone1;
							PassengerRepo.update(Passenger1);
						}
						else if (string.IsNullOrEmpty(newJMP.PassengerName1))
						{
							Passenger Passenger1 = PassengerRepo.getbyid(orgjMP_Passengers[0].PassengerID);
							Passenger1.IsDeleted = true;
							PassengerRepo.update(Passenger1);
							JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getall().FirstOrDefault(jm => jm.PassengerID == orgjMP_Passengers[0].PassengerID);
							jMP_Passenger.IsDeleted = true;
							JMP_PassengerRepo.update(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName2))
						{
							Passenger Passenger = new Passenger();
							Passenger.Name = newJMP.PassengerName2;
							Passenger.Telephone = newJMP.PassengerPhone2;
							PassengerRepo.create(Passenger);
							JMP_Passenger jMP_Passenger = new JMP_Passenger();
							jMP_Passenger.PassengerID = Passenger.Id;
							jMP_Passenger.JMPID = orgJMP.Id;
							JMP_PassengerRepo.create(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName3))
						{
							Passenger Passenger = new Passenger();
							Passenger.Name = newJMP.PassengerName3;
							Passenger.Telephone = newJMP.PassengerPhone3;
							PassengerRepo.create(Passenger);
							JMP_Passenger jMP_Passenger = new JMP_Passenger();
							jMP_Passenger.PassengerID = Passenger.Id;
							jMP_Passenger.JMPID = orgJMP.Id;
							JMP_PassengerRepo.create(jMP_Passenger);
						}

						if (!string.IsNullOrEmpty(newJMP.PassengerName4))
						{
							Passenger Passenger = new Passenger();
							Passenger.Name = newJMP.PassengerName4;
							Passenger.Telephone = newJMP.PassengerPhone4;
							PassengerRepo.create(Passenger);
							JMP_Passenger jMP_Passenger = new JMP_Passenger();
							jMP_Passenger.PassengerID = Passenger.Id;
							jMP_Passenger.JMPID = orgJMP.Id;
							JMP_PassengerRepo.create(jMP_Passenger);
						}
					}


					result.Message = "Success";
                    result.Data = orgJMP;
                    result.Statescode = 200;
                    return result;
                }
                catch (Exception ex)
                {
                    result.Message = "Error in Updating";
                    result.Statescode = 400;
                    return result;
                }
            }
            return BadRequest(ModelState);
        }

		[HttpPut]
		public ActionResult<ResultDTO> EditNotifyStatus(int id, NotifyStatus notifyStatus) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

				try
				{
					JMP orgJMP = JMPRepo.getbyid(id);
                    orgJMP.notifyStatus = notifyStatus;
					
                    JMPRepo.update(orgJMP);

					result.Message = "Success";
					result.Data = orgJMP;
					result.Statescode = 200;
					return result;
				}
				catch (Exception ex)
				{
					result.Message = "Error in Updating";
					result.Statescode = 400;
					return result;
				}
		}

        [HttpPut("ArrivalStatus")]
        public async Task<ResultDTO> EditArrivalStatus(int id, bool arrivalStatus) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				JMP orgJMP = JMPRepo.getbyid(id);
				orgJMP.ArrivalStatus = arrivalStatus;
				orgJMP.ArrivalTime = DateTime.Now;

				JMPRepo.update(orgJMP);

				await ArrivalNotificationHub.Clients.All.SendMessage2(new ArrivalNotification
				{
					SerialNo = orgJMP.JournyNumber,
					ArrivalTime = orgJMP.ArrivalTime.ToString("HH:mm:ss"),
					Message = "SJP has Arrived",
					Destination = orgJMP.Destination
				});

				result.Message = "Success";
				result.Data = orgJMP;
				result.Statescode = 200;
				return result;
			}
			catch (Exception ex)
			{
				result.Message = "Error in Updating";
				result.Statescode = 400;
				return result;
			}
		}

		[HttpGet("SJPByPage/{page:int}")]
		public PageResult<JMPResponseDTO> GetSJPArrivalStatusByPage(int? page, int pagesize = 10)
		{
			List<JMP> temp = jMPRepository.getall().Where(jm=>jm.notifyStatus==NotifyStatus.Approved&&jm.ArrivalStatus==false).ToList();
			List<JMPResponseDTO> newTemp = new List<JMPResponseDTO>();
			foreach (JMP JMP in temp)
			{
				JMPResponseDTO JMPDTO = new JMPResponseDTO();
				JMPDTO.Id = JMP.Id;
				JMPDTO.JournyNumber = JMP.JournyNumber;
				JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
				JMPDTO.JournyManagerName = JMP.JournyManagerName;
				JMPDTO.Date = JMP.Date;
				JMPDTO.Time = JMP.Time;
				JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
				JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
				JMPDTO.Destination = JMP.Destination;
				JMPDTO.DepartureDate = JMP.DepartureDate;
				JMPDTO.DriverName = JMP.DriverName.Name;
				JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
				JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
				JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
				JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
				JMPDTO.Company = JMP.Company;
				JMPDTO.SpeedLimit = JMP.SpeedLimit;
				JMPDTO.Distance = JMP.Distance;
				JMPDTO.VehicleNumber = JMP.Vehicle.Number;
				JMPDTO.VehicleColor = JMP.Vehicle.Color;
				JMPDTO.VehicleType = JMP.Vehicle.Type;
				JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
				JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
				JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
				JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
				JMPDTO.RouteName = JMP.RouteName.Name;
				JMPDTO.RestLocationNames = JMP.RestLocationNames;
				JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
				JMPDTO.ManagerNumber = JMP.ManagerNumber;
				JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
				JMPDTO.InspectionVechile = JMP.InspectionVechile;
				JMPDTO.EnterTime = JMP.EnterTime;
				JMPDTO.notifyStatus = JMP.notifyStatus.ToString();
				JMPDTO.Status = JMP.Status;
				JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
				JMPDTO.ArrivalTime = JMP.ArrivalTime;
                JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
				JMPDTO.userName = JMP.user.UserName;

				newTemp.Add(JMPDTO);
			}

			float countDetails = jMPRepository.getall().Where(jm => jm.notifyStatus == NotifyStatus.Approved && jm.ArrivalStatus == false).Count();
			var result = new PageResult<JMPResponseDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}

		[HttpGet("ArrivedSJPByPage/{page:int}")]
		public PageResult<JMPResponseDTO> GetArrivedSJPByPage(int? page, int pagesize = 10)
		{
			List<JMP> temp = jMPRepository.getall().Where(jm => jm.ArrivalStatus == true).ToList();
			List<JMPResponseDTO> newTemp = new List<JMPResponseDTO>();
			foreach (JMP JMP in temp)
			{
				JMPResponseDTO JMPDTO = new JMPResponseDTO();
				JMPDTO.Id = JMP.Id;
				JMPDTO.JournyNumber = JMP.JournyNumber;
				JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
				JMPDTO.JournyManagerName = JMP.JournyManagerName;
				JMPDTO.Date = JMP.Date;
				JMPDTO.Time = JMP.Time;
				JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
				JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
				JMPDTO.Destination = JMP.Destination;
				JMPDTO.DepartureDate = JMP.DepartureDate;
				JMPDTO.DriverName = JMP.DriverName.Name;
				JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
				JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
				JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
				JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
				JMPDTO.Company = JMP.Company;
				JMPDTO.SpeedLimit = JMP.SpeedLimit;
				JMPDTO.Distance = JMP.Distance;
				JMPDTO.VehicleNumber = JMP.Vehicle.Number;
				JMPDTO.VehicleColor = JMP.Vehicle.Color;
				JMPDTO.VehicleType = JMP.Vehicle.Type;
				JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
				JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
				JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
				JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
				JMPDTO.RouteName = JMP.RouteName.Name;
				JMPDTO.RestLocationNames = JMP.RestLocationNames;
				JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
				JMPDTO.ManagerNumber = JMP.ManagerNumber;
				JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
				JMPDTO.InspectionVechile = JMP.InspectionVechile;
				JMPDTO.EnterTime = JMP.EnterTime;
				JMPDTO.notifyStatus = JMP.notifyStatus.ToString();
				JMPDTO.Status = JMP.Status;
                JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
                JMPDTO.ArrivalTime = JMP.ArrivalTime;
                JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
				JMPDTO.userName = JMP.user.UserName;

				newTemp.Add(JMPDTO);
			}

			float countDetails = jMPRepository.getall().Where(jm => jm.ArrivalStatus == true).Count();
			var result = new PageResult<JMPResponseDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}


		[HttpGet("SerialNO/{SN:int}")]
        public ActionResult<ResultDTO> GetDataBySN(int SN)
        {

            ResultDTO result = new ResultDTO();

            JMP temp = jMPRepository.getall().FirstOrDefault(j => j.JournyNumber == SN);
            JMPResponseDTO newTemp = new JMPResponseDTO();

            newTemp.Id = temp.Id;
            newTemp.JournyNumber = temp.JournyNumber;
            newTemp.PurposeOfJourny = temp.PurposeOfJourny;
            newTemp.JournyManagerName = temp.JournyManagerName;
            newTemp.Date = temp.Date;
            newTemp.Time = temp.Time;
            newTemp.EstimatedArriveDate = temp.EstimatedArriveDate;
            newTemp.EstimatedArriveTime = temp.EstimatedArriveTime;
            newTemp.Destination = temp.Destination;
            newTemp.DepartureDate = temp.DepartureDate;
            newTemp.DriverName = temp.DriverName.Name;
            newTemp.DriverPhoneNumber = temp.DriverName.PhoneNumber;
            newTemp.DriverLicenceExpireDate = temp.DriverName.LicenceExpireData;
            newTemp.DriverLicenceNumber = temp.DriverName.LicenceNumber;
            newTemp.CommunicationMethod = temp.comminucationMethod.Name;
            newTemp.Company = temp.Company;
            newTemp.SpeedLimit = temp.SpeedLimit;
            newTemp.Distance = temp.Distance;
            newTemp.ManagerNumber = temp.ManagerNumber;
            newTemp.VehicleNumber = temp.Vehicle.Number;
            newTemp.VehicleColor = temp.Vehicle.Color;
            newTemp.VehicleType = temp.Vehicle.Type;
            newTemp.VehiclePassengerNumber = temp.Vehicle.PassengerNumber;
            newTemp.VehicleLicenceNumber = temp.Vehicle.LicenceNumber;
            newTemp.VehicleLicenceExpireData = temp.Vehicle.LicenceExpireData;
            newTemp.ReachBeforeDark = temp.ReachBeforeDark;
            newTemp.RouteName = temp.RouteName.Name;
			newTemp.EnterTime = temp.EnterTime;
			newTemp.ArrivalStatus = temp.ArrivalStatus;
			newTemp.ArrivalTime = temp.ArrivalTime;
			newTemp.notifyStatus = temp.notifyStatus.ToString();
			newTemp.RestLocationNames = temp.RestLocationNames;
            newTemp.QHSEManagerMustApprove = temp.QHSEManagerMustApprove;
            newTemp.NightDrivingReason = temp.NightDrivingReason;
            newTemp.InspectionVechile = temp.InspectionVechile;
            newTemp.Status = temp.Status;
            newTemp.Passengers = temp.jMP_Passengers.Where(jp => jp.JMPID == temp.Id).Select(jp => jp.Passenger).ToList();
            newTemp.userName = temp.user.UserName;

            if (newTemp != null)
            {

                result.Message = "Success";
                result.Statescode = 200;
                result.Data = newTemp;

                return result;
            }

            result.Statescode = 404;
            result.Message = "data not found";
            return result;

        }

        /////////////////////////////////////////////////

        [HttpGet("/date/{page:int}")]
        public PageResult<JMPResponseDTO> GetDataByDate(int? page, int pagesize = 10)
        {
            List<JMP> temp = jMPRepository.getall().Where(j=>j.Date==DateTime.Now.Date).ToList();
            List<JMPResponseDTO> newTemp = new List<JMPResponseDTO>();
            foreach (JMP JMP in temp)
            {
                JMPResponseDTO JMPDTO = new JMPResponseDTO();
                JMPDTO.Id = JMP.Id;
                JMPDTO.JournyNumber = JMP.JournyNumber;
                JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
                JMPDTO.JournyManagerName = JMP.JournyManagerName;
                JMPDTO.Date = JMP.Date;
                JMPDTO.Time = JMP.Time;
                JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
                JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
                JMPDTO.Destination = JMP.Destination;
                JMPDTO.DepartureDate = JMP.DepartureDate;
                JMPDTO.DriverName = JMP.DriverName.Name;
                JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
                JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
                JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
                JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
                JMPDTO.Company = JMP.Company;
                JMPDTO.SpeedLimit = JMP.SpeedLimit;
                JMPDTO.Distance = JMP.Distance;
                JMPDTO.ManagerNumber = JMP.ManagerNumber;
                JMPDTO.VehicleNumber = JMP.Vehicle.Number;
                JMPDTO.VehicleColor = JMP.Vehicle.Color;
                JMPDTO.VehicleType = JMP.Vehicle.Type;
                JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
                JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
                JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
                JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
                JMPDTO.RouteName = JMP.RouteName.Name;
                JMPDTO.RestLocationNames = JMP.RestLocationNames;
                JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
                JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
                JMPDTO.InspectionVechile = JMP.InspectionVechile;
                JMPDTO.Status = JMP.Status;
				JMPDTO.EnterTime = JMP.EnterTime;

				JMPDTO.ArrivalStatus = JMP.ArrivalStatus;
				JMPDTO.ArrivalTime = JMP.ArrivalTime;
				JMPDTO.notifyStatus = JMP.notifyStatus.ToString(); 
                JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
                JMPDTO.userName = JMP.user.UserName;

                newTemp.Add(JMPDTO);
            }
			float countDetails = jMPRepository.getall().Where(j => j.Date == DateTime.Now.Date).Count();
			var result = new PageResult<JMPResponseDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;

		}

        //[HttpGet("Date/{date:alpha}")]
        //public ActionResult<ResultDTO> GetDataByDateString(string date)
        //{

        //    ResultDTO result = new ResultDTO();

            

        //    List<JMP> temp = jMPRepository.getall().Where(j => j.Date == DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture)).ToList();
        //    List<JMPResponseDTO> newTemp = new List<JMPResponseDTO>();
        //    foreach (JMP JMP in temp)
        //    {
        //        JMPResponseDTO JMPDTO = new JMPResponseDTO();
        //        JMPDTO.Id = JMP.Id;
        //        JMPDTO.JournyNumber = JMP.JournyNumber;
        //        JMPDTO.PurposeOfJourny = JMP.PurposeOfJourny;
        //        JMPDTO.JournyManagerName = JMP.JournyManagerName;
        //        JMPDTO.Date = JMP.Date;
        //        JMPDTO.Time = JMP.Time;
        //        JMPDTO.EstimatedArriveDate = JMP.EstimatedArriveDate;
        //        JMPDTO.EstimatedArriveTime = JMP.EstimatedArriveTime;
        //        JMPDTO.Destination = JMP.Destination;
        //        JMPDTO.DepartureDate = JMP.DepartureDate;
        //        JMPDTO.DriverName = JMP.DriverName.Name;
        //        JMPDTO.DriverPhoneNumber = JMP.DriverName.PhoneNumber;
        //        JMPDTO.DriverLicenceExpireDate = JMP.DriverName.LicenceExpireData;
        //        JMPDTO.DriverLicenceNumber = JMP.DriverName.LicenceNumber;
        //        JMPDTO.CommunicationMethod = JMP.comminucationMethod.Name;
        //        JMPDTO.Company = JMP.Company;
        //        JMPDTO.SpeedLimit = JMP.SpeedLimit;
        //        JMPDTO.Distance = JMP.Distance;
        //        JMPDTO.VehicleNumber = JMP.Vehicle.Number;
        //        JMPDTO.VehicleColor = JMP.Vehicle.Color;
        //        JMPDTO.VehicleType = JMP.Vehicle.Type;
        //        JMPDTO.VehiclePassengerNumber = JMP.Vehicle.PassengerNumber;
        //        JMPDTO.VehicleLicenceNumber = JMP.Vehicle.LicenceNumber;
        //        JMPDTO.VehicleLicenceExpireData = JMP.Vehicle.LicenceExpireData;
        //        JMPDTO.ReachBeforeDark = JMP.ReachBeforeDark;
        //        JMPDTO.RouteName = JMP.RouteName.Name;
        //        JMPDTO.RestLocationNames = JMP.RestLocationNames;
        //        JMPDTO.QHSEManagerMustApprove = JMP.QHSEManagerMustApprove;
        //        JMPDTO.NightDrivingReason = JMP.NightDrivingReason;
        //        JMPDTO.InspectionVechile = JMP.InspectionVechile;
        //        JMPDTO.Status = JMP.Status;
        //        //JMPDTO.passengerNames = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger.Name).ToList();
        //        //JMPDTO.passengerTelephones = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger.Telephone).ToList();
        //        JMPDTO.Passengers = JMP.jMP_Passengers.Where(jp => jp.JMPID == JMP.Id).Select(jp => jp.Passenger).ToList();
        //        JMPDTO.userName = JMP.user.UserName;

        //        newTemp.Add(JMPDTO);
        //    }
        //    if (newTemp != null)
        //    {

        //        result.Statescode = 200;
        //        result.Data = newTemp;

        //        return result;
        //    }

        //    result.Statescode = 404;
        //    result.Message = "data not found";
        //    return result;

        //}



        [HttpPost]
        public async Task<ResultDTO> AddJMP(JMPDTO JMPDTO)
        {
            ResultDTO result = new ResultDTO();
            int Counter = jMPRepository.getall().Count();

            if (ModelState.IsValid)
            {
                try
                {
                    JMP JMP = new JMP();
                    JMP.Id = JMPDTO.Id;
                    JMP.JournyNumber = Counter + 1;
                    JMP.PurposeOfJourny = JMPDTO.PurposeOfJourny;
                    JMP.JournyManagerName = JMPDTO.JournyManagerName;
                    JMP.Date = JMPDTO.Date;
                    JMP.EstimatedArriveDate = JMPDTO.EstimatedArriveDate;
                    JMP.EstimatedArriveTime = JMPDTO.EstimatedArriveTime;
                    JMP.Destination = JMPDTO.Destination;
                    JMP.DepartureDate = JMPDTO.DepartureDate;
                    JMP.DriverNameId = JMPDTO.DriverNameId;
                    JMP.CommunicationID = JMPDTO.CommunicationID;
                    JMP.Company = JMPDTO.Company;
                    JMP.SpeedLimit = JMPDTO.SpeedLimit;
                    JMP.Distance = JMPDTO.Distance;
                    JMP.VehicleId = JMPDTO.VehicleId;
					JMP.InspectionVechile = JMPDTO.InspectionVechile;
					JMP.Status = JMPDTO.Status;
					JMP.NightDrivingReason = JMPDTO.NightDrivingReason;
					JMP.QHSEManagerMustApprove = JMPDTO.QHSEManagerMustApprove;
					JMP.ManagerNumber = JMPDTO.ManagerNumber;
					JMP.EnterTime = DateTime.Now;
					JMP.ReachBeforeDark = JMPDTO.ReachBeforeDark;
                    JMP.RouteNameID = JMPDTO.RouteNameID;
                    JMP.RestLocationNames = JMPDTO.RestLocationNames;
					JMP.Time = Math.Round((JMPDTO.Distance / JMPDTO.SpeedLimit) * 100) / 100;
                    JMP.userID = JMPDTO.userID;

                    JMPRepo.create(JMP);

					if(!string.IsNullOrEmpty(JMPDTO.PassengerName1))
					{
						Passenger Passenger = new Passenger();
						Passenger.Name = JMPDTO.PassengerName1;
						Passenger.Telephone = JMPDTO.PassengerPhone1;
						PassengerRepo.create(Passenger);
						JMP_Passenger jMP_Passenger = new JMP_Passenger();
						jMP_Passenger.PassengerID = Passenger.Id;
						jMP_Passenger.JMPID = JMP.Id;
						JMP_PassengerRepo.create(jMP_Passenger);
					}

					if (!string.IsNullOrEmpty(JMPDTO.PassengerName2))
					{
						Passenger Passenger = new Passenger();
						Passenger.Name = JMPDTO.PassengerName2;
						Passenger.Telephone = JMPDTO.PassengerPhone2;
						PassengerRepo.create(Passenger);
						JMP_Passenger jMP_Passenger = new JMP_Passenger();
						jMP_Passenger.PassengerID = Passenger.Id;
						jMP_Passenger.JMPID = JMP.Id;
						JMP_PassengerRepo.create(jMP_Passenger);
					}
					if (!string.IsNullOrEmpty(JMPDTO.PassengerName3))
					{
						Passenger Passenger = new Passenger();
						Passenger.Name = JMPDTO.PassengerName3;
						Passenger.Telephone = JMPDTO.PassengerPhone3;
						PassengerRepo.create(Passenger);
						JMP_Passenger jMP_Passenger = new JMP_Passenger();
						jMP_Passenger.PassengerID = Passenger.Id;
						jMP_Passenger.JMPID = JMP.Id;
						JMP_PassengerRepo.create(jMP_Passenger);
					}
					if (!string.IsNullOrEmpty(JMPDTO.PassengerName4))
					{
						Passenger Passenger = new Passenger();
						Passenger.Name = JMPDTO.PassengerName4;
						Passenger.Telephone = JMPDTO.PassengerPhone4;
						PassengerRepo.create(Passenger);
						JMP_Passenger jMP_Passenger = new JMP_Passenger();
						jMP_Passenger.PassengerID = Passenger.Id;
						jMP_Passenger.JMPID = JMP.Id;
						JMP_PassengerRepo.create(jMP_Passenger);
					}


                    var UserObj = await userManager.FindByIdAsync(JMP.userID);

					await NotificationHub.Clients.All.SendMessage(new Notification
                    {
						FormId = JMP.JournyNumber,
                        User= UserObj.UserName,
                        Message= "New SJP is Added"
					});

					result.Message = "Success";
                    result.Data = JMPDTO;
                    result.Statescode = 200;
					

				}
                catch (Exception ex)
                {
                    result.Message = "Error in inserting";
                    result.Statescode = 400;

                }
            }
            return result;
        }

        [HttpPut("Delete/{id:int}")]
        public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                JMP jMP = JMPRepo.getbyid(id);
                jMP.IsDeleted = true;
                JMPRepo.update(jMP);
				List<JMP_Passenger> jMP_Passenger = JMP_PassengerRepo.getall().Where(jm => jm.JMPID == id).ToList();
				foreach(JMP_Passenger item in jMP_Passenger)
				{
					item.IsDeleted = true;
					JMP_PassengerRepo.update(item);
					Passenger passenger = PassengerRepo.getbyid(item.PassengerID);
					passenger.IsDeleted = true;
					PassengerRepo.update(passenger);
				}

				result.Data = jMP;
                result.Statescode = 200;
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                result.Message = "Error in deleted";
                result.Statescode = 400;
            }

            return result;
        }
    }
}
