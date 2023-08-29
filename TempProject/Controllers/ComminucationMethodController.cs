using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComminucationMethodController : ControllerBase
    {
        public IRepository<ComminucationMethod> ComminucationMethodRepo { get; set; }

        public ComminucationMethodController(IRepository<ComminucationMethod> _ComminucationMethodRepo)
        {
            this.ComminucationMethodRepo = _ComminucationMethodRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<ComminucationMethod> temp = ComminucationMethodRepo.getall();
            List<ComminucationMethodDTO> newTemp = new List<ComminucationMethodDTO>();
            foreach (ComminucationMethod ComminucationMethod in temp)
            {
                ComminucationMethodDTO ComminucationMethodDTO = new ComminucationMethodDTO();
                ComminucationMethodDTO.Id = ComminucationMethod.Id;
                ComminucationMethodDTO.IsDeleted = ComminucationMethod.IsDeleted;
                ComminucationMethodDTO.Name = ComminucationMethod.Name;

                newTemp.Add(ComminucationMethodDTO);
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
		public PageResult<ComminucationMethodDTO> GettAllComminucationMethodByPage(int? page, int pagesize = 10)
		{
			List<ComminucationMethod> temp = ComminucationMethodRepo.getall();
			List<ComminucationMethodDTO> newTemp = new List<ComminucationMethodDTO>();
			foreach (ComminucationMethod ComminucationMethod in temp)
			{
				ComminucationMethodDTO ComminucationMethodDTO = new ComminucationMethodDTO();
				ComminucationMethodDTO.Id = ComminucationMethod.Id;
				ComminucationMethodDTO.IsDeleted = ComminucationMethod.IsDeleted;
				ComminucationMethodDTO.Name = ComminucationMethod.Name;

				newTemp.Add(ComminucationMethodDTO);
			}

			float countDetails = ComminucationMethodRepo.getall().Count();
			var result = new PageResult<ComminucationMethodDTO>
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
                ComminucationMethodDTO ComminucationMethodDTO = new ComminucationMethodDTO();
                ComminucationMethod ComminucationMethod = ComminucationMethodRepo.getbyid(ID);
                ComminucationMethodDTO.Id = ComminucationMethod.Id;
                ComminucationMethodDTO.IsDeleted = ComminucationMethod.IsDeleted;
                ComminucationMethodDTO.Name = ComminucationMethod.Name;

                result.Message = "Success";
                result.Data = ComminucationMethodDTO;
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
        public ActionResult<ResultDTO> Put(int id, ComminucationMethodDTO newComminucationMethod) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ComminucationMethod orgComminucationMethod = ComminucationMethodRepo.getbyid(id);
                    newComminucationMethod.Id = orgComminucationMethod.Id;
                    orgComminucationMethod.Name = newComminucationMethod.Name;
                    orgComminucationMethod.IsDeleted = newComminucationMethod.IsDeleted;


                    ComminucationMethodRepo.update(orgComminucationMethod);
                    result.Message = "Success";
                    result.Data = orgComminucationMethod;
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
        public ActionResult<ResultDTO> AddComminucationMethod(ComminucationMethodDTO ComminucationMethodDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ComminucationMethod ComminucationMethod = new ComminucationMethod();
                    ComminucationMethod.Id = ComminucationMethodDTO.Id;
                    ComminucationMethod.Name = ComminucationMethodDTO.Name;
                    ComminucationMethod.IsDeleted = ComminucationMethodDTO.IsDeleted;

                    ComminucationMethodRepo.create(ComminucationMethod);
                    result.Message = "Success";
                    result.Data = ComminucationMethodDTO;
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
                ComminucationMethod comminucationMethod = ComminucationMethodRepo.getbyid(id);
                comminucationMethod.IsDeleted = true;
                ComminucationMethodRepo.update(comminucationMethod);
                result.Data = comminucationMethod;
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
