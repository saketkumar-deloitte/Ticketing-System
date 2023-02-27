using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;

namespace Ticketing_System.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
public class RoleController 
{

    private IRoleService roleService;

    public RoleController(IRoleService _roleService)
    {
        roleService = _roleService;
    }


    [HttpPost]
    [Route("[action]")]
     [Authorize(Roles="admin")]
    public Role AddRole(Role role)
    {
        return roleService.AddRole(role);
    }


    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="standard")]
    public List<Role> GetAllRoles()
    {
        return roleService.GetAllRoles();
    }

}
