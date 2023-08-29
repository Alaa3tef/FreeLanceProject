using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JMP_PassengerController : ControllerBase
    {
        public IRepository<JMP_Passenger> JMP_PassengerRepo { get; set; }

        public JMP_PassengerController(IRepository<JMP_Passenger> _JMP_PassengerRepo)
        {
            this.JMP_PassengerRepo = _JMP_PassengerRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<JMP_Passenger> temp = JMP_PassengerRepo.getall();
            List<JMP_PassengerDTO> newTemp = new List<JMP_PassengerDTO>();
            foreach (JMP_Passenger JMP_Passenger in temp)
            {
                JMP_PassengerDTO JMP_PassengerDTO = new JMP_PassengerDTO();
                JMP_PassengerDTO.Id = JMP_Passenger.Id;
                JMP_PassengerDTO.PassengerID = JMP_Passenger.PassengerID;
                JMP_PassengerDTO.JMPID = JMP_Passenger.JMPID;
                JMP_PassengerDTO.IsDeleted = JMP_Passenger.IsDeleted;
                newTemp.Add(JMP_PassengerDTO);
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

        [HttpGet("{ID:int}")]
        public ActionResult<ResultDTO> GetByID(int ID)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                JMP_PassengerDTO JMP_PassengerDTO = new JMP_PassengerDTO();
                JMP_Passenger JMP_Passenger = JMP_PassengerRepo.getbyid(ID);
                JMP_PassengerDTO.Id = JMP_Passenger.Id;
                JMP_PassengerDTO.PassengerID = JMP_Passenger.PassengerID;
                JMP_PassengerDTO.JMPID = JMP_Passenger.JMPID;
                JMP_PassengerDTO.IsDeleted = JMP_Passenger.IsDeleted;

                result.Message = "Success";
                result.Data = JMP_PassengerDTO;
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
        public ActionResult<ResultDTO> Put(int id, [FromForm] JMP_PassengerDTO newJMP_Passenger) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    JMP_Passenger orgJMP_Passenger = JMP_PassengerRepo.getbyid(id);
                    newJMP_Passenger.Id = orgJMP_Passenger.Id;
                    orgJMP_Passenger.PassengerID = newJMP_Passenger.PassengerID;
                    orgJMP_Passenger.JMPID = newJMP_Passenger.JMPID;
                    orgJMP_Passenger.IsDeleted = newJMP_Passenger.IsDeleted;


                    JMP_PassengerRepo.update(orgJMP_Passenger);
                    result.Message = "Success";
                    result.Data = orgJMP_Passenger;
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
        public ActionResult<ResultDTO> AddJMP_Passenger(JMP_PassengerDTO JMP_PassengerDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    JMP_Passenger JMP_Passenger = new JMP_Passenger();
                    JMP_Passenger.Id = JMP_PassengerDTO.Id;
                    JMP_Passenger.PassengerID = JMP_PassengerDTO.PassengerID;
                    JMP_Passenger.JMPID = JMP_PassengerDTO.JMPID;
                    JMP_Passenger.IsDeleted = JMP_PassengerDTO.IsDeleted;

                    JMP_PassengerRepo.create(JMP_Passenger);
                    result.Message = "Success";
                    result.Data = JMP_PassengerDTO;
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
                JMP_Passenger jMP_Passenger = JMP_PassengerRepo.getbyid(id);
                jMP_Passenger.IsDeleted = true;
                JMP_PassengerRepo.update(jMP_Passenger);
                result.Data = jMP_Passenger;
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
