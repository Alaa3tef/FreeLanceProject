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
	public class StopCardRegisterController : ControllerBase
	{
        public IRepository<StopCardRegister> StopCardRegisterRepo { get; set; }
        public IStopCardRepository StopCardRegisterRepoistory { get; set; }

        public StopCardRegisterController(IStopCardRepository _StopCardRegisterRepoistory, IRepository<StopCardRegister> _StopCardRegisterRepo)
        {
            this.StopCardRegisterRepo = _StopCardRegisterRepo;
            this.StopCardRegisterRepoistory = _StopCardRegisterRepoistory;
        }

        [HttpGet("GetData")]
        public ActionResult<ResultDTO> GetAllWithData(string UserId,string UserRole)
        {
            ResultDTO result = new ResultDTO();

            try
            {
                if(string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall();
					List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();
					foreach (StopCardRegister StopCardRegister in temp)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						newTemp.Add(StopCardRegisterDTO);
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
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall().Where(s=>s.user.Id==UserId).ToList();
					List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();
					foreach (StopCardRegister StopCardRegister in temp)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						newTemp.Add(StopCardRegisterDTO);
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

		[HttpGet("GetDataForExcel")]
		public ActionResult<ResultDTO> GetDataForExcel(string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();
            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    List<StopCardRegister> temp = StopCardRegisterRepoistory.getall();
                    List<StopCardExcelDTO> newTemp = new List<StopCardExcelDTO>();
                    foreach (StopCardRegister StopCardRegister in temp)
                    {
                        StopCardExcelDTO StopCardRegisterDTO = new StopCardExcelDTO();
                        StopCardRegisterDTO.Id = StopCardRegister.Id;
                        StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
                        StopCardRegisterDTO.ReportedByCode = StopCardRegister.EmpCode;
                        StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
                        StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
                        StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
                        StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
                        StopCardRegisterDTO.Date = StopCardRegister.Date;
                        StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
                        StopCardRegisterDTO.Status = StopCardRegister.Status;
                        StopCardRegisterDTO.Description = StopCardRegister.Description;
                        StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

                        newTemp.Add(StopCardRegisterDTO);
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
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall().Where(s => s.user.Id == UserId).ToList();
					List<StopCardExcelDTO> newTemp = new List<StopCardExcelDTO>();
					foreach (StopCardRegister StopCardRegister in temp)
					{
						StopCardExcelDTO StopCardRegisterDTO = new StopCardExcelDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByCode = StopCardRegister.EmpCode;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						newTemp.Add(StopCardRegisterDTO);
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


		//[HttpGet("GetDataByClassification/{classification:alpha}")]
		//public ActionResult<ResultDTO> GetAllWithClassification(string classification)
		//{


		//	// The new string will be "This_is_a_string_with_a_space"

		//	string Newclassification = classification.Replace(@"%20", " ");
		//          Console.WriteLine(Newclassification);
		//	ResultDTO result = new ResultDTO();

		//	List<StopCardRegister> temp = StopCardRegisterRepoistory.getall().Where(e=>e.Classification.Name== Newclassification || e.Status== Newclassification).ToList();
		//	List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();
		//	foreach (StopCardRegister StopCardRegister in temp)
		//	{
		//		StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
		//		StopCardRegisterDTO.Id = StopCardRegister.Id;
		//		StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
		//		StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
		//		StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
		//		StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
		//		StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
		//		StopCardRegisterDTO.Date = StopCardRegister.Date;
		//		StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
		//		StopCardRegisterDTO.Status = StopCardRegister.Status;
		//		StopCardRegisterDTO.Description = StopCardRegister.Description;
		//		StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

		//		newTemp.Add(StopCardRegisterDTO);
		//		//result.Data = prod;
		//	}
		//	if (newTemp != null)
		//	{

		//		result.Statescode = 200;
		//		result.Data = newTemp;

		//		return result;
		//	}

		//	result.Statescode = 404;
		//	result.Message = "data not found";
		//	return result;
		//}



		[HttpGet("ByPage/{page:int}")]
		public PageResult<StopCardResponseDTO> GettAllStoCardsByPage(string UserId, string UserRole,int? page, int pagesize = 10)
		{
            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall();//.Where(s => s.Status == "Open").ToList();
                    List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();
                    foreach (StopCardRegister StopCardRegister in temp)
                    {
                        StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
                        StopCardRegisterDTO.Id = StopCardRegister.Id;
                        StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
                        StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
                        StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
                        StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
                        StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
                        StopCardRegisterDTO.Date = StopCardRegister.Date;
                        StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
                        StopCardRegisterDTO.Status = StopCardRegister.Status;
                        StopCardRegisterDTO.Description = StopCardRegister.Description;
                        StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

                        newTemp.Add(StopCardRegisterDTO);
                        //result.Data = prod;
                    }

                    float countDetails = StopCardRegisterRepoistory.getall().Count();
                    var result = new PageResult<StopCardResponseDTO>
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
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall().Where(s => s.user.Id==UserId).ToList();//&&s.Status == "Open"
					List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();
					foreach (StopCardRegister StopCardRegister in temp)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						newTemp.Add(StopCardRegisterDTO);
						//result.Data = prod;
					}

					float countDetails = StopCardRegisterRepoistory.getall().Count();
					var result = new PageResult<StopCardResponseDTO>
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
                return new PageResult<StopCardResponseDTO>();
            }
			return new PageResult<StopCardResponseDTO>();

		}


		[HttpGet("GetDataByClassification")]
		public ActionResult<ResultDTO> GetAllWithClassification([FromQuery] string classification, string UserId, string UserRole)
		{
            string newClassification = classification.Replace("%20", " ");
            Console.WriteLine(newClassification);

            ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall()
						.Where(e => e.Classification.Name.Contains(newClassification) || e.Status.Contains(newClassification))
						.ToList();

					List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();

					foreach (StopCardRegister stopCardRegister in temp)
					{
						StopCardResponseDTO stopCardRegisterDTO = new StopCardResponseDTO();
						stopCardRegisterDTO.Id = stopCardRegister.Id;
						stopCardRegisterDTO.ReportedByName = stopCardRegister.ReportedByName.Name;
						stopCardRegisterDTO.ReportedByPosition = stopCardRegister.ReportedByPosition.Name;
						stopCardRegisterDTO.Classification = stopCardRegister.Classification.Name;
						stopCardRegisterDTO.TypeOfObservationCategory = stopCardRegister.TypeOfObservationCategory.Name;
						stopCardRegisterDTO.ActionRequired = stopCardRegister.ActionRequired;
						stopCardRegisterDTO.Date = stopCardRegister.Date;
						stopCardRegisterDTO.StopWorkAuthorityApplied = stopCardRegister.StopWorkAuthorityApplied;
						stopCardRegisterDTO.Status = stopCardRegister.Status;
						stopCardRegisterDTO.Description = stopCardRegister.Description;
						stopCardRegisterDTO.userName = stopCardRegister.user.UserName;

						newTemp.Add(stopCardRegisterDTO);
					}

					if (newTemp.Count > 0)
					{
						result.Statescode = 200;
						result.Data = newTemp;
					}
					else
					{
						result.Statescode = 404;
						result.Message = "Data not found";
					}
				}
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall()
	                .Where(e => (e.Classification.Name.Contains(newClassification) || e.Status.Contains(newClassification))&&e.user.Id==UserId)
	                .ToList();

					List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();

					foreach (StopCardRegister stopCardRegister in temp)
					{
						StopCardResponseDTO stopCardRegisterDTO = new StopCardResponseDTO();
						stopCardRegisterDTO.Id = stopCardRegister.Id;
						stopCardRegisterDTO.ReportedByName = stopCardRegister.ReportedByName.Name;
						stopCardRegisterDTO.ReportedByPosition = stopCardRegister.ReportedByPosition.Name;
						stopCardRegisterDTO.Classification = stopCardRegister.Classification.Name;
						stopCardRegisterDTO.TypeOfObservationCategory = stopCardRegister.TypeOfObservationCategory.Name;
						stopCardRegisterDTO.ActionRequired = stopCardRegister.ActionRequired;
						stopCardRegisterDTO.Date = stopCardRegister.Date;
						stopCardRegisterDTO.StopWorkAuthorityApplied = stopCardRegister.StopWorkAuthorityApplied;
						stopCardRegisterDTO.Status = stopCardRegister.Status;
						stopCardRegisterDTO.Description = stopCardRegister.Description;
						stopCardRegisterDTO.userName = stopCardRegister.user.UserName;

						newTemp.Add(stopCardRegisterDTO);
					}

					if (newTemp.Count > 0)
					{
						result.Statescode = 200;
						result.Data = newTemp;
					}
					else
					{
						result.Statescode = 404;
						result.Message = "Data not found";
					}
				}
            }
            catch (Exception ex)
            {
				result.Statescode = 404;
				result.Message = "Data not found";
			}

            return result;
        }

		[HttpGet("GetDataForCharts")]
		public ActionResult<ResultDTO> GetDataForCharts([FromQuery] string query, [FromQuery] int month, string UserId, string UserRole)
		{
			string newQuery = query.Replace("%20", " ");

			ResultDTO result = new ResultDTO();

            try
            {
                if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
                {
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall()
						.Where(e => e.Date.Month == month && (e.Classification.Name == newQuery || e.TypeOfObservationCategory.Name == newQuery || e.StopWorkAuthorityApplied == newQuery))
						.ToList();

					List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();

					foreach (StopCardRegister stopCardRegister in temp)
					{
						StopCardResponseDTO stopCardRegisterDTO = new StopCardResponseDTO();
						stopCardRegisterDTO.Id = stopCardRegister.Id;
						stopCardRegisterDTO.ReportedByName = stopCardRegister.ReportedByName.Name;
						stopCardRegisterDTO.ReportedByPosition = stopCardRegister.ReportedByPosition.Name;
						stopCardRegisterDTO.Classification = stopCardRegister.Classification.Name;
						stopCardRegisterDTO.TypeOfObservationCategory = stopCardRegister.TypeOfObservationCategory.Name;
						stopCardRegisterDTO.ActionRequired = stopCardRegister.ActionRequired;
						stopCardRegisterDTO.Date = stopCardRegister.Date;
						stopCardRegisterDTO.StopWorkAuthorityApplied = stopCardRegister.StopWorkAuthorityApplied;
						stopCardRegisterDTO.Status = stopCardRegister.Status;
						stopCardRegisterDTO.Description = stopCardRegister.Description;
						stopCardRegisterDTO.userName = stopCardRegister.user.UserName;

						newTemp.Add(stopCardRegisterDTO);
					}

					if (newTemp.Count > 0)
					{
						result.Statescode = 200;
						result.Data = newTemp;
					}
					else
					{
						result.Statescode = 404;
						result.Message = "Data not found";
					}
				}
                else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
                {
					List<StopCardRegister> temp = StopCardRegisterRepoistory.getall()
						.Where(e => (e.Date.Month == month && (e.Classification.Name == newQuery || e.TypeOfObservationCategory.Name == newQuery || e.StopWorkAuthorityApplied == newQuery))&&e.user.Id==UserId)
						.ToList();

					List<StopCardResponseDTO> newTemp = new List<StopCardResponseDTO>();

					foreach (StopCardRegister stopCardRegister in temp)
					{
						StopCardResponseDTO stopCardRegisterDTO = new StopCardResponseDTO();
						stopCardRegisterDTO.Id = stopCardRegister.Id;
						stopCardRegisterDTO.ReportedByName = stopCardRegister.ReportedByName.Name;
						stopCardRegisterDTO.ReportedByPosition = stopCardRegister.ReportedByPosition.Name;
						stopCardRegisterDTO.Classification = stopCardRegister.Classification.Name;
						stopCardRegisterDTO.TypeOfObservationCategory = stopCardRegister.TypeOfObservationCategory.Name;
						stopCardRegisterDTO.ActionRequired = stopCardRegister.ActionRequired;
						stopCardRegisterDTO.Date = stopCardRegister.Date;
						stopCardRegisterDTO.StopWorkAuthorityApplied = stopCardRegister.StopWorkAuthorityApplied;
						stopCardRegisterDTO.Status = stopCardRegister.Status;
						stopCardRegisterDTO.Description = stopCardRegister.Description;
						stopCardRegisterDTO.userName = stopCardRegister.user.UserName;

						newTemp.Add(stopCardRegisterDTO);
					}

					if (newTemp.Count > 0)
					{
						result.Statescode = 200;
						result.Data = newTemp;
					}
					else
					{
						result.Statescode = 404;
						result.Message = "Data not found";
					}
				}
            }

            catch (Exception ex)
            {
				result.Statescode = 404;
				result.Message = "Data not found";
			}

			return result;
		}




		[HttpGet("GetDataById/{ID:int}")]
        public ActionResult<ResultDTO> GetAllWithDataByID(int ID, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();

			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					StopCardRegister temp = StopCardRegisterRepoistory.getall().FirstOrDefault(a => a.Id == ID);
					if (temp != null)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = temp.Id;
						StopCardRegisterDTO.ReportedByName = temp.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = temp.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = temp.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = temp.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = temp.ActionRequired;
						StopCardRegisterDTO.Date = temp.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = temp.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = temp.Status;
						StopCardRegisterDTO.Description = temp.Description;
						StopCardRegisterDTO.userName = temp.user.UserName;

						if (StopCardRegisterDTO != null)
						{

							result.Statescode = 200;
							result.Data = StopCardRegisterDTO;

							return result;
						}
					}
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					StopCardRegister temp = StopCardRegisterRepoistory.getall().FirstOrDefault(a => a.Id == ID&&a.user.Id==UserId);
					if (temp != null)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = temp.Id;
						StopCardRegisterDTO.ReportedByName = temp.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = temp.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = temp.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = temp.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = temp.ActionRequired;
						StopCardRegisterDTO.Date = temp.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = temp.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = temp.Status;
						StopCardRegisterDTO.Description = temp.Description;
						StopCardRegisterDTO.userName = temp.user.UserName;

						if (StopCardRegisterDTO != null)
						{

							result.Statescode = 200;
							result.Data = StopCardRegisterDTO;

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


        [HttpGet("GetDataByDate/{date:DateTime}")]
        public ActionResult<ResultDTO> GetAllWithDataByDate(DateTime date, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<StopCardResponseDTO> StopCardRegisterDTOs = new List<StopCardResponseDTO>();
					List<StopCardRegister> StopCardRegisters = StopCardRegisterRepoistory.getall().Where(a => a.Date == date).ToList();
					foreach (StopCardRegister StopCardRegister in StopCardRegisters)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						StopCardRegisterDTOs.Add(StopCardRegisterDTO);

					}
					result.Data = StopCardRegisterDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<StopCardResponseDTO> StopCardRegisterDTOs = new List<StopCardResponseDTO>();
					List<StopCardRegister> StopCardRegisters = StopCardRegisterRepoistory.getall().Where(a => a.Date == date&&a.user.Id==UserId).ToList();
					foreach (StopCardRegister StopCardRegister in StopCardRegisters)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						StopCardRegisterDTOs.Add(StopCardRegisterDTO);

					}
					result.Data = StopCardRegisterDTOs;
					result.Statescode = 200;
					return result;
				}
			}

			catch (Exception ex)
			{
				result.Message = "Error Not Find";
				result.Statescode = 404;
			}
			return result;

		}

		[HttpGet("GetDataByMonth/{date:int}")]
		public ActionResult<ResultDTO> GetAllWithDataByMonth(int date, string UserId, string UserRole)
		{
			ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<StopCardResponseDTO> StopCardRegisterDTOs = new List<StopCardResponseDTO>();
					List<StopCardRegister> StopCardRegisters = StopCardRegisterRepoistory.getall().Where(a => a.Date.Month == date).ToList();
					foreach (StopCardRegister StopCardRegister in StopCardRegisters)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						StopCardRegisterDTOs.Add(StopCardRegisterDTO);

					}
					result.Data = StopCardRegisterDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<StopCardResponseDTO> StopCardRegisterDTOs = new List<StopCardResponseDTO>();
					List<StopCardRegister> StopCardRegisters = StopCardRegisterRepoistory.getall().Where(a => a.Date.Month == date&&a.user.Id==UserId).ToList();
					foreach (StopCardRegister StopCardRegister in StopCardRegisters)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						StopCardRegisterDTOs.Add(StopCardRegisterDTO);

					}
					result.Data = StopCardRegisterDTOs;
					result.Statescode = 200;
					return result;
				}
			}
			catch (Exception ex)
			{
				result.Message = "Error Not Find";
				result.Statescode = 404;
			}
			return result;

		}


		[HttpGet("GetDataByMonthCompare")]
        public ActionResult<ResultDTO> GetDataByMonthCompare([FromQuery] int date1, [FromQuery] int date2, string UserId, string UserRole)
        {
            ResultDTO result = new ResultDTO();
			try
			{
				if (string.Equals(UserRole, "Admin", StringComparison.OrdinalIgnoreCase))
				{
					List<StopCardResponseDTO> StopCardRegisterDTOs = new List<StopCardResponseDTO>();
					List<StopCardRegister> StopCardRegisters = StopCardRegisterRepoistory.getall().Where(a => a.Date.Month == date1 || a.Date.Month == date2).ToList();
					foreach (StopCardRegister StopCardRegister in StopCardRegisters)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						StopCardRegisterDTOs.Add(StopCardRegisterDTO);

					}
					result.Data = StopCardRegisterDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<StopCardResponseDTO> StopCardRegisterDTOs = new List<StopCardResponseDTO>();
					List<StopCardRegister> StopCardRegisters = StopCardRegisterRepoistory.getall().Where(a => (a.Date.Month == date1 || a.Date.Month == date2)&&a.user.Id==UserId).ToList();
					foreach (StopCardRegister StopCardRegister in StopCardRegisters)
					{
						StopCardResponseDTO StopCardRegisterDTO = new StopCardResponseDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.ReportedByName = StopCardRegister.ReportedByName.Name;
						StopCardRegisterDTO.ReportedByPosition = StopCardRegister.ReportedByPosition.Name;
						StopCardRegisterDTO.Classification = StopCardRegister.Classification.Name;
						StopCardRegisterDTO.TypeOfObservationCategory = StopCardRegister.TypeOfObservationCategory.Name;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.userName = StopCardRegister.user.UserName;

						StopCardRegisterDTOs.Add(StopCardRegisterDTO);

					}
					result.Data = StopCardRegisterDTOs;
					result.Statescode = 200;
					return result;
				}
			}
			catch (Exception ex)
			{
				result.Message = "Error Not Find";
				result.Statescode = 404;
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
					List<StopCardRegister> temp = StopCardRegisterRepo.getall();
					List<StopCardRegisterDTO> newTemp = new List<StopCardRegisterDTO>();
					foreach (StopCardRegister StopCardRegister in temp)
					{
						StopCardRegisterDTO StopCardRegisterDTO = new StopCardRegisterDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.ClassificationID = StopCardRegister.ClassificationID;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.EmpCode = StopCardRegister.EmpCode;
						StopCardRegisterDTO.ReportedByPositionID = StopCardRegister.ReportedByPositionID;
						StopCardRegisterDTO.ReportedByNameID = StopCardRegister.ReportedByNameID;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.TypeOfObservationCategoryID = StopCardRegister.TypeOfObservationCategoryID;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.userID = StopCardRegister.userID;

						newTemp.Add(StopCardRegisterDTO);
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
					List<StopCardRegister> temp = StopCardRegisterRepo.getall().Where(s => s.userID == UserId).ToList(); ;
					List<StopCardRegisterDTO> newTemp = new List<StopCardRegisterDTO>();
					foreach (StopCardRegister StopCardRegister in temp)
					{
						StopCardRegisterDTO StopCardRegisterDTO = new StopCardRegisterDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.ClassificationID = StopCardRegister.ClassificationID;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.EmpCode = StopCardRegister.EmpCode;
						StopCardRegisterDTO.ReportedByPositionID = StopCardRegister.ReportedByPositionID;
						StopCardRegisterDTO.ReportedByNameID = StopCardRegister.ReportedByNameID;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.TypeOfObservationCategoryID = StopCardRegister.TypeOfObservationCategoryID;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.userID = StopCardRegister.userID;

						newTemp.Add(StopCardRegisterDTO);
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
					StopCardRegister StopCardRegister = StopCardRegisterRepo.getall().FirstOrDefault(a => a.Id == EditID);
					StopCardRegisterDTO StopCardRegisterDTO = new StopCardRegisterDTO();
					StopCardRegisterDTO.Id = StopCardRegister.Id;
					StopCardRegisterDTO.Date = StopCardRegister.Date;
					StopCardRegisterDTO.ClassificationID = StopCardRegister.ClassificationID;
					StopCardRegisterDTO.Description = StopCardRegister.Description;
					StopCardRegisterDTO.EmpCode = StopCardRegister.EmpCode;
					StopCardRegisterDTO.ReportedByPositionID = StopCardRegister.ReportedByPositionID;
					StopCardRegisterDTO.ReportedByNameID = StopCardRegister.ReportedByNameID;
					StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
					StopCardRegisterDTO.TypeOfObservationCategoryID = StopCardRegister.TypeOfObservationCategoryID;
					StopCardRegisterDTO.Status = StopCardRegister.Status;
					StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
					StopCardRegisterDTO.userID = StopCardRegister.userID;

					result.Message = "Success";
					result.Data = StopCardRegisterDTO;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					StopCardRegister StopCardRegister = StopCardRegisterRepo.getall().FirstOrDefault(a => a.Id == EditID&&a.userID==UserId);
					StopCardRegisterDTO StopCardRegisterDTO = new StopCardRegisterDTO();
					StopCardRegisterDTO.Id = StopCardRegister.Id;
					StopCardRegisterDTO.Date = StopCardRegister.Date;
					StopCardRegisterDTO.ClassificationID = StopCardRegister.ClassificationID;
					StopCardRegisterDTO.Description = StopCardRegister.Description;
					StopCardRegisterDTO.EmpCode = StopCardRegister.EmpCode;
					StopCardRegisterDTO.ReportedByPositionID = StopCardRegister.ReportedByPositionID;
					StopCardRegisterDTO.ReportedByNameID = StopCardRegister.ReportedByNameID;
					StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
					StopCardRegisterDTO.TypeOfObservationCategoryID = StopCardRegister.TypeOfObservationCategoryID;
					StopCardRegisterDTO.Status = StopCardRegister.Status;
					StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
					StopCardRegisterDTO.userID = StopCardRegister.userID;

					result.Message = "Success";
					result.Data = StopCardRegisterDTO;
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
        public ActionResult<ResultDTO> Put(int id, StopCardRegisterDTO newStopCard) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    StopCardRegister orgStopCard = StopCardRegisterRepo.getbyid(id);
                    newStopCard.Id = orgStopCard.Id;
                    orgStopCard.Date = newStopCard.Date;
                    orgStopCard.ClassificationID = newStopCard.ClassificationID;
                    orgStopCard.Description = newStopCard.Description;
					orgStopCard.EmpCode = newStopCard.EmpCode;
					orgStopCard.ReportedByPositionID = newStopCard.ReportedByPositionID;
					orgStopCard.ReportedByNameID = newStopCard.ReportedByNameID;
                    orgStopCard.ActionRequired = newStopCard.ActionRequired;
                    orgStopCard.TypeOfObservationCategoryID = newStopCard.TypeOfObservationCategoryID;
                    orgStopCard.Status = newStopCard.Status;
                    orgStopCard.StopWorkAuthorityApplied = newStopCard.StopWorkAuthorityApplied;
                    //orgStopCard.userID = newStopCard.userID;


                    StopCardRegisterRepo.update(orgStopCard);
                    result.Message = "Success";
                    result.Data = orgStopCard;
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
        public ActionResult<ResultDTO> AddStopCardRegister(StopCardRegisterDTO StopCardRegisterDTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                try
                {
                    StopCardRegister StopCardRegister = new StopCardRegister();
                    StopCardRegister.Id = StopCardRegisterDTO.Id;
                    StopCardRegister.Date = StopCardRegisterDTO.Date;
                    StopCardRegister.ClassificationID = StopCardRegisterDTO.ClassificationID;
                    StopCardRegister.Description = StopCardRegisterDTO.Description;
					StopCardRegister.EmpCode = StopCardRegisterDTO.EmpCode;
					StopCardRegister.ReportedByPositionID = StopCardRegisterDTO.ReportedByPositionID;
					StopCardRegister.ReportedByNameID = StopCardRegisterDTO.ReportedByNameID;
                    StopCardRegister.ActionRequired = StopCardRegisterDTO.ActionRequired;
                    StopCardRegister.TypeOfObservationCategoryID = StopCardRegisterDTO.TypeOfObservationCategoryID;
                    StopCardRegister.Status = StopCardRegisterDTO.Status;
                    StopCardRegister.StopWorkAuthorityApplied = StopCardRegisterDTO.StopWorkAuthorityApplied;
                    StopCardRegister.userID = StopCardRegisterDTO.userID;

                    StopCardRegisterRepo.create(StopCardRegister);
                    result.Data = StopCardRegisterDTO;
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
					List<StopCardRegisterDTO> StopCardRegisterDTOs = new List<StopCardRegisterDTO>();
					List<StopCardRegister> StopCardRegisters = StopCardRegisterRepo.getall().Where(a => a.Date == date).ToList();
					foreach (StopCardRegister StopCardRegister in StopCardRegisters)
					{
						StopCardRegisterDTO StopCardRegisterDTO = new StopCardRegisterDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.ClassificationID = StopCardRegister.ClassificationID;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.EmpCode = StopCardRegister.EmpCode;
						StopCardRegisterDTO.ReportedByPositionID = StopCardRegister.ReportedByPositionID;
						StopCardRegisterDTO.ReportedByNameID = StopCardRegister.ReportedByNameID;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.TypeOfObservationCategoryID = StopCardRegister.TypeOfObservationCategoryID;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.userID = StopCardRegister.userID;
						StopCardRegisterDTOs.Add(StopCardRegisterDTO);

					}
					result.Data = StopCardRegisterDTOs;
					result.Statescode = 200;
					return result;
				}
				else if (string.Equals(UserRole, "User", StringComparison.OrdinalIgnoreCase))
				{
					List<StopCardRegisterDTO> StopCardRegisterDTOs = new List<StopCardRegisterDTO>();
					List<StopCardRegister> StopCardRegisters = StopCardRegisterRepo.getall().Where(a => a.Date == date&&a.userID==UserId).ToList();
					foreach (StopCardRegister StopCardRegister in StopCardRegisters)
					{
						StopCardRegisterDTO StopCardRegisterDTO = new StopCardRegisterDTO();
						StopCardRegisterDTO.Id = StopCardRegister.Id;
						StopCardRegisterDTO.Date = StopCardRegister.Date;
						StopCardRegisterDTO.ClassificationID = StopCardRegister.ClassificationID;
						StopCardRegisterDTO.Description = StopCardRegister.Description;
						StopCardRegisterDTO.EmpCode = StopCardRegister.EmpCode;
						StopCardRegisterDTO.ReportedByPositionID = StopCardRegister.ReportedByPositionID;
						StopCardRegisterDTO.ReportedByNameID = StopCardRegister.ReportedByNameID;
						StopCardRegisterDTO.ActionRequired = StopCardRegister.ActionRequired;
						StopCardRegisterDTO.TypeOfObservationCategoryID = StopCardRegister.TypeOfObservationCategoryID;
						StopCardRegisterDTO.Status = StopCardRegister.Status;
						StopCardRegisterDTO.StopWorkAuthorityApplied = StopCardRegister.StopWorkAuthorityApplied;
						StopCardRegisterDTO.userID = StopCardRegister.userID;
						StopCardRegisterDTOs.Add(StopCardRegisterDTO);

					}
					result.Data = StopCardRegisterDTOs;
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

		[HttpPut("Delete/{id:int}")]
        public ActionResult<ResultDTO> Delete(int id) //[FromBody] string value)
        {
            ResultDTO result = new ResultDTO();
            try
            {
                StopCardRegister stopCardRegister = StopCardRegisterRepo.getbyid(id);
                stopCardRegister.IsDeleted = true;
                StopCardRegisterRepo.update(stopCardRegister);
                result.Data = stopCardRegister;
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
