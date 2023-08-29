using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.DTO.ExcelDTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        public IRepository<Passenger> PassengerRepo { get; set; }

        public PassengerController(IRepository<Passenger> _PassengerRepo)
        {
            this.PassengerRepo = _PassengerRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<Passenger> temp = PassengerRepo.getall();
            List<PassengerDTO> newTemp = new List<PassengerDTO>();
            foreach (Passenger Passenger in temp)
            {
                PassengerDTO PassengerDTO = new PassengerDTO();
                PassengerDTO.Id = Passenger.Id;
                PassengerDTO.Name = Passenger.Name;
                PassengerDTO.Telephone = Passenger.Telephone;
                PassengerDTO.IsDeleted = Passenger.IsDeleted;
                newTemp.Add(PassengerDTO);
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

			List<Passenger> temp = PassengerRepo.getall();
			List<PassengerExcel2DTO> newTemp = new List<PassengerExcel2DTO>();
			foreach (Passenger Passenger in temp)
			{
				PassengerExcel2DTO PassengerDTO = new PassengerExcel2DTO();
				PassengerDTO.Id = Passenger.Id;
				PassengerDTO.Name = Passenger.Name;
				PassengerDTO.Telephone = Passenger.Telephone;
				newTemp.Add(PassengerDTO);
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
		public PageResult<PassengerDTO> GettAllPassengerByPage(int? page, int pagesize = 10)
		{
			List<Passenger> temp = PassengerRepo.getall();
			List<PassengerDTO> newTemp = new List<PassengerDTO>();
			foreach (Passenger Passenger in temp)
			{
				PassengerDTO PassengerDTO = new PassengerDTO();
				PassengerDTO.Id = Passenger.Id;
				PassengerDTO.Name = Passenger.Name;
				PassengerDTO.Telephone = Passenger.Telephone;
				PassengerDTO.IsDeleted = Passenger.IsDeleted;
				newTemp.Add(PassengerDTO);
			}

			float countDetails = PassengerRepo.getall().Count();
			var result = new PageResult<PassengerDTO>
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
                PassengerDTO PassengerDTO = new PassengerDTO();
                Passenger Passenger = PassengerRepo.getbyid(ID);
                PassengerDTO.Id = Passenger.Id;
                PassengerDTO.Name = Passenger.Name;
                PassengerDTO.Telephone = Passenger.Telephone;
                PassengerDTO.IsDeleted = Passenger.IsDeleted;

                result.Message = "Success";
                result.Data = PassengerDTO;
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
        public ActionResult<ResultDTO> Put(int id, PassengerDTO newPassenger) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Passenger orgPassenger = PassengerRepo.getbyid(id);
                    newPassenger.Id = orgPassenger.Id;
                    orgPassenger.Name = newPassenger.Name;
                    orgPassenger.Telephone = newPassenger.Telephone;
                    orgPassenger.IsDeleted = newPassenger.IsDeleted;


                    PassengerRepo.update(orgPassenger);
                    result.Message = "Success";
                    result.Data = orgPassenger;
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
        public ActionResult<ResultDTO> AddPassenger(PassengerDTO PassengerDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Passenger Passenger = new Passenger();
                    Passenger.Id = PassengerDTO.Id;
                    Passenger.Name = PassengerDTO.Name;
                    Passenger.Telephone = PassengerDTO.Telephone;
                    Passenger.IsDeleted = PassengerDTO.IsDeleted;

                    PassengerRepo.create(Passenger);
                    result.Message = "Success";
                    result.Data = PassengerDTO;
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
                Passenger passenger = PassengerRepo.getbyid(id);
                passenger.IsDeleted = true;
                PassengerRepo.update(passenger);
                result.Data = passenger;
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
