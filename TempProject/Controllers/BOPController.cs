using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempProject.DTO;
using TempProject.DTO.ResponseDTO;
using TempProject.Models;
using TempProject.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BOPController : ControllerBase
	{
        public IRepository<BOP> BOPRepo { get; set; }
        public IBOPRepossitory BOPRepoistory { get; set; }

        public BOPController(IBOPRepossitory _BOPrRepoistory, IRepository<BOP> _BOPRepo)
        {
            this.BOPRepo = _BOPRepo;
            this.BOPRepoistory = _BOPrRepoistory;
        }

        [HttpGet("GetData")]
        public ActionResult<ResultDTO> GetAllWithData(string UserId,string UserRole)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                if(string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
					List<BOP> temp = BOPRepoistory.getall();
					List<BOPResponseDTO> newTemp = new List<BOPResponseDTO>();
					foreach (BOP bop in temp)
					{
                        BOPResponseDTO BOPDTO = new BOPResponseDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.Rig.Number;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserName = bop.user.UserName;
                        BOPDTO.Visitors = bop.Visitors;

                        newTemp.Add(BOPDTO);
						//result.Data = prod;
					}
					if (newTemp != null)
					{

						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
                else if(string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
					List<BOP> temp = BOPRepoistory.getall().Where(s=>s.user.Id==UserId).ToList();
					List<BOPResponseDTO> newTemp = new List<BOPResponseDTO>();
					foreach (BOP bop in temp)
					{
                        BOPResponseDTO BOPDTO = new BOPResponseDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.Rig.Number;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserName = bop.user.UserName;

                        newTemp.Add(BOPDTO);
						//result.Data = prod;
					}
					if (newTemp != null)
					{

						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
			}

            catch(Exception ex)
            {
				result.Statescode = 404;
				result.Message = "data not found";
			}

            return result;
        }



		[HttpGet("GetTotalManHours")]
		public ActionResult<ResultDTO> GetTotalManHours(string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();

			try
			{
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
					List<BOP> temp = BOPRepoistory.getall().Where(e => e.Date.Year == DateTime.Now.Year).ToList();
					long TotalSum = 0;

					foreach (BOP bop in temp)
					{
						TotalSum += bop.TotalManHours;
					}
					result.Statescode = 200;
					result.Data = TotalSum;
					return result;
				}
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase)) 
                {
					List<BOP> temp = BOPRepoistory.getall().Where(e => e.Date.Year == DateTime.Now.Year&&e.UserId==UserId).ToList();
					long TotalSum = 0;

					foreach (BOP bop in temp)
					{
						TotalSum += bop.TotalManHours;
					}
					result.Statescode = 200;
					result.Data = TotalSum;
					return result;
				}
			}

			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

			return result;
		}




		[HttpGet("GetDataForExcel")]
		public ActionResult<ResultDTO> GetDataForExcel(string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();
            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<BOP> temp = BOPRepoistory.getall();
                    List<BOPExcelDTO> newTemp = new List<BOPExcelDTO>();
                    foreach (BOP bop in temp)
                    {
                        BOPExcelDTO BOPDTO = new BOPExcelDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.Rig.Number;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserName = bop.user.UserName;
                        BOPDTO.Visitors = bop.Visitors;

                        newTemp.Add(BOPDTO);
                        //result.Data = prod;
                    }
                    if (newTemp != null)
                    {

                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
					List<BOP> temp = BOPRepoistory.getall().Where(s => s.user.Id == UserId).ToList();
					List<BOPExcelDTO> newTemp = new List<BOPExcelDTO>();
					foreach (BOP bop in temp)
					{
                        BOPExcelDTO BOPDTO = new BOPExcelDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.Rig.Number;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserName = bop.user.UserName;

                        newTemp.Add(BOPDTO);
                        //result.Data = prod;
                    }
					if (newTemp != null)
					{

						result.Statescode = 200;
						result.Data = newTemp;

						return result;
					}
				}
				}
            catch(Exception ex) 
            {
                result.Statescode = 404;
	            result.Message = "data not found";
            }
					
			return result;
		}




		[HttpGet("ByPage/{page:int}")]
		public PageResult<BOPResponseDTO> GettAllStoCardsByPage(string UserId, string UserRole,int? page, int pagesize = 10)
		{
            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
					List<BOP> temp = BOPRepoistory.getall();//.Where(s => s.Status == "Open").ToList();
                    List<BOPResponseDTO> newTemp = new List<BOPResponseDTO>();
                    foreach (BOP bop in temp)
                    {
                        BOPResponseDTO BOPDTO = new BOPResponseDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.Rig.Number;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserName = bop.user.UserName;
                        BOPDTO.Visitors = bop.Visitors;

                        newTemp.Add(BOPDTO);
                        //result.Data = prod;
                    }

                    float countDetails = BOPRepoistory.getall().Count();
                    var result = new PageResult<BOPResponseDTO>
                    {
                        Count = (int)Math.Ceiling(countDetails / pagesize),
                        PageIndex = page ?? 1,
                        PageSize = pagesize,
                        Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
                    };
                    return result;
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
					List<BOP> temp = BOPRepoistory.getall().Where(s => s.user.Id==UserId).ToList();//&&s.Status == "Open"
					List<BOPResponseDTO> newTemp = new List<BOPResponseDTO>();
					foreach (BOP bop in temp)
					{
                        BOPResponseDTO BOPDTO = new BOPResponseDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.Rig.Number;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserName = bop.user.UserName;

                        newTemp.Add(BOPDTO);
						//result.Data = prod;
					}

					float countDetails = BOPRepoistory.getall().Count();
					var result = new PageResult<BOPResponseDTO>
					{
						Count = (int)Math.Ceiling(countDetails / pagesize),
						PageIndex = page ?? 1,
						PageSize = pagesize,
						Items = newTemp.Skip((page - 1 ?? 0) * pagesize).Take(pagesize).ToList()
					};
					return result;
				}
            }
            catch (Exception Ex)
            {
                return new PageResult<BOPResponseDTO>();
            }
			return new PageResult<BOPResponseDTO>();

		}


		[HttpGet("GetDataById/{ID:int}")]
        public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					BOP temp = BOPRepoistory.getall().FirstOrDefault(a => a.Id == ID);
					if (temp != null)
					{
						BOPResponseDTO BOPResponseDTO = new BOPResponseDTO();
                        BOPResponseDTO.Id = temp.Id;
                        BOPResponseDTO.RigId = temp.Rig.Number;
                        BOPResponseDTO.ECDC = temp.ECDC;
                        BOPResponseDTO.Client = temp.Client;
                        BOPResponseDTO.Catering = temp.Catering;
                        BOPResponseDTO.Date = temp.Date;
                        BOPResponseDTO.Service = temp.Service;
                        BOPResponseDTO.WatchMen = temp.WatchMen;
                        BOPResponseDTO.TotalManHours = temp.TotalManHours;
                        BOPResponseDTO.inspection = temp.inspection;
                        BOPResponseDTO.Other = temp.Other;
                        BOPResponseDTO.Rental = temp.Rental;
                        BOPResponseDTO.ManPower = temp.ManPower;
                        BOPResponseDTO.UserName = temp.user.UserName;
                        BOPResponseDTO.Visitors = temp.Visitors;

                        if (BOPResponseDTO != null)
						{

							result.Statescode = 200;
							result.Data = BOPResponseDTO;

							return result;
						}
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					BOP temp = BOPRepoistory.getall().FirstOrDefault(a => a.Id == ID&&a.user.Id==UserId);
					if (temp != null)
					{
                        BOPResponseDTO BOPResponseDTO = new BOPResponseDTO();
                        BOPResponseDTO.Id = temp.Id;
                        BOPResponseDTO.RigId = temp.Rig.Number;
                        BOPResponseDTO.ECDC = temp.ECDC;
                        BOPResponseDTO.Client = temp.Client;
                        BOPResponseDTO.Catering = temp.Catering;
                        BOPResponseDTO.Date = temp.Date;
                        BOPResponseDTO.Service = temp.Service;
                        BOPResponseDTO.WatchMen = temp.WatchMen;
                        BOPResponseDTO.TotalManHours = temp.TotalManHours;
                        BOPResponseDTO.inspection = temp.inspection;
                        BOPResponseDTO.Other = temp.Other;
                        BOPResponseDTO.Rental = temp.Rental;
                        BOPResponseDTO.ManPower = temp.ManPower;
                        BOPResponseDTO.UserName = temp.user.UserName;

                        if (BOPResponseDTO != null)
						{

							result.Statescode = 200;
							result.Data = BOPResponseDTO;

							return result;
						}
					}
				}
			}
			catch (Exception ex)
			{
				result.Statescode = 404;
				result.Message = "data not found";
			}

            return result;
        }

		[HttpGet]
        public ActionResult<ResultDTO> GetAll(string UserId, string UserRole)
        {

            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<BOP> temp = BOPRepo.getall();
                    List<BopDTO> newTemp = new List<BopDTO>();
                    foreach (BOP bop in temp)
                    {
                        BopDTO BOPDTO = new BopDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.RigId;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserId = bop.UserId;
                        BOPDTO.Visitors = bop.Visitors;

                        newTemp.Add(BOPDTO);
                    }
                    if (newTemp != null)
                    {

                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    List<BOP> temp = BOPRepo.getall().Where(s => s.UserId == UserId).ToList(); ;
                    List<BopDTO> newTemp = new List<BopDTO>();
                    foreach (BOP bop in temp)
                    {
                        BopDTO BOPDTO = new BopDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.RigId;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserId = bop.UserId;
                        BOPDTO.Visitors = bop.Visitors;

                        newTemp.Add(BOPDTO);
                    }
                    if (newTemp != null)
                    {

                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Statescode = 404;
                result.Message = "data not found";
            }

            
            return result;

        }

        [HttpGet("Edit/{EditID:int}")]
        public ActionResult<ResultDTO> GetByEditID(int EditID, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					BOP bop = BOPRepo.getall().FirstOrDefault(a => a.Id == EditID);
                    BopDTO BOPDTO = new BopDTO();
                    BOPDTO.Id = bop.Id;
                    BOPDTO.RigId = bop.RigId;
                    BOPDTO.ECDC = bop.ECDC;
                    BOPDTO.Client = bop.Client;
                    BOPDTO.Catering = bop.Catering;
                    BOPDTO.Date = bop.Date;
                    BOPDTO.Service = bop.Service;
                    BOPDTO.WatchMen = bop.WatchMen;
                    BOPDTO.TotalManHours = bop.TotalManHours;
                    BOPDTO.inspection = bop.inspection;
                    BOPDTO.Other = bop.Other;
                    BOPDTO.Rental = bop.Rental;
                    BOPDTO.ManPower = bop.ManPower;
                    BOPDTO.UserId = bop.UserId;
                    BOPDTO.Visitors = bop.Visitors;



                    result.Message = "Success";
					result.Data = BOPDTO;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
                    BOP bop = BOPRepo.getall().FirstOrDefault(a => a.Id == EditID && a.UserId== UserId);
                    BopDTO BOPDTO = new BopDTO();
                    BOPDTO.Id = bop.Id;
                    BOPDTO.RigId = bop.RigId;
                    BOPDTO.ECDC = bop.ECDC;
                    BOPDTO.Client = bop.Client;
                    BOPDTO.Catering = bop.Catering;
                    BOPDTO.Date = bop.Date;
                    BOPDTO.Service = bop.Service;
                    BOPDTO.WatchMen = bop.WatchMen;
                    BOPDTO.TotalManHours = bop.TotalManHours;
                    BOPDTO.inspection = bop.inspection;
                    BOPDTO.Other = bop.Other;
                    BOPDTO.Rental = bop.Rental;
                    BOPDTO.ManPower = bop.ManPower;
                    BOPDTO.UserId = bop.UserId;
                    BOPDTO.Visitors = bop.Visitors;

                    result.Message = "Success";
                    result.Data = BOPDTO;
                    result.Statescode = 200;
                    return result;
                }
			}

			catch (Exception ex)
			{
				result.Message = "Erroe Not Find";
				result.Statescode = 404;
			}
			return result;
		}

		[HttpPut("{id:int}")]
        public ActionResult<ResultDTO> Put(int id, BopDTO newBOP) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    BOP orgBOP = BOPRepo.getbyid(id);
                    newBOP.Id = orgBOP.Id;
                    orgBOP.Date = newBOP.Date;
                    orgBOP.RigId = newBOP.RigId;
                    orgBOP.ECDC = newBOP.ECDC;
                    orgBOP.Client = newBOP.Client;
                    orgBOP.Catering = newBOP.Catering;
                    orgBOP.Date = newBOP.Date;
                    orgBOP.Service = newBOP.Service;
                    orgBOP.WatchMen = newBOP.WatchMen;
                    orgBOP.inspection = newBOP.inspection;
                    orgBOP.Other = newBOP.Other;
                    orgBOP.Rental = newBOP.Rental;
                    orgBOP.Visitors = newBOP.Visitors;
                    orgBOP.ManPower = newBOP.ECDC + newBOP.Client + newBOP.Catering + newBOP.Service
                      + newBOP.WatchMen + newBOP.Visitors + newBOP.Other + newBOP.inspection + newBOP.Rental;

                    orgBOP.TotalManHours = (newBOP.ECDC + newBOP.Client + newBOP.Catering + newBOP.Service
                       + newBOP.WatchMen + newBOP.Visitors + newBOP.Other + newBOP.inspection + newBOP.Rental) * 12;
                    BOPRepo.update(orgBOP);

                    result.Message = "Success";
                    result.Data = orgBOP;
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
        public ActionResult<ResultDTO> AddBOP(BopDTO BopDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    BOP bop = new BOP();
                    bop.Id = BopDTO.Id;
                    bop.RigId = BopDTO.RigId;
                    bop.ECDC = BopDTO.ECDC;
                    bop.Client = BopDTO.Client;
                    bop.Catering = BopDTO.Catering;
                    bop.Date = BopDTO.Date;
                    bop.Visitors = BopDTO.Visitors;
                    bop.Service = BopDTO.Service;
                    bop.WatchMen = BopDTO.WatchMen;
                    bop.inspection = BopDTO.inspection;
                    bop.Other = BopDTO.Other;
                    bop.Rental = BopDTO.Rental;
                    bop.UserId = BopDTO.UserId;
                    bop.ManPower = BopDTO.ECDC + BopDTO.Client + BopDTO.Catering + BopDTO.Service
                      + BopDTO.WatchMen + BopDTO.Visitors + BopDTO.Other + BopDTO.inspection + BopDTO.Rental;
                    bop.TotalManHours = (BopDTO.ECDC + BopDTO.Client + BopDTO.Catering + BopDTO.Service
                       + BopDTO.WatchMen + BopDTO.Visitors + BopDTO.Other + BopDTO.inspection + BopDTO.Rental) * 12;
                    BOPRepo.create(bop);
                    result.Data = BopDTO;
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

        [HttpGet("{date:DateTime}")]
		public ActionResult<ResultDTO> GetByDate(DateTime date, string UserId, string UserRole)
		{
            ResultDTO result = new ResultDTO();
            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    //
                    List<BOP> temp = BOPRepoistory.getall().Where(a => a.Date == date).ToList(); ;
                    List<BOPResponseDTO> newTemp = new List<BOPResponseDTO>();
                    foreach (BOP bop in temp)
                    {
                        BOPResponseDTO BOPDTO = new BOPResponseDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.Rig.Number;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserName = bop.user.UserName;
                        BOPDTO.Visitors = bop.Visitors;

                        newTemp.Add(BOPDTO);
                        //result.Data = prod;
                    }
                    if (newTemp != null)
                    {

                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
                    List<BOP> temp = BOPRepoistory.getall().Where(a => a.Date == date && a.UserId == UserId).ToList(); ;
                    List<BOPResponseDTO> newTemp = new List<BOPResponseDTO>();
                    foreach (BOP bop in temp)
                    {
                        BOPResponseDTO BOPDTO = new BOPResponseDTO();
                        BOPDTO.Id = bop.Id;
                        BOPDTO.RigId = bop.Rig.Number;
                        BOPDTO.ECDC = bop.ECDC;
                        BOPDTO.Client = bop.Client;
                        BOPDTO.Catering = bop.Catering;
                        BOPDTO.Date = bop.Date;
                        BOPDTO.Service = bop.Service;
                        BOPDTO.WatchMen = bop.WatchMen;
                        BOPDTO.TotalManHours = bop.TotalManHours;
                        BOPDTO.inspection = bop.inspection;
                        BOPDTO.Other = bop.Other;
                        BOPDTO.Rental = bop.Rental;
                        BOPDTO.ManPower = bop.ManPower;
                        BOPDTO.UserName = bop.user.UserName;
                        BOPDTO.Visitors = bop.Visitors;

                        newTemp.Add(BOPDTO);
                        //result.Data = prod;
                    }
                    if (newTemp != null)
                    {

                        result.Statescode = 200;
                        result.Data = newTemp;

                        return result;
                    }
                }
            }

            catch (Exception ex)
            {
                result.Message = "Erroe Not Find";
                result.Statescode = 404;
            }

			return result;
		}

		[HttpPut("Delete/{id:int}")]
        public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                BOP bop = BOPRepo.getbyid(id);
                bop.IsDeleted = true;
                BOPRepo.update(bop);
                result.Data = bop;
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
