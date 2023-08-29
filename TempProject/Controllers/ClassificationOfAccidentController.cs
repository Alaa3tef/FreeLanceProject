using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationOfAccidentController : ControllerBase
    {
        public IRepository<ClassificationOfAccident> ClassificationOfAccidentRepo { get; set; }

        public ClassificationOfAccidentController(IRepository<ClassificationOfAccident> _ClassificationOfAccidentRepo)
        {
            this.ClassificationOfAccidentRepo = _ClassificationOfAccidentRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<ClassificationOfAccident> temp = ClassificationOfAccidentRepo.getall();
            List<ClassificationOfAccidentDTO> newTemp = new List<ClassificationOfAccidentDTO>();
            foreach (ClassificationOfAccident ClassificationOfAccident in temp)
            {
                ClassificationOfAccidentDTO ClassificationOfAccidentDTO = new ClassificationOfAccidentDTO();
                ClassificationOfAccidentDTO.Id = ClassificationOfAccident.Id;
                ClassificationOfAccidentDTO.Name = ClassificationOfAccident.Name;
                ClassificationOfAccidentDTO.IsDeleted = ClassificationOfAccident.IsDeleted;

                newTemp.Add(ClassificationOfAccidentDTO);
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
		public PageResult<ClassificationOfAccidentDTO> GettAllClassificationOfAccidentByPage(int? page, int pagesize = 10)
		{
			List<ClassificationOfAccident> temp = ClassificationOfAccidentRepo.getall();
			List<ClassificationOfAccidentDTO> newTemp = new List<ClassificationOfAccidentDTO>();
			foreach (ClassificationOfAccident ClassificationOfAccident in temp)
			{
				ClassificationOfAccidentDTO ClassificationOfAccidentDTO = new ClassificationOfAccidentDTO();
				ClassificationOfAccidentDTO.Id = ClassificationOfAccident.Id;
				ClassificationOfAccidentDTO.Name = ClassificationOfAccident.Name;
				ClassificationOfAccidentDTO.IsDeleted = ClassificationOfAccident.IsDeleted;

				newTemp.Add(ClassificationOfAccidentDTO);
			}

			float countDetails = ClassificationOfAccidentRepo.getall().Count();
			var result = new PageResult<ClassificationOfAccidentDTO>
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
                ClassificationOfAccidentDTO ClassificationOfAccidentDTO = new ClassificationOfAccidentDTO();
                ClassificationOfAccident classificationOfAccident = ClassificationOfAccidentRepo.getbyid(ID);
                ClassificationOfAccidentDTO.Id = classificationOfAccident.Id;
                ClassificationOfAccidentDTO.Name = classificationOfAccident.Name;
                ClassificationOfAccidentDTO.IsDeleted = classificationOfAccident.IsDeleted;

                result.Message = "Success";
                result.Data = ClassificationOfAccidentDTO;
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
        public ActionResult<ResultDTO> Put(int id, ClassificationOfAccidentDTO newClassificationOfAccident) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ClassificationOfAccident orgClassificationOfAccident = ClassificationOfAccidentRepo.getbyid(id);
                    newClassificationOfAccident.Id = orgClassificationOfAccident.Id;
                    orgClassificationOfAccident.Name = newClassificationOfAccident.Name;
                    orgClassificationOfAccident.IsDeleted = newClassificationOfAccident.IsDeleted;


                    ClassificationOfAccidentRepo.update(orgClassificationOfAccident);
                    result.Message = "Success";
                    result.Data = orgClassificationOfAccident;
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
        public ActionResult<ResultDTO> AddClassificationOfAccident(ClassificationOfAccidentDTO classificationOfAccidentDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    ClassificationOfAccident classificationOfAccident = new ClassificationOfAccident();
                    classificationOfAccident.Id = classificationOfAccidentDTO.Id;
                    classificationOfAccident.Name = classificationOfAccidentDTO.Name;
                    classificationOfAccident.IsDeleted = classificationOfAccidentDTO.IsDeleted;

                    ClassificationOfAccidentRepo.create(classificationOfAccident);
                    result.Message = "Success";
                    result.Data = classificationOfAccidentDTO;
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
                ClassificationOfAccident classificationOfAccident = ClassificationOfAccidentRepo.getbyid(id);
                classificationOfAccident.IsDeleted = true;
                ClassificationOfAccidentRepo.update(classificationOfAccident);
                result.Data = classificationOfAccident;
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
