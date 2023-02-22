using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;



[ApiController]
[Route("[controller]")]
public class UserController{

    private IUserService userService;

    public UserController(IUserService _userService)
    {
       userService=_userService;   
    }


    [HttpPost]
    [Route("[action]")]
    public String UserSignUp(userSignUpDto user){
         return userService.SignUp(user);
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