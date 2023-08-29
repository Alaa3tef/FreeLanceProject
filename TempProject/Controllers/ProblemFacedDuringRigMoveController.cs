using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemFacedDuringRigMoveController : ControllerBase
    {
        public IRepository<ProblemFacedDuringRigMove> ProblemFacedDuringRigMoveRepo { get; set; }

        public ProblemFacedDuringRigMoveController(IRepository<ProblemFacedDuringRigMove> _ProblemFacedDuringRigMoveRepo)
        {
            this.ProblemFacedDuringRigMoveRepo = _ProblemFacedDuringRigMoveRepo;
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<ProblemFacedDuringRigMove> temp = ProblemFacedDuringRigMoveRepo.getall();
            List<ProblemFacedDuringRigMoveDTO> newTemp = new List<ProblemFacedDuringRigMoveDTO>();
            foreach (ProblemFacedDuringRigMove item in temp)
            {
                ProblemFacedDuringRigMoveDTO ProblemFacedDuringRigMoveDTO = new ProblemFacedDuringRigMoveDTO();
                ProblemFacedDuringRigMoveDTO.Id = item.Id;
                ProblemFacedDuringRigMoveDTO.Item = item.Item;
                ProblemFacedDuringRigMoveDTO.TimeLostProblem = item.TimeLostProblem;
                ProblemFacedDuringRigMoveDTO.ProblemDescription = item.ProblemDescription;
                ProblemFacedDuringRigMoveDTO.RecommendationProblemRepeated = item.RecommendationProblemRepeated;
                ProblemFacedDuringRigMoveDTO.IsDeleted = item.IsDeleted;

                newTemp.Add(ProblemFacedDuringRigMoveDTO);
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
        public PageResult<ProblemFacedDuringRigMoveDTO> GettAllProblemFacedDuringRigMoveByPage(int? page, int pagesize = 10)
        {
            List<ProblemFacedDuringRigMove> temp = ProblemFacedDuringRigMoveRepo.getall();
            List<ProblemFacedDuringRigMoveDTO> newTemp = new List<ProblemFacedDuringRigMoveDTO>();
            foreach (ProblemFacedDuringRigMove ProblemFacedDuringRigMove in temp)
            {
                ProblemFacedDuringRigMoveDTO ProblemFacedDuringRigMoveDTO = new ProblemFacedDuringRigMoveDTO();
                ProblemFacedDuringRigMoveDTO.Id = ProblemFacedDuringRigMove.Id;
                ProblemFacedDuringRigMoveDTO.Item = ProblemFacedDuringRigMove.Item;
                ProblemFacedDuringRigMoveDTO.TimeLostProblem = ProblemFacedDuringRigMove.TimeLostProblem;
                ProblemFacedDuringRigMoveDTO.ProblemDescription = ProblemFacedDuringRigMove.ProblemDescription;
                ProblemFacedDuringRigMoveDTO.RecommendationProblemRepeated = ProblemFacedDuringRigMove.RecommendationProblemRepeated;
                ProblemFacedDuringRigMoveDTO.IsDeleted = ProblemFacedDuringRigMove.IsDeleted;

                newTemp.Add(ProblemFacedDuringRigMoveDTO);
            }

            float countDetails = ProblemFacedDuringRigMoveRepo.getall().Count();
            var result = new PageResult<ProblemFacedDuringRigMoveDTO>
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
                ProblemFacedDuringRigMoveDTO ProblemFacedDuringRigMoveDTO = new ProblemFacedDuringRigMoveDTO();
                ProblemFacedDuringRigMove ProblemFacedDuringRigMove = ProblemFacedDuringRigMoveRepo.getbyid(ID);
                ProblemFacedDuringRigMoveDTO.Id = ProblemFacedDuringRigMove.Id;
                ProblemFacedDuringRigMoveDTO.Item = ProblemFacedDuringRigMove.Item;
                ProblemFacedDuringRigMoveDTO.TimeLostProblem = ProblemFacedDuringRigMove.TimeLostProblem;
                ProblemFacedDuringRigMoveDTO.ProblemDescription = ProblemFacedDuringRigMove.ProblemDescription;
                ProblemFacedDuringRigMoveDTO.RecommendationProblemRepeated = ProblemFacedDuringRigMove.RecommendationProblemRepeated;
                ProblemFacedDuringRigMoveDTO.IsDeleted = ProblemFacedDuringRigMove.IsDeleted;

                result.Message = "Success";
                result.Data = ProblemFacedDuringRigMoveDTO;
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
        public ActionResult<ResultDTO> Put(int id, ProblemFacedDuringRigMoveDTO newProblemFacedDuringRigMove) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ProblemFacedDuringRigMove orgProblemFacedDuringRigMove = ProblemFacedDuringRigMoveRepo.getbyid(id);
                    newProblemFacedDuringRigMove.Id = orgProblemFacedDuringRigMove.Id;
                    orgProblemFacedDuringRigMove.Item = newProblemFacedDuringRigMove.Item;
                    orgProblemFacedDuringRigMove.TimeLostProblem = newProblemFacedDuringRigMove.TimeLostProblem;
                    orgProblemFacedDuringRigMove.ProblemDescription = newProblemFacedDuringRigMove.ProblemDescription;
                    orgProblemFacedDuringRigMove.RecommendationProblemRepeated = newProblemFacedDuringRigMove.RecommendationProblemRepeated;
                    orgProblemFacedDuringRigMove.IsDeleted = newProblemFacedDuringRigMove.IsDeleted;


                    ProblemFacedDuringRigMoveRepo.update(orgProblemFacedDuringRigMove);
                    result.Message = "Success";
                    result.Data = orgProblemFacedDuringRigMove;
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
        public ActionResult<ResultDTO> AddProblemFacedDuringRigMove(ProblemFacedDuringRigMoveDTO ProblemFacedDuringRigMoveDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ProblemFacedDuringRigMove ProblemFacedDuringRigMove = new ProblemFacedDuringRigMove();
                    ProblemFacedDuringRigMove.Id = ProblemFacedDuringRigMoveDTO.Id;
                    ProblemFacedDuringRigMove.Item = ProblemFacedDuringRigMoveDTO.Item;
                    ProblemFacedDuringRigMove.TimeLostProblem = ProblemFacedDuringRigMoveDTO.TimeLostProblem;
                    ProblemFacedDuringRigMove.ProblemDescription = ProblemFacedDuringRigMoveDTO.ProblemDescription;
                    ProblemFacedDuringRigMove.RecommendationProblemRepeated = ProblemFacedDuringRigMoveDTO.RecommendationProblemRepeated;
                    ProblemFacedDuringRigMove.IsDeleted = ProblemFacedDuringRigMoveDTO.IsDeleted;

                    ProblemFacedDuringRigMoveRepo.create(ProblemFacedDuringRigMove);
                    result.Message = "Success";
                    result.Data = ProblemFacedDuringRigMove;
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
                ProblemFacedDuringRigMove ProblemFacedDuringRigMove = ProblemFacedDuringRigMoveRepo.getbyid(id);
                ProblemFacedDuringRigMove.IsDeleted = true;
                ProblemFacedDuringRigMoveRepo.update(ProblemFacedDuringRigMove);
                result.Data = ProblemFacedDuringRigMove;
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
