using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.IdentityModel.Tokens;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RigMovePerformanceController : ControllerBase
	{
		public IRepository<RigMovePerformance> RigMoveRepo { get; set; }
        public IRepository<ProblemFacedDuringRigMove> ProblemFacedDuringRigMoveRepo { get; set; }
        public IRigMovePerformanceRepository RigMovePerformanceRepo { get; set; }
        public RigMovePerformanceController(IRepository<RigMovePerformance> _RigMoveRepo,
			IRigMovePerformanceRepository _RigMovePerformanceRepo, IRepository<ProblemFacedDuringRigMove>  _ProblemFacedDuringRigMoveRepo)
		{
			this.RigMoveRepo = _RigMoveRepo;
			this.RigMovePerformanceRepo = _RigMovePerformanceRepo;
			this.ProblemFacedDuringRigMoveRepo = _ProblemFacedDuringRigMoveRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll(string UserID,string UserRole)
		{

			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<RigMovePerformance> temp = RigMoveRepo.getall();


					List<RigMovePerformanceDTO> newTemp = new List<RigMovePerformanceDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigMovePerformanceDTO RigMovePerformanceDTO = new RigMovePerformanceDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserId = RigMovePerformance.UserId;
						RigMovePerformanceDTO.RigId = RigMovePerformance.RigId;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;

						newTemp.Add(RigMovePerformanceDTO);
					}
					if (temp != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = temp;

						return result;
					}
				}
				else if(string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<RigMovePerformance> temp = RigMoveRepo.getall().Where(e=>e.UserId==UserID).ToList();


					List<RigMovePerformanceDTO> newTemp = new List<RigMovePerformanceDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigMovePerformanceDTO RigMovePerformanceDTO = new RigMovePerformanceDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserId = RigMovePerformance.UserId;
						RigMovePerformanceDTO.RigId = RigMovePerformance.RigId;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;

						newTemp.Add(RigMovePerformanceDTO);
					}
					if (temp != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = temp;

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

        [HttpGet("GetAllWithResponseDTO")]
        public ActionResult<ResultDTO> GetAllWithResponseDTO(string UserID, string UserRole)
        {

            ResultDTO result = new ResultDTO();

			try
			{
				if(string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{

					List<RigMovePerformance> temp = RigMovePerformanceRepo.getall();


					List<RigPerformanceResponseDTO> newTemp = new List<RigPerformanceResponseDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigPerformanceResponseDTO RigMovePerformanceDTO = new RigPerformanceResponseDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
						RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						foreach (ProblemFacedDuringRigMove item in RigMovePerformance.problemFacedDuringRigMoves)
						{
							ProblemFacedDuringRigMoveDTO problemFacedDuringRigMove = new ProblemFacedDuringRigMoveDTO();
							problemFacedDuringRigMove.Id = item.Id;
							problemFacedDuringRigMove.TimeLostProblem = item.TimeLostProblem;
							problemFacedDuringRigMove.RecommendationProblemRepeated = item.RecommendationProblemRepeated;
							problemFacedDuringRigMove.ProblemDescription = item.ProblemDescription;
							//problemFacedDuringRigMove.RigMovePerformanceId = item.RigMovePerformanceId;
							problemFacedDuringRigMove.IsDeleted = item.IsDeleted;
							problemFacedDuringRigMove.Item = item.Item;
							RigMovePerformanceDTO.ProblemFacedDuringRigMoveDTOs.Add(problemFacedDuringRigMove);
						}

						//RigMovePerformanceDTO.ProblemFacedDuringRigMoves = RigMovePerformance.problemFacedDuringRigMoves;

						newTemp.Add(RigMovePerformanceDTO);
					}
					
					if (newTemp != null)
					{

						result.Message = "Success";
						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}

				}
				else if(string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{

					List<RigMovePerformance> temp = RigMovePerformanceRepo.getall().Where(a=>a.user.Id==UserID).ToList();


					List<RigPerformanceResponseDTO> newTemp = new List<RigPerformanceResponseDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigPerformanceResponseDTO RigMovePerformanceDTO = new RigPerformanceResponseDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
						RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						foreach (ProblemFacedDuringRigMove item in RigMovePerformance.problemFacedDuringRigMoves)
						{
							ProblemFacedDuringRigMoveDTO problemFacedDuringRigMove = new ProblemFacedDuringRigMoveDTO();
							problemFacedDuringRigMove.Id = item.Id;
							problemFacedDuringRigMove.TimeLostProblem = item.TimeLostProblem;
							problemFacedDuringRigMove.RecommendationProblemRepeated = item.RecommendationProblemRepeated;
							problemFacedDuringRigMove.ProblemDescription = item.ProblemDescription;
							//problemFacedDuringRigMove.RigMovePerformanceId = item.RigMovePerformanceId;
							problemFacedDuringRigMove.IsDeleted = item.IsDeleted;
							problemFacedDuringRigMove.Item = item.Item;
							RigMovePerformanceDTO.ProblemFacedDuringRigMoveDTOs.Add(problemFacedDuringRigMove);
						}

						//RigMovePerformanceDTO.ProblemFacedDuringRigMoves = RigMovePerformance.problemFacedDuringRigMoves;

						newTemp.Add(RigMovePerformanceDTO);
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

		[HttpGet("GetAllForAnalysis/{RigID:int}")]
		public ActionResult<ResultDTO> GetAllForAnalysis(int RigID, string UserID, string UserRole)
		{

			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{

					List<RigMovePerformance> temp = RigMovePerformanceRepo.getall().Where(r => r.RigId == RigID).ToList();


					List<RigPerformanceResponseDTO> newTemp = new List<RigPerformanceResponseDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigPerformanceResponseDTO RigMovePerformanceDTO = new RigPerformanceResponseDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
						RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						newTemp.Add(RigMovePerformanceDTO);
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

					List<RigMovePerformance> temp = RigMovePerformanceRepo.getall().Where(r => r.RigId== RigID && r.user.Id==UserID).ToList();


					List<RigPerformanceResponseDTO> newTemp = new List<RigPerformanceResponseDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigPerformanceResponseDTO RigMovePerformanceDTO = new RigPerformanceResponseDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
						RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						newTemp.Add(RigMovePerformanceDTO);
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

		[HttpGet("GetAllForCompareAnalysis")]
		public ActionResult<ResultDTO> GetAllForCompareAnalysis([FromQuery] int RigID1, [FromQuery] int RigID2, [FromQuery] int Year, string UserID, string UserRole)
		{

			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<RigMovePerformance> temp = RigMoveRepo.getall().Where(r => (r.RigId == RigID1 || r.RigId == RigID2) && (r.AcceptanceDate.Year == Year || r.ReleaseDate.Year == Year)).ToList();


					List<RigMovePerformanceDTO> newTemp = new List<RigMovePerformanceDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigMovePerformanceDTO RigMovePerformanceDTO = new RigMovePerformanceDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserId = RigMovePerformance.UserId;
						RigMovePerformanceDTO.RigId = RigMovePerformance.RigId;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						newTemp.Add(RigMovePerformanceDTO);
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
					List<RigMovePerformance> temp = RigMoveRepo.getall().Where(r => ((r.RigId == RigID1 || r.RigId == RigID2) && (r.AcceptanceDate.Year == Year || r.ReleaseDate.Year == Year))&&(r.UserId==UserID)).ToList();


					List<RigMovePerformanceDTO> newTemp = new List<RigMovePerformanceDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigMovePerformanceDTO RigMovePerformanceDTO = new RigMovePerformanceDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserId = RigMovePerformance.UserId;
						RigMovePerformanceDTO.RigId = RigMovePerformance.RigId;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						newTemp.Add(RigMovePerformanceDTO);
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

		//[HttpGet("GetAllByTargetForAnalysis/{target:alpha}")]
		//public ActionResult<ResultDTO> GetAllByTargetForAnalysis(string target)
		//{

		//	ResultDTO result = new ResultDTO();

		//	List<RigMovePerformance> temp = RigMovePerformanceRepo.getall().Where(r => r.TargetArchived == target).ToList();


		//	List<RigPerformanceResponseDTO> newTemp = new List<RigPerformanceResponseDTO>();
		//	foreach (RigMovePerformance RigMovePerformance in temp)
		//	{
		//		RigPerformanceResponseDTO RigMovePerformanceDTO = new RigPerformanceResponseDTO();
		//		RigMovePerformanceDTO.Id = RigMovePerformance.Id;
		//		RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
		//		RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
		//		RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
		//		RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
		//		RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
		//		RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
		//		RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
		//		RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
		//		RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
		//		RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
		//		RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
		//		RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
		//		RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
		//		RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
		//		RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
		//		newTemp.Add(RigMovePerformanceDTO);
		//	}
		//	if (newTemp != null)
		//	{

		//		result.Message = "Success";
		//		result.Statescode = 200;
		//		result.Data = newTemp;

		//		return result;
		//	}

		//	result.Statescode = 404;
		//	result.Message = "data not found";
		//	return result;
		//}

		[HttpGet("GetAllWithExcelDTO")]
		public ActionResult<ResultDTO> GetAllWithExcelDTO(string UserID, string UserRole)
		{

			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
				List<RigMovePerformance> temp = RigMovePerformanceRepo.getall();
				List<RigPerformanceExcelDTO> newTemp = new List<RigPerformanceExcelDTO>();
			foreach (RigMovePerformance RigMovePerformance in temp)
			{
				RigPerformanceExcelDTO RigMovePerformanceDTO = new RigPerformanceExcelDTO();
				RigMovePerformanceDTO.Id = RigMovePerformance.Id;
				RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
				RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
				RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
				RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
				RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
				RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
				RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
				RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
				RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
				RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
				RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
				RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
				RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
				RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
				RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
                if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 5)
                {
                    RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;
                    RigMovePerformanceDTO.Item2 = RigMovePerformance.problemFacedDuringRigMoves[1].Item;
                    RigMovePerformanceDTO.Item3 = RigMovePerformance.problemFacedDuringRigMoves[2].Item;
                    RigMovePerformanceDTO.Item4 = RigMovePerformance.problemFacedDuringRigMoves[3].Item;
                    RigMovePerformanceDTO.Item5 = RigMovePerformance.problemFacedDuringRigMoves[4].Item;

                    RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;
                    RigMovePerformanceDTO.ProblemDescription2 = RigMovePerformance.problemFacedDuringRigMoves[1].ProblemDescription;
                    RigMovePerformanceDTO.ProblemDescription3 = RigMovePerformance.problemFacedDuringRigMoves[2].ProblemDescription;
                    RigMovePerformanceDTO.ProblemDescription4 = RigMovePerformance.problemFacedDuringRigMoves[3].ProblemDescription;
                    RigMovePerformanceDTO.ProblemDescription5 = RigMovePerformance.problemFacedDuringRigMoves[4].ProblemDescription;

					RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem2 = RigMovePerformance.problemFacedDuringRigMoves[1].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem3 = RigMovePerformance.problemFacedDuringRigMoves[2].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem4 = RigMovePerformance.problemFacedDuringRigMoves[3].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem5 = RigMovePerformance.problemFacedDuringRigMoves[4].TimeLostProblem;
					
                    RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated2 = RigMovePerformance.problemFacedDuringRigMoves[1].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated3 = RigMovePerformance.problemFacedDuringRigMoves[2].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated4 = RigMovePerformance.problemFacedDuringRigMoves[3].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated5 = RigMovePerformance.problemFacedDuringRigMoves[4].RecommendationProblemRepeated;
				}
				else if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 4)
				{
					RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;
					RigMovePerformanceDTO.Item2 = RigMovePerformance.problemFacedDuringRigMoves[1].Item;
					RigMovePerformanceDTO.Item3 = RigMovePerformance.problemFacedDuringRigMoves[2].Item;
					RigMovePerformanceDTO.Item4 = RigMovePerformance.problemFacedDuringRigMoves[3].Item;

					RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;
					RigMovePerformanceDTO.ProblemDescription2 = RigMovePerformance.problemFacedDuringRigMoves[1].ProblemDescription;
					RigMovePerformanceDTO.ProblemDescription3 = RigMovePerformance.problemFacedDuringRigMoves[2].ProblemDescription;
					RigMovePerformanceDTO.ProblemDescription4 = RigMovePerformance.problemFacedDuringRigMoves[3].ProblemDescription;

					RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem2 = RigMovePerformance.problemFacedDuringRigMoves[1].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem3 = RigMovePerformance.problemFacedDuringRigMoves[2].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem4 = RigMovePerformance.problemFacedDuringRigMoves[3].TimeLostProblem;

					RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated2 = RigMovePerformance.problemFacedDuringRigMoves[1].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated3 = RigMovePerformance.problemFacedDuringRigMoves[2].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated4 = RigMovePerformance.problemFacedDuringRigMoves[3].RecommendationProblemRepeated;
				}
				else if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 3)
				{
					RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;
					RigMovePerformanceDTO.Item2 = RigMovePerformance.problemFacedDuringRigMoves[1].Item;
					RigMovePerformanceDTO.Item3 = RigMovePerformance.problemFacedDuringRigMoves[2].Item;

					RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;
					RigMovePerformanceDTO.ProblemDescription2 = RigMovePerformance.problemFacedDuringRigMoves[1].ProblemDescription;
					RigMovePerformanceDTO.ProblemDescription3 = RigMovePerformance.problemFacedDuringRigMoves[2].ProblemDescription;

					RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem2 = RigMovePerformance.problemFacedDuringRigMoves[1].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem3 = RigMovePerformance.problemFacedDuringRigMoves[2].TimeLostProblem;

					RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated2 = RigMovePerformance.problemFacedDuringRigMoves[1].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated3 = RigMovePerformance.problemFacedDuringRigMoves[2].RecommendationProblemRepeated;
				}
				else if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 2)
				{
					RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;
					RigMovePerformanceDTO.Item2 = RigMovePerformance.problemFacedDuringRigMoves[1].Item;

					RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;
					RigMovePerformanceDTO.ProblemDescription2 = RigMovePerformance.problemFacedDuringRigMoves[1].ProblemDescription;

					RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;
					RigMovePerformanceDTO.TimeLostProblem2 = RigMovePerformance.problemFacedDuringRigMoves[1].TimeLostProblem;

					RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
					RigMovePerformanceDTO.RecommendationProblemRepeated2 = RigMovePerformance.problemFacedDuringRigMoves[1].RecommendationProblemRepeated;
				}
				else if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 1)
				{
					RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;

					RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;

					RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;

					RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
				}


				newTemp.Add(RigMovePerformanceDTO);
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
					List<RigMovePerformance> temp = RigMovePerformanceRepo.getall().Where(a=>a.user.Id==UserID).ToList();


					List<RigPerformanceExcelDTO> newTemp = new List<RigPerformanceExcelDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigPerformanceExcelDTO RigMovePerformanceDTO = new RigPerformanceExcelDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
						RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 5)
						{
							RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;
							RigMovePerformanceDTO.Item2 = RigMovePerformance.problemFacedDuringRigMoves[1].Item;
							RigMovePerformanceDTO.Item3 = RigMovePerformance.problemFacedDuringRigMoves[2].Item;
							RigMovePerformanceDTO.Item4 = RigMovePerformance.problemFacedDuringRigMoves[3].Item;
							RigMovePerformanceDTO.Item5 = RigMovePerformance.problemFacedDuringRigMoves[4].Item;

							RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription2 = RigMovePerformance.problemFacedDuringRigMoves[1].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription3 = RigMovePerformance.problemFacedDuringRigMoves[2].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription4 = RigMovePerformance.problemFacedDuringRigMoves[3].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription5 = RigMovePerformance.problemFacedDuringRigMoves[4].ProblemDescription;

							RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem2 = RigMovePerformance.problemFacedDuringRigMoves[1].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem3 = RigMovePerformance.problemFacedDuringRigMoves[2].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem4 = RigMovePerformance.problemFacedDuringRigMoves[3].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem5 = RigMovePerformance.problemFacedDuringRigMoves[4].TimeLostProblem;

							RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated2 = RigMovePerformance.problemFacedDuringRigMoves[1].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated3 = RigMovePerformance.problemFacedDuringRigMoves[2].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated4 = RigMovePerformance.problemFacedDuringRigMoves[3].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated5 = RigMovePerformance.problemFacedDuringRigMoves[4].RecommendationProblemRepeated;
						}
						else if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 4)
						{
							RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;
							RigMovePerformanceDTO.Item2 = RigMovePerformance.problemFacedDuringRigMoves[1].Item;
							RigMovePerformanceDTO.Item3 = RigMovePerformance.problemFacedDuringRigMoves[2].Item;
							RigMovePerformanceDTO.Item4 = RigMovePerformance.problemFacedDuringRigMoves[3].Item;

							RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription2 = RigMovePerformance.problemFacedDuringRigMoves[1].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription3 = RigMovePerformance.problemFacedDuringRigMoves[2].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription4 = RigMovePerformance.problemFacedDuringRigMoves[3].ProblemDescription;

							RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem2 = RigMovePerformance.problemFacedDuringRigMoves[1].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem3 = RigMovePerformance.problemFacedDuringRigMoves[2].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem4 = RigMovePerformance.problemFacedDuringRigMoves[3].TimeLostProblem;

							RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated2 = RigMovePerformance.problemFacedDuringRigMoves[1].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated3 = RigMovePerformance.problemFacedDuringRigMoves[2].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated4 = RigMovePerformance.problemFacedDuringRigMoves[3].RecommendationProblemRepeated;
						}
						else if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 3)
						{
							RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;
							RigMovePerformanceDTO.Item2 = RigMovePerformance.problemFacedDuringRigMoves[1].Item;
							RigMovePerformanceDTO.Item3 = RigMovePerformance.problemFacedDuringRigMoves[2].Item;

							RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription2 = RigMovePerformance.problemFacedDuringRigMoves[1].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription3 = RigMovePerformance.problemFacedDuringRigMoves[2].ProblemDescription;

							RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem2 = RigMovePerformance.problemFacedDuringRigMoves[1].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem3 = RigMovePerformance.problemFacedDuringRigMoves[2].TimeLostProblem;

							RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated2 = RigMovePerformance.problemFacedDuringRigMoves[1].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated3 = RigMovePerformance.problemFacedDuringRigMoves[2].RecommendationProblemRepeated;
						}
						else if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 2)
						{
							RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;
							RigMovePerformanceDTO.Item2 = RigMovePerformance.problemFacedDuringRigMoves[1].Item;

							RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;
							RigMovePerformanceDTO.ProblemDescription2 = RigMovePerformance.problemFacedDuringRigMoves[1].ProblemDescription;

							RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;
							RigMovePerformanceDTO.TimeLostProblem2 = RigMovePerformance.problemFacedDuringRigMoves[1].TimeLostProblem;

							RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
							RigMovePerformanceDTO.RecommendationProblemRepeated2 = RigMovePerformance.problemFacedDuringRigMoves[1].RecommendationProblemRepeated;
						}
						else if (RigMovePerformance.problemFacedDuringRigMoves.Count() == 1)
						{
							RigMovePerformanceDTO.Item1 = RigMovePerformance.problemFacedDuringRigMoves[0].Item;

							RigMovePerformanceDTO.ProblemDescription1 = RigMovePerformance.problemFacedDuringRigMoves[0].ProblemDescription;

							RigMovePerformanceDTO.TimeLostProblem1 = RigMovePerformance.problemFacedDuringRigMoves[0].TimeLostProblem;

							RigMovePerformanceDTO.RecommendationProblemRepeated1 = RigMovePerformance.problemFacedDuringRigMoves[0].RecommendationProblemRepeated;
						}


						newTemp.Add(RigMovePerformanceDTO);
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

		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					RigMovePerformanceDTO RigMovePerformanceDTO = new RigMovePerformanceDTO();
					List<ProblemFacedDuringRigMove> problemFacedDuringRigMove = ProblemFacedDuringRigMoveRepo.getall().Where(p => p.RigMovePerformanceId == ID).ToList();
					RigMovePerformance RigMovePerformance = RigMoveRepo.getbyid(ID);
					RigMovePerformanceDTO.Id = RigMovePerformance.Id;
					RigMovePerformanceDTO.RigId = RigMovePerformance.RigId;
					RigMovePerformanceDTO.UserId = RigMovePerformance.UserId;
					RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
					RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
					RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
					RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
					RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
					RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
					RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
					RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
					RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
					RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
					RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
					RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
					RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
					RigMovePerformanceDTO.IsDeleted = RigMovePerformance.IsDeleted;
					if (problemFacedDuringRigMove.Count == 1)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

					}
					else if (problemFacedDuringRigMove.Count == 2)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

						RigMovePerformanceDTO.Item2 = problemFacedDuringRigMove[1].Item;
						RigMovePerformanceDTO.ProblemDescription2 = problemFacedDuringRigMove[1].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated2 = problemFacedDuringRigMove[1].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem2 = problemFacedDuringRigMove[1].TimeLostProblem;
					}

					else if (problemFacedDuringRigMove.Count == 3)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

						RigMovePerformanceDTO.Item2 = problemFacedDuringRigMove[1].Item;
						RigMovePerformanceDTO.ProblemDescription2 = problemFacedDuringRigMove[1].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated2 = problemFacedDuringRigMove[1].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem2 = problemFacedDuringRigMove[1].TimeLostProblem;

						RigMovePerformanceDTO.Item3 = problemFacedDuringRigMove[2].Item;
						RigMovePerformanceDTO.ProblemDescription3 = problemFacedDuringRigMove[2].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated3 = problemFacedDuringRigMove[2].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem3 = problemFacedDuringRigMove[2].TimeLostProblem;
					}

					else if (problemFacedDuringRigMove.Count == 4)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

						RigMovePerformanceDTO.Item2 = problemFacedDuringRigMove[1].Item;
						RigMovePerformanceDTO.ProblemDescription2 = problemFacedDuringRigMove[1].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated2 = problemFacedDuringRigMove[1].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem2 = problemFacedDuringRigMove[1].TimeLostProblem;

						RigMovePerformanceDTO.Item3 = problemFacedDuringRigMove[2].Item;
						RigMovePerformanceDTO.ProblemDescription3 = problemFacedDuringRigMove[2].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated3 = problemFacedDuringRigMove[2].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem3 = problemFacedDuringRigMove[2].TimeLostProblem;

						RigMovePerformanceDTO.Item4 = problemFacedDuringRigMove[3].Item;
						RigMovePerformanceDTO.ProblemDescription4 = problemFacedDuringRigMove[3].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated4 = problemFacedDuringRigMove[3].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem4 = problemFacedDuringRigMove[3].TimeLostProblem;
					}
					else if (problemFacedDuringRigMove.Count == 5)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

						RigMovePerformanceDTO.Item2 = problemFacedDuringRigMove[1].Item;
						RigMovePerformanceDTO.ProblemDescription2 = problemFacedDuringRigMove[1].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated2 = problemFacedDuringRigMove[1].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem2 = problemFacedDuringRigMove[1].TimeLostProblem;

						RigMovePerformanceDTO.Item3 = problemFacedDuringRigMove[2].Item;
						RigMovePerformanceDTO.ProblemDescription3 = problemFacedDuringRigMove[2].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated3 = problemFacedDuringRigMove[2].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem3 = problemFacedDuringRigMove[2].TimeLostProblem;

						RigMovePerformanceDTO.Item4 = problemFacedDuringRigMove[3].Item;
						RigMovePerformanceDTO.ProblemDescription4 = problemFacedDuringRigMove[3].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated4 = problemFacedDuringRigMove[3].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem4 = problemFacedDuringRigMove[3].TimeLostProblem;

						RigMovePerformanceDTO.Item5 = problemFacedDuringRigMove[4].Item;
						RigMovePerformanceDTO.ProblemDescription5 = problemFacedDuringRigMove[4].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated5 = problemFacedDuringRigMove[4].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem5 = problemFacedDuringRigMove[4].TimeLostProblem;
					}
					result.Message = "Success";
					result.Data = RigMovePerformanceDTO;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					RigMovePerformanceDTO RigMovePerformanceDTO = new RigMovePerformanceDTO();
					List<ProblemFacedDuringRigMove> problemFacedDuringRigMove = ProblemFacedDuringRigMoveRepo.getall().Where(p => p.RigMovePerformanceId == ID).ToList();
					RigMovePerformance RigMovePerformance = RigMoveRepo.getall().FirstOrDefault(e=>e.UserId==UserID&&e.Id==ID);
					RigMovePerformanceDTO.Id = RigMovePerformance.Id;
					RigMovePerformanceDTO.RigId = RigMovePerformance.RigId;
					RigMovePerformanceDTO.UserId = RigMovePerformance.UserId;
					RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
					RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
					RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
					RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
					RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
					RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
					RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
					RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
					RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
					RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
					RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
					RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
					RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
					RigMovePerformanceDTO.IsDeleted = RigMovePerformance.IsDeleted;
					if (problemFacedDuringRigMove.Count == 1)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

					}
					else if (problemFacedDuringRigMove.Count == 2)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

						RigMovePerformanceDTO.Item2 = problemFacedDuringRigMove[1].Item;
						RigMovePerformanceDTO.ProblemDescription2 = problemFacedDuringRigMove[1].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated2 = problemFacedDuringRigMove[1].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem2 = problemFacedDuringRigMove[1].TimeLostProblem;
					}

					else if (problemFacedDuringRigMove.Count == 3)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

						RigMovePerformanceDTO.Item2 = problemFacedDuringRigMove[1].Item;
						RigMovePerformanceDTO.ProblemDescription2 = problemFacedDuringRigMove[1].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated2 = problemFacedDuringRigMove[1].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem2 = problemFacedDuringRigMove[1].TimeLostProblem;

						RigMovePerformanceDTO.Item3 = problemFacedDuringRigMove[2].Item;
						RigMovePerformanceDTO.ProblemDescription3 = problemFacedDuringRigMove[2].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated3 = problemFacedDuringRigMove[2].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem3 = problemFacedDuringRigMove[2].TimeLostProblem;
					}

					else if (problemFacedDuringRigMove.Count == 4)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

						RigMovePerformanceDTO.Item2 = problemFacedDuringRigMove[1].Item;
						RigMovePerformanceDTO.ProblemDescription2 = problemFacedDuringRigMove[1].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated2 = problemFacedDuringRigMove[1].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem2 = problemFacedDuringRigMove[1].TimeLostProblem;

						RigMovePerformanceDTO.Item3 = problemFacedDuringRigMove[2].Item;
						RigMovePerformanceDTO.ProblemDescription3 = problemFacedDuringRigMove[2].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated3 = problemFacedDuringRigMove[2].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem3 = problemFacedDuringRigMove[2].TimeLostProblem;

						RigMovePerformanceDTO.Item4 = problemFacedDuringRigMove[3].Item;
						RigMovePerformanceDTO.ProblemDescription4 = problemFacedDuringRigMove[3].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated4 = problemFacedDuringRigMove[3].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem4 = problemFacedDuringRigMove[3].TimeLostProblem;
					}
					else if (problemFacedDuringRigMove.Count == 5)
					{
						RigMovePerformanceDTO.Item1 = problemFacedDuringRigMove[0].Item;
						RigMovePerformanceDTO.ProblemDescription1 = problemFacedDuringRigMove[0].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated1 = problemFacedDuringRigMove[0].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem1 = problemFacedDuringRigMove[0].TimeLostProblem;

						RigMovePerformanceDTO.Item2 = problemFacedDuringRigMove[1].Item;
						RigMovePerformanceDTO.ProblemDescription2 = problemFacedDuringRigMove[1].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated2 = problemFacedDuringRigMove[1].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem2 = problemFacedDuringRigMove[1].TimeLostProblem;

						RigMovePerformanceDTO.Item3 = problemFacedDuringRigMove[2].Item;
						RigMovePerformanceDTO.ProblemDescription3 = problemFacedDuringRigMove[2].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated3 = problemFacedDuringRigMove[2].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem3 = problemFacedDuringRigMove[2].TimeLostProblem;

						RigMovePerformanceDTO.Item4 = problemFacedDuringRigMove[3].Item;
						RigMovePerformanceDTO.ProblemDescription4 = problemFacedDuringRigMove[3].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated4 = problemFacedDuringRigMove[3].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem4 = problemFacedDuringRigMove[3].TimeLostProblem;

						RigMovePerformanceDTO.Item5 = problemFacedDuringRigMove[4].Item;
						RigMovePerformanceDTO.ProblemDescription5 = problemFacedDuringRigMove[4].ProblemDescription;
						RigMovePerformanceDTO.RecommendationProblemRepeated5 = problemFacedDuringRigMove[4].RecommendationProblemRepeated;
						RigMovePerformanceDTO.TimeLostProblem5 = problemFacedDuringRigMove[4].TimeLostProblem;
					}
					result.Message = "Success";
					result.Data = RigMovePerformanceDTO;
					result.Statescode = 200;
					return result;
				}
			}
			catch (Exception ex)
			{
				result.Message = "Error Not Find";
				result.Statescode = 404;	
			}
			return result;
		}



		[HttpPut("{id:int}")]
		public ActionResult<ResultDTO> Put(int id, RigMovePerformanceDTO newRigMovePerformance) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RigMovePerformance orgRigMovePerformance = RigMoveRepo.getbyid(id);
					List<ProblemFacedDuringRigMove> problemFacedDuringRigMove= ProblemFacedDuringRigMoveRepo.getall().Where(p => p.RigMovePerformanceId == id).ToList();
                    newRigMovePerformance.Id = orgRigMovePerformance.Id;
                    orgRigMovePerformance.RigId = newRigMovePerformance.RigId;
                    //orgRigMovePerformance.UserId = newRigMovePerformance.UserId;
                    orgRigMovePerformance.OldWellName = newRigMovePerformance.OldWellName;
                    orgRigMovePerformance.NewWellName = newRigMovePerformance.NewWellName;
                    orgRigMovePerformance.TargetArchived = newRigMovePerformance.TargetArchived;
					orgRigMovePerformance.ActualMoveTime = newRigMovePerformance.ActualMoveTime;
					orgRigMovePerformance.ReleaseTime = newRigMovePerformance.ReleaseTime;
					orgRigMovePerformance.AcceptanceTime = newRigMovePerformance.AcceptanceTime;
					orgRigMovePerformance.AcceptanceDate = newRigMovePerformance.AcceptanceDate;
					orgRigMovePerformance.ReleaseDate = newRigMovePerformance.ReleaseDate;
					orgRigMovePerformance.BudgetTargetTotalDay = newRigMovePerformance.BudgetTargetTotalDay;
                    orgRigMovePerformance.BudgetTargetTotalMoney = newRigMovePerformance.BudgetTargetTotalMoney;
                    orgRigMovePerformance.ActualMoveTime = newRigMovePerformance.ActualMoveTime;
					orgRigMovePerformance.MoveDistance = newRigMovePerformance.MoveDistance;
					orgRigMovePerformance.DieselConsumed = newRigMovePerformance.DieselConsumed;
					orgRigMovePerformance.IsDeleted = newRigMovePerformance.IsDeleted;
                    if (problemFacedDuringRigMove.Count == 1)
                    {
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription1) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated1) && newRigMovePerformance.TimeLostProblem1 == null)
						{
							problemFacedDuringRigMove[0].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						else
						{
							problemFacedDuringRigMove[0].Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove[0].ProblemDescription = newRigMovePerformance.ProblemDescription1;
							problemFacedDuringRigMove[0].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated1;
							problemFacedDuringRigMove[0].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem1;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription2) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated2) )

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item2;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription2;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem2;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated2;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription3)|| !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated3 ))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item3;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription3;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem3;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated3;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription4 )|| !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated4 ))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription4;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem4;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated4;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription5 )|| !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated5 ))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item5;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription5;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem5;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated5;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}

					}
					else if (problemFacedDuringRigMove.Count == 2)
                    {
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription1) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated1) && newRigMovePerformance.TimeLostProblem1 == null)
						{
							problemFacedDuringRigMove[0].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						else
						{
							problemFacedDuringRigMove[0].Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove[0].ProblemDescription = newRigMovePerformance.ProblemDescription1;
							problemFacedDuringRigMove[0].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated1;
							problemFacedDuringRigMove[0].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem1;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription2) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated2) && newRigMovePerformance.TimeLostProblem2 == null)
						{
							problemFacedDuringRigMove[1].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);
						}
						else
						{
							problemFacedDuringRigMove[1].Item = newRigMovePerformance.Item2;
							problemFacedDuringRigMove[1].ProblemDescription = newRigMovePerformance.ProblemDescription2;
							problemFacedDuringRigMove[1].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated2;
							problemFacedDuringRigMove[1].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem2;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);
						}

						//problemFacedDuringRigMove[0].Item = newRigMovePerformance.Item1;
      //                  problemFacedDuringRigMove[0].ProblemDescription = newRigMovePerformance.ProblemDescription1;
      //                  problemFacedDuringRigMove[0].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated1;
      //                  problemFacedDuringRigMove[0].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem1 ;
      //                  ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);

      //                  problemFacedDuringRigMove[1].Item = newRigMovePerformance.Item2;
      //                  problemFacedDuringRigMove[1].ProblemDescription = newRigMovePerformance.ProblemDescription2;
      //                  problemFacedDuringRigMove[1].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated2;
      //                  problemFacedDuringRigMove[1].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem2;
      //                  ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);

						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription3)
						|| !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated3 ))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item3;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription3;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem3;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated3;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription4)
						|| !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated4 ))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription4;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem4;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated4;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription5) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated5))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item5;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription5;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem5;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated5;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
					}

                    else if (problemFacedDuringRigMove.Count == 3)
                    {
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription1) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated1) && newRigMovePerformance.TimeLostProblem1 == null)
						{
							problemFacedDuringRigMove[0].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						else
						{
							problemFacedDuringRigMove[0].Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove[0].ProblemDescription = newRigMovePerformance.ProblemDescription1;
							problemFacedDuringRigMove[0].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated1;
							problemFacedDuringRigMove[0].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem1;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription2) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated2) && newRigMovePerformance.TimeLostProblem2 == null)
						{
							problemFacedDuringRigMove[1].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);
						}
						else
						{
							problemFacedDuringRigMove[1].Item = newRigMovePerformance.Item2;
							problemFacedDuringRigMove[1].ProblemDescription = newRigMovePerformance.ProblemDescription2;
							problemFacedDuringRigMove[1].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated2;
							problemFacedDuringRigMove[1].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem2;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);
						}
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription3) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated3) && newRigMovePerformance.TimeLostProblem3 == null)
						{
							problemFacedDuringRigMove[2].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[2]);
						}
						else
						{
							problemFacedDuringRigMove[2].Item = newRigMovePerformance.Item3;
							problemFacedDuringRigMove[2].ProblemDescription = newRigMovePerformance.ProblemDescription3;
							problemFacedDuringRigMove[2].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated3;
							problemFacedDuringRigMove[2].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem3;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[2]);
						}
					                       

						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription4) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated4))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item4;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription4;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem4;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated4;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription5) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated5))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item5;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription5;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem5;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated5;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
					}

                    else if (problemFacedDuringRigMove.Count == 4)
                    {
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription1) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated1) && newRigMovePerformance.TimeLostProblem1 == null)
						{
							problemFacedDuringRigMove[0].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						else
						{
							problemFacedDuringRigMove[0].Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove[0].ProblemDescription = newRigMovePerformance.ProblemDescription1;
							problemFacedDuringRigMove[0].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated1;
							problemFacedDuringRigMove[0].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem1;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription2) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated2) && newRigMovePerformance.TimeLostProblem2 == null)
						{
							problemFacedDuringRigMove[1].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);
						}
						else
						{
							problemFacedDuringRigMove[1].Item = newRigMovePerformance.Item2;
							problemFacedDuringRigMove[1].ProblemDescription = newRigMovePerformance.ProblemDescription2;
							problemFacedDuringRigMove[1].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated2;
							problemFacedDuringRigMove[1].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem2;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);
						}
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription3) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated3) && newRigMovePerformance.TimeLostProblem3 == null)
						{
							problemFacedDuringRigMove[2].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[2]);
						}
						else
						{
							problemFacedDuringRigMove[2].Item = newRigMovePerformance.Item3;
							problemFacedDuringRigMove[2].ProblemDescription = newRigMovePerformance.ProblemDescription3;
							problemFacedDuringRigMove[2].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated3;
							problemFacedDuringRigMove[2].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem3;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[2]);
						}
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription4) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated4) && newRigMovePerformance.TimeLostProblem4 == null)
						{
							problemFacedDuringRigMove[3].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[3]);
						}
						else
						{
							problemFacedDuringRigMove[3].Item = newRigMovePerformance.Item4;
							problemFacedDuringRigMove[3].ProblemDescription = newRigMovePerformance.ProblemDescription4;
							problemFacedDuringRigMove[3].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated4;
							problemFacedDuringRigMove[3].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem4;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[3]);
						}
						                  

						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription5) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated5))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item5;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription5;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem5;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated5;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
					}
                    else if (problemFacedDuringRigMove.Count == 5)
                    {
						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription1) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated1) && newRigMovePerformance.TimeLostProblem1 == null)
						{
							problemFacedDuringRigMove[0].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}
						else
						{
							problemFacedDuringRigMove[0].Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove[0].ProblemDescription = newRigMovePerformance.ProblemDescription1;
							problemFacedDuringRigMove[0].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated1;
							problemFacedDuringRigMove[0].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem1;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[0]);
						}

						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription2) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated2) && newRigMovePerformance.TimeLostProblem2 == null)
						{
							problemFacedDuringRigMove[1].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);
						}
						else
						{
							problemFacedDuringRigMove[1].Item = newRigMovePerformance.Item2;
							problemFacedDuringRigMove[1].ProblemDescription = newRigMovePerformance.ProblemDescription2;
							problemFacedDuringRigMove[1].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated2;
							problemFacedDuringRigMove[1].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem2;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[1]);
						}

						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription3) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated3) && newRigMovePerformance.TimeLostProblem3 == null)
						{
							problemFacedDuringRigMove[2].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[2]);
						}
						else
						{
							problemFacedDuringRigMove[2].Item = newRigMovePerformance.Item3;
							problemFacedDuringRigMove[2].ProblemDescription = newRigMovePerformance.ProblemDescription3;
							problemFacedDuringRigMove[2].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated3;
							problemFacedDuringRigMove[2].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem3;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[2]);
						}

						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription4) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated4) && newRigMovePerformance.TimeLostProblem4 == null)
						{
							problemFacedDuringRigMove[3].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[3]);
						}
						else
						{
							problemFacedDuringRigMove[3].Item = newRigMovePerformance.Item4;
							problemFacedDuringRigMove[3].ProblemDescription = newRigMovePerformance.ProblemDescription4;
							problemFacedDuringRigMove[3].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated4;
							problemFacedDuringRigMove[3].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem4;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[3]);
						}

						if (string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription5) && string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated5) && newRigMovePerformance.TimeLostProblem5 == null)
						{
							problemFacedDuringRigMove[4].IsDeleted = true;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[4]);
						}
						else
						{
							problemFacedDuringRigMove[4].Item = newRigMovePerformance.Item5;
							problemFacedDuringRigMove[4].ProblemDescription = newRigMovePerformance.ProblemDescription5;
							problemFacedDuringRigMove[4].RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated5;
							problemFacedDuringRigMove[4].TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem5;
							ProblemFacedDuringRigMoveRepo.update(problemFacedDuringRigMove[4]);
						}
						
                    }
					else if(problemFacedDuringRigMove.Count == 0)
					{
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription1) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated1))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription1;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem1;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated1;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}

						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription2) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated2))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item2;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription2;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem2;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated2;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription3) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated3))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item3;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription3;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem3;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated3;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if ( !string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription4) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated4))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item1;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription4;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem4;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated4;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}
						if (!string.IsNullOrEmpty(newRigMovePerformance.ProblemDescription5) || !string.IsNullOrEmpty(newRigMovePerformance.RecommendationProblemRepeated5))

						{
							ProblemFacedDuringRigMove problemFacedDuringRigMove2 = new ProblemFacedDuringRigMove();
							problemFacedDuringRigMove2.RigMovePerformanceId = newRigMovePerformance.Id;
							problemFacedDuringRigMove2.Item = newRigMovePerformance.Item5;
							problemFacedDuringRigMove2.ProblemDescription = newRigMovePerformance.ProblemDescription5;
							problemFacedDuringRigMove2.TimeLostProblem = (double)newRigMovePerformance.TimeLostProblem5;
							problemFacedDuringRigMove2.RecommendationProblemRepeated = newRigMovePerformance.RecommendationProblemRepeated5;
							ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove2);

						}


					}

                    RigMoveRepo.update(orgRigMovePerformance);
					result.Message = "Success";
					result.Data = orgRigMovePerformance;
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

        [HttpGet("ByPage/{page:int}")]
        public PageResult<RigPerformanceResponseDTO> GetAllRigMovePerformanceByPage(string UserID, string UserRole, int? page, int pagesize = 10)
        {

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<RigMovePerformance> temp = RigMovePerformanceRepo.getall();


					List<RigPerformanceResponseDTO> newTemp = new List<RigPerformanceResponseDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigPerformanceResponseDTO RigMovePerformanceDTO = new RigPerformanceResponseDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
						RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						foreach (ProblemFacedDuringRigMove item in RigMovePerformance.problemFacedDuringRigMoves)
						{
							ProblemFacedDuringRigMoveDTO problemFacedDuringRigMove = new ProblemFacedDuringRigMoveDTO();
							problemFacedDuringRigMove.Id = item.Id;
							problemFacedDuringRigMove.TimeLostProblem = item.TimeLostProblem;
							problemFacedDuringRigMove.RecommendationProblemRepeated = item.RecommendationProblemRepeated;
							problemFacedDuringRigMove.ProblemDescription = item.ProblemDescription;

							problemFacedDuringRigMove.IsDeleted = item.IsDeleted;
							problemFacedDuringRigMove.Item = item.Item;
							RigMovePerformanceDTO.ProblemFacedDuringRigMoveDTOs.Add(problemFacedDuringRigMove);

						}


						newTemp.Add(RigMovePerformanceDTO);
					}

					float countDetails = RigMovePerformanceRepo.getall().Count();
					var result = new PageResult<RigPerformanceResponseDTO>
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
					List<RigMovePerformance> temp = RigMovePerformanceRepo.getall().Where(e=>e.user.Id==UserID).ToList();


					List<RigPerformanceResponseDTO> newTemp = new List<RigPerformanceResponseDTO>();
					foreach (RigMovePerformance RigMovePerformance in temp)
					{
						RigPerformanceResponseDTO RigMovePerformanceDTO = new RigPerformanceResponseDTO();
						RigMovePerformanceDTO.Id = RigMovePerformance.Id;
						RigMovePerformanceDTO.UserName = RigMovePerformance.user.UserName;
						RigMovePerformanceDTO.RigNumber = RigMovePerformance.Rig.Number;
						RigMovePerformanceDTO.OldWellName = RigMovePerformance.OldWellName;
						RigMovePerformanceDTO.NewWellName = RigMovePerformance.NewWellName;
						RigMovePerformanceDTO.TargetArchived = RigMovePerformance.TargetArchived;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.ReleaseTime = RigMovePerformance.ReleaseTime;
						RigMovePerformanceDTO.AcceptanceTime = RigMovePerformance.AcceptanceTime;
						RigMovePerformanceDTO.AcceptanceDate = RigMovePerformance.AcceptanceDate;
						RigMovePerformanceDTO.ReleaseDate = RigMovePerformance.ReleaseDate;
						RigMovePerformanceDTO.BudgetTargetTotalDay = RigMovePerformance.BudgetTargetTotalDay;
						RigMovePerformanceDTO.BudgetTargetTotalMoney = RigMovePerformance.BudgetTargetTotalMoney;
						RigMovePerformanceDTO.ActualMoveTime = RigMovePerformance.ActualMoveTime;
						RigMovePerformanceDTO.MoveDistance = RigMovePerformance.MoveDistance;
						RigMovePerformanceDTO.DieselConsumed = RigMovePerformance.DieselConsumed;
						foreach (ProblemFacedDuringRigMove item in RigMovePerformance.problemFacedDuringRigMoves)
						{
							ProblemFacedDuringRigMoveDTO problemFacedDuringRigMove = new ProblemFacedDuringRigMoveDTO();
							problemFacedDuringRigMove.Id = item.Id;
							problemFacedDuringRigMove.TimeLostProblem = item.TimeLostProblem;
							problemFacedDuringRigMove.RecommendationProblemRepeated = item.RecommendationProblemRepeated;
							problemFacedDuringRigMove.ProblemDescription = item.ProblemDescription;

							problemFacedDuringRigMove.IsDeleted = item.IsDeleted;
							problemFacedDuringRigMove.Item = item.Item;
							RigMovePerformanceDTO.ProblemFacedDuringRigMoveDTOs.Add(problemFacedDuringRigMove);

						}


						newTemp.Add(RigMovePerformanceDTO);
					}

					float countDetails = RigMovePerformanceRepo.getall().Count();
					var result = new PageResult<RigPerformanceResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};
					return result;
				}
			}
			catch(Exception ex)
			{
				return new PageResult<RigPerformanceResponseDTO>();
			}
			return new PageResult<RigPerformanceResponseDTO>();
		}

		[HttpPost]
		public ActionResult<ResultDTO> AddRigMovePerformance(RigMovePerformanceDTO RigMovePerformanceDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					RigMovePerformance RigMovePerformance = new RigMovePerformance();
					
					RigMovePerformance.Id = RigMovePerformanceDTO.Id;
					RigMovePerformance.RigId = RigMovePerformanceDTO.RigId;
                    RigMovePerformance.UserId = RigMovePerformanceDTO.UserId;
                    RigMovePerformance.OldWellName = RigMovePerformanceDTO.OldWellName;
                    RigMovePerformance.NewWellName = RigMovePerformanceDTO.NewWellName;
                    RigMovePerformance.TargetArchived = RigMovePerformanceDTO.TargetArchived;
					RigMovePerformance.ActualMoveTime = RigMovePerformanceDTO.ActualMoveTime;
					RigMovePerformance.ReleaseTime = RigMovePerformanceDTO.ReleaseTime;
					RigMovePerformance.AcceptanceTime = RigMovePerformanceDTO.AcceptanceTime;
					RigMovePerformance.AcceptanceDate = RigMovePerformanceDTO.AcceptanceDate;
					RigMovePerformance.ReleaseDate = RigMovePerformanceDTO.ReleaseDate;
					RigMovePerformance.BudgetTargetTotalDay = RigMovePerformanceDTO.BudgetTargetTotalDay;
                    RigMovePerformance.BudgetTargetTotalMoney = RigMovePerformanceDTO.BudgetTargetTotalMoney;
                    RigMovePerformance.ActualMoveTime = RigMovePerformanceDTO.ActualMoveTime;
					RigMovePerformance.MoveDistance = RigMovePerformanceDTO.MoveDistance;
					RigMovePerformance.DieselConsumed = RigMovePerformanceDTO.DieselConsumed;
                    RigMovePerformance.IsDeleted = RigMovePerformanceDTO.IsDeleted;

					RigMoveRepo.create(RigMovePerformance);


					if (RigMovePerformanceDTO.Item1 != "" || RigMovePerformanceDTO.ProblemDescription1 != ""
						  || RigMovePerformanceDTO.RecommendationProblemRepeated1 != "")

					{
						ProblemFacedDuringRigMove problemFacedDuringRigMove = new ProblemFacedDuringRigMove();
						problemFacedDuringRigMove.RigMovePerformanceId = RigMovePerformance.Id;
						problemFacedDuringRigMove.Item = RigMovePerformanceDTO.Item1;
						problemFacedDuringRigMove.ProblemDescription = RigMovePerformanceDTO.ProblemDescription1;
						problemFacedDuringRigMove.TimeLostProblem = (double)RigMovePerformanceDTO.TimeLostProblem1;
						problemFacedDuringRigMove.RecommendationProblemRepeated = RigMovePerformanceDTO.RecommendationProblemRepeated1;
						ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove);

					}

					if ((RigMovePerformanceDTO.Item2 != "" || RigMovePerformanceDTO.ProblemDescription2 != ""
						   || RigMovePerformanceDTO.RecommendationProblemRepeated2 != "") )

					{
						ProblemFacedDuringRigMove problemFacedDuringRigMove = new ProblemFacedDuringRigMove();
						problemFacedDuringRigMove.RigMovePerformanceId = RigMovePerformance.Id;
						problemFacedDuringRigMove.Item = RigMovePerformanceDTO.Item2;
						problemFacedDuringRigMove.ProblemDescription = RigMovePerformanceDTO.ProblemDescription2;
						problemFacedDuringRigMove.TimeLostProblem = (double)RigMovePerformanceDTO.TimeLostProblem2;
						problemFacedDuringRigMove.RecommendationProblemRepeated = RigMovePerformanceDTO.RecommendationProblemRepeated2;
						ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove);

					}


					if (RigMovePerformanceDTO.Item3 != "" || RigMovePerformanceDTO.ProblemDescription3 != ""
						 || RigMovePerformanceDTO.RecommendationProblemRepeated3 != "")

					{
						ProblemFacedDuringRigMove problemFacedDuringRigMove = new ProblemFacedDuringRigMove();
						problemFacedDuringRigMove.RigMovePerformanceId = RigMovePerformance.Id;
						problemFacedDuringRigMove.Item = RigMovePerformanceDTO.Item3;
						problemFacedDuringRigMove.ProblemDescription = RigMovePerformanceDTO.ProblemDescription3;
						problemFacedDuringRigMove.TimeLostProblem = (double)RigMovePerformanceDTO.TimeLostProblem3;
						problemFacedDuringRigMove.RecommendationProblemRepeated = RigMovePerformanceDTO.RecommendationProblemRepeated3;
						ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove);

					}

					if (RigMovePerformanceDTO.Item4 != "" || RigMovePerformanceDTO.ProblemDescription4 != ""
						   || RigMovePerformanceDTO.RecommendationProblemRepeated4 != "")

					{
						ProblemFacedDuringRigMove problemFacedDuringRigMove = new ProblemFacedDuringRigMove();
						problemFacedDuringRigMove.RigMovePerformanceId = RigMovePerformance.Id;
						problemFacedDuringRigMove.Item = RigMovePerformanceDTO.Item4;
						problemFacedDuringRigMove.ProblemDescription = RigMovePerformanceDTO.ProblemDescription4;
						problemFacedDuringRigMove.TimeLostProblem = (double)RigMovePerformanceDTO.TimeLostProblem4;
						problemFacedDuringRigMove.RecommendationProblemRepeated = RigMovePerformanceDTO.RecommendationProblemRepeated4;
						ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove);

					}

					if (RigMovePerformanceDTO.Item5 != "" || RigMovePerformanceDTO.ProblemDescription5 != ""
						  || RigMovePerformanceDTO.RecommendationProblemRepeated5 != "")

					{
						ProblemFacedDuringRigMove problemFacedDuringRigMove = new ProblemFacedDuringRigMove();
						problemFacedDuringRigMove.RigMovePerformanceId = RigMovePerformance.Id;
						problemFacedDuringRigMove.Item = RigMovePerformanceDTO.Item5;
						problemFacedDuringRigMove.ProblemDescription = RigMovePerformanceDTO.ProblemDescription5;
						problemFacedDuringRigMove.TimeLostProblem = (double)RigMovePerformanceDTO.TimeLostProblem5;
						problemFacedDuringRigMove.RecommendationProblemRepeated = RigMovePerformanceDTO.RecommendationProblemRepeated5;
						ProblemFacedDuringRigMoveRepo.create(problemFacedDuringRigMove);

					}

					result.Message = "Success";
					result.Data = RigMovePerformanceDTO;
					result.Statescode = 200;

				}
				catch (Exception ex)
				{
					result.Message = "Error in inserting";
					result.Statescode = 400;
					Console.WriteLine(ex.Message);

				}
			}
			return result;
		}
        [HttpGet("GetAllRigPerformanceWithDataByDate/{date:DateTime}")]
        public ActionResult<ResultDTO> GetAllRigPerformanceWithDataByDate(DateTime date, string UserID, string UserRole)
        {
            ResultDTO result = new ResultDTO();
            try
            {
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<RigPerformanceResponseDTO> rigPerformanceResponseDTOs = new List<RigPerformanceResponseDTO>();
					RigMovePerformance rigMovePerformance = RigMovePerformanceRepo.getall().FirstOrDefault(a => a.AcceptanceDate == date);


					RigPerformanceResponseDTO rigPerformanceResponseDTO = new RigPerformanceResponseDTO();
					rigPerformanceResponseDTO.Id = rigMovePerformance.Id;
					rigPerformanceResponseDTO.RigNumber = rigMovePerformance.Rig.Number;
					rigPerformanceResponseDTO.AcceptanceTime = rigMovePerformance.AcceptanceTime;
					rigPerformanceResponseDTO.AcceptanceDate = rigMovePerformance.AcceptanceDate;
					rigPerformanceResponseDTO.ReleaseDate = rigMovePerformance.ReleaseDate;
					rigPerformanceResponseDTO.ReleaseTime = rigMovePerformance.ReleaseTime;
					rigPerformanceResponseDTO.OldWellName = rigMovePerformance.OldWellName;
					rigPerformanceResponseDTO.NewWellName = rigMovePerformance.NewWellName;
					rigPerformanceResponseDTO.DieselConsumed = rigMovePerformance.DieselConsumed;
					rigPerformanceResponseDTO.BudgetTargetTotalDay = rigMovePerformance.BudgetTargetTotalDay;
					rigPerformanceResponseDTO.BudgetTargetTotalMoney = rigMovePerformance.BudgetTargetTotalMoney;
					rigPerformanceResponseDTO.MoveDistance = rigMovePerformance.MoveDistance;
					rigPerformanceResponseDTO.ActualMoveTime = rigMovePerformance.ActualMoveTime;
					rigPerformanceResponseDTO.TargetArchived = rigMovePerformance.TargetArchived;
					rigPerformanceResponseDTO.UserName = rigMovePerformance.user.UserName;

					List<ProblemFacedDuringRigMove> ProblemFacedDuringRigMoves = ProblemFacedDuringRigMoveRepo.getall().Where(p => p.RigMovePerformanceId == rigMovePerformance.Id).ToList();
					foreach (ProblemFacedDuringRigMove item in ProblemFacedDuringRigMoves)
					{
						ProblemFacedDuringRigMoveDTO problemRigMoveDTO = new ProblemFacedDuringRigMoveDTO();
						problemRigMoveDTO.Id = item.Id;
						problemRigMoveDTO.Item = item.Item;
						problemRigMoveDTO.TimeLostProblem = item.TimeLostProblem;
						problemRigMoveDTO.RecommendationProblemRepeated = item.RecommendationProblemRepeated;
						problemRigMoveDTO.ProblemDescription = item.ProblemDescription;
						rigPerformanceResponseDTO.ProblemFacedDuringRigMoveDTOs.Add(problemRigMoveDTO);
					}




					result.Message = "Success";
					result.Data = rigPerformanceResponseDTO;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<RigPerformanceResponseDTO> rigPerformanceResponseDTOs = new List<RigPerformanceResponseDTO>();
					RigMovePerformance rigMovePerformance = RigMovePerformanceRepo.getall().FirstOrDefault(a => a.AcceptanceDate == date&&a.user.Id==UserID);


					RigPerformanceResponseDTO rigPerformanceResponseDTO = new RigPerformanceResponseDTO();
					rigPerformanceResponseDTO.Id = rigMovePerformance.Id;
					rigPerformanceResponseDTO.RigNumber = rigMovePerformance.Rig.Number;
					rigPerformanceResponseDTO.AcceptanceTime = rigMovePerformance.AcceptanceTime;
					rigPerformanceResponseDTO.AcceptanceDate = rigMovePerformance.AcceptanceDate;
					rigPerformanceResponseDTO.ReleaseDate = rigMovePerformance.ReleaseDate;
					rigPerformanceResponseDTO.ReleaseTime = rigMovePerformance.ReleaseTime;
					rigPerformanceResponseDTO.OldWellName = rigMovePerformance.OldWellName;
					rigPerformanceResponseDTO.NewWellName = rigMovePerformance.NewWellName;
					rigPerformanceResponseDTO.DieselConsumed = rigMovePerformance.DieselConsumed;
					rigPerformanceResponseDTO.BudgetTargetTotalDay = rigMovePerformance.BudgetTargetTotalDay;
					rigPerformanceResponseDTO.BudgetTargetTotalMoney = rigMovePerformance.BudgetTargetTotalMoney;
					rigPerformanceResponseDTO.MoveDistance = rigMovePerformance.MoveDistance;
					rigPerformanceResponseDTO.ActualMoveTime = rigMovePerformance.ActualMoveTime;
					rigPerformanceResponseDTO.TargetArchived = rigMovePerformance.TargetArchived;
					rigPerformanceResponseDTO.UserName = rigMovePerformance.user.UserName;

					List<ProblemFacedDuringRigMove> ProblemFacedDuringRigMoves = ProblemFacedDuringRigMoveRepo.getall().Where(p => p.RigMovePerformanceId == rigMovePerformance.Id).ToList();
					foreach (ProblemFacedDuringRigMove item in ProblemFacedDuringRigMoves)
					{
						ProblemFacedDuringRigMoveDTO problemRigMoveDTO = new ProblemFacedDuringRigMoveDTO();
						problemRigMoveDTO.Id = item.Id;
						problemRigMoveDTO.Item = item.Item;
						problemRigMoveDTO.TimeLostProblem = item.TimeLostProblem;
						problemRigMoveDTO.RecommendationProblemRepeated = item.RecommendationProblemRepeated;
						problemRigMoveDTO.ProblemDescription = item.ProblemDescription;
						rigPerformanceResponseDTO.ProblemFacedDuringRigMoveDTOs.Add(problemRigMoveDTO);
					}




					result.Message = "Success";
					result.Data = rigPerformanceResponseDTO;
					result.Statescode = 200;
					return result;
				}

			}
            catch (Exception ex)
            {
                result.Message = "Error Not Find";
                result.Statescode = 404;
            }
			return result;
		}

        [HttpPut("Delete/{id:int}")]
		public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				RigMovePerformance rigMovePerformance = RigMoveRepo.getbyid(id);
                List<ProblemFacedDuringRigMove> problemFacedDuringRigMoves = ProblemFacedDuringRigMoveRepo.getall().Where(p => p.RigMovePerformanceId == id).ToList();

                rigMovePerformance.IsDeleted = true;
				RigMoveRepo.update(rigMovePerformance);
                foreach (var item in problemFacedDuringRigMoves)
                {
                    item.IsDeleted = true;
                    ProblemFacedDuringRigMoveRepo.update(item);
                }
                
				result.Data = rigMovePerformance;
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
