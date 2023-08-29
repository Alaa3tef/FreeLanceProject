using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QHSEPositionNameController : ControllerBase
    {
        public IRepository<QHSEPositionName> QHSEPositionNameRepo { get; set; }
		public IRepository<QHSEPosition> QHSEPositionRepo { get; set; }


		public QHSEPositionNameController(IRepository<QHSEPosition> _QHSEPositionRepo,IRepository<QHSEPositionName> _QHSEPositionNameRepo)
        {
			this.QHSEPositionNameRepo = _QHSEPositionNameRepo;
			this.QHSEPositionRepo = _QHSEPositionRepo;
		}
		[HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<QHSEPositionName> temp = QHSEPositionNameRepo.getall();
            List<QHSEPositionNameDTO> newTemp = new List<QHSEPositionNameDTO>();
            foreach (QHSEPositionName QHSEPositionName in temp)
            {
                QHSEPositionNameDTO QHSEPositionNameDTO = new QHSEPositionNameDTO();
                QHSEPositionNameDTO.Id = QHSEPositionName.Id;
				QHSEPositionNameDTO.Name = QHSEPositionName.Name;
				QHSEPositionNameDTO.EmpCode = QHSEPositionName.EmpCode;
				QHSEPositionNameDTO.PositionId = QHSEPositionName.PositionId;
                QHSEPositionNameDTO.IsDeleted = QHSEPositionName.IsDeleted;

                newTemp.Add(QHSEPositionNameDTO);
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

			List<QHSEPositionName> temp = QHSEPositionNameRepo.getall();
			List<QHSEPositionNameExcelDTO> newTemp = new List<QHSEPositionNameExcelDTO>();
			foreach (QHSEPositionName QHSEPositionName in temp)
			{
				QHSEPositionNameExcelDTO QHSEPositionNameDTO = new QHSEPositionNameExcelDTO();
				QHSEPositionNameDTO.Id = QHSEPositionName.Id;
				QHSEPositionNameDTO.Name = QHSEPositionName.Name;
				QHSEPositionNameDTO.EmpCode = QHSEPositionName.EmpCode;
                QHSEPositionNameDTO.Position = QHSEPositionRepo.getbyid(QHSEPositionName.PositionId).Name;

				newTemp.Add(QHSEPositionNameDTO);
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
		public PageResult<QHSEPositionNameDTO> GettAllQHSEPositionNameByPage(int? page, int pagesize = 10)
		{
			List<QHSEPositionName> temp = QHSEPositionNameRepo.getall();
			List<QHSEPositionNameDTO> newTemp = new List<QHSEPositionNameDTO>();
			foreach (QHSEPositionName QHSEPositionName in temp)
			{
				QHSEPositionNameDTO QHSEPositionNameDTO = new QHSEPositionNameDTO();
				QHSEPositionNameDTO.Id = QHSEPositionName.Id;
				QHSEPositionNameDTO.Name = QHSEPositionName.Name;
				QHSEPositionNameDTO.EmpCode = QHSEPositionName.EmpCode;
				QHSEPositionNameDTO.PositionId = QHSEPositionName.PositionId;
				QHSEPositionNameDTO.IsDeleted = QHSEPositionName.IsDeleted;

				newTemp.Add(QHSEPositionNameDTO);
			}

			float countDetails = QHSEPositionNameRepo.getall().Count();
			var result = new PageResult<QHSEPositionNameDTO>
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

            List<QHSEPositionName> temp = QHSEPositionNameRepo.getall().Where(n => n.PositionId == positionId).ToList();
            List<QHSEPositionNameDTO> newTemp = new List<QHSEPositionNameDTO>();
            foreach (QHSEPositionName QHSEPositionName in temp)
            {
                QHSEPositionNameDTO QHSEPositionNameDTO = new QHSEPositionNameDTO();
                QHSEPositionNameDTO.Id = QHSEPositionName.Id;
				QHSEPositionNameDTO.Name = QHSEPositionName.Name;
				QHSEPositionNameDTO.EmpCode = QHSEPositionName.EmpCode;
				QHSEPositionNameDTO.PositionId = QHSEPositionName.PositionId;
                QHSEPositionNameDTO.IsDeleted = QHSEPositionName.IsDeleted;

                newTemp.Add(QHSEPositionNameDTO);
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

		[HttpGet("Code/{empCode:int}")]
		public ActionResult<ResultDTO> GetByEmpCode(int empCode)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				QHSEPositionNameDTO QHSEPositionNameDTO = new QHSEPositionNameDTO();
				QHSEPositionName QHSEPositionName = QHSEPositionNameRepo.getall().FirstOrDefault(t => t.EmpCode == empCode);
				QHSEPositionNameDTO.Id = QHSEPositionName.Id;
				QHSEPositionNameDTO.Name = QHSEPositionName.Name;
				QHSEPositionNameDTO.EmpCode = QHSEPositionName.EmpCode;
				QHSEPositionNameDTO.PositionId = QHSEPositionName.PositionId;
				QHSEPositionNameDTO.IsDeleted = QHSEPositionName.IsDeleted;

				result.Data = QHSEPositionNameDTO;
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
        public ActionResult<ResultDTO> Put(int id, QHSEPositionNameDTO newQHSEPositionName) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    QHSEPositionName orgQHSEPositionName = QHSEPositionNameRepo.getbyid(id);
                    newQHSEPositionName.Id = orgQHSEPositionName.Id;
					orgQHSEPositionName.Name = newQHSEPositionName.Name;
					orgQHSEPositionName.EmpCode = newQHSEPositionName.EmpCode;
					orgQHSEPositionName.PositionId = newQHSEPositionName.PositionId;
                    orgQHSEPositionName.IsDeleted = newQHSEPositionName.IsDeleted;


                    QHSEPositionNameRepo.update(orgQHSEPositionName);
                    result.Message = "Success";
                    result.Data = orgQHSEPositionName;
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

        [HttpGet("{ID:int}")]
        public ActionResult<ResultDTO> GetByID(int ID)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                QHSEPositionNameDTO QHSEPositionNameDTO = new QHSEPositionNameDTO();
                QHSEPositionName QHSEPositionName = QHSEPositionNameRepo.getbyid(ID);
                QHSEPositionNameDTO.Id = QHSEPositionName.Id;
				QHSEPositionNameDTO.Name = QHSEPositionName.Name;
				QHSEPositionNameDTO.EmpCode = QHSEPositionName.EmpCode;
				QHSEPositionNameDTO.PositionId = QHSEPositionName.PositionId;
                QHSEPositionNameDTO.IsDeleted = QHSEPositionName.IsDeleted;

                result.Message = "Success";
                result.Data = QHSEPositionNameDTO;
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

        [HttpPost]
        public ActionResult<ResultDTO> AddQHSEPositionName(QHSEPositionNameDTO QHSEPositionNameDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    QHSEPositionName QHSEPositionName = new QHSEPositionName();
                    QHSEPositionName.Id = QHSEPositionNameDTO.Id;
					QHSEPositionName.Name = QHSEPositionNameDTO.Name;
					QHSEPositionName.EmpCode = QHSEPositionNameDTO.EmpCode;
					QHSEPositionName.PositionId = QHSEPositionNameDTO.PositionId;
                    QHSEPositionName.IsDeleted = QHSEPositionNameDTO.IsDeleted;

                    QHSEPositionNameRepo.create(QHSEPositionName);
                    result.Data = QHSEPositionNameDTO;
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
                QHSEPositionName qHSEPositionName = QHSEPositionNameRepo.getbyid(id);
                qHSEPositionName.IsDeleted = true;
                QHSEPositionNameRepo.update(qHSEPositionName);
                result.Data = qHSEPositionName;
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
