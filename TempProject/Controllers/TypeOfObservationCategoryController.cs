using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfObservationCategoryController : ControllerBase
    {
        public IRepository<TypeOfObservationCategory> TypeOfObservationCategoryRepo { get; set; }

        public TypeOfObservationCategoryController(IRepository<TypeOfObservationCategory> _TypeOfObservationCategoryRepo)
        {
            this.TypeOfObservationCategoryRepo = _TypeOfObservationCategoryRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<TypeOfObservationCategory> temp = TypeOfObservationCategoryRepo.getall();
            List<TypeOfObservationCategoryDTO> newTemp = new List<TypeOfObservationCategoryDTO>();
            foreach (TypeOfObservationCategory TypeOfObservationCategory in temp)
            {
                TypeOfObservationCategoryDTO TypeOfObservationCategoryDTO = new TypeOfObservationCategoryDTO();
                TypeOfObservationCategoryDTO.Id = TypeOfObservationCategory.Id;
                TypeOfObservationCategoryDTO.Name = TypeOfObservationCategory.Name;
                TypeOfObservationCategoryDTO.IsDeleted = TypeOfObservationCategory.IsDeleted;

                newTemp.Add(TypeOfObservationCategoryDTO);
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
		public PageResult<TypeOfObservationCategoryDTO> GettAllTypeOfObservationCategoryByPage(int? page, int pagesize = 10)
		{
			List<TypeOfObservationCategory> temp = TypeOfObservationCategoryRepo.getall();
			List<TypeOfObservationCategoryDTO> newTemp = new List<TypeOfObservationCategoryDTO>();
			foreach (TypeOfObservationCategory TypeOfObservationCategory in temp)
			{
				TypeOfObservationCategoryDTO TypeOfObservationCategoryDTO = new TypeOfObservationCategoryDTO();
				TypeOfObservationCategoryDTO.Id = TypeOfObservationCategory.Id;
				TypeOfObservationCategoryDTO.Name = TypeOfObservationCategory.Name;
				TypeOfObservationCategoryDTO.IsDeleted = TypeOfObservationCategory.IsDeleted;

				newTemp.Add(TypeOfObservationCategoryDTO);
			}

			float countDetails = TypeOfObservationCategoryRepo.getall().Count();
			var result = new PageResult<TypeOfObservationCategoryDTO>
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
                TypeOfObservationCategoryDTO TypeOfObservationCategoryDTO = new TypeOfObservationCategoryDTO();
                TypeOfObservationCategory TypeOfObservationCategory = TypeOfObservationCategoryRepo.getbyid(ID);
                TypeOfObservationCategoryDTO.Id = TypeOfObservationCategory.Id;
                TypeOfObservationCategoryDTO.Name = TypeOfObservationCategory.Name;
                TypeOfObservationCategoryDTO.IsDeleted = TypeOfObservationCategory.IsDeleted;

                result.Message = "Success";
                result.Data = TypeOfObservationCategoryDTO;
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
        public ActionResult<ResultDTO> Put(int id, TypeOfObservationCategoryDTO newTypeOfObservationCategory) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    TypeOfObservationCategory orgTypeOfObservationCategory = TypeOfObservationCategoryRepo.getbyid(id);
                    newTypeOfObservationCategory.Id = orgTypeOfObservationCategory.Id;
                    orgTypeOfObservationCategory.Name = newTypeOfObservationCategory.Name;
                    orgTypeOfObservationCategory.IsDeleted = newTypeOfObservationCategory.IsDeleted;


                    TypeOfObservationCategoryRepo.update(orgTypeOfObservationCategory);
                    result.Message = "Success";
                    result.Data = orgTypeOfObservationCategory;
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
        public ActionResult<ResultDTO> AddTypeOfObservationCategory(TypeOfObservationCategoryDTO TypeOfObservationCategoryDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    TypeOfObservationCategory TypeOfObservationCategory = new TypeOfObservationCategory();
                    TypeOfObservationCategory.Id = TypeOfObservationCategoryDTO.Id;
                    TypeOfObservationCategory.Name = TypeOfObservationCategoryDTO.Name;
                    TypeOfObservationCategory.IsDeleted = TypeOfObservationCategoryDTO.IsDeleted;

                    TypeOfObservationCategoryRepo.create(TypeOfObservationCategory);
                    result.Message = "Success";
                    result.Data = TypeOfObservationCategoryDTO;
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
               TypeOfObservationCategory typeOfObservationCategory  = TypeOfObservationCategoryRepo.getbyid(id);
                typeOfObservationCategory.IsDeleted = true;
                TypeOfObservationCategoryRepo.update(typeOfObservationCategory);
                result.Data = typeOfObservationCategory;
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
