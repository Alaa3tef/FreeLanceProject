
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TempProject.DTO;

namespace TempProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;
		private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> RoleManager;

		private readonly IConfiguration config;


		public AccountController(Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> RoleManager, Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager, IConfiguration config)
		{
			this.RoleManager = RoleManager;
			this.userManager = userManager;
			this.config = config;
			
		}


		//[Authorize]
		[HttpPost("register")]//api/account/register
		public async Task<ResultDTO> Register(RegisterUserDto userDTO)
		{
			ResultDTO resultDTO = new ResultDTO();
			if (ModelState.IsValid)
			{
				bool ErrorinmakeSupopject = false;
				IdentityUser userModel = new IdentityUser();
				userModel.UserName = userDTO.UserName;

                Microsoft.AspNetCore.Identity.IdentityResult resultOfUser = await userManager.CreateAsync(userModel, userDTO.Password);
                Microsoft.AspNetCore.Identity.IdentityResult resultOfRole = await userManager.AddToRoleAsync(userModel, userDTO.Role);
				
				if (resultOfUser.Succeeded && resultOfRole.Succeeded && !ErrorinmakeSupopject)
				{
					resultDTO.Message = "success";
					resultDTO.Statescode = 200;
				}
				else
				{
					resultDTO.Message = "Failure";
					resultDTO.Statescode = 400;
				}

				
				resultDTO.Data = ModelState;
			}

			return resultDTO;
		}

		[HttpPost("login")]//api/account/login
		public async Task<IActionResult> Login(LoginDTO userDto)
		{
			if (ModelState.IsValid)
			{
				//check 
				IdentityUser userModel = await userManager.FindByNameAsync(userDto.UserName);
				if (userModel != null && await userManager.CheckPasswordAsync(userModel, userDto.Password))
				{
					List<Claim> myClaims = new List<Claim>();
					myClaims.Add(new Claim(type: "ID", value: userModel.Id));
					myClaims.Add(new Claim(type: "Name", value: userModel.UserName));
					myClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

					List<string> roles = (List<string>)await userManager.GetRolesAsync(userModel);
					if (roles != null)
					{
						foreach (var item in roles)
						{
							myClaims.Add(new Claim(type: "Role", value: item));
						}
					}
					var authSecritKey =
						new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecrytKey"]));//asdZXCZX!#!@342352

					SigningCredentials credentials =
						new SigningCredentials(authSecritKey, SecurityAlgorithms.HmacSha256);

					//craete token
					JwtSecurityToken mytoken = new JwtSecurityToken(
						issuer: config["JWT:ValidIss"],
						audience: config["JWT:ValidAud"],
						expires: DateTime.Now.AddHours(2),
						claims: myClaims,
						signingCredentials: credentials
						);//signed token "resprest Toke"

					return Ok(new
					{
						message = "Success",
						token = new JwtSecurityTokenHandler().WriteToken(mytoken),
						expiration = mytoken.ValidTo
					});

				}
				//craete toke
				return BadRequest("Invalid Login Account");
			}
			return BadRequest(ModelState);
		}


		[HttpGet("getRoles")]//api/account/login
		public async Task<ResultDTO> getRoles()
		{
			ResultDTO ResultDTO = new ResultDTO();
			try
			{
				ResultDTO.Statescode = 200;
				ResultDTO.Data = RoleManager.Roles.ToList();
			}
			catch (Exception)
			{
				ResultDTO.Statescode = 400;
				ResultDTO.Data = RoleManager.Roles.ToList();
				ResultDTO.Message = "error in get roles";
			}
			return ResultDTO;
		}

		[HttpGet("CreateRoles")]//api/account/login
		public async Task<ResultDTO> CreateRoles(string RoleName)
		{
			ResultDTO ResultDTO = new ResultDTO();
			try
			{
				IdentityRole temp = new IdentityRole();
				temp.Name = RoleName;
				Microsoft.AspNetCore.Identity.IdentityResult result = await RoleManager.CreateAsync(temp);
				if (result.Succeeded)
				{
					ResultDTO.Statescode = 200;
					ResultDTO.Message = "Successed";
				}
				else
				{
					ResultDTO.Statescode = 400;
					ResultDTO.Message = "Creation not succes";
				}
			}
			catch (Exception)
			{
				ResultDTO.Statescode = 400;
				ResultDTO.Data = null;
				ResultDTO.Message = "error in get roles";

			}
			return ResultDTO;
		}


		[HttpPut("ChangePassword")]//api/account/login
		public async Task<ResultDTO> ChangePassword(ChangePasswordDTO changePasswordDTO)
		{
			IdentityUser user = await userManager.FindByIdAsync(changePasswordDTO.id);

			ResultDTO ResultDTO = new ResultDTO();
			try
			{
				var passwordHasher = new Microsoft.AspNet.Identity.PasswordHasher();
                //// Hash a password
                //string hashedPassword = passwordHasher.HashPassword(changePasswordDTO.CurrentPassword);
                //if (user.PasswordHash== hashedPassword)
                //{
                //	user.PasswordHash= changePasswordDTO.NewPassword;
                //	ResultDTO.Statescode = 200;
                //	ResultDTO.Data = user;
                //}
                //Microsoft.AspNetCore.Identity.PasswordVerificationResult r = Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success;

                //Microsoft.AspNetCore.Identity.PasswordVerificationResult passresult = userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, changePasswordDTO.CurrentPassword);
                //// result= passwordHasher.VerifyHashedPassword(user.PasswordHash, changePasswordDTO.CurrentPassword);
                //if (passresult==r)
                //{
                //	//user.PasswordHash = changePasswordDTO.NewPassword;
                //	ResultDTO.Statescode = 200;
                //	ResultDTO.Data = user;
                //}
                var res = await userManager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);
                if (res.Succeeded)
                {
                    userManager.UpdateAsync(user);
                    ResultDTO.Statescode = 200;
                    ResultDTO.Data = user;

                }
                

            }
			catch (Exception)
			{
				ResultDTO.Statescode = 400;
				ResultDTO.Data = user;
				ResultDTO.Message = "error in update password";
			}
			return ResultDTO;
		}

		



		

	}
}
