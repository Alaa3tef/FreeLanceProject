using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttendanceController : ControllerBase
	{
		public IRepository<Attendance> AttendanceRepo { get; set; }

		public AttendanceController(IRepository<Attendance> _AttendanceRepo)
		{
			this.AttendanceRepo = _AttendanceRepo;
		}
		[HttpGet]
		public ActionResult<ResultDTO> GetAll()
		{

			ResultDTO result = new ResultDTO();

			List<Attendance> temp = AttendanceRepo.getall();
			List<AttendanceDTO> newTemp = new List<AttendanceDTO>();
			foreach (Attendance item in temp)
			{
				AttendanceDTO AttendanceDTO = new AttendanceDTO();
				AttendanceDTO.Id = item.Id;
				AttendanceDTO.Name = item.Name;
				AttendanceDTO.No = item.No;
				AttendanceDTO.Position = item.Position;
				AttendanceDTO.PTSMId = item.PTSMId;

				AttendanceDTO.IsDeleted = item.IsDeleted;

				newTemp.Add(AttendanceDTO);
			}
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

		[HttpGet("ByPage/{page:int}")]
		public PageResult<AttendanceDTO> GettAllAttendanceByPage(int? page, int pagesize = 10)
		{
			List<Attendance> temp = AttendanceRepo.getall();
			List<AttendanceDTO> newTemp = new List<AttendanceDTO>();
			foreach (Attendance Attendance in temp)
			{
				AttendanceDTO AttendanceDTO = new AttendanceDTO();
				AttendanceDTO.Id = Attendance.Id;
				AttendanceDTO.Id = Attendance.Id;
				AttendanceDTO.Name = Attendance.Name;
				AttendanceDTO.No = Attendance.No;
				AttendanceDTO.Position = Attendance.Position;
				AttendanceDTO.PTSMId = Attendance.PTSMId;

				AttendanceDTO.IsDeleted = Attendance.IsDeleted;

				newTemp.Add(AttendanceDTO);
			}

			float countDetails = AttendanceRepo.getall().Count();
			var result = new PageResult<AttendanceDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}

		[HttpGet("{ID:int}")]
		public ActionResult<ResultDTO> GetByID(int ID)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				AttendanceDTO AttendanceDTO = new AttendanceDTO();
				Attendance Attendance = AttendanceRepo.getbyid(ID);
				AttendanceDTO.Id = Attendance.Id;
				AttendanceDTO.Name = Attendance.Name;
				AttendanceDTO.No = Attendance.No;
				AttendanceDTO.Position = Attendance.Position;
				AttendanceDTO.PTSMId = Attendance.PTSMId;

				AttendanceDTO.IsDeleted = Attendance.IsDeleted;

				result.Message = "Success";
				result.Data = AttendanceDTO;
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

		[HttpPut("{id:int}")]
		public ActionResult<ResultDTO> Put(int id, AttendanceDTO newAttendance) //[FromBody] string value)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Attendance orgAttendance = AttendanceRepo.getbyid(id);
					newAttendance.Id = orgAttendance.Id;
					orgAttendance.Name = newAttendance.Name;
					orgAttendance.No = newAttendance.No;
					orgAttendance.Position = newAttendance.Position;
					orgAttendance.PTSMId = newAttendance.PTSMId;

					orgAttendance.IsDeleted = newAttendance.IsDeleted;


					AttendanceRepo.update(orgAttendance);
					result.Message = "Success";
					result.Data = orgAttendance;
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
		public ActionResult<ResultDTO> AddAttendance(AttendanceDTO AttendanceDTO)
		{
			ResultDTO result = new ResultDTO();

			if (ModelState.IsValid)
			{
				try
				{
					Attendance Attendance = new Attendance();
					Attendance.Id = AttendanceDTO.Id;
					Attendance.Name = AttendanceDTO.Name;
					Attendance.No = AttendanceDTO.No;
					Attendance.Position = AttendanceDTO.Position;
					Attendance.PTSMId = AttendanceDTO.PTSMId;
					Attendance.IsDeleted = AttendanceDTO.IsDeleted;

					AttendanceRepo.create(Attendance);
					result.Message = "Success";
					result.Data = Attendance;
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
				Attendance Attendance = AttendanceRepo.getbyid(id);
				Attendance.IsDeleted = true;
				AttendanceRepo.update(Attendance);
				result.Data = Attendance;
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
