using Microsoft.AspNetCore.Mvc;
using se4458_midterm.Models;
using se4458_midterm.Models.Dto;
using se4458_midterm.Source.Svc;
using System.Net;

namespace se4458_midterm.Controllers
{
    [Route("api/v{version:apiVersion}/User")]
    [ApiController]
    [ApiVersionNeutral]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    public class LoginController : Controller
    {
        private IUserService _userService;
        protected APIResponse _response;
        public LoginController(IUserService userService)
        {
            _userService = userService;
            _response = new();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginReguestDTO loginReguestDTO)
        {
            var loginResponse = _userService.Login(loginReguestDTO);
            if(loginResponse.APIUser == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Status = "Fail";
                _response.ErrorMessage = "Username or password is invalid";
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterationRequestDTO registerationRequestDTO)
        {
            bool isUserUnique = _userService.IsUserUnique(registerationRequestDTO.UserName);

            if(!isUserUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Status = "Fail";
                _response.ErrorMessage = "User already exists";
                return BadRequest(_response);
            }

            var user = _userService.Register(registerationRequestDTO);

            if(user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Status = "Fail";
                _response.ErrorMessage = "error";
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);

        }


    }
}
