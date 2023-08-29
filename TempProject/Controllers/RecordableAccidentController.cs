using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordableAccidentController : ControllerBase
    {
        public IRepository<RecordableAccident> RecordableAccidentRepo { get; set; }

        public RecordableAccidentController(IRepository<RecordableAccident> _RecordableAccidentRepo)
        {
            this.RecordableAccidentRepo = _RecordableAccidentRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<RecordableAccident> temp = RecordableAccidentRepo.getall();
            List<RecordableAccidentDTO> newTemp = new List<RecordableAccidentDTO>();
            foreach (RecordableAccident RecordableAccident in temp)
            {
                RecordableAccidentDTO RecordableAccidentDTO = new RecordableAccidentDTO();
                RecordableAccidentDTO.id = RecordableAccident.Id;
				RecordableAccidentDTO.AccidentType = RecordableAccident.AccidentType;
				RecordableAccidentDTO.IsDeleted = RecordableAccident.IsDeleted;

				newTemp.Add(RecordableAccidentDTO);
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
                RecordableAccidentDTO RecordableAccidentDTO = new RecordableAccidentDTO();
                RecordableAccident RecordableAccident = RecordableAccidentRepo.getbyid(ID);
                RecordableAccidentDTO.id = RecordableAccident.Id;
				RecordableAccidentDTO.AccidentType = RecordableAccident.AccidentType;
				RecordableAccidentDTO.IsDeleted = RecordableAccident.IsDeleted;

				result.Message = "Success";
                result.Data = RecordableAccidentDTO;
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
        public ActionResult<ResultDTO> Put(int id, RecordableAccidentDTO newRecordableAccident) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    RecordableAccident orgRecordableAccident = RecordableAccidentRepo.getbyid(id);
                    newRecordableAccident.id = orgRecordableAccident.Id;
					orgRecordableAccident.AccidentType = newRecordableAccident.AccidentType;
					orgRecordableAccident.IsDeleted = newRecordableAccident.IsDeleted;


					RecordableAccidentRepo.update(orgRecordableAccident);
                    result.Message = "Success";
                    result.Data = orgRecordableAccident;
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
        public ActionResult<ResultDTO> AddRecordableAccident(RecordableAccidentDTO RecordableAccidentDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    RecordableAccident RecordableAccident = new RecordableAccident();
                    RecordableAccident.Id = RecordableAccidentDTO.id;
					RecordableAccident.AccidentType = RecordableAccidentDTO.AccidentType;
					RecordableAccident.IsDeleted = RecordableAccidentDTO.IsDeleted;

					RecordableAccidentRepo.create(RecordableAccident);
                    result.Message = "Success";
                    result.Data = RecordableAccidentDTO;
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
                RecordableAccident recordableAccident = RecordableAccidentRepo.getbyid(id);
                recordableAccident.IsDeleted = true;
                RecordableAccidentRepo.update(recordableAccident);
                result.Data = recordableAccident;
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
