using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RigController : ControllerBase
    {
        public IRepository<Rig> RigRepo { get; set; }

        public RigController(IRepository<Rig> _RigRepo)
        {
            this.RigRepo = _RigRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<Rig> temp = RigRepo.getall();
            List<RigDTO> newTemp = new List<RigDTO>();
            foreach (Rig Rig in temp)
            {
                RigDTO RigDTO = new RigDTO();
                RigDTO.Id = Rig.Id;
                RigDTO.Number = Rig.Number;
                RigDTO.IsDeleted = Rig.IsDeleted;

                newTemp.Add(RigDTO);
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
		public PageResult<RigDTO> GettAllRigByPage(int? page, int pagesize = 10)
		{
			List<Rig> temp = RigRepo.getall();
			List<RigDTO> newTemp = new List<RigDTO>();
			foreach (Rig Rig in temp)
			{
				RigDTO RigDTO = new RigDTO();
				RigDTO.Id = Rig.Id;
				RigDTO.Number = Rig.Number;
				RigDTO.IsDeleted = Rig.IsDeleted;

				newTemp.Add(RigDTO);
			}

			float countDetails = RigRepo.getall().Count();
			var result = new PageResult<RigDTO>
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
                RigDTO RigDTO = new RigDTO();
                Rig Rig = RigRepo.getbyid(ID);
                RigDTO.Id = Rig.Id;
                RigDTO.Number = Rig.Number;
                RigDTO.IsDeleted = Rig.IsDeleted;

                result.Message = "Success";
                result.Data = RigDTO;
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
        public ActionResult<ResultDTO> Put(int id, RigDTO newRig) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Rig orgRig = RigRepo.getbyid(id);
                    newRig.Id = orgRig.Id;
                    orgRig.Number = newRig.Number;
                    orgRig.IsDeleted = newRig.IsDeleted;


                    RigRepo.update(orgRig);
                    result.Message = "Success";
                    result.Data = orgRig;
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
        public ActionResult<ResultDTO> AddRig(RigDTO RigDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Rig Rig = new Rig();
                    Rig.Id = RigDTO.Id;
                    Rig.Number = RigDTO.Number;
                    Rig.IsDeleted = RigDTO.IsDeleted;

                    RigRepo.create(Rig);
                    result.Message = "Success";
                    result.Data = RigDTO;
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
                Rig rig = RigRepo.getbyid(id);
                rig.IsDeleted = true;
                RigRepo.update(rig);
                result.Data = rig;
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
