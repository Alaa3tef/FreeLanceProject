using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.Models;
using TempProject.Repository;

namespace TempProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteNameController : ControllerBase
    {
        public IRepository<RouteName> RouteNameRepo { get; set; }

        public RouteNameController(IRepository<RouteName> _RouteNameRepo)
        {
            this.RouteNameRepo = _RouteNameRepo;
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetAll()
        {

            ResultDTO result = new ResultDTO();

            List<RouteName> temp = RouteNameRepo.getall();
            List<RouteNameDTO> newTemp = new List<RouteNameDTO>();
            foreach (RouteName RouteName in temp)
            {
                RouteNameDTO RouteNameDTO = new RouteNameDTO();
                RouteNameDTO.Id = RouteName.Id;
                RouteNameDTO.Name = RouteName.Name;
                RouteNameDTO.IsDeleted = RouteName.IsDeleted;

                newTemp.Add(RouteNameDTO);
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
		public PageResult<RouteNameDTO> GettAllRouteNameByPage(int? page, int pagesize = 10)
		{
			List<RouteName> temp = RouteNameRepo.getall();
			List<RouteNameDTO> newTemp = new List<RouteNameDTO>();
			foreach (RouteName RouteName in temp)
			{
				RouteNameDTO RouteNameDTO = new RouteNameDTO();
				RouteNameDTO.Id = RouteName.Id;
				RouteNameDTO.Name = RouteName.Name;
				RouteNameDTO.IsDeleted = RouteName.IsDeleted;

				newTemp.Add(RouteNameDTO);
			}

			float countDetails = RouteNameRepo.getall().Count();
			var result = new PageResult<RouteNameDTO>
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
                RouteNameDTO RouteNameDTO = new RouteNameDTO();
                RouteName RouteName = RouteNameRepo.getbyid(ID);
                RouteNameDTO.Id = RouteName.Id;
                RouteNameDTO.Name = RouteName.Name;
                RouteNameDTO.IsDeleted = RouteName.IsDeleted;

                result.Message = "Success";
                result.Data = RouteNameDTO;
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
        public ActionResult<ResultDTO> Put(int id, RouteNameDTO newRouteName) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    RouteName orgRouteName = RouteNameRepo.getbyid(id);
                    newRouteName.Id = orgRouteName.Id;
                    orgRouteName.Name = newRouteName.Name;
                    orgRouteName.IsDeleted = newRouteName.IsDeleted;


                    RouteNameRepo.update(orgRouteName);
                    result.Message = "Success";
                    result.Data = orgRouteName;
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
        public ActionResult<ResultDTO> AddRouteName(RouteNameDTO RouteNameDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    RouteName RouteName = new RouteName();
                    RouteName.Id = RouteNameDTO.Id;
                    RouteName.Name = RouteNameDTO.Name;
                    RouteName.IsDeleted = RouteNameDTO.IsDeleted;

                    RouteNameRepo.create(RouteName);
                    result.Message = "Success";
                    result.Data = RouteNameDTO;
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
                RouteName routeName = RouteNameRepo.getbyid(id);
                routeName.IsDeleted = true;
                RouteNameRepo.update(routeName);
                result.Data = routeName;
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
