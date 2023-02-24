using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private IUserService userService;

    public UserController(IUserService _userService)
    {
        userService = _userService;
    }


    [HttpPost]
    [Route("[action]")]
    public IActionResult UserSignUp(userSignUpDto user)
    {
        return Ok(userService.SignUp(user));
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult UserLogin(userloginDto user)
    {
        return Ok(userService.Login(user));
    }


    [HttpPost]
    [Route("[action]")]
    public IActionResult AddRole(int userId, int roleId)
    {
        return Ok(userService.AddRole(userId, roleId));
    }


    [HttpDelete]
    [Route("[action]")]
    public IActionResult DeleteUser(int userId)
    {
        return Ok(userService.DeleteUser(userId));
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult getUserDetail(int userId)
    {
        return Ok(userService.getUserDetail(userId));
    }


    [HttpPut]
    [Route("[action]")]
    public User updateUser(userSignUpDto user)
    {
        return userService.updateUser(user);
    }



    [HttpGet]
    [Route("[action]")]
    public IActionResult getAllUser()
    {
        return Ok(userService.getAllUser());
    }


}