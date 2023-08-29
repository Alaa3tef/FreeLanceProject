using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        public IRepository<Driver> DriverNameRepo { get; set; }

        public DriverController(IRepository<Driver> _DriverNameRepo)
        {
            this.DriverNameRepo = _DriverNameRepo;
        }

        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<Driver> temp = DriverNameRepo.getall();
            List<DriverDTO> newTemp = new List<DriverDTO>();
            foreach (Driver DriverName in temp)
            {
                DriverDTO DriverNameDTO = new DriverDTO();
                DriverNameDTO.Id = DriverName.Id;
                DriverNameDTO.Name = DriverName.Name;
                DriverNameDTO.IsDeleted = DriverName.IsDeleted;
				DriverNameDTO.LicenceExpireData = DriverName.LicenceExpireData;
				DriverNameDTO.LicenceNumber = DriverName.LicenceNumber;
				DriverNameDTO.PhoneNumber = DriverName.PhoneNumber;

				newTemp.Add(DriverNameDTO);
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

			List<Driver> temp = DriverNameRepo.getall();
			List<DriverExcelDTO> newTemp = new List<DriverExcelDTO>();
			foreach (Driver DriverName in temp)
			{
				DriverExcelDTO DriverNameDTO = new DriverExcelDTO();
				DriverNameDTO.Id = DriverName.Id;
				DriverNameDTO.Name = DriverName.Name;
				DriverNameDTO.LicenceExpireData = DriverName.LicenceExpireData;
				DriverNameDTO.LicenceNumber = DriverName.LicenceNumber;
				DriverNameDTO.PhoneNumber = DriverName.PhoneNumber;

				newTemp.Add(DriverNameDTO);
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
		public PageResult<DriverDTO> GettAllDriverByPage(int? page, int pagesize = 10)
		{
			List<Driver> temp = DriverNameRepo.getall();
			List<DriverDTO> newTemp = new List<DriverDTO>();
			foreach (Driver DriverName in temp)
			{
				DriverDTO DriverNameDTO = new DriverDTO();
				DriverNameDTO.Id = DriverName.Id;
				DriverNameDTO.Name = DriverName.Name;
				DriverNameDTO.IsDeleted = DriverName.IsDeleted;
				DriverNameDTO.LicenceExpireData = DriverName.LicenceExpireData;
				DriverNameDTO.LicenceNumber = DriverName.LicenceNumber;
				DriverNameDTO.PhoneNumber = DriverName.PhoneNumber;

				newTemp.Add(DriverNameDTO);
			}

			float countDetails = DriverNameRepo.getall().Count();
			var result = new PageResult<DriverDTO>
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
                DriverDTO DriverNameDTO = new DriverDTO();
                Driver DriverName = DriverNameRepo.getbyid(ID);
                DriverNameDTO.Id = DriverName.Id;
                DriverNameDTO.Name = DriverName.Name;
                DriverNameDTO.IsDeleted = DriverName.IsDeleted;
				DriverNameDTO.LicenceExpireData = DriverName.LicenceExpireData;
				DriverNameDTO.LicenceNumber = DriverName.LicenceNumber;
				DriverNameDTO.PhoneNumber = DriverName.PhoneNumber;

                result.Message = "Success";
                result.Data = DriverNameDTO;
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
        public ActionResult<ResultDTO> Put(int id, DriverDTO newDriver) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Driver orgDriver = DriverNameRepo.getbyid(id);
                    newDriver.Id = orgDriver.Id;
					orgDriver.Name = newDriver.Name;
					orgDriver.LicenceNumber = newDriver.LicenceNumber;
					orgDriver.LicenceExpireData = newDriver.LicenceExpireData;
					orgDriver.PhoneNumber = newDriver.PhoneNumber;
					orgDriver.IsDeleted = newDriver.IsDeleted;


                    DriverNameRepo.update(orgDriver);
                    result.Message = "Success";
                    result.Data = orgDriver;
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

        [HttpGet("{Name:alpha}")]
        public ActionResult<ResultDTO> GetByName(string Name)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                DriverDTO DriverNameDTO = new DriverDTO();
                Driver DriverName = DriverNameRepo.getall().FirstOrDefault(d=>d.Name==Name);
                DriverNameDTO.Id = DriverName.Id;
                DriverNameDTO.Name = DriverName.Name;
                DriverNameDTO.IsDeleted = DriverName.IsDeleted;
                DriverNameDTO.LicenceExpireData = DriverName.LicenceExpireData;
                DriverNameDTO.LicenceNumber = DriverName.LicenceNumber;
                DriverNameDTO.PhoneNumber = DriverName.PhoneNumber;

                result.Message = "Success";
                result.Data = DriverNameDTO;
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
        public ActionResult<ResultDTO> AddDriverName(DriverDTO DriverNameDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Driver DriverName = new Driver();
                    DriverName.Id = DriverNameDTO.Id;
                    DriverName.Name = DriverNameDTO.Name;
                    DriverName.IsDeleted = DriverNameDTO.IsDeleted;
					DriverName.LicenceExpireData = DriverNameDTO.LicenceExpireData;
					DriverName.LicenceNumber = DriverNameDTO.LicenceNumber;
					DriverName.PhoneNumber = DriverNameDTO.PhoneNumber;

					DriverNameRepo.create(DriverName);
                    result.Message = "Success";
                    result.Data = DriverNameDTO;
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
                Driver driver = DriverNameRepo.getbyid(id);
                driver.IsDeleted = true;
                DriverNameRepo.update(driver);
                result.Data = driver;
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
