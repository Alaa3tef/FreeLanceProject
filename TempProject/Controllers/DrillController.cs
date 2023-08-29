using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillController : ControllerBase
    {
        public IRepository<Drill> DrillRepo { get; set; }

        public DrillController(IRepository<Drill> _DrillRepo)
        {
            this.DrillRepo = _DrillRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<Drill> temp = DrillRepo.getall();
            List<DrillDTO> newTemp = new List<DrillDTO>();
            foreach (Drill Drill in temp)
            {
                DrillDTO DrillDTO = new DrillDTO();
                DrillDTO.id = Drill.Id;
				DrillDTO.DrillType = Drill.DrillType;
				DrillDTO.IsDeleted = Drill.IsDeleted;

				newTemp.Add(DrillDTO);
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
                DrillDTO DrillDTO = new DrillDTO();
                Drill Drill = DrillRepo.getbyid(ID);
                DrillDTO.id = Drill.Id;
				DrillDTO.DrillType = Drill.DrillType;
				DrillDTO.IsDeleted = Drill.IsDeleted;

				result.Message = "Success";
                result.Data = DrillDTO;
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
        public ActionResult<ResultDTO> Put(int id, [FromForm] DrillDTO newDrill) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Drill orgDrill = DrillRepo.getbyid(id);
                    newDrill.id = orgDrill.Id;
					orgDrill.DrillType = newDrill.DrillType;
					orgDrill.IsDeleted = newDrill.IsDeleted;


					DrillRepo.update(orgDrill);
                    result.Message = "Success";
                    result.Data = orgDrill;
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
        public ActionResult<ResultDTO> AddDrill(DrillDTO DrillDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Drill Drill = new Drill();
                    Drill.Id = DrillDTO.id;
					Drill.DrillType = DrillDTO.DrillType;
					Drill.IsDeleted = DrillDTO.IsDeleted;

					DrillRepo.create(Drill);
                    result.Message = "Success";
                    result.Data = DrillDTO;
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
                Drill drill = DrillRepo.getbyid(id);
                drill.IsDeleted = true;
                DrillRepo.update(drill);
                result.Data = drill;
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
