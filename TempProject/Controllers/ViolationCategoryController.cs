using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationCategoryController : ControllerBase
    {
        public IRepository<ViolationCategory> ViolationCategoryRepo { get; set; }

        public ViolationCategoryController(IRepository<ViolationCategory> _ViolationCategoryRepo)
        {
            this.ViolationCategoryRepo = _ViolationCategoryRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<ViolationCategory> temp = ViolationCategoryRepo.getall();
            List<ViolationCategoryDTO> newTemp = new List<ViolationCategoryDTO>();
            foreach (ViolationCategory ViolationCategory in temp)
            {
                ViolationCategoryDTO ViolationCategoryDTO = new ViolationCategoryDTO();
                ViolationCategoryDTO.Id = ViolationCategory.Id;
                ViolationCategoryDTO.Name = ViolationCategory.Name;
                ViolationCategoryDTO.IsDeleted = ViolationCategory.IsDeleted;

                newTemp.Add(ViolationCategoryDTO);
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
		public PageResult<ViolationCategoryDTO> GettAllViolationCategoryByPage(int? page, int pagesize = 10)
		{
			List<ViolationCategory> temp = ViolationCategoryRepo.getall();
			List<ViolationCategoryDTO> newTemp = new List<ViolationCategoryDTO>();
			foreach (ViolationCategory ViolationCategory in temp)
			{
				ViolationCategoryDTO ViolationCategoryDTO = new ViolationCategoryDTO();
				ViolationCategoryDTO.Id = ViolationCategory.Id;
				ViolationCategoryDTO.Name = ViolationCategory.Name;
				ViolationCategoryDTO.IsDeleted = ViolationCategory.IsDeleted;

				newTemp.Add(ViolationCategoryDTO);
			}

			float countDetails = ViolationCategoryRepo.getall().Count();
			var result = new PageResult<ViolationCategoryDTO>
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
                ViolationCategoryDTO ViolationCategoryDTO = new ViolationCategoryDTO();
                ViolationCategory ViolationCategory = ViolationCategoryRepo.getbyid(ID);
                ViolationCategoryDTO.Id = ViolationCategory.Id;
                ViolationCategoryDTO.Name = ViolationCategory.Name;
                ViolationCategoryDTO.IsDeleted = ViolationCategory.IsDeleted;

                result.Message = "Success";
                result.Data = ViolationCategoryDTO;
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
        public ActionResult<ResultDTO> Put(int id, ViolationCategoryDTO newViolationCategory) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ViolationCategory orgViolationCategory = ViolationCategoryRepo.getbyid(id);
                    newViolationCategory.Id = orgViolationCategory.Id;
                    orgViolationCategory.Name = newViolationCategory.Name;
                    orgViolationCategory.IsDeleted = newViolationCategory.IsDeleted;


                    ViolationCategoryRepo.update(orgViolationCategory);
                    result.Message = "Success";
                    result.Data = orgViolationCategory;
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
        public ActionResult<ResultDTO> AddViolationCategory(ViolationCategoryDTO ViolationCategoryDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ViolationCategory ViolationCategory = new ViolationCategory();
                    ViolationCategory.Id = ViolationCategoryDTO.Id;
                    ViolationCategory.Name = ViolationCategoryDTO.Name;
                    ViolationCategory.IsDeleted = ViolationCategoryDTO.IsDeleted;

                    ViolationCategoryRepo.create(ViolationCategory);
                    result.Message = "Success";
                    result.Data = ViolationCategoryDTO;
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
                ViolationCategory violationCategory = ViolationCategoryRepo.getbyid(id);
                violationCategory.IsDeleted = true;
                ViolationCategoryRepo.update(violationCategory);
                result.Data = violationCategory;
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
