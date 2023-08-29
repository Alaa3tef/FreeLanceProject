using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreventionCategoryController : ControllerBase
    {
        public IRepository<PreventionCategory> PreventionCategoryRepo { get; set; }

        public PreventionCategoryController(IRepository<PreventionCategory> _PreventionCategoryRepo)
        {
            this.PreventionCategoryRepo = _PreventionCategoryRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<PreventionCategory> temp = PreventionCategoryRepo.getall();
            List<PreventionCategoryDTO> newTemp = new List<PreventionCategoryDTO>();
            foreach (PreventionCategory PreventionCategory in temp)
            {
                PreventionCategoryDTO PreventionCategoryDTO = new PreventionCategoryDTO();
                PreventionCategoryDTO.Id = PreventionCategory.Id;
                PreventionCategoryDTO.Name = PreventionCategory.Name;
                PreventionCategoryDTO.IsDeleted = PreventionCategory.IsDeleted;

                newTemp.Add(PreventionCategoryDTO);
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
		public PageResult<PreventionCategoryDTO> GettAllPreventionCategoryByPage(int? page, int pagesize = 10)
		{
			List<PreventionCategory> temp = PreventionCategoryRepo.getall();
			List<PreventionCategoryDTO> newTemp = new List<PreventionCategoryDTO>();
			foreach (PreventionCategory PreventionCategory in temp)
			{
				PreventionCategoryDTO PreventionCategoryDTO = new PreventionCategoryDTO();
				PreventionCategoryDTO.Id = PreventionCategory.Id;
				PreventionCategoryDTO.Name = PreventionCategory.Name;
				PreventionCategoryDTO.IsDeleted = PreventionCategory.IsDeleted;

				newTemp.Add(PreventionCategoryDTO);
			}

			float countDetails = PreventionCategoryRepo.getall().Count();
			var result = new PageResult<PreventionCategoryDTO>
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
                PreventionCategoryDTO PreventionCategoryDTO = new PreventionCategoryDTO();
                PreventionCategory PreventionCategory = PreventionCategoryRepo.getbyid(ID);
                PreventionCategoryDTO.Id = PreventionCategory.Id;
                PreventionCategoryDTO.Name = PreventionCategory.Name;
                PreventionCategoryDTO.IsDeleted = PreventionCategory.IsDeleted;

                result.Message = "Success";
                result.Data = PreventionCategoryDTO;
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
        public ActionResult<ResultDTO> Put(int id, PreventionCategoryDTO newPreventionCategory) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    PreventionCategory orgPreventionCategory = PreventionCategoryRepo.getbyid(id);
                    newPreventionCategory.Id = orgPreventionCategory.Id;
                    orgPreventionCategory.Name = newPreventionCategory.Name;
                    orgPreventionCategory.IsDeleted = newPreventionCategory.IsDeleted;


                    PreventionCategoryRepo.update(orgPreventionCategory);
                    result.Message = "Success";
                    result.Data = orgPreventionCategory;
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
        public ActionResult<ResultDTO> AddPreventionCategory(PreventionCategoryDTO PreventionCategoryDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    PreventionCategory PreventionCategory = new PreventionCategory();
                    PreventionCategory.Id = PreventionCategoryDTO.Id;
                    PreventionCategory.Name = PreventionCategoryDTO.Name;
                    PreventionCategory.IsDeleted = PreventionCategoryDTO.IsDeleted;

                    PreventionCategoryRepo.create(PreventionCategory);
                    result.Message = "Success";
                    result.Data = PreventionCategoryDTO;
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
                PreventionCategory preventionCategory = PreventionCategoryRepo.getbyid(id);
                preventionCategory.IsDeleted = true;
                PreventionCategoryRepo.update(preventionCategory);
                result.Data = preventionCategory;
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
