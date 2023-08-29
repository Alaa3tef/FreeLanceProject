using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfInjuryController : ControllerBase
    {
        public IRepository<TypeOfInjury> TypeOfInjuryRepo { get; set; }

        public TypeOfInjuryController(IRepository<TypeOfInjury> _TypeOfInjuryRepo)
        {
            this.TypeOfInjuryRepo = _TypeOfInjuryRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<TypeOfInjury> temp = TypeOfInjuryRepo.getall();
            List<TypeOfInjuryDTO> newTemp = new List<TypeOfInjuryDTO>();
            foreach (TypeOfInjury TypeOfInjury in temp)
            {
                TypeOfInjuryDTO TypeOfInjuryDTO = new TypeOfInjuryDTO();
                TypeOfInjuryDTO.Id = TypeOfInjury.Id;
                TypeOfInjuryDTO.Name = TypeOfInjury.Name;
                TypeOfInjuryDTO.IsDeleted = TypeOfInjury.IsDeleted;

                newTemp.Add(TypeOfInjuryDTO);
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
		public PageResult<TypeOfInjuryDTO> GettAllTypeOfInjuryByPage(int? page, int pagesize = 10)
		{
			List<TypeOfInjury> temp = TypeOfInjuryRepo.getall();
			List<TypeOfInjuryDTO> newTemp = new List<TypeOfInjuryDTO>();
			foreach (TypeOfInjury TypeOfInjury in temp)
			{
				TypeOfInjuryDTO TypeOfInjuryDTO = new TypeOfInjuryDTO();
				TypeOfInjuryDTO.Id = TypeOfInjury.Id;
				TypeOfInjuryDTO.Name = TypeOfInjury.Name;
				TypeOfInjuryDTO.IsDeleted = TypeOfInjury.IsDeleted;

				newTemp.Add(TypeOfInjuryDTO);
			}

			float countDetails = TypeOfInjuryRepo.getall().Count();
			var result = new PageResult<TypeOfInjuryDTO>
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
                TypeOfInjuryDTO TypeOfInjuryDTO = new TypeOfInjuryDTO();
                TypeOfInjury TypeOfInjury = TypeOfInjuryRepo.getbyid(ID);
                TypeOfInjuryDTO.Id = TypeOfInjury.Id;
                TypeOfInjuryDTO.Name = TypeOfInjury.Name;
                TypeOfInjuryDTO.IsDeleted = TypeOfInjury.IsDeleted;

                result.Message = "Success";
                result.Data = TypeOfInjuryDTO;
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
        public ActionResult<ResultDTO> Put(int id, TypeOfInjuryDTO newTypeOfInjury) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    TypeOfInjury orgTypeOfInjury = TypeOfInjuryRepo.getbyid(id);
                    newTypeOfInjury.Id = orgTypeOfInjury.Id;
                    orgTypeOfInjury.Name = newTypeOfInjury.Name;
                    orgTypeOfInjury.IsDeleted = newTypeOfInjury.IsDeleted;


                    TypeOfInjuryRepo.update(orgTypeOfInjury);
                    result.Message = "Success";
                    result.Data = orgTypeOfInjury;
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
        public ActionResult<ResultDTO> AddTypeOfInjury(TypeOfInjuryDTO TypeOfInjuryDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    TypeOfInjury TypeOfInjury = new TypeOfInjury();
                    TypeOfInjury.Id = TypeOfInjuryDTO.Id;
                    TypeOfInjury.Name = TypeOfInjuryDTO.Name;
                    TypeOfInjury.IsDeleted = TypeOfInjuryDTO.IsDeleted;

                    TypeOfInjuryRepo.create(TypeOfInjury);
                    result.Message = "Success";
                    result.Data = TypeOfInjuryDTO;
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
                TypeOfInjury typeOfInjury = TypeOfInjuryRepo.getbyid(id);
                typeOfInjury.IsDeleted = true;
                TypeOfInjuryRepo.update(typeOfInjury);
                result.Data = typeOfInjury;
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
