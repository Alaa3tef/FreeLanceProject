using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadershipVisitController : ControllerBase
    {
        public IRepository<LeadershipVisit> LeadershipVisitRepo { get; set; }

        public LeadershipVisitController(IRepository<LeadershipVisit> _LeadershipVisitRepo)
        {
            this.LeadershipVisitRepo = _LeadershipVisitRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<LeadershipVisit> temp = LeadershipVisitRepo.getall();
            List<LeadershipVisitDTO> newTemp = new List<LeadershipVisitDTO>();
            foreach (LeadershipVisit LeadershipVisit in temp)
            {
                LeadershipVisitDTO LeadershipVisitDTO = new LeadershipVisitDTO();
                LeadershipVisitDTO.id = LeadershipVisit.Id;
				LeadershipVisitDTO.LeadershipType = LeadershipVisit.LeadershipType;
				LeadershipVisitDTO.IsDeleted = LeadershipVisit.IsDeleted;

				newTemp.Add(LeadershipVisitDTO);
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
                LeadershipVisitDTO LeadershipVisitDTO = new LeadershipVisitDTO();
                LeadershipVisit LeadershipVisit = LeadershipVisitRepo.getbyid(ID);
                LeadershipVisitDTO.id = LeadershipVisit.Id;
				LeadershipVisitDTO.LeadershipType = LeadershipVisit.LeadershipType;
				LeadershipVisitDTO.IsDeleted = LeadershipVisit.IsDeleted;

				result.Message = "Success";
                result.Data = LeadershipVisitDTO;
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
        public ActionResult<ResultDTO> Put(int id, [FromForm] LeadershipVisitDTO newLeadershipVisit) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    LeadershipVisit orgLeadershipVisit = LeadershipVisitRepo.getbyid(id);
                    newLeadershipVisit.id = orgLeadershipVisit.Id;
					orgLeadershipVisit.LeadershipType = newLeadershipVisit.LeadershipType;
					orgLeadershipVisit.IsDeleted = newLeadershipVisit.IsDeleted;


					LeadershipVisitRepo.update(orgLeadershipVisit);
                    result.Message = "Success";
                    result.Data = orgLeadershipVisit;
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
        public ActionResult<ResultDTO> AddLeadershipVisit(LeadershipVisitDTO LeadershipVisitDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    LeadershipVisit LeadershipVisit = new LeadershipVisit();
                    LeadershipVisit.Id = LeadershipVisitDTO.id;
					LeadershipVisit.LeadershipType = LeadershipVisitDTO.LeadershipType;
					LeadershipVisit.IsDeleted = LeadershipVisitDTO.IsDeleted;

					LeadershipVisitRepo.create(LeadershipVisit);
                    result.Message = "Success";
                    result.Data = LeadershipVisitDTO;
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
                LeadershipVisit leadershipVisit = LeadershipVisitRepo.getbyid(id);
                leadershipVisit.IsDeleted = true;
                LeadershipVisitRepo.update(leadershipVisit);
                result.Data = leadershipVisit;
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
