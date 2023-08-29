using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        public IRepository<Vehicle> VehicleRepo { get; set; }

        public VehicleController(IRepository<Vehicle> _VehicleRepo)
        {
            this.VehicleRepo = _VehicleRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<Vehicle> temp = VehicleRepo.getall();
            List<VehicleDTO> newTemp = new List<VehicleDTO>();
            foreach (Vehicle Vehicle in temp)
            {
                VehicleDTO VehicleDTO = new VehicleDTO();
                VehicleDTO.Id = Vehicle.Id;
                VehicleDTO.Number = Vehicle.Number;
                VehicleDTO.Color = Vehicle.Color;
                VehicleDTO.Type = Vehicle.Type;
                VehicleDTO.PassengerNumber = Vehicle.PassengerNumber;
                VehicleDTO.IsDeleted = Vehicle.IsDeleted;
				VehicleDTO.LicenceNumber = Vehicle.LicenceNumber;
				VehicleDTO.LicenceExpireData= Vehicle.LicenceExpireData;


				newTemp.Add(VehicleDTO);
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
		public PageResult<VehicleDTO> GettAllVehicleByPage(int? page, int pagesize = 10)
		{
			List<Vehicle> temp = VehicleRepo.getall();
			List<VehicleDTO> newTemp = new List<VehicleDTO>();
			foreach (Vehicle Vehicle in temp)
			{
				VehicleDTO VehicleDTO = new VehicleDTO();
				VehicleDTO.Id = Vehicle.Id;
				VehicleDTO.Number = Vehicle.Number;
				VehicleDTO.Color = Vehicle.Color;
				VehicleDTO.Type = Vehicle.Type;
				VehicleDTO.PassengerNumber = Vehicle.PassengerNumber;
				VehicleDTO.IsDeleted = Vehicle.IsDeleted;
				VehicleDTO.LicenceNumber = Vehicle.LicenceNumber;
				VehicleDTO.LicenceExpireData = Vehicle.LicenceExpireData;


				newTemp.Add(VehicleDTO);
			}

			float countDetails = VehicleRepo.getall().Count();
			var result = new PageResult<VehicleDTO>
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
                VehicleDTO VehicleDTO = new VehicleDTO();
                Vehicle Vehicle = VehicleRepo.getbyid(ID);
                VehicleDTO.Id = Vehicle.Id;
                VehicleDTO.Number = Vehicle.Number;
                VehicleDTO.Color = Vehicle.Color;
                VehicleDTO.Type = Vehicle.Type;
                VehicleDTO.PassengerNumber = Vehicle.PassengerNumber;
                VehicleDTO.IsDeleted = Vehicle.IsDeleted;
				VehicleDTO.LicenceNumber = Vehicle.LicenceNumber;
				VehicleDTO.LicenceExpireData = Vehicle.LicenceExpireData;

                result.Message = "Success";
                result.Data = VehicleDTO;
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
        public ActionResult<ResultDTO> Put(int id, VehicleDTO newVehicle) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Vehicle orgVehicle = VehicleRepo.getbyid(id);
                    newVehicle.Id = orgVehicle.Id;
                    orgVehicle.Number = newVehicle.Number;
                    orgVehicle.Color = newVehicle.Color;
                    orgVehicle.Type = newVehicle.Type;
                    orgVehicle.PassengerNumber = newVehicle.PassengerNumber;
                    orgVehicle.IsDeleted = newVehicle.IsDeleted;
                    orgVehicle.LicenceNumber = newVehicle.LicenceNumber;
                    orgVehicle.LicenceExpireData = newVehicle.LicenceExpireData;


                    VehicleRepo.update(orgVehicle);
                    result.Message = "Success";
                    result.Data = orgVehicle;
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
        public ActionResult<ResultDTO> AddVehicle(VehicleDTO VehicleDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    Vehicle Vehicle = new Vehicle();
                    Vehicle.Id = VehicleDTO.Id;
                    Vehicle.Number = VehicleDTO.Number;
                    Vehicle.Color = VehicleDTO.Color;
                    Vehicle.Type = VehicleDTO.Type;
                    Vehicle.PassengerNumber = VehicleDTO.PassengerNumber;
                    Vehicle.IsDeleted = VehicleDTO.IsDeleted;
					Vehicle.LicenceNumber = VehicleDTO.LicenceNumber;
					Vehicle.LicenceExpireData = VehicleDTO.LicenceExpireData;

					VehicleRepo.create(Vehicle);
                    result.Message = "Success";
                    result.Data = VehicleDTO;
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
                Vehicle vehicle = VehicleRepo.getbyid(id);
                vehicle.IsDeleted = true;
                VehicleRepo.update(vehicle);
                result.Data = vehicle;
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
