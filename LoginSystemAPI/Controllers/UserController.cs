using LoginSystemAPI.Model;
using LoginSystemAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        [Route("add")]
        public IActionResult AddUser(UserViewModel model)
        {
            try
            { 
                ResponseModel response=new ResponseModel(); 
                if (!ModelState.IsValid)
                {
                    response.status = false;
                    response.message = "Invalid data";
                }
                else
                {
                    var result=userService.AddUser(model);
                    string err_no = result.Tables[0].Rows[0].ItemArray[0].ToString();
                    if(err_no=="0")
                    {
                        response.status = true;
                        response.message= result.Tables[0].Rows[0].ItemArray[1].ToString();
                    }
                    else
                    {
                        response.status = false;
                        response.message = result.Tables[0].Rows[0].ItemArray[1].ToString();
                    }
                    return Ok(response);
                }
                 return Ok(response);
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
            
        }
        
    }
}
