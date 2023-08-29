using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolPusherPositionController : ControllerBase
    {
        public IRepository<ToolPusherPosition> ToolPusherPositionRepo { get; set; }

        public ToolPusherPositionController(IRepository<ToolPusherPosition> _ToolPusherPositionRepo)
        {
            this.ToolPusherPositionRepo = _ToolPusherPositionRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<ToolPusherPosition> temp = ToolPusherPositionRepo.getall();
            List<ToolPusherPositionDTO> newTemp = new List<ToolPusherPositionDTO>();
            foreach (ToolPusherPosition ToolPusherPosition in temp)
            {
                ToolPusherPositionDTO ToolPusherPositionDTO = new ToolPusherPositionDTO();
                ToolPusherPositionDTO.Id = ToolPusherPosition.Id;
                ToolPusherPositionDTO.Name = ToolPusherPosition.Name;
                ToolPusherPositionDTO.IsDeleted = ToolPusherPosition.IsDeleted;

                newTemp.Add(ToolPusherPositionDTO);
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
		public PageResult<ToolPusherPositionDTO> GettAllToolPusherPositionByPage(int? page, int pagesize = 10)
		{
			List<ToolPusherPosition> temp = ToolPusherPositionRepo.getall();
			List<ToolPusherPositionDTO> newTemp = new List<ToolPusherPositionDTO>();
			foreach (ToolPusherPosition ToolPusherPosition in temp)
			{
				ToolPusherPositionDTO ToolPusherPositionDTO = new ToolPusherPositionDTO();
				ToolPusherPositionDTO.Id = ToolPusherPosition.Id;
				ToolPusherPositionDTO.Name = ToolPusherPosition.Name;
				ToolPusherPositionDTO.IsDeleted = ToolPusherPosition.IsDeleted;

				newTemp.Add(ToolPusherPositionDTO);
			}

			float countDetails = ToolPusherPositionRepo.getall().Count();
			var result = new PageResult<ToolPusherPositionDTO>
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
                ToolPusherPositionDTO ToolPusherPositionDTO = new ToolPusherPositionDTO();
                ToolPusherPosition ToolPusherPosition = ToolPusherPositionRepo.getbyid(ID);
                ToolPusherPositionDTO.Id = ToolPusherPosition.Id;
                ToolPusherPositionDTO.Name = ToolPusherPosition.Name;
                ToolPusherPositionDTO.IsDeleted = ToolPusherPosition.IsDeleted;

                result.Message = "Success";
                result.Data = ToolPusherPositionDTO;
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
        public ActionResult<ResultDTO> Put(int id, ToolPusherPositionDTO newToolPusherPosition) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ToolPusherPosition orgToolPusherPosition = ToolPusherPositionRepo.getbyid(id);
                    newToolPusherPosition.Id = orgToolPusherPosition.Id;
                    orgToolPusherPosition.Name = newToolPusherPosition.Name;
                    orgToolPusherPosition.IsDeleted = newToolPusherPosition.IsDeleted;


                    ToolPusherPositionRepo.update(orgToolPusherPosition);
                    result.Message = "Success";
                    result.Data = orgToolPusherPosition;
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
        public ActionResult<ResultDTO> AddToolPusherPosition(ToolPusherPositionDTO ToolPusherPositionDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ToolPusherPosition ToolPusherPosition = new ToolPusherPosition();
                    ToolPusherPosition.Id = ToolPusherPositionDTO.Id;
                    ToolPusherPosition.Name = ToolPusherPositionDTO.Name;
                    ToolPusherPosition.IsDeleted = ToolPusherPositionDTO.IsDeleted;

                    ToolPusherPositionRepo.create(ToolPusherPosition);
                    result.Message = "Success";
                    result.Data = ToolPusherPositionDTO;
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
                ToolPusherPosition toolPusherPosition = ToolPusherPositionRepo.getbyid(id);
                toolPusherPosition.IsDeleted = true;
                ToolPusherPositionRepo.update(toolPusherPosition);
                result.Data = toolPusherPosition;
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
