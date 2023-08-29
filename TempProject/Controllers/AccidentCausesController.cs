using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AccidentCausesController : ControllerBase
    {
        public IRepository<AccidentCauses> AccidentCausesRepo { get; set; }

        public AccidentCausesController(IRepository<AccidentCauses> _AccidentCausesRepo)
        {
            this.AccidentCausesRepo = _AccidentCausesRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<AccidentCauses> temp = AccidentCausesRepo.getall();
            List<AccidentCausesDTO> newTemp = new List<AccidentCausesDTO>();
            foreach (AccidentCauses accidentCauses in temp)
            {
                AccidentCausesDTO accidentCausesDTO = new AccidentCausesDTO();
                accidentCausesDTO.Id = accidentCauses.Id;
                accidentCausesDTO.Name = accidentCauses.Name;
                accidentCausesDTO.IsDeleted = accidentCauses.IsDeleted;

                newTemp.Add(accidentCausesDTO);
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

			List<AccidentCauses> temp = AccidentCausesRepo.getall();
			List<AccidentCausesExcelDTO> newTemp = new List<AccidentCausesExcelDTO>();
			foreach (AccidentCauses accidentCauses in temp)
			{
				AccidentCausesExcelDTO accidentCausesDTO = new AccidentCausesExcelDTO();
				accidentCausesDTO.Id = accidentCauses.Id;
				accidentCausesDTO.Name = accidentCauses.Name;

				newTemp.Add(accidentCausesDTO);
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
		public PageResult<AccidentCausesDTO> GettAllAccidentCausesByPage(int? page, int pagesize = 10)
		{
			List<AccidentCauses> temp = AccidentCausesRepo.getall();
			List<AccidentCausesDTO> newTemp = new List<AccidentCausesDTO>();
			foreach (AccidentCauses accidentCauses in temp)
			{
				AccidentCausesDTO accidentCausesDTO = new AccidentCausesDTO();
				accidentCausesDTO.Id = accidentCauses.Id;
				accidentCausesDTO.Name = accidentCauses.Name;
				accidentCausesDTO.IsDeleted = accidentCauses.IsDeleted;

				newTemp.Add(accidentCausesDTO);
			}

			float countDetails = AccidentCausesRepo.getall().Count();
			var result = new PageResult<AccidentCausesDTO>
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
                AccidentCausesDTO accidentCausesDTO = new AccidentCausesDTO();
                AccidentCauses accidentCauses = AccidentCausesRepo.getbyid(ID);
                accidentCausesDTO.Id = accidentCauses.Id;
                accidentCausesDTO.Name = accidentCauses.Name;
                accidentCausesDTO.IsDeleted = accidentCauses.IsDeleted;

                result.Message = "Success";
                result.Data = accidentCausesDTO;
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
        public ActionResult<ResultDTO> Put(int id, AccidentCausesDTO newAccidentCauses) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    AccidentCauses orgAccidentCauses = AccidentCausesRepo.getbyid(id);
                    newAccidentCauses.Id = orgAccidentCauses.Id;
                    orgAccidentCauses.Name = newAccidentCauses.Name;
                    orgAccidentCauses.IsDeleted = newAccidentCauses.IsDeleted;


                    AccidentCausesRepo.update(orgAccidentCauses);
                    result.Message = "Success";
                    result.Data = orgAccidentCauses;
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
        public ActionResult<ResultDTO> AddAccidentCauses(AccidentCausesDTO AccidentCausesDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    AccidentCauses accidentCauses = new AccidentCauses();
                    accidentCauses.Id = AccidentCausesDTO.Id;
                    accidentCauses.Name = AccidentCausesDTO.Name;
                    accidentCauses.IsDeleted = AccidentCausesDTO.IsDeleted;

                    AccidentCausesRepo.create(accidentCauses);
                    result.Data = AccidentCausesDTO;
                    result.Statescode = 200;
                    result.Message = "Success";

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
                AccidentCauses accidentCauses = AccidentCausesRepo.getbyid(id);
                accidentCauses.IsDeleted = true;
                AccidentCausesRepo.update(accidentCauses);
                result.Data = accidentCauses;
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
