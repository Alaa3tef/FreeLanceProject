using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Helper;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	//[Authorize]
	public class AccidentController : ControllerBase
    {
        public IRepository<Accident> accidentRepo { get; set; }
        public IAccidentRepository accidentRepoistory { get; set; }

		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;


		public AccidentController(Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager,IRepository<Accident> _accidentRepo, IAccidentRepository _accidentRepoistory)
        {
            this.accidentRepo = _accidentRepo;
            this.accidentRepoistory = _accidentRepoistory;
            this.userManager = _userManager;
        }

        [HttpGet("GetData")]
        public async Task<ResultDTO> GetAllWithData(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Accident> temp = accidentRepoistory.getall();
					List<AccidentResponseDTO> newTemp = new List<AccidentResponseDTO>();
					foreach (Accident accident in temp)
					{
						AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						newTemp.Add(accidentDTO);
						//result.Data = prod;
					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<Accident> temp = accidentRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<AccidentResponseDTO> newTemp = new List<AccidentResponseDTO>();
					foreach (Accident accident in temp)
					{
						AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						newTemp.Add(accidentDTO);
						//result.Data = prod;
					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}					
				}
			}
			catch(Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}
			return result;
		}

		[HttpGet("GetDataForExcel")]
		public ActionResult<ResultDTO> GetDataForExcel(string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Accident> temp = accidentRepoistory.getall();
					List<AccidentExcelDTO> newTemp = new List<AccidentExcelDTO>();
					foreach (Accident accident in temp)
					{
						AccidentExcelDTO accidentDTO = new AccidentExcelDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.QHSECode = accident.QHSEEmpCode;
						accidentDTO.ToolPusherCode = accident.PusherEmpCode;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						newTemp.Add(accidentDTO);
						//result.Data = prod;
					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<Accident> temp = accidentRepoistory.getall().Where(a => a.user.Id == UserID).ToList();
					List<AccidentExcelDTO> newTemp = new List<AccidentExcelDTO>();
					foreach (Accident accident in temp)
					{
						AccidentExcelDTO accidentDTO = new AccidentExcelDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.QHSECode = accident.QHSEEmpCode;
						accidentDTO.ToolPusherCode = accident.PusherEmpCode;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						newTemp.Add(accidentDTO);
						//result.Data = prod;
					}
					if (newTemp != null)
					{
						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}

				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;
		}

		[HttpGet("ByPage/{page:int}")]
		public PageResult<AccidentResponseDTO> GettAllStoCardsByPage(string UserId,string UserRole,int? page, int pagesize = 10)
		{

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<Accident> temp = accidentRepoistory.getall();
					List<AccidentResponseDTO> newTemp = new List<AccidentResponseDTO>();
					foreach (Accident accident in temp)
					{
						AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						newTemp.Add(accidentDTO);
						//result.Data = prod;
					}

					float countDetails = accidentRepoistory.getall().Count();
					var result = new PageResult<AccidentResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};

					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<Accident> temp = accidentRepoistory.getall().Where(a => a.user.Id == UserId).ToList();
					List<AccidentResponseDTO> newTemp = new List<AccidentResponseDTO>();
					foreach (Accident accident in temp)
					{
						AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						newTemp.Add(accidentDTO);
						//result.Data = prod;
					}

					float countDetails = accidentRepoistory.getall().Where(a => a.user.Id == UserId).Count();
					var result = new PageResult<AccidentResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};
					return result;
				}
			}
			catch (Exception ex)
			{
				return new PageResult<AccidentResponseDTO>();

			}
			return new PageResult<AccidentResponseDTO>();
		}


		[HttpGet("GetDataById/{ID:int}")]
        public ActionResult<ResultDTO> GetAllWithDataByID(int ID,string UserId,string UserRole)
        {
            ResultDTO result = new ResultDTO();


			if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
            {
				Accident temp = accidentRepoistory.getall().FirstOrDefault(a => a.Id == ID);
				if (temp != null)
				{
					AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
					accidentDTO.id = temp.Id;
					accidentDTO.Rig = temp.Rig.Number;
					accidentDTO.TimeOfEvent = temp.TimeOfEvent;
					accidentDTO.DateOfEvent = temp.DateOfEvent;
					accidentDTO.TypeOfInjury = temp.TypeOfInjury.Name;
					accidentDTO.ViolationCategory = temp.ViolationCategory.Name;
					accidentDTO.AccidentCauses = temp.AccidentCauses.Name;
					accidentDTO.PreventionCategory = temp.PreventionCategory.Name;
					accidentDTO.ClassificationOfAccident = temp.ClassificationOfAccident.Name;
					accidentDTO.AccidentLocation = temp.AccidentLocation;
					accidentDTO.QHSEName = temp.QHSEPositionName.Name;
					accidentDTO.ToolPusherName = temp.ToolPusherPositionName.Name;
					accidentDTO.ToolPusherPosition = temp.ToolPusherPosition.Name;
					accidentDTO.QHSEPosition = temp.QHSEPosition.Name;
					accidentDTO.DrillerName = temp.DrillerName;
					accidentDTO.DescriptionOfTheEvent = temp.DescriptionOfTheEvent;
					accidentDTO.ImmediateActionType = temp.ImmediateActionType;
					accidentDTO.DirectCauses = temp.DirectCauses;
					accidentDTO.RootCauses = temp.RootCauses;
					accidentDTO.userName = temp.user.UserName;
					accidentDTO.Recommendations = temp.Recommendations;
					accidentDTO.Pictures = temp.Pictures;

					if (accidentDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = accidentDTO;

						return result;
					}
				}

			}
			else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
            {
				Accident temp = accidentRepoistory.getall().FirstOrDefault(a => a.Id == ID&&a.user.Id==UserId);
				if (temp != null)
				{
					AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
					accidentDTO.id = temp.Id;
					accidentDTO.Rig = temp.Rig.Number;
					accidentDTO.TimeOfEvent = temp.TimeOfEvent;
					accidentDTO.DateOfEvent = temp.DateOfEvent;
					accidentDTO.TypeOfInjury = temp.TypeOfInjury.Name;
					accidentDTO.ViolationCategory = temp.ViolationCategory.Name;
					accidentDTO.AccidentCauses = temp.AccidentCauses.Name;
					accidentDTO.PreventionCategory = temp.PreventionCategory.Name;
					accidentDTO.ClassificationOfAccident = temp.ClassificationOfAccident.Name;
					accidentDTO.AccidentLocation = temp.AccidentLocation;
					accidentDTO.QHSEName = temp.QHSEPositionName.Name;
					accidentDTO.ToolPusherName = temp.ToolPusherPositionName.Name;
					accidentDTO.ToolPusherPosition = temp.ToolPusherPosition.Name;
					accidentDTO.QHSEPosition = temp.QHSEPosition.Name;
					accidentDTO.DrillerName = temp.DrillerName;
					accidentDTO.DescriptionOfTheEvent = temp.DescriptionOfTheEvent;
					accidentDTO.ImmediateActionType = temp.ImmediateActionType;
					accidentDTO.DirectCauses = temp.DirectCauses;
					accidentDTO.RootCauses = temp.RootCauses;
					accidentDTO.userName = temp.user.UserName;
					accidentDTO.Recommendations = temp.Recommendations;
					accidentDTO.Pictures = temp.Pictures;

					if (accidentDTO != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = accidentDTO;

						return result;
					}
				}

			}

			result.Statescode = 404;
            result.Message = "data not found";
            return result;
        }


        [HttpGet("GetDataByDate/{date:DateTime}")]
        public ActionResult<ResultDTO> GetAllWithDataByDate(DateTime date,string UserId,string UserRole)
        {
            ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<AccidentResponseDTO> accidentDTOs = new List<AccidentResponseDTO>();
					List<Accident> accidents = accidentRepoistory.getall().Where(a => a.DateOfEvent == date).ToList();
					foreach (Accident accident in accidents)
					{
						AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						accidentDTOs.Add(accidentDTO);

					}
					result.Message = "Success";
					result.Data = accidentDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<AccidentResponseDTO> accidentDTOs = new List<AccidentResponseDTO>();
					List<Accident> accidents = accidentRepoistory.getall().Where(a => a.DateOfEvent == date && a.user.Id == UserId).ToList();
					foreach (Accident accident in accidents)
					{
						AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						accidentDTOs.Add(accidentDTO);

					}
					result.Message = "Success";
					result.Data = accidentDTOs;
					result.Statescode = 200;
					return result;
				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;

        }

        [HttpGet("GetDataByClass/{Class:int}")]
        public ActionResult<ResultDTO> GetAllWithDataByClassification(int Class,string UserId,string UserRole)
        {
            ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<AccidentResponseDTO> accidentDTOs = new List<AccidentResponseDTO>();
					List<Accident> accidents = accidentRepoistory.getall().Where(a => a.ClassificationOfAccidentId == Class).ToList();
					foreach (Accident accident in accidents)
					{
						AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						accidentDTOs.Add(accidentDTO);

					}
					result.Message = "Success";
					result.Data = accidentDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<AccidentResponseDTO> accidentDTOs = new List<AccidentResponseDTO>();
					List<Accident> accidents = accidentRepoistory.getall().Where(a => a.ClassificationOfAccidentId == Class && a.user.Id == UserId).ToList();
					foreach (Accident accident in accidents)
					{
						AccidentResponseDTO accidentDTO = new AccidentResponseDTO();
						accidentDTO.id = accident.Id;
						accidentDTO.Rig = accident.Rig.Number;
						accidentDTO.TimeOfEvent = accident.TimeOfEvent;
						accidentDTO.DateOfEvent = accident.DateOfEvent;
						accidentDTO.TypeOfInjury = accident.TypeOfInjury.Name;
						accidentDTO.ViolationCategory = accident.ViolationCategory.Name;
						accidentDTO.AccidentCauses = accident.AccidentCauses.Name;
						accidentDTO.PreventionCategory = accident.PreventionCategory.Name;
						accidentDTO.ClassificationOfAccident = accident.ClassificationOfAccident.Name;
						accidentDTO.AccidentLocation = accident.AccidentLocation;
						accidentDTO.QHSEName = accident.QHSEPositionName.Name;
						accidentDTO.ToolPusherName = accident.ToolPusherPositionName.Name;
						accidentDTO.ToolPusherPosition = accident.ToolPusherPosition.Name;
						accidentDTO.QHSEPosition = accident.QHSEPosition.Name;
						accidentDTO.DrillerName = accident.DrillerName;
						accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
						accidentDTO.ImmediateActionType = accident.ImmediateActionType;
						accidentDTO.DirectCauses = accident.DirectCauses;
						accidentDTO.RootCauses = accident.RootCauses;
						accidentDTO.userName = accident.user.UserName;
						accidentDTO.Recommendations = accident.Recommendations;
						accidentDTO.Pictures = accident.Pictures;

						accidentDTOs.Add(accidentDTO);

					}
					result.Message = "Success";
					result.Data = accidentDTOs;
					result.Statescode = 200;
					return result;
				}

			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

            return result;
        }


        //[HttpGet]
        //public ActionResult<ResultDTO> GetAll()
        //{

        //    ResultDTO result = new ResultDTO();

        //    List<Accident> temp = accidentRepo.getall();
        //    List<AccidentDTO> newTemp = new List<AccidentDTO>();
        //    foreach (Accident accident in temp)
        //    {
        //        AccidentDTO accidentDTO = new AccidentDTO();
        //        accidentDTO.id = accident.id;
        //        accidentDTO.RigId = accident.RigId;
        //        accidentDTO.TimeOfEvent = accident.TimeOfEvent;
        //        accidentDTO.DateOfEvent = accident.DateOfEvent;
        //        accidentDTO.TypeOfInjuryID = accident.TypeOfInjuryID;
        //        accidentDTO.ViolationCategoryId = accident.ViolationCategoryId;
        //        accidentDTO.AccidentCausesId = accident.AccidentCausesId;
        //        accidentDTO.PreventionCategoryId = accident.PreventionCategoryId;
        //        accidentDTO.ClassificationOfAccidentId = accident.ClassificationOfAccidentId;
        //        accidentDTO.AccidentLocation = accident.AccidentLocation;
        //        accidentDTO.QHSEPositionNameId = accident.QHSEPositionNameId;
        //        accidentDTO.ToolPusherPositionNameId = accident.ToolPusherPositionNameId;
        //        accidentDTO.ToolPusherPositionId = accident.ToolPusherPositionId;
        //        accidentDTO.QHSEPositionId = accident.QHSEPositionId;
        //        accidentDTO.DrillerName = accident.DrillerName;
        //        accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
        //        accidentDTO.ImmediateActionType = accident.ImmediateActionType;
        //        accidentDTO.DirectCauses = accident.DirectCauses;
        //        accidentDTO.RootCauses = accident.RootCauses;
        //        accidentDTO.userID = accident.userID;
        //        accidentDTO.Recommendations = accident.Recommendations;
        //        accidentDTO.Pictures = accident.Pictures;

        //        newTemp.Add(accidentDTO);
        //        //result.Data = prod;
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

        [HttpGet("{ID:int}")]
        public ActionResult<ResultDTO> GetByID(int ID,string UserId,string UserRole)
        {
            ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					Accident accident = accidentRepo.getall().FirstOrDefault(a => a.Id == ID);
					AccidentDTO accidentDTO = new AccidentDTO();
					accidentDTO.id = accident.Id;
					accidentDTO.RigId = accident.RigId;
					accidentDTO.TimeOfEvent = accident.TimeOfEvent;
					accidentDTO.DateOfEvent = accident.DateOfEvent;
					accidentDTO.TypeOfInjuryID = accident.TypeOfInjuryID;
					accidentDTO.ViolationCategoryId = accident.ViolationCategoryId;
					accidentDTO.AccidentCausesId = accident.AccidentCausesId;
					accidentDTO.PreventionCategoryId = accident.PreventionCategoryId;
					accidentDTO.ClassificationOfAccidentId = accident.ClassificationOfAccidentId;
					accidentDTO.AccidentLocation = accident.AccidentLocation;
					accidentDTO.QHSEPositionNameId = accident.QHSEPositionNameId;
					accidentDTO.PusherEmpCode = accident.PusherEmpCode;
					accidentDTO.QHSEEmpCode = accident.QHSEEmpCode;
					accidentDTO.ToolPusherPositionNameId = accident.ToolPusherPositionNameId;
					accidentDTO.ToolPusherPositionId = accident.ToolPusherPositionId;
					accidentDTO.QHSEPositionId = accident.QHSEPositionId;
					accidentDTO.DrillerName = accident.DrillerName;
					accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
					accidentDTO.ImmediateActionType = accident.ImmediateActionType;
					accidentDTO.DirectCauses = accident.DirectCauses;
					accidentDTO.RootCauses = accident.RootCauses;
					accidentDTO.userID = accident.userID;
					accidentDTO.Recommendations = accident.Recommendations;
					accidentDTO.Pictures = accident.Pictures;

					result.Message = "Success";
					result.Data = accidentDTO;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					Accident accident = accidentRepo.getall().FirstOrDefault(a => a.Id == ID && a.userID == UserId);
					AccidentDTO accidentDTO = new AccidentDTO();
					accidentDTO.id = accident.Id;
					accidentDTO.RigId = accident.RigId;
					accidentDTO.TimeOfEvent = accident.TimeOfEvent;
					accidentDTO.DateOfEvent = accident.DateOfEvent;
					accidentDTO.TypeOfInjuryID = accident.TypeOfInjuryID;
					accidentDTO.ViolationCategoryId = accident.ViolationCategoryId;
					accidentDTO.AccidentCausesId = accident.AccidentCausesId;
					accidentDTO.PreventionCategoryId = accident.PreventionCategoryId;
					accidentDTO.ClassificationOfAccidentId = accident.ClassificationOfAccidentId;
					accidentDTO.AccidentLocation = accident.AccidentLocation;
					accidentDTO.QHSEPositionNameId = accident.QHSEPositionNameId;
					accidentDTO.PusherEmpCode = accident.PusherEmpCode;
					accidentDTO.QHSEEmpCode = accident.QHSEEmpCode;
					accidentDTO.ToolPusherPositionNameId = accident.ToolPusherPositionNameId;
					accidentDTO.ToolPusherPositionId = accident.ToolPusherPositionId;
					accidentDTO.QHSEPositionId = accident.QHSEPositionId;
					accidentDTO.DrillerName = accident.DrillerName;
					accidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
					accidentDTO.ImmediateActionType = accident.ImmediateActionType;
					accidentDTO.DirectCauses = accident.DirectCauses;
					accidentDTO.RootCauses = accident.RootCauses;
					accidentDTO.userID = accident.userID;
					accidentDTO.Recommendations = accident.Recommendations;
					accidentDTO.Pictures = accident.Pictures;

					result.Message = "Success";
					result.Data = accidentDTO;
					result.Statescode = 200;
					return result;
				}

			}
			catch (Exception Ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;
		}

        [HttpPost]
        public ActionResult<ResultDTO> AddAccident([FromForm] AccidentDTO accident)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Accident acci = new Accident();
                    acci.Id = default;
                    acci.RigId = accident.RigId;
                    acci.TimeOfEvent = accident.TimeOfEvent;
                    acci.DateOfEvent = accident.DateOfEvent;
                    acci.TypeOfInjuryID = accident.TypeOfInjuryID;
                    acci.ViolationCategoryId = accident.ViolationCategoryId;
                    acci.AccidentCausesId = accident.AccidentCausesId;
                    acci.PreventionCategoryId = accident.PreventionCategoryId;
                    acci.ClassificationOfAccidentId = accident.ClassificationOfAccidentId;
                    acci.AccidentLocation = accident.AccidentLocation;
                    acci.QHSEPositionNameId = accident.QHSEPositionNameId;
					acci.PusherEmpCode = accident.PusherEmpCode;
					acci.QHSEEmpCode = accident.QHSEEmpCode;
					acci.ToolPusherPositionNameId = accident.ToolPusherPositionNameId;
                    acci.ToolPusherPositionId = accident.ToolPusherPositionId;
                    acci.QHSEPositionId = accident.QHSEPositionId;
                    acci.DrillerName = accident.DrillerName;
                    acci.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
                    acci.ImmediateActionType = accident.ImmediateActionType;
                    acci.DirectCauses = accident.DirectCauses;
                    acci.RootCauses = accident.RootCauses;
                    acci.userID = accident.userID;

                    acci.Recommendations = accident.Recommendations;
                    acci.Pictures = ImagesHelper.uploadImg(accident.ImageOfaccident, "acciIMG");


                    accidentRepo.create(acci);
                    result.Message = "Success";
                    result.Data = acci;
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

        //[HttpGet("{date:DateTime}")]
        //public ActionResult<ResultDTO> GetByDate(DateTime date)
        //{
        //    ResultDTO result = new ResultDTO();
        //    try
        //    {
        //        List<AccidentDTO> accidentDTOs = new List<AccidentDTO>();
        //        List<Accident> accidents = accidentRepo.getall().Where(a => a.DateOfEvent == date).ToList();
        //        foreach (Accident accident in accidents)
        //        {
        //            AccidentDTO AccidentDTO = new AccidentDTO();
        //            AccidentDTO.id = accident.id;
        //            AccidentDTO.RigId = accident.RigId;
        //            AccidentDTO.TimeOfEvent = accident.TimeOfEvent;
        //            AccidentDTO.DateOfEvent = accident.DateOfEvent;
        //            AccidentDTO.TypeOfInjuryID = accident.TypeOfInjuryID;
        //            AccidentDTO.ViolationCategoryId = accident.ViolationCategoryId;
        //            AccidentDTO.AccidentCausesId = accident.AccidentCausesId;
        //            AccidentDTO.PreventionCategoryId = accident.PreventionCategoryId;
        //            AccidentDTO.ClassificationOfAccidentId = accident.ClassificationOfAccidentId;
        //            AccidentDTO.AccidentLocation = accident.AccidentLocation;
        //            AccidentDTO.QHSEPositionNameId = accident.QHSEPositionNameId;
        //            AccidentDTO.ToolPusherPositionNameId = accident.ToolPusherPositionNameId;
        //            AccidentDTO.ToolPusherPositionId = accident.ToolPusherPositionId;
        //            AccidentDTO.QHSEPositionId = accident.QHSEPositionId;
        //            AccidentDTO.DrillerName = accident.DrillerName;
        //            AccidentDTO.DescriptionOfTheEvent = accident.DescriptionOfTheEvent;
        //            AccidentDTO.ImmediateActionType = accident.ImmediateActionType;
        //            AccidentDTO.DirectCauses = accident.DirectCauses;
        //            AccidentDTO.RootCauses = accident.RootCauses;
        //            AccidentDTO.userID = accident.userID;
        //            AccidentDTO.Recommendations = accident.Recommendations;
        //            AccidentDTO.Pictures = accident.Pictures;
        //            accidentDTOs.Add(AccidentDTO);

        //        }
        //        result.Data = accidentDTOs;
        //        result.Statescode = 200;
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = "Erroe Not Find";
        //        result.Statescode = 404;
        //        return result;
        //    }
        //}

        [HttpPut("{id:int}")]
        public ActionResult<ResultDTO> Put(int id, [FromForm] AccidentDTO newAccident) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Accident orgAccd = accidentRepo.getbyid(id);
                    newAccident.id = orgAccd.Id;
                    orgAccd.RigId = newAccident.RigId;
                    orgAccd.TimeOfEvent = newAccident.TimeOfEvent;
                    orgAccd.DateOfEvent = newAccident.DateOfEvent;
                    orgAccd.TypeOfInjuryID = newAccident.TypeOfInjuryID;
                    orgAccd.ViolationCategoryId = newAccident.ViolationCategoryId;
                    orgAccd.AccidentCausesId = newAccident.AccidentCausesId;
                    orgAccd.PreventionCategoryId = newAccident.PreventionCategoryId;
                    orgAccd.ClassificationOfAccidentId = newAccident.ClassificationOfAccidentId;
                    orgAccd.AccidentLocation = newAccident.AccidentLocation;
                    orgAccd.QHSEPositionNameId = newAccident.QHSEPositionNameId;
                    orgAccd.ToolPusherPositionNameId = newAccident.ToolPusherPositionNameId;
                    orgAccd.ToolPusherPositionId = newAccident.ToolPusherPositionId;
                    orgAccd.QHSEPositionId = newAccident.QHSEPositionId;
					orgAccd.PusherEmpCode = newAccident.PusherEmpCode;
					orgAccd.QHSEEmpCode = newAccident.QHSEEmpCode;
					orgAccd.DrillerName = newAccident.DrillerName;
                    orgAccd.DescriptionOfTheEvent = newAccident.DescriptionOfTheEvent;
                    orgAccd.ImmediateActionType = newAccident.ImmediateActionType;
                    orgAccd.DirectCauses = newAccident.DirectCauses;
                    orgAccd.RootCauses = newAccident.RootCauses;
                    //orgAccd.userID = newAccident.userID;

                    orgAccd.Recommendations = newAccident.Recommendations;
                    orgAccd.Pictures = orgAccd.Pictures;// ImagesHelper.uploadImg(newAccident.ImageOfaccident, "acciIMG");


                    accidentRepo.update(orgAccd);
                    result.Data = orgAccd;
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

        [HttpPut("Delete/{id:int}")]
        public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                Accident accident = accidentRepo.getbyid(id);
                accident.IsDeleted = true;
                accidentRepo.update(accident);
                result.Data = accident;
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
