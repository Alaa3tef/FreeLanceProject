using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : ControllerBase
    {
        public IRepository<Crew> CrewRepo { get; set; }

        public CrewController(IRepository<Crew> _CrewRepo)
        {
            this.CrewRepo = _CrewRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<Crew> temp = CrewRepo.getall();
            List<CrewDTO> newTemp = new List<CrewDTO>();
            foreach (Crew Crew in temp)
            {
                CrewDTO CrewDTO = new CrewDTO();
                CrewDTO.id = Crew.Id;
				CrewDTO.CrewName = Crew.CrewName;
				CrewDTO.IsDeleted = Crew.IsDeleted;

				newTemp.Add(CrewDTO);
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
                CrewDTO CrewDTO = new CrewDTO();
                Crew Crew = CrewRepo.getbyid(ID);
                CrewDTO.id = Crew.Id;
				CrewDTO.CrewName = Crew.CrewName;
				CrewDTO.IsDeleted = Crew.IsDeleted;

				result.Message = "Success";
                result.Data = CrewDTO;
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
        public ActionResult<ResultDTO> Put(int id, [FromForm] CrewDTO newCrew) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Crew orgCrew = CrewRepo.getbyid(id);
                    newCrew.id = orgCrew.Id;
					orgCrew.CrewName = newCrew.CrewName;
					orgCrew.IsDeleted = newCrew.IsDeleted;


					CrewRepo.update(orgCrew);
                    result.Message = "Success";
                    result.Data = orgCrew;
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
        public ActionResult<ResultDTO> AddCrew(CrewDTO CrewDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Crew Crew = new Crew();
                    Crew.Id = CrewDTO.id;
					Crew.CrewName = CrewDTO.CrewName;
					Crew.IsDeleted = CrewDTO.IsDeleted;

					CrewRepo.create(Crew);
                    result.Message = "Success";
                    result.Data = CrewDTO;
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
                Crew crew = CrewRepo.getbyid(id);
                crew.IsDeleted = true;
                CrewRepo.update(crew);
                result.Data = crew;
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
