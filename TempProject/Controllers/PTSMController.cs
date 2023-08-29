using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PTSMController : ControllerBase
	{
		public IRepository<PTSM> PTSMRepo { get; set; }
		public IPTSMRepository PTSMRepository { get; set; }
		public IRepository<Attendance> AttendanceRepo { get; set; }

		public PTSMController(IPTSMRepository _PTSMRepository,IRepository<PTSM> _PTSMRepo, IRepository<Attendance> _AttendanceRepo)
		{
			this.PTSMRepo = _PTSMRepo;
			this.PTSMRepository = _PTSMRepository;
			this.AttendanceRepo = _AttendanceRepo;
		}

		[HttpGet]
		public ActionResult<ResultDTO> GetAll(string UserID, string UserRole)
		{

			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<PTSM> temp = PTSMRepo.getall();
					List<PTSMDTO> newTemp = new List<PTSMDTO>();
					foreach (PTSM No in temp)
					{
						PTSMDTO PTSMResponseDTO = new PTSMDTO();
						PTSMResponseDTO.Id = No.Id;
						PTSMResponseDTO.TrainerName = No.TrainerName;
						PTSMResponseDTO.SubjectTitle = No.SubjectTitle;
						PTSMResponseDTO.SubjectContent = No.SubjectContent;
						PTSMResponseDTO.NumsofTrainees = No.NumsofTrainees;
						PTSMResponseDTO.RigId = No.RigId;
						PTSMResponseDTO.Date = No.Date;
						PTSMResponseDTO.Time = No.Time;
						PTSMResponseDTO.UserId = No.UserId;
						PTSMResponseDTO.IsDeleted = No.IsDeleted;

						newTemp.Add(PTSMResponseDTO);
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
					List<PTSM> temp = PTSMRepo.getall().Where(p => p.UserId == UserID).ToList();
					List<PTSMDTO> newTemp = new List<PTSMDTO>();
					foreach (PTSM No in temp)
					{
						PTSMDTO PTSMResponseDTO = new PTSMDTO();
						PTSMResponseDTO.Id = No.Id;
						PTSMResponseDTO.TrainerName = No.TrainerName;
						PTSMResponseDTO.SubjectTitle = No.SubjectTitle;
						PTSMResponseDTO.SubjectContent = No.SubjectContent;
						PTSMResponseDTO.NumsofTrainees = No.NumsofTrainees;
						PTSMResponseDTO.RigId = No.RigId;
						PTSMResponseDTO.Date = No.Date;
						PTSMResponseDTO.Time = No.Time;
						PTSMResponseDTO.UserId = No.UserId;
						PTSMResponseDTO.IsDeleted = No.IsDeleted;

						newTemp.Add(PTSMResponseDTO);
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

		[HttpGet("GetAllWithResponseDTO")]
		public ActionResult<ResultDTO> GetAllWithResponseDTO(string UserID, string UserRole)
		{

			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{

					List<PTSM> temp = PTSMRepository.getall();

					List<PTSMResponseDTO> newTemp = new List<PTSMResponseDTO>();
					foreach (PTSM PTSM in temp)
					{
						PTSMResponseDTO PTSMResponseDTO = new PTSMResponseDTO();
						PTSMResponseDTO.Id = PTSM.Id;
						PTSMResponseDTO.UserName = PTSM.user.UserName;
						PTSMResponseDTO.RigNumber = PTSM.Rig.Number;
						PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
						PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
						PTSMResponseDTO.Time = PTSM.Time;
						PTSMResponseDTO.Date = PTSM.Date;
						PTSMResponseDTO.TrainerName = PTSM.TrainerName;
						PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
						foreach (Attendance No in PTSM.Attendances)
						{
							AttendanceDTO attendanceDTO = new AttendanceDTO();
							attendanceDTO.Id = No.Id;
							attendanceDTO.Name = No.Name;
							attendanceDTO.No = No.No;
							attendanceDTO.PTSMId = No.PTSMId;
							attendanceDTO.IsDeleted = No.IsDeleted;
							attendanceDTO.Position = No.Position;
							PTSMResponseDTO.AttendancesDTO.Add(attendanceDTO);
						}

						//PTSMResponseDTO.Attendances = PTSM.Attendances;

						newTemp.Add(PTSMResponseDTO);
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

					List<PTSM> temp = PTSMRepository.getall().Where(a => a.user.Id == UserID).ToList();


					List<PTSMResponseDTO> newTemp = new List<PTSMResponseDTO>();
					foreach (PTSM PTSM in temp)
					{
						PTSMResponseDTO PTSMResponseDTO = new PTSMResponseDTO();
						PTSMResponseDTO.Id = PTSM.Id;
						PTSMResponseDTO.UserName = PTSM.user.UserName;
						PTSMResponseDTO.RigNumber = PTSM.Rig.Number;
						PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
						PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
						PTSMResponseDTO.Time = PTSM.Time;
						PTSMResponseDTO.Date = PTSM.Date;
						PTSMResponseDTO.TrainerName = PTSM.TrainerName;
						PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
						foreach (Attendance No in PTSM.Attendances)
						{
							AttendanceDTO attendanceDTO = new AttendanceDTO();
							attendanceDTO.Id = No.Id;
							attendanceDTO.Name = No.Name;
							attendanceDTO.No = No.No;
							attendanceDTO.PTSMId = No.PTSMId;
							attendanceDTO.IsDeleted = No.IsDeleted;
							attendanceDTO.Position = No.Position;
							PTSMResponseDTO.AttendancesDTO.Add(attendanceDTO);
						}

						//PTSMResponseDTO.Attendances = PTSM.Attendances;

						newTemp.Add(PTSMResponseDTO);
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

		[HttpGet("GetAllWithExcelDTO")]
		public ActionResult<ResultDTO> GetAllWithExcelDTO(string UserID, string UserRole)
		{

			ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<PTSM> temp = PTSMRepository.getall();
					List<PTSMExcelDTO> newTemp = new List<PTSMExcelDTO>();
					foreach (PTSM PTSM in temp)
					{
						PTSMExcelDTO PTSMResponseDTO = new PTSMExcelDTO();
						PTSMResponseDTO.Id = PTSM.Id;
						PTSMResponseDTO.UserName = PTSM.user.UserName;
						PTSMResponseDTO.RigNumber = PTSM.Rig.Number;
						PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
						PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
						PTSMResponseDTO.Time = PTSM.Time;
						PTSMResponseDTO.Date = PTSM.Date;
						PTSMResponseDTO.TrainerName = PTSM.TrainerName;
						PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
						if (PTSM.Attendances.Count() == 5)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							PTSMResponseDTO.Name2 = PTSM.Attendances[1].Name;
							PTSMResponseDTO.Name3 = PTSM.Attendances[2].Name;
							PTSMResponseDTO.Name4 = PTSM.Attendances[3].Name;
							PTSMResponseDTO.Name5 = PTSM.Attendances[4].Name;

							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							PTSMResponseDTO.No2 = (int)PTSM.Attendances[1].No;
							PTSMResponseDTO.No3 = (int)PTSM.Attendances[2].No;
							PTSMResponseDTO.No4 = (int)PTSM.Attendances[3].No;
							PTSMResponseDTO.No5 = (int)PTSM.Attendances[4].No;

							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							PTSMResponseDTO.Position2 = PTSM.Attendances[1].Position;
							PTSMResponseDTO.Position3 = PTSM.Attendances[2].Position;
							PTSMResponseDTO.Position4 = PTSM.Attendances[3].Position;
							PTSMResponseDTO.Position5 = PTSM.Attendances[4].Position;
						}
						else if (PTSM.Attendances.Count() == 4)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							PTSMResponseDTO.Name2 = PTSM.Attendances[1].Name;
							PTSMResponseDTO.Name3 = PTSM.Attendances[2].Name;
							PTSMResponseDTO.Name4 = PTSM.Attendances[3].Name;

							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							PTSMResponseDTO.No2 = (int)PTSM.Attendances[1].No;
							PTSMResponseDTO.No3 = (int)PTSM.Attendances[2].No;
							PTSMResponseDTO.No4 = (int)PTSM.Attendances[3].No;

							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							PTSMResponseDTO.Position2 = PTSM.Attendances[1].Position;
							PTSMResponseDTO.Position3 = PTSM.Attendances[2].Position;
							PTSMResponseDTO.Position4 = PTSM.Attendances[3].Position;
						}
						else if (PTSM.Attendances.Count() == 3)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							PTSMResponseDTO.Name2 = PTSM.Attendances[1].Name;
							PTSMResponseDTO.Name3 = PTSM.Attendances[2].Name;

							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							PTSMResponseDTO.No2 = (int)PTSM.Attendances[1].No;
							PTSMResponseDTO.No3 = (int)PTSM.Attendances[2].No;

							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							PTSMResponseDTO.Position2 = PTSM.Attendances[1].Position;
							PTSMResponseDTO.Position3 = PTSM.Attendances[2].Position;
						}
						else if (PTSM.Attendances.Count() == 2)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							PTSMResponseDTO.Name2 = PTSM.Attendances[1].Name;
							

							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							PTSMResponseDTO.No2 = (int)PTSM.Attendances[1].No;
							

							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							PTSMResponseDTO.Position2 = PTSM.Attendances[1].Position;
							
						}
						else if (PTSM.Attendances.Count() == 1)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							

							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							
							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							
						}


						newTemp.Add(PTSMResponseDTO);
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
					List<PTSM> temp = PTSMRepository.getall().Where(a => a.user.Id == UserID).ToList();


					List<PTSMExcelDTO> newTemp = new List<PTSMExcelDTO>();
					foreach (PTSM PTSM in temp)
					{
						PTSMExcelDTO PTSMResponseDTO = new PTSMExcelDTO();
						PTSMResponseDTO.Id = PTSM.Id;
						PTSMResponseDTO.UserName = PTSM.user.UserName;
						PTSMResponseDTO.RigNumber = PTSM.Rig.Number;
						PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
						PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
						PTSMResponseDTO.Time = PTSM.Time;
						PTSMResponseDTO.Date = PTSM.Date;
						PTSMResponseDTO.TrainerName = PTSM.TrainerName;
						PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
						if (PTSM.Attendances.Count() == 5)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							PTSMResponseDTO.Name2 = PTSM.Attendances[1].Name;
							PTSMResponseDTO.Name3 = PTSM.Attendances[2].Name;
							PTSMResponseDTO.Name4 = PTSM.Attendances[3].Name;
							PTSMResponseDTO.Name5 = PTSM.Attendances[4].Name;

							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							PTSMResponseDTO.No2 = (int)PTSM.Attendances[1].No;
							PTSMResponseDTO.No3 = (int)PTSM.Attendances[2].No;
							PTSMResponseDTO.No4 = (int)PTSM.Attendances[3].No;
							PTSMResponseDTO.No5 = (int)PTSM.Attendances[4].No;

							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							PTSMResponseDTO.Position2 = PTSM.Attendances[1].Position;
							PTSMResponseDTO.Position3 = PTSM.Attendances[2].Position;
							PTSMResponseDTO.Position4 = PTSM.Attendances[3].Position;
							PTSMResponseDTO.Position5 = PTSM.Attendances[4].Position;
						}
						else if (PTSM.Attendances.Count() == 4)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							PTSMResponseDTO.Name2 = PTSM.Attendances[1].Name;
							PTSMResponseDTO.Name3 = PTSM.Attendances[2].Name;
							PTSMResponseDTO.Name4 = PTSM.Attendances[3].Name;

							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							PTSMResponseDTO.No2 = (int)PTSM.Attendances[1].No;
							PTSMResponseDTO.No3 = (int)PTSM.Attendances[2].No;
							PTSMResponseDTO.No4 = (int)PTSM.Attendances[3].No;

							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							PTSMResponseDTO.Position2 = PTSM.Attendances[1].Position;
							PTSMResponseDTO.Position3 = PTSM.Attendances[2].Position;
							PTSMResponseDTO.Position4 = PTSM.Attendances[3].Position;
						}
						else if (PTSM.Attendances.Count() == 3)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							PTSMResponseDTO.Name2 = PTSM.Attendances[1].Name;
							PTSMResponseDTO.Name3 = PTSM.Attendances[2].Name;

							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							PTSMResponseDTO.No2 = (int)PTSM.Attendances[1].No;
							PTSMResponseDTO.No3 = (int)PTSM.Attendances[2].No;

							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							PTSMResponseDTO.Position2 = PTSM.Attendances[1].Position;
							PTSMResponseDTO.Position3 = PTSM.Attendances[2].Position;
						}
						else if (PTSM.Attendances.Count() == 2)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;
							PTSMResponseDTO.Name2 = PTSM.Attendances[1].Name;


							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;
							PTSMResponseDTO.No2 = (int)PTSM.Attendances[1].No;


							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;
							PTSMResponseDTO.Position2 = PTSM.Attendances[1].Position;

						}
						else if (PTSM.Attendances.Count() == 1)
						{
							PTSMResponseDTO.Name1 = PTSM.Attendances[0].Name;


							PTSMResponseDTO.No1 = (int)PTSM.Attendances[0].No;

							PTSMResponseDTO.Position1 = PTSM.Attendances[0].Position;

						}


						newTemp.Add(PTSMResponseDTO);
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
		public PageResult<PTSMResponseDTO> GettAllPTSMByPage(string UserID, string UserRole,int? page, int pagesize = 10)
		{
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<PTSM> temp = PTSMRepository.getall();
					List<PTSMResponseDTO> newTemp = new List<PTSMResponseDTO>();
					foreach (PTSM PTSM in temp)
					{
						PTSMResponseDTO PTSMResponseDTO = new PTSMResponseDTO();
						PTSMResponseDTO.Id = PTSM.Id;
						PTSMResponseDTO.TrainerName = PTSM.TrainerName;
						PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
						PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
						PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
						PTSMResponseDTO.RigNumber = PTSM.Rig.Number;
						PTSMResponseDTO.UserName = PTSM.user.UserName;
						PTSMResponseDTO.Date = PTSM.Date;
						PTSMResponseDTO.Time = PTSM.Time;
						PTSMResponseDTO.IsDeleted = PTSM.IsDeleted;
						foreach (Attendance No in PTSM.Attendances)
						{
							AttendanceDTO attendanceDTO = new AttendanceDTO();
							attendanceDTO.Id = No.Id;
							attendanceDTO.Name = No.Name;
							attendanceDTO.No = No.No;
							attendanceDTO.Position = No.Position;
							attendanceDTO.PTSMId = No.PTSMId;
							attendanceDTO.IsDeleted = No.IsDeleted;

							PTSMResponseDTO.AttendancesDTO.Add(attendanceDTO);
						}

						newTemp.Add(PTSMResponseDTO);
					}

					float countDetails = PTSMRepository.getall().Count();
					var result = new PageResult<PTSMResponseDTO>
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
					List<PTSM> temp = PTSMRepository.getall().Where(p=>p.UserId==UserID).ToList();
					List<PTSMResponseDTO> newTemp = new List<PTSMResponseDTO>();
					foreach (PTSM PTSM in temp)
					{
						PTSMResponseDTO PTSMResponseDTO = new PTSMResponseDTO();
						PTSMResponseDTO.Id = PTSM.Id;
						PTSMResponseDTO.TrainerName = PTSM.TrainerName;
						PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
						PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
						PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
						PTSMResponseDTO.RigNumber = PTSM.Rig.Number;
						PTSMResponseDTO.UserName = PTSM.user.UserName;
						PTSMResponseDTO.Date = PTSM.Date;
						PTSMResponseDTO.Time = PTSM.Time;
						PTSMResponseDTO.IsDeleted = PTSM.IsDeleted;
						foreach (Attendance No in PTSM.Attendances)
						{
							AttendanceDTO attendanceDTO = new AttendanceDTO();
							attendanceDTO.Id = No.Id;
							attendanceDTO.Name = No.Name;
							attendanceDTO.No = No.No;
							attendanceDTO.Position = No.Position;
							attendanceDTO.PTSMId = No.PTSMId;
							attendanceDTO.IsDeleted = No.IsDeleted;

							PTSMResponseDTO.AttendancesDTO.Add(attendanceDTO);
						}

						newTemp.Add(PTSMResponseDTO);
					}

					float countDetails = PTSMRepository.getall().Where(p => p.UserId == UserID).Count();
					var result = new PageResult<PTSMResponseDTO>
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
				return new PageResult<PTSMResponseDTO>();
			}
			return new PageResult<PTSMResponseDTO>();
		}

		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					PTSMDTO PTSMResponseDTO = new PTSMDTO();
					List<Attendance> attendances = AttendanceRepo.getall().Where(p => p.PTSMId == ID).ToList();
					PTSM PTSM = PTSMRepo.getbyid(ID);
					PTSMResponseDTO.Id = PTSM.Id;
					PTSMResponseDTO.TrainerName = PTSM.TrainerName;
					PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
					PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
					PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
					PTSMResponseDTO.RigId = PTSM.RigId;
					PTSMResponseDTO.UserId = PTSM.UserId;
					PTSMResponseDTO.Date = PTSM.Date;
					PTSMResponseDTO.Time = PTSM.Time;
					PTSMResponseDTO.IsDeleted = PTSM.IsDeleted;
					if (attendances.Count == 1)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

					}
					else if (attendances.Count == 2)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

						PTSMResponseDTO.Name2 = attendances[1].Name;
						PTSMResponseDTO.Position2 = attendances[1].Position;
						PTSMResponseDTO.No2 = (int)attendances[1].No;
					}

					else if (attendances.Count == 3)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

						PTSMResponseDTO.Name2 = attendances[1].Name;
						PTSMResponseDTO.Position2 = attendances[1].Position;
						PTSMResponseDTO.No2 = (int)attendances[1].No;

						PTSMResponseDTO.Name3 = attendances[2].Name;
						PTSMResponseDTO.Position3 = attendances[2].Position;
						PTSMResponseDTO.No3 = (int)attendances[2].No;
					}

					else if (attendances.Count == 4)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

						PTSMResponseDTO.Name2 = attendances[1].Name;
						PTSMResponseDTO.Position2 = attendances[1].Position;
						PTSMResponseDTO.No2 = (int)attendances[1].No;

						PTSMResponseDTO.Name3 = attendances[2].Name;
						PTSMResponseDTO.Position3 = attendances[2].Position;
						PTSMResponseDTO.No3 = (int)attendances[2].No;

						PTSMResponseDTO.Name4 = attendances[3].Name;
						PTSMResponseDTO.Position4 = attendances[3].Position;
						PTSMResponseDTO.No4 = (int)attendances[3].No;
					}
					else if (attendances.Count == 5)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

						PTSMResponseDTO.Name2 = attendances[1].Name;
						PTSMResponseDTO.Position2 = attendances[1].Position;
						PTSMResponseDTO.No2 = (int)attendances[1].No;

						PTSMResponseDTO.Name3 = attendances[2].Name;
						PTSMResponseDTO.Position3 = attendances[2].Position;
						PTSMResponseDTO.No3 = (int)attendances[2].No;

						PTSMResponseDTO.Name4 = attendances[3].Name;
						PTSMResponseDTO.Position4 = attendances[3].Position;
						PTSMResponseDTO.No4 = (int)attendances[3].No;

						PTSMResponseDTO.Name5 = attendances[4].Name;
						PTSMResponseDTO.Position5 = attendances[4].Position;
						PTSMResponseDTO.No5 = (int)attendances[4].No;
					}

					result.Message = "Success";
					result.Data = PTSMResponseDTO;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					PTSMDTO PTSMResponseDTO = new PTSMDTO();
					List<Attendance> attendances = AttendanceRepo.getall().Where(p => p.PTSMId == ID).ToList();
					PTSM PTSM = PTSMRepo.getall().FirstOrDefault(p=>p.UserId==UserID && p.Id == ID);
					PTSMResponseDTO.Id = PTSM.Id;
					PTSMResponseDTO.TrainerName = PTSM.TrainerName;
					PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
					PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
					PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
					PTSMResponseDTO.RigId = PTSM.RigId;
					PTSMResponseDTO.UserId = PTSM.UserId;
					PTSMResponseDTO.Date = PTSM.Date;
					PTSMResponseDTO.Time = PTSM.Time;
					PTSMResponseDTO.IsDeleted = PTSM.IsDeleted;
					if (attendances.Count == 1)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

					}
					else if (attendances.Count == 2)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

						PTSMResponseDTO.Name2 = attendances[1].Name;
						PTSMResponseDTO.Position2 = attendances[1].Position;
						PTSMResponseDTO.No2 = (int)attendances[1].No;
					}

					else if (attendances.Count == 3)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

						PTSMResponseDTO.Name2 = attendances[1].Name;
						PTSMResponseDTO.Position2 = attendances[1].Position;
						PTSMResponseDTO.No2 = (int)attendances[1].No;

						PTSMResponseDTO.Name3 = attendances[2].Name;
						PTSMResponseDTO.Position3 = attendances[2].Position;
						PTSMResponseDTO.No3 = (int)attendances[2].No;
					}

					else if (attendances.Count == 4)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

						PTSMResponseDTO.Name2 = attendances[1].Name;
						PTSMResponseDTO.Position2 = attendances[1].Position;
						PTSMResponseDTO.No2 = (int)attendances[1].No;

						PTSMResponseDTO.Name3 = attendances[2].Name;
						PTSMResponseDTO.Position3 = attendances[2].Position;
						PTSMResponseDTO.No3 = (int)attendances[2].No;

						PTSMResponseDTO.Name4 = attendances[3].Name;
						PTSMResponseDTO.Position4 = attendances[3].Position;
						PTSMResponseDTO.No4 = (int)attendances[3].No;
					}
					else if (attendances.Count == 5)
					{
						PTSMResponseDTO.Name1 = attendances[0].Name;
						PTSMResponseDTO.Position1 = attendances[0].Position;
						PTSMResponseDTO.No1 = (int)attendances[0].No;

						PTSMResponseDTO.Name2 = attendances[1].Name;
						PTSMResponseDTO.Position2 = attendances[1].Position;
						PTSMResponseDTO.No2 = (int)attendances[1].No;

						PTSMResponseDTO.Name3 = attendances[2].Name;
						PTSMResponseDTO.Position3 = attendances[2].Position;
						PTSMResponseDTO.No3 = (int)attendances[2].No;

						PTSMResponseDTO.Name4 = attendances[3].Name;
						PTSMResponseDTO.Position4 = attendances[3].Position;
						PTSMResponseDTO.No4 = (int)attendances[3].No;

						PTSMResponseDTO.Name5 = attendances[4].Name;
						PTSMResponseDTO.Position5 = attendances[4].Position;
						PTSMResponseDTO.No5 = (int)attendances[4].No;
					}

					result.Message = "Success";
					result.Data = PTSMResponseDTO;
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
		public ActionResult<ResultDTO> Put(int id, PTSMDTO newPTSM) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					PTSM orgPTSM = PTSMRepo.getbyid(id);
					List<Attendance> attendances = AttendanceRepo.getall().Where(p => p.PTSMId == id).ToList();

					newPTSM.Id = orgPTSM.Id;
					orgPTSM.TrainerName = newPTSM.TrainerName;
					orgPTSM.SubjectTitle = newPTSM.SubjectTitle;
					orgPTSM.SubjectContent = newPTSM.SubjectContent;
					orgPTSM.NumsofTrainees = newPTSM.NumsofTrainees;
					orgPTSM.RigId = newPTSM.RigId;
					orgPTSM.Date = newPTSM.Date;
					orgPTSM.Time = newPTSM.Time;
					orgPTSM.IsDeleted = newPTSM.IsDeleted;
					if (attendances.Count == 1)
					{
						if (string.IsNullOrEmpty(newPTSM.Position1) && string.IsNullOrEmpty(newPTSM.Name1))
						{
							attendances[0].IsDeleted = true;
							AttendanceRepo.update(attendances[0]);
						}
						else
						{
							attendances[0].No = newPTSM.No1;
							attendances[0].Name = newPTSM.Name1;
							attendances[0].Position = newPTSM.Position1;
							attendances[0].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[0]);
						}
						if (!string.IsNullOrEmpty(newPTSM.Position2) || !string.IsNullOrEmpty(newPTSM.Name2))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No2;
							attendace2.Position = newPTSM.Position2;
							attendace2.Name = newPTSM.Name2;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position3) || !string.IsNullOrEmpty(newPTSM.Name3))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No3;
							attendace2.Position = newPTSM.Position3;
							attendace2.Name = newPTSM.Name3;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position4) || !string.IsNullOrEmpty(newPTSM.Name4))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No4;
							attendace2.Position = newPTSM.Position4;
							attendace2.Name = newPTSM.Name4;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position5) || !string.IsNullOrEmpty(newPTSM.Name5))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No5;
							attendace2.Position = newPTSM.Position5;
							attendace2.Name = newPTSM.Name5;
							AttendanceRepo.create(attendace2);

						}

					}
					else if (attendances.Count == 2)
					{
						if (string.IsNullOrEmpty(newPTSM.Position1) && string.IsNullOrEmpty(newPTSM.Name1) )
						{
							attendances[0].IsDeleted = true;
							AttendanceRepo.update(attendances[0]);
						}
						else
						{
							attendances[0].No = newPTSM.No1;
							attendances[0].Position = newPTSM.Position1;
							attendances[0].Name = newPTSM.Name1;
							attendances[0].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[0]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position2) && string.IsNullOrEmpty(newPTSM.Name2) )
						{
							attendances[1].IsDeleted = true;
							AttendanceRepo.update(attendances[1]);
						}
						else
						{
							attendances[1].No = newPTSM.No2;
							attendances[1].Position = newPTSM.Position2;
							attendances[1].Name = newPTSM.Name2;
							attendances[1].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[1]);
						}


						attendances[0].No = newPTSM.No1;
						attendances[0].Position = newPTSM.Position1;
						attendances[0].Name = newPTSM.Name1;
						attendances[0].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[0]);

						attendances[1].No = newPTSM.No2;
						attendances[1].Position = newPTSM.Position2;
						attendances[1].Name = newPTSM.Name2;
						attendances[1].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[1]);

						if (!string.IsNullOrEmpty(newPTSM.Position3)
						|| !string.IsNullOrEmpty(newPTSM.Name3))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No3;
							attendace2.Position = newPTSM.Position3;
							attendace2.Name = newPTSM.Name3;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position4)
						|| !string.IsNullOrEmpty(newPTSM.Name4))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No1;
							attendace2.Position = newPTSM.Position4;
							attendace2.Name = newPTSM.Name4;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position5) || !string.IsNullOrEmpty(newPTSM.Name5))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No5;
							attendace2.Position = newPTSM.Position5;
							attendace2.Name = newPTSM.Name5;
							AttendanceRepo.create(attendace2);

						}
					}

					else if (attendances.Count == 3)
					{
						if (string.IsNullOrEmpty(newPTSM.Position1) && string.IsNullOrEmpty(newPTSM.Name1) )
						{
							attendances[0].IsDeleted = true;
							AttendanceRepo.update(attendances[0]);
						}
						else
						{
							attendances[0].No = newPTSM.No1;
							attendances[0].Position = newPTSM.Position1;
							attendances[0].Name = newPTSM.Name1;
							attendances[0].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[0]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position2) && string.IsNullOrEmpty(newPTSM.Name2) )
						{
							attendances[1].IsDeleted = true;
							AttendanceRepo.update(attendances[1]);
						}
						else
						{
							attendances[1].No = newPTSM.No2;
							attendances[1].Position = newPTSM.Position2;
							attendances[1].Name = newPTSM.Name2;
							attendances[1].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[1]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position3) && string.IsNullOrEmpty(newPTSM.Name3) )
						{
							attendances[2].IsDeleted = true;
							AttendanceRepo.update(attendances[2]);
						}
						else
						{
							attendances[2].No = newPTSM.No3;
							attendances[2].Position = newPTSM.Position3;
							attendances[2].Name = newPTSM.Name3;
							attendances[2].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[2]);
						}


						attendances[0].No = newPTSM.No1;
						attendances[0].Position = newPTSM.Position1;
						attendances[0].Name = newPTSM.Name1;
						attendances[0].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[0]);

						attendances[1].No = newPTSM.No2;
						attendances[1].Position = newPTSM.Position2;
						attendances[1].Name = newPTSM.Name2;
						attendances[1].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[1]);

						attendances[2].No = newPTSM.No3;
						attendances[2].Position = newPTSM.Position3;
						attendances[2].Name = newPTSM.Name3;
						attendances[2].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[2]);

						if (!string.IsNullOrEmpty(newPTSM.Position4) || !string.IsNullOrEmpty(newPTSM.Name4))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No4;
							attendace2.Position = newPTSM.Position4;
							attendace2.Name = newPTSM.Name4;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position5) || !string.IsNullOrEmpty(newPTSM.Name5))

						{
							Attendance attendace2 = new Attendance();
							attendace2.PTSMId = newPTSM.Id;
							attendace2.No = newPTSM.No5;
							attendace2.Position = newPTSM.Position5;
							attendace2.Name = newPTSM.Name5;
							AttendanceRepo.create(attendace2);

						}
					}

					else if (attendances.Count == 4)
					{
						if (string.IsNullOrEmpty(newPTSM.Position1) && string.IsNullOrEmpty(newPTSM.Name1) )
						{
							attendances[0].IsDeleted = true;
							AttendanceRepo.update(attendances[0]);
						}
						else
						{
							attendances[0].No = newPTSM.No1;
							attendances[0].Position = newPTSM.Position1;
							attendances[0].Name = newPTSM.Name1;
							attendances[0].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[0]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position2) && string.IsNullOrEmpty(newPTSM.Name2) )
						{
							attendances[1].IsDeleted = true;
							AttendanceRepo.update(attendances[1]);
						}
						else
						{
							attendances[1].No = newPTSM.No2;
							attendances[1].Position = newPTSM.Position2;
							attendances[1].Name = newPTSM.Name2;
							attendances[1].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[1]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position3) && string.IsNullOrEmpty(newPTSM.Name3) )
						{
							attendances[2].IsDeleted = true;
							AttendanceRepo.update(attendances[2]);
						}
						else
						{
							attendances[2].No = newPTSM.No3;
							attendances[2].Position = newPTSM.Position3;
							attendances[2].Name = newPTSM.Name3;
							attendances[2].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[2]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position4) && string.IsNullOrEmpty(newPTSM.Name4) )
						{
							attendances[3].IsDeleted = true;
							AttendanceRepo.update(attendances[3]);
						}
						else
						{
							attendances[3].No = newPTSM.No4;
							attendances[3].Position = newPTSM.Position4;
							attendances[3].Name = newPTSM.Name4;
							attendances[3].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[3]);
						}

						attendances[0].No = newPTSM.No1;
						attendances[0].Position = newPTSM.Position1;
						attendances[0].Name = newPTSM.Name1;
						attendances[0].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[0]);

						attendances[1].No = newPTSM.No2;
						attendances[1].Position = newPTSM.Position2;
						attendances[1].Name = newPTSM.Name2;
						attendances[1].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[1]);

						attendances[2].No = newPTSM.No3;
						attendances[2].Position = newPTSM.Position3;
						attendances[2].Name = newPTSM.Name3;
						attendances[2].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[2]);

						attendances[3].No = newPTSM.No4;
						attendances[3].Position = newPTSM.Position4;
						attendances[3].Name = newPTSM.Name4;
						attendances[3].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[3]);

						if (!string.IsNullOrEmpty(newPTSM.Position5) || !string.IsNullOrEmpty(newPTSM.Name5))

						{
							Attendance attendace2 = new Attendance();
							attendace2.No = newPTSM.No5;
							attendace2.Position = newPTSM.Position5;
							attendace2.PTSMId = newPTSM.Id;
							attendace2.Name = newPTSM.Name5;
							AttendanceRepo.create(attendace2);

						}
					}
					else if (attendances.Count == 5)
					{
						if (string.IsNullOrEmpty(newPTSM.Position1) && string.IsNullOrEmpty(newPTSM.Name1) )
						{
							attendances[0].IsDeleted = true;
							AttendanceRepo.update(attendances[0]);
						}
						else
						{
							attendances[0].No = newPTSM.No1;
							attendances[0].Position = newPTSM.Position1;
							attendances[0].Name = newPTSM.Name1;
							attendances[0].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[0]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position2) && string.IsNullOrEmpty(newPTSM.Name2) )
						{
							attendances[1].IsDeleted = true;
							AttendanceRepo.update(attendances[1]);
						}
						else
						{
							attendances[1].No = newPTSM.No2;
							attendances[1].Position = newPTSM.Position2;
							attendances[1].Name = newPTSM.Name2;
							attendances[1].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[1]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position3) && string.IsNullOrEmpty(newPTSM.Name3) )
						{
							attendances[2].IsDeleted = true;
							AttendanceRepo.update(attendances[2]);
						}
						else
						{
							attendances[2].No = newPTSM.No3;
							attendances[2].Position = newPTSM.Position3;
							attendances[2].Name = newPTSM.Name3;
							attendances[2].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[2]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position4) && string.IsNullOrEmpty(newPTSM.Name4) )
						{
							attendances[3].IsDeleted = true;
							AttendanceRepo.update(attendances[3]);
						}
						else
						{
							attendances[3].No = newPTSM.No4;
							attendances[3].Position = newPTSM.Position4;
							attendances[3].Name = newPTSM.Name4;
							attendances[3].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[3]);
						}

						if (string.IsNullOrEmpty(newPTSM.Position5) && string.IsNullOrEmpty(newPTSM.Name5) )
						{
							attendances[4].IsDeleted = true;
							AttendanceRepo.update(attendances[4]);
						}
						else
						{
							attendances[4].No = newPTSM.No5;
							attendances[4].Position = newPTSM.Position5;
							attendances[4].Name = newPTSM.Name5;
							attendances[4].PTSMId = newPTSM.Id;
							AttendanceRepo.update(attendances[4]);
						}
						attendances[0].No = newPTSM.No1;
						attendances[0].Position = newPTSM.Position1;
						attendances[0].Name = newPTSM.Name1;
						attendances[0].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[0]);

						attendances[1].No = newPTSM.No2;
						attendances[1].Position = newPTSM.Position2;
						attendances[1].Name = newPTSM.Name2;
						attendances[1].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[1]);

						attendances[2].No = newPTSM.No3;
						attendances[2].Position = newPTSM.Position3;
						attendances[2].Name = newPTSM.Name3;
						attendances[2].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[2]);

						attendances[3].No = newPTSM.No4;
						attendances[3].Position = newPTSM.Position4;
						attendances[3].Name = newPTSM.Name4;
						attendances[3].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[3]);

						attendances[4].No = newPTSM.No5;
						attendances[4].Position = newPTSM.Position5;
						attendances[4].Name = newPTSM.Name5;
						attendances[4].PTSMId = newPTSM.Id;
						AttendanceRepo.update(attendances[4]);
					}
					else if (attendances.Count == 0)
					{
						if (!string.IsNullOrEmpty(newPTSM.Position1) || !string.IsNullOrEmpty(newPTSM.Name1))

						{
							Attendance attendace2 = new Attendance();
							attendace2.No = newPTSM.No1;
							attendace2.Position = newPTSM.Position1;
							attendace2.PTSMId = newPTSM.Id;
							attendace2.Name = newPTSM.Name1;
							AttendanceRepo.create(attendace2);

						}

						if (!string.IsNullOrEmpty(newPTSM.Position2) || !string.IsNullOrEmpty(newPTSM.Name2))

						{
							Attendance attendace2 = new Attendance();
							attendace2.No = newPTSM.No2;
							attendace2.Position = newPTSM.Position2;
							attendace2.PTSMId = newPTSM.Id;
							attendace2.Name = newPTSM.Name2;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position3) || !string.IsNullOrEmpty(newPTSM.Name3))

						{
							Attendance attendace2 = new Attendance();
							attendace2.No = newPTSM.No3;
							attendace2.Position = newPTSM.Position3;
							attendace2.PTSMId = newPTSM.Id;
							attendace2.Name = newPTSM.Name3;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position4) || !string.IsNullOrEmpty(newPTSM.Name4))

						{
							Attendance attendace2 = new Attendance();
							attendace2.No = newPTSM.No1;
							attendace2.Position = newPTSM.Position4;
							attendace2.PTSMId = newPTSM.Id;
							attendace2.Name = newPTSM.Name4;
							AttendanceRepo.create(attendace2);

						}
						if (!string.IsNullOrEmpty(newPTSM.Position5) || !string.IsNullOrEmpty(newPTSM.Name5))

						{
							Attendance attendace2 = new Attendance();
							attendace2.No = newPTSM.No5;
							attendace2.Position = newPTSM.Position5;
							attendace2.PTSMId = newPTSM.Id;
							attendace2.Name = newPTSM.Name5;
							AttendanceRepo.create(attendace2);

						}


					}

					PTSMRepo.update(orgPTSM);
					result.Message = "Success";
					result.Data = orgPTSM;
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


		[HttpPost]
		public ActionResult<ResultDTO> AddPTSM(PTSMDTO PTSMDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					PTSM PTSM = new PTSM();
					PTSM.Id = PTSMDTO.Id;
					PTSM.TrainerName = PTSMDTO.TrainerName;
					PTSM.SubjectTitle = PTSMDTO.SubjectTitle;
					PTSM.SubjectContent = PTSMDTO.SubjectContent;
					PTSM.NumsofTrainees = PTSMDTO.NumsofTrainees;
					PTSM.RigId = PTSMDTO.RigId;
					PTSM.Date = PTSMDTO.Date;
					PTSM.Time = PTSMDTO.Time;
					PTSM.UserId = PTSMDTO.UserId;
					PTSM.IsDeleted = PTSMDTO.IsDeleted;

					PTSMRepo.create(PTSM);
								

					if (!string.IsNullOrEmpty(PTSMDTO.Position1) || !string.IsNullOrEmpty(PTSMDTO.Name1))
					{
						Attendance attendance = new Attendance();
						attendance.Name= PTSMDTO.Name1;
						attendance.Position= PTSMDTO.Position1;
						attendance.No = PTSMDTO.No1;
						attendance.PTSMId = PTSM.Id;
						attendance.IsDeleted = false;

						AttendanceRepo.create(attendance);
					}

					if (!string.IsNullOrEmpty(PTSMDTO.Position2) || !string.IsNullOrEmpty(PTSMDTO.Name2))

					{
						Attendance attendance = new Attendance();
						attendance.Name = PTSMDTO.Name2;
						attendance.Position = PTSMDTO.Position2;
						attendance.No = PTSMDTO.No2;
						attendance.PTSMId = PTSM.Id;
						attendance.IsDeleted = false;

						AttendanceRepo.create(attendance);

					}


					if (!string.IsNullOrEmpty(PTSMDTO.Position3) || !string.IsNullOrEmpty(PTSMDTO.Name3))

					{
						Attendance attendance = new Attendance();
						attendance.Name = PTSMDTO.Name3;
						attendance.Position = PTSMDTO.Position3;
						attendance.No = PTSMDTO.No3;
						attendance.PTSMId = PTSM.Id;
						attendance.IsDeleted = false;

						AttendanceRepo.create(attendance);

					}

					if (!string.IsNullOrEmpty(PTSMDTO.Position4) || !string.IsNullOrEmpty(PTSMDTO.Name4))

					{
						Attendance attendance = new Attendance();
						attendance.Name = PTSMDTO.Name4;
						attendance.Position = PTSMDTO.Position4;
						attendance.No = PTSMDTO.No4;
						attendance.PTSMId = PTSM.Id;
						attendance.IsDeleted = false;

						AttendanceRepo.create(attendance);

					}

					if (!string.IsNullOrEmpty(PTSMDTO.Position5) ||	!string.IsNullOrEmpty(PTSMDTO.Name5))

					{
						Attendance attendance = new Attendance();
						attendance.Name = PTSMDTO.Name5;
						attendance.Position = PTSMDTO.Position5;
						attendance.No = PTSMDTO.No5;
						attendance.PTSMId = PTSM.Id;
						attendance.IsDeleted = false;

						AttendanceRepo.create(attendance);

					}

					result.Message = "Success";
					result.Data = PTSMDTO;
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

		[HttpGet("GetAllPTSMWithDataByDate/{date:DateTime}")]
		public ActionResult<ResultDTO> GetAllPTSMWithDataByDate(DateTime date, string UserID, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<PTSMResponseDTO> PTSMResponseDTOs = new List<PTSMResponseDTO>();
					List<PTSM> PTSMs = PTSMRepository.getall().Where(a => a.Date == date).ToList();

					foreach (PTSM PTSM in PTSMs)
					{
						PTSMResponseDTO PTSMResponseDTO = new PTSMResponseDTO();
						PTSMResponseDTO.Id = PTSM.Id;
						PTSMResponseDTO.TrainerName = PTSM.TrainerName;
						PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
						PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
						PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
						PTSMResponseDTO.RigNumber = PTSM.Rig.Number;
						PTSMResponseDTO.UserName = PTSM.user.UserName;
						PTSMResponseDTO.Date = PTSM.Date;
						PTSMResponseDTO.Time = PTSM.Time;
						PTSMResponseDTO.IsDeleted = PTSM.IsDeleted;

						List<Attendance> attendances = AttendanceRepo.getall().Where(p => p.PTSMId == PTSM.Id).ToList();
						foreach (Attendance No in attendances)
						{
							AttendanceDTO attendanceDTO = new AttendanceDTO();
							attendanceDTO.Id = No.Id;
							attendanceDTO.Name = No.Name;
							attendanceDTO.No = No.No;
							attendanceDTO.Position = No.Position;
							attendanceDTO.PTSMId = No.PTSMId;
							PTSMResponseDTO.AttendancesDTO.Add(attendanceDTO);
						}

						PTSMResponseDTOs.Add(PTSMResponseDTO);



					}
					result.Message = "Success";
					result.Data = PTSMResponseDTOs;
					result.Statescode = 200;
					return result;

				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<PTSMResponseDTO> PTSMResponseDTOs = new List<PTSMResponseDTO>();
					List<PTSM> PTSMs = PTSMRepository.getall().Where(a => a.Date == date&&a.user.Id==UserID).ToList();

					foreach (PTSM PTSM in PTSMs)
					{
						PTSMResponseDTO PTSMResponseDTO = new PTSMResponseDTO();
						PTSMResponseDTO.Id = PTSM.Id;
						PTSMResponseDTO.TrainerName = PTSM.TrainerName;
						PTSMResponseDTO.SubjectTitle = PTSM.SubjectTitle;
						PTSMResponseDTO.SubjectContent = PTSM.SubjectContent;
						PTSMResponseDTO.NumsofTrainees = PTSM.NumsofTrainees;
						PTSMResponseDTO.RigNumber = PTSM.Rig.Number;
						PTSMResponseDTO.UserName = PTSM.user.UserName;
						PTSMResponseDTO.Date = PTSM.Date;
						PTSMResponseDTO.Time = PTSM.Time;
						PTSMResponseDTO.IsDeleted = PTSM.IsDeleted;

						List<Attendance> attendances = AttendanceRepo.getall().Where(p => p.PTSMId == PTSM.Id).ToList();
						foreach (Attendance No in attendances)
						{
							AttendanceDTO attendanceDTO = new AttendanceDTO();
							attendanceDTO.Id = No.Id;
							attendanceDTO.Name = No.Name;
							attendanceDTO.No = No.No;
							attendanceDTO.Position = No.Position;
							attendanceDTO.PTSMId = No.PTSMId;
							PTSMResponseDTO.AttendancesDTO.Add(attendanceDTO);
						}

						PTSMResponseDTOs.Add(PTSMResponseDTO);



					}

					result.Message = "Success";
					result.Data = PTSMResponseDTOs;
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
				PTSM PTSM = PTSMRepo.getbyid(id);
				List<Attendance> attendances = AttendanceRepo.getall().Where(p => p.PTSMId == id).ToList();

				PTSM.IsDeleted = true;
				PTSMRepo.update(PTSM);
				foreach (var No in attendances)
				{
					No.IsDeleted = true;
					AttendanceRepo.update(No);
				}
				result.Data = PTSM;
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

