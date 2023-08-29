using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QHSEPositionController : ControllerBase
    {
        public IRepository<QHSEPosition> QHSEPositionRepo { get; set; }

        public QHSEPositionController(IRepository<QHSEPosition> _QHSEPositionRepo)
        {
            this.QHSEPositionRepo = _QHSEPositionRepo;
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<QHSEPosition> temp = QHSEPositionRepo.getall();
            List<QHSEPositionDTO> newTemp = new List<QHSEPositionDTO>();
            foreach (QHSEPosition QHSEPosition in temp)
            {
                QHSEPositionDTO QHSEPositionDTO = new QHSEPositionDTO();
                QHSEPositionDTO.Id = QHSEPosition.Id;
                QHSEPositionDTO.Name = QHSEPosition.Name;
                QHSEPositionDTO.IsDeleted = QHSEPosition.IsDeleted;

                newTemp.Add(QHSEPositionDTO);
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
		public PageResult<QHSEPositionDTO> GettAllQHSEPositionByPage(int? page, int pagesize = 10)
		{
			List<QHSEPosition> temp = QHSEPositionRepo.getall();
			List<QHSEPositionDTO> newTemp = new List<QHSEPositionDTO>();
			foreach (QHSEPosition QHSEPosition in temp)
			{
				QHSEPositionDTO QHSEPositionDTO = new QHSEPositionDTO();
				QHSEPositionDTO.Id = QHSEPosition.Id;
				QHSEPositionDTO.Name = QHSEPosition.Name;
				QHSEPositionDTO.IsDeleted = QHSEPosition.IsDeleted;

				newTemp.Add(QHSEPositionDTO);
			}

			float countDetails = QHSEPositionRepo.getall().Count();
			var result = new PageResult<QHSEPositionDTO>
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
                QHSEPositionDTO QHSEPositionDTO = new QHSEPositionDTO();
                QHSEPosition QHSEPosition = QHSEPositionRepo.getbyid(ID);
                QHSEPositionDTO.Id = QHSEPosition.Id;
                QHSEPositionDTO.Name = QHSEPosition.Name;
                QHSEPositionDTO.IsDeleted = QHSEPosition.IsDeleted;

                result.Message = "Success";
                result.Data = QHSEPositionDTO;
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
        public ActionResult<ResultDTO> Put(int id, QHSEPositionDTO newQHSEPosition) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    QHSEPosition orgQHSEPosition = QHSEPositionRepo.getbyid(id);
                    newQHSEPosition.Id = orgQHSEPosition.Id;
                    orgQHSEPosition.Name = newQHSEPosition.Name;
                    orgQHSEPosition.IsDeleted = newQHSEPosition.IsDeleted;


                    QHSEPositionRepo.update(orgQHSEPosition);
                    result.Message = "Success";
                    result.Data = orgQHSEPosition;
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
        public ActionResult<ResultDTO> AddQHSEPosition(QHSEPositionDTO QHSEPositionDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    QHSEPosition QHSEPosition = new QHSEPosition();
                    QHSEPosition.Id = QHSEPositionDTO.Id;
                    QHSEPosition.Name = QHSEPositionDTO.Name;
                    QHSEPosition.IsDeleted = QHSEPositionDTO.IsDeleted;

                    QHSEPositionRepo.create(QHSEPosition);
                    result.Message = "Success";
                    result.Data = QHSEPositionDTO;
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
                QHSEPosition  qHSEPosition = QHSEPositionRepo.getbyid(id);
                qHSEPosition.IsDeleted = true;
                QHSEPositionRepo.update(qHSEPosition);
                result.Data = qHSEPosition;
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
