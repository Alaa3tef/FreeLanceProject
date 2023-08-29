using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        public IRepository<Classification> ClassificationRepo { get; set; }

        public ClassificationController(IRepository<Classification> _ClassificationRepo)
        {
            this.ClassificationRepo = _ClassificationRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<Classification> temp = ClassificationRepo.getall();
            List<ClassificationDTO> newTemp = new List<ClassificationDTO>();
            foreach (Classification classification in temp)
            {
                ClassificationDTO ClassificationDTO = new ClassificationDTO();
                ClassificationDTO.Id = classification.Id;
                ClassificationDTO.Name = classification.Name;
                ClassificationDTO.IsDeleted = classification.IsDeleted;

                newTemp.Add(ClassificationDTO);
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
		public PageResult<ClassificationDTO> GettAllClassificationByPage(int? page, int pagesize = 10)
		{
			List<Classification> temp = ClassificationRepo.getall();
			List<ClassificationDTO> newTemp = new List<ClassificationDTO>();
			foreach (Classification classification in temp)
			{
				ClassificationDTO ClassificationDTO = new ClassificationDTO();
				ClassificationDTO.Id = classification.Id;
				ClassificationDTO.Name = classification.Name;
				ClassificationDTO.IsDeleted = classification.IsDeleted;

				newTemp.Add(ClassificationDTO);
			}

			float countDetails = ClassificationRepo.getall().Count();
			var result = new PageResult<ClassificationDTO>
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
                ClassificationDTO classificationDTO = new ClassificationDTO();
                Classification classification = ClassificationRepo.getbyid(ID);
                classificationDTO.Id = classification.Id;
                classificationDTO.Name = classification.Name;
                classificationDTO.IsDeleted = classification.IsDeleted;

                result.Message = "Success";
                result.Data = classificationDTO;
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
        public ActionResult<ResultDTO> Put(int id, ClassificationDTO newClassification) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Classification orgClassification = ClassificationRepo.getbyid(id);
                    newClassification.Id = orgClassification.Id;
                    orgClassification.Name = newClassification.Name;
                    orgClassification.IsDeleted = newClassification.IsDeleted;


                    ClassificationRepo.update(orgClassification);
                    result.Message = "Success";
                    result.Data = orgClassification;
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
        public ActionResult<ResultDTO> AddClassification(ClassificationDTO ClassificationDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Classification classification = new Classification();
                    classification.Id = ClassificationDTO.Id;
                    classification.Name = ClassificationDTO.Name;
                    classification.IsDeleted = ClassificationDTO.IsDeleted;

                    ClassificationRepo.create(classification);
                    result.Message = "Success";
                    result.Data = ClassificationDTO;
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
                Classification classification = ClassificationRepo.getbyid(id);
                classification.IsDeleted = true;
                ClassificationRepo.update(classification);
                result.Data = classification;
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
