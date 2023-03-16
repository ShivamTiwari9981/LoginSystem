using LoginSystemAPI.Model;
using LoginSystemAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.status = false;
                    response.message = "Please enter user name or password";
                }
                else
                {
                    LoginSessionModel loginSessionModel = userService.AuthenticateUser(model);
                    if (loginSessionModel.usr_id == 0)
                    {
                        response.status = true;
                        response.message = "Invalid user name or password";
                    }
                    else
                    {
                        CreateSession(loginSessionModel);
                        response.status = true;
                        response.message = "login successfull";
                        response.data = loginSessionModel.usr_id;
                    }
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                return Ok(response);
            }
        }
        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp([FromBody] UserViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.status = false;
                    response.message = "Please Enter data";
                }
                else
                {
                    bool IsSuccess = userService.SignUpUser(model);
                    if (IsSuccess)
                    {
                        response.status = true;
                        response.message = "User registered successfully";
                    }
                    else
                    {
                        response.status = false;
                        response.message = "Error in registered";
                    }
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                return Ok(response);
            }
        }
        [HttpGet]
        [Route("getstring")]
        public IActionResult GetString()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response.message = "hello";
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("module")]
        public IActionResult GetAllModule()
        {
            try
            {
                ResponseModel response = new ResponseModel();
                string userType= GetValueFromSession("usr_type");
                 response = userService.GetAllModule("A");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

        #region session
        public void CreateSession(LoginSessionModel model)
        {
            HttpContext.Session.SetString("usr_id", model.usr_id.ToString());
            HttpContext.Session.SetString("role_id", model.role_id.ToString());
            HttpContext.Session.SetString("usr_type", model.usr_type);
        }
        public void RemoveSession()
        {
            HttpContext.Session.Remove("usr_id");
            HttpContext.Session.Remove("role_id");
            HttpContext.Session.Remove("usr_type");
        }
        public string GetValueFromSession(string sessionType)
        {
           return HttpContext.Session.GetString(sessionType)??string.Empty;
        }
        #endregion
    }
}
