using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportedByPositionController : ControllerBase
    {
        public IRepository<ReportedByPosition> ReportedByPositionRepo { get; set; }

        public ReportedByPositionController(IRepository<ReportedByPosition> _ReportedByPositionRepo)
        {
            this.ReportedByPositionRepo = _ReportedByPositionRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<ReportedByPosition> temp = ReportedByPositionRepo.getall();
            List<ReportedByPositionDTO> newTemp = new List<ReportedByPositionDTO>();
            foreach (ReportedByPosition ReportedByPosition in temp)
            {
                ReportedByPositionDTO ReportedByPositionDTO = new ReportedByPositionDTO();
                ReportedByPositionDTO.Id = ReportedByPosition.Id;
                ReportedByPositionDTO.Name = ReportedByPosition.Name;
                ReportedByPositionDTO.IsDeleted = ReportedByPosition.IsDeleted;

                newTemp.Add(ReportedByPositionDTO);
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
		public PageResult<ReportedByPositionDTO> GettAllReportedByPositionByPage(int? page, int pagesize = 10)
		{
			List<ReportedByPosition> temp = ReportedByPositionRepo.getall();
			List<ReportedByPositionDTO> newTemp = new List<ReportedByPositionDTO>();
			foreach (ReportedByPosition ReportedByPosition in temp)
			{
				ReportedByPositionDTO ReportedByPositionDTO = new ReportedByPositionDTO();
				ReportedByPositionDTO.Id = ReportedByPosition.Id;
				ReportedByPositionDTO.Name = ReportedByPosition.Name;
				ReportedByPositionDTO.IsDeleted = ReportedByPosition.IsDeleted;

				newTemp.Add(ReportedByPositionDTO);
			}

			float countDetails = ReportedByPositionRepo.getall().Count();
			var result = new PageResult<ReportedByPositionDTO>
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
                ReportedByPositionDTO ReportedByPositionDTO = new ReportedByPositionDTO();
                ReportedByPosition ReportedByPosition = ReportedByPositionRepo.getbyid(ID);
                ReportedByPositionDTO.Id = ReportedByPosition.Id;
                ReportedByPositionDTO.Name = ReportedByPosition.Name;
                ReportedByPositionDTO.IsDeleted = ReportedByPosition.IsDeleted;

                result.Message = "Success";
                result.Data = ReportedByPositionDTO;
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
        public ActionResult<ResultDTO> Put(int id, ReportedByPositionDTO newReportedByPosition) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ReportedByPosition orgReportedByPosition = ReportedByPositionRepo.getbyid(id);
                    newReportedByPosition.Id = orgReportedByPosition.Id;
                    orgReportedByPosition.Name = newReportedByPosition.Name;
                    orgReportedByPosition.IsDeleted = newReportedByPosition.IsDeleted;


                    ReportedByPositionRepo.update(orgReportedByPosition);
                    result.Message = "Success";
                    result.Data = orgReportedByPosition;
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
        public ActionResult<ResultDTO> AddReportedByPosition(ReportedByPositionDTO ReportedByPositionDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ReportedByPosition ReportedByPosition = new ReportedByPosition();
                    ReportedByPosition.Id = ReportedByPositionDTO.Id;
                    ReportedByPosition.Name = ReportedByPositionDTO.Name;
                    ReportedByPosition.IsDeleted = ReportedByPositionDTO.IsDeleted;

                    ReportedByPositionRepo.create(ReportedByPosition);
                    result.Message = "Success";
                    result.Data = ReportedByPositionDTO;
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
                ReportedByPosition reportedByPosition = ReportedByPositionRepo.getbyid(id);
                reportedByPosition.IsDeleted = true;
                ReportedByPositionRepo.update(reportedByPosition);
                result.Data = reportedByPosition;
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
