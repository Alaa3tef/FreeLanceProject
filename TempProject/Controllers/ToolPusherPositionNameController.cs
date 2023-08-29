using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolPusherPositionNameController : ControllerBase
    {
        public IRepository<ToolPusherPositionName> ToolPusherPositionNameRepo { get; set; }
		public IRepository<ToolPusherPosition> ToolPusherPositionRepo { get; set; }

		public ToolPusherPositionNameController(IRepository<ToolPusherPosition> _ToolPusherPositionRepo,IRepository<ToolPusherPositionName> _ToolPusherPositionNameRepo)
        {
			this.ToolPusherPositionNameRepo = _ToolPusherPositionNameRepo;
			this.ToolPusherPositionRepo = _ToolPusherPositionRepo;
		}
		[HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<ToolPusherPositionName> temp = ToolPusherPositionNameRepo.getall();
            List<ToolPusherPositionNameDTO> newTemp = new List<ToolPusherPositionNameDTO>();
            foreach (ToolPusherPositionName ToolPusherPositionName in temp)
            {
                ToolPusherPositionNameDTO ToolPusherPositionNameDTO = new ToolPusherPositionNameDTO();
                ToolPusherPositionNameDTO.Id = ToolPusherPositionName.Id;
				ToolPusherPositionNameDTO.Name = ToolPusherPositionName.Name;
				ToolPusherPositionNameDTO.EmpCode = ToolPusherPositionName.EmpCode;
				ToolPusherPositionNameDTO.PositionId = ToolPusherPositionName.PositionId;
                ToolPusherPositionNameDTO.IsDeleted = ToolPusherPositionName.IsDeleted;

                newTemp.Add(ToolPusherPositionNameDTO);
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

		[HttpGet("GetAllForExcel")]
		public ActionResult<ResultDTO> GetAllForExcel()
		{

			ResultDTO result = new ResultDTO();

			List<ToolPusherPositionName> temp = ToolPusherPositionNameRepo.getall();
			List<ToolPusherPositionNameExcelDTO> newTemp = new List<ToolPusherPositionNameExcelDTO>();
			foreach (ToolPusherPositionName ToolPusherPositionName in temp)
			{
				ToolPusherPositionNameExcelDTO ToolPusherPositionNameDTO = new ToolPusherPositionNameExcelDTO();
				ToolPusherPositionNameDTO.Id = ToolPusherPositionName.Id;
				ToolPusherPositionNameDTO.Name = ToolPusherPositionName.Name;
				ToolPusherPositionNameDTO.EmpCode = ToolPusherPositionName.EmpCode;
				ToolPusherPositionNameDTO.Position = ToolPusherPositionRepo.getbyid(ToolPusherPositionName.PositionId).Name;

				newTemp.Add(ToolPusherPositionNameDTO);
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
		public PageResult<ToolPusherPositionNameDTO> GettAllToolPusherPositionNameByPage(int? page, int pagesize = 10)
		{
			List<ToolPusherPositionName> temp = ToolPusherPositionNameRepo.getall();
			List<ToolPusherPositionNameDTO> newTemp = new List<ToolPusherPositionNameDTO>();
			foreach (ToolPusherPositionName ToolPusherPositionName in temp)
			{
				ToolPusherPositionNameDTO ToolPusherPositionNameDTO = new ToolPusherPositionNameDTO();
				ToolPusherPositionNameDTO.Id = ToolPusherPositionName.Id;
				ToolPusherPositionNameDTO.Name = ToolPusherPositionName.Name;
				ToolPusherPositionNameDTO.EmpCode = ToolPusherPositionName.EmpCode;
				ToolPusherPositionNameDTO.PositionId = ToolPusherPositionName.PositionId;
				ToolPusherPositionNameDTO.IsDeleted = ToolPusherPositionName.IsDeleted;

				newTemp.Add(ToolPusherPositionNameDTO);
			}

			float countDetails = ToolPusherPositionNameRepo.getall().Count();
			var result = new PageResult<ToolPusherPositionNameDTO>
			{
				Count = (int)Math.Ceiling(countDetails / pagesize),
				PageIndex = page ?? 1,
				PageSize = pagesize,
				Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
			};
			return result;
		}

		[HttpGet("Name/{positionId:int}")]
        public ActionResult<ResultDTO> GetByPositionId(int positionId)
        {

            ResultDTO result = new ResultDTO();

            List<ToolPusherPositionName> temp = ToolPusherPositionNameRepo.getall().Where(n=>n.PositionId==positionId).ToList();
            List<ToolPusherPositionNameDTO> newTemp = new List<ToolPusherPositionNameDTO>();
            foreach (ToolPusherPositionName ToolPusherPositionName in temp)
            {
                ToolPusherPositionNameDTO ToolPusherPositionNameDTO = new ToolPusherPositionNameDTO();
                ToolPusherPositionNameDTO.Id = ToolPusherPositionName.Id;
				ToolPusherPositionNameDTO.Name = ToolPusherPositionName.Name;
				ToolPusherPositionNameDTO.EmpCode = ToolPusherPositionName.EmpCode;
				ToolPusherPositionNameDTO.PositionId = ToolPusherPositionName.PositionId;
                ToolPusherPositionNameDTO.IsDeleted = ToolPusherPositionName.IsDeleted;

                newTemp.Add(ToolPusherPositionNameDTO);
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
                ToolPusherPositionNameDTO ToolPusherPositionNameDTO = new ToolPusherPositionNameDTO();
                ToolPusherPositionName ToolPusherPositionName = ToolPusherPositionNameRepo.getbyid(ID);
                ToolPusherPositionNameDTO.Id = ToolPusherPositionName.Id;
				ToolPusherPositionNameDTO.Name = ToolPusherPositionName.Name;
				ToolPusherPositionNameDTO.EmpCode = ToolPusherPositionName.EmpCode;
				ToolPusherPositionNameDTO.PositionId = ToolPusherPositionName.PositionId;
                ToolPusherPositionNameDTO.IsDeleted = ToolPusherPositionName.IsDeleted;

                result.Data = ToolPusherPositionNameDTO;
                result.Message = "Success";
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

		[HttpGet("Code/{empCode:int}")]
		public ActionResult<ResultDTO> GetByEmpCode(int empCode)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				ToolPusherPositionNameDTO ToolPusherPositionNameDTO = new ToolPusherPositionNameDTO();
				ToolPusherPositionName ToolPusherPositionName = ToolPusherPositionNameRepo.getall().FirstOrDefault(t=>t.EmpCode==empCode);
				ToolPusherPositionNameDTO.Id = ToolPusherPositionName.Id;
				ToolPusherPositionNameDTO.Name = ToolPusherPositionName.Name;
				ToolPusherPositionNameDTO.EmpCode = ToolPusherPositionName.EmpCode;
				ToolPusherPositionNameDTO.PositionId = ToolPusherPositionName.PositionId;
				ToolPusherPositionNameDTO.IsDeleted = ToolPusherPositionName.IsDeleted;

				result.Data = ToolPusherPositionNameDTO;
				result.Message = "Success";
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
        public ActionResult<ResultDTO> Put(int id, ToolPusherPositionNameDTO newToolPusherPositionName) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ToolPusherPositionName orgToolPusherPositionName = ToolPusherPositionNameRepo.getbyid(id);
                    newToolPusherPositionName.Id = orgToolPusherPositionName.Id;
					orgToolPusherPositionName.Name = newToolPusherPositionName.Name;
					orgToolPusherPositionName.EmpCode = newToolPusherPositionName.EmpCode;
					orgToolPusherPositionName.PositionId = newToolPusherPositionName.PositionId;
                    orgToolPusherPositionName.IsDeleted = newToolPusherPositionName.IsDeleted;


                    ToolPusherPositionNameRepo.update(orgToolPusherPositionName);
                    result.Message = "Success";
                    result.Data = orgToolPusherPositionName;
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
        public ActionResult<ResultDTO> AddToolPusherPositionName(ToolPusherPositionNameDTO ToolPusherPositionNameDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ToolPusherPositionName ToolPusherPositionName = new ToolPusherPositionName();
                    ToolPusherPositionName.Id = ToolPusherPositionNameDTO.Id;
					ToolPusherPositionName.Name = ToolPusherPositionNameDTO.Name;
					ToolPusherPositionName.EmpCode = ToolPusherPositionNameDTO.EmpCode;
					ToolPusherPositionName.PositionId = ToolPusherPositionNameDTO.PositionId;
                    ToolPusherPositionName.IsDeleted = ToolPusherPositionNameDTO.IsDeleted;

                    ToolPusherPositionNameRepo.create(ToolPusherPositionName);
                    result.Message = "Success";
                    result.Data = ToolPusherPositionNameDTO;
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
                ToolPusherPositionName toolPusherPositionName = ToolPusherPositionNameRepo.getbyid(id);
                toolPusherPositionName.IsDeleted = true;
                ToolPusherPositionNameRepo.update(toolPusherPositionName);
                result.Data = toolPusherPositionName;
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
