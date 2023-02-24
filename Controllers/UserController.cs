using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;



[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase{

    private IUserService userService;

    public UserController(IUserService _userService)
    {
       userService=_userService;   
    }


    [HttpPost]
    [Route("[action]")]
    public IActionResult UserSignUp(userSignUpDto user){
         return Ok(userService.SignUp(user));
    }

    [HttpPost]
    [Route("[action]")]
    public String UserLogin(userSignUpDto user){
        return userService.Login(user);
    }


     [HttpPost]
    [Route("[action]")]
    public User AddRole(int userId,int roleId){
        return userService.AddRole(userId,roleId);
    }


}