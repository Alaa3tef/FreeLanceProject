using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportedByNameController : ControllerBase
    {
        public IRepository<ReportedByName> ReportedByNameRepo { get; set; }
		public IRepository<ReportedByPosition> ReportedByPositionRepo { get; set; }


		public ReportedByNameController(IRepository<ReportedByPosition> _ReportedByPositionRepo,IRepository<ReportedByName> _ReportedByNameRepo)
        {
			this.ReportedByNameRepo = _ReportedByNameRepo;
			this.ReportedByPositionRepo = _ReportedByPositionRepo;
		}
		[HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<ReportedByName> temp = ReportedByNameRepo.getall();
            List<ReportedByNameDTO> newTemp = new List<ReportedByNameDTO>();
            foreach (ReportedByName ReportedByName in temp)
            {
                ReportedByNameDTO ReportedByNameDTO = new ReportedByNameDTO();
                ReportedByNameDTO.Id = ReportedByName.Id;
				ReportedByNameDTO.Name = ReportedByName.Name;
				ReportedByNameDTO.EmpCode = ReportedByName.EmpCode;
				ReportedByNameDTO.PositionId = ReportedByName.PositionId;
				ReportedByNameDTO.IsDeleted = ReportedByName.IsDeleted;

                newTemp.Add(ReportedByNameDTO);
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

		[HttpGet("GetAllForExcel")]
		public ActionResult<ResultDTO> GetAllForExcel()
		{

			ResultDTO result = new ResultDTO();

			List<ReportedByName> temp = ReportedByNameRepo.getall();
			List<ReportedByNameExcelDTO> newTemp = new List<ReportedByNameExcelDTO>();
			foreach (ReportedByName ReportedByName in temp)
			{
				ReportedByNameExcelDTO ReportedByNameDTO = new ReportedByNameExcelDTO();
				ReportedByNameDTO.Id = ReportedByName.Id;
				ReportedByNameDTO.Name = ReportedByName.Name;
				ReportedByNameDTO.EmpCode = ReportedByName.EmpCode;
				ReportedByNameDTO.Position = ReportedByPositionRepo.getbyid(ReportedByName.PositionId).Name;

				newTemp.Add(ReportedByNameDTO);
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
		public PageResult<ReportedByNameDTO> GettAllReportedByNameByPage(int? page, int pagesize = 10)
		{
			List<ReportedByName> temp = ReportedByNameRepo.getall();
			List<ReportedByNameDTO> newTemp = new List<ReportedByNameDTO>();
			foreach (ReportedByName ReportedByName in temp)
			{
				ReportedByNameDTO ReportedByNameDTO = new ReportedByNameDTO();
				ReportedByNameDTO.Id = ReportedByName.Id;
				ReportedByNameDTO.Name = ReportedByName.Name;
				ReportedByNameDTO.EmpCode = ReportedByName.EmpCode;
				ReportedByNameDTO.PositionId = ReportedByName.PositionId;
				ReportedByNameDTO.IsDeleted = ReportedByName.IsDeleted;

				newTemp.Add(ReportedByNameDTO);
			}

			float countDetails = ReportedByNameRepo.getall().Count();
			var result = new PageResult<ReportedByNameDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}

		[HttpGet("Name/{positionId:int}")]
        public ActionResult<ResultDTO> GetByPositionId(int positionId)
        {

            ResultDTO result = new ResultDTO();

            List<ReportedByName> temp = ReportedByNameRepo.getall().Where(n => n.PositionId == positionId).ToList();
            List<ReportedByNameDTO> newTemp = new List<ReportedByNameDTO>();
            foreach (ReportedByName ReportedByName in temp)
            {
                ReportedByNameDTO ReportedByNameDTO = new ReportedByNameDTO();
                ReportedByNameDTO.Id = ReportedByName.Id;
				ReportedByNameDTO.Name = ReportedByName.Name;
				ReportedByNameDTO.EmpCode = ReportedByName.EmpCode;
				ReportedByNameDTO.PositionId = ReportedByName.PositionId;
                ReportedByNameDTO.IsDeleted = ReportedByName.IsDeleted;

                newTemp.Add(ReportedByNameDTO);
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

        [HttpGet("{ID:int}")]
        public ActionResult<ResultDTO> GetByID(int ID)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                ReportedByNameDTO ReportedByNameDTO = new ReportedByNameDTO();
                ReportedByName ReportedByName = ReportedByNameRepo.getbyid(ID);
                ReportedByNameDTO.Id = ReportedByName.Id;
				ReportedByNameDTO.Name = ReportedByName.Name;
				ReportedByNameDTO.EmpCode = ReportedByName.EmpCode;
				ReportedByNameDTO.PositionId = ReportedByName.PositionId;
                ReportedByNameDTO.IsDeleted = ReportedByName.IsDeleted;

                result.Message = "Success";
                result.Data = ReportedByNameDTO;
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

		[HttpGet("Code/{empCode:int}")]
		public ActionResult<ResultDTO> GetByEmpCode(int empCode)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				ReportedByNameDTO ReportedByNameDTO = new ReportedByNameDTO();
				ReportedByName ReportedByName = ReportedByNameRepo.getall().FirstOrDefault(t => t.EmpCode == empCode);
				ReportedByNameDTO.Id = ReportedByName.Id;
				ReportedByNameDTO.Name = ReportedByName.Name;
				ReportedByNameDTO.EmpCode = ReportedByName.EmpCode;
				ReportedByNameDTO.PositionId = ReportedByName.PositionId;
				ReportedByNameDTO.IsDeleted = ReportedByName.IsDeleted;

				result.Data = ReportedByNameDTO;
				result.Message = "Success";
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
        public ActionResult<ResultDTO> Put(int id, ReportedByNameDTO newReportedByName) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ReportedByName orgReportedByName = ReportedByNameRepo.getbyid(id);
                    newReportedByName.Id = orgReportedByName.Id;
					orgReportedByName.Name = newReportedByName.Name;
					orgReportedByName.EmpCode = newReportedByName.EmpCode;
					orgReportedByName.PositionId = newReportedByName.PositionId;
                    orgReportedByName.IsDeleted = newReportedByName.IsDeleted;


                    ReportedByNameRepo.update(orgReportedByName);
                    result.Message = "Success";
                    result.Data = orgReportedByName;
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
        public ActionResult<ResultDTO> AddReportedByName(ReportedByNameDTO ReportedByNameDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ReportedByName ReportedByName = new ReportedByName();
                    ReportedByName.Id = ReportedByNameDTO.Id;
					ReportedByName.Name = ReportedByNameDTO.Name;
					ReportedByName.EmpCode = ReportedByNameDTO.EmpCode;
					ReportedByName.PositionId = ReportedByNameDTO.PositionId;
                    ReportedByName.IsDeleted = ReportedByNameDTO.IsDeleted;

                    ReportedByNameRepo.create(ReportedByName);
                    result.Message = "Success";
                    result.Data = ReportedByNameDTO;
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
                ReportedByName reportedByName = ReportedByNameRepo.getbyid(id);
                reportedByName.IsDeleted = true;
                ReportedByNameRepo.update(reportedByName);
                result.Data = reportedByName;
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
