using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NonRecordableAccidentController : ControllerBase
    {
        public IRepository<NonRecordableAccident> NonRecordableAccidentRepo { get; set; }

        public NonRecordableAccidentController(IRepository<NonRecordableAccident> _NonRecordableAccidentRepo)
        {
            this.NonRecordableAccidentRepo = _NonRecordableAccidentRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<NonRecordableAccident> temp = NonRecordableAccidentRepo.getall();
            List<NonRecordableAccidentDTO> newTemp = new List<NonRecordableAccidentDTO>();
            foreach (NonRecordableAccident NonRecordableAccident in temp)
            {
                NonRecordableAccidentDTO NonRecordableAccidentDTO = new NonRecordableAccidentDTO();
                NonRecordableAccidentDTO.id = NonRecordableAccident.Id;
				NonRecordableAccidentDTO.AccidentType = NonRecordableAccident.AccidentType;
				NonRecordableAccidentDTO.IsDeleted = NonRecordableAccident.IsDeleted;

				newTemp.Add(NonRecordableAccidentDTO);
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
                NonRecordableAccidentDTO NonRecordableAccidentDTO = new NonRecordableAccidentDTO();
                NonRecordableAccident NonRecordableAccident = NonRecordableAccidentRepo.getbyid(ID);
                NonRecordableAccidentDTO.id = NonRecordableAccident.Id;
				NonRecordableAccidentDTO.AccidentType = NonRecordableAccident.AccidentType;
				NonRecordableAccidentDTO.IsDeleted = NonRecordableAccident.IsDeleted;

				result.Message = "Success";
                result.Data = NonRecordableAccidentDTO;
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
        public ActionResult<ResultDTO> Put(int id, [FromForm] NonRecordableAccidentDTO newNonRecordableAccident) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    NonRecordableAccident orgNonRecordableAccident = NonRecordableAccidentRepo.getbyid(id);
                    newNonRecordableAccident.id = orgNonRecordableAccident.Id;
					orgNonRecordableAccident.AccidentType = newNonRecordableAccident.AccidentType;
					orgNonRecordableAccident.IsDeleted = newNonRecordableAccident.IsDeleted;


					NonRecordableAccidentRepo.update(orgNonRecordableAccident);
                    result.Message = "Success";
                    result.Data = orgNonRecordableAccident;
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
        public ActionResult<ResultDTO> AddNonRecordableAccident(NonRecordableAccidentDTO NonRecordableAccidentDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    NonRecordableAccident NonRecordableAccident = new NonRecordableAccident();
                    NonRecordableAccident.Id = NonRecordableAccidentDTO.id;
					NonRecordableAccident.AccidentType = NonRecordableAccidentDTO.AccidentType;
					NonRecordableAccident.IsDeleted = NonRecordableAccidentDTO.IsDeleted;

					NonRecordableAccidentRepo.create(NonRecordableAccident);
                    result.Message = "Success";
                    result.Data = NonRecordableAccidentDTO;
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
                NonRecordableAccident nonRecordableAccident = NonRecordableAccidentRepo.getbyid(id);
                nonRecordableAccident.IsDeleted = true;
                NonRecordableAccidentRepo.update(nonRecordableAccident);
                result.Data = nonRecordableAccident;
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
