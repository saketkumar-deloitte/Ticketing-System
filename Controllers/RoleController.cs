using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;

namespace Ticketing_System.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController 
{

    private IRoleService roleService;

    public RoleController(IRoleService _roleService)
    {
        roleService = _roleService;
    }


    [HttpPost]
    [Route("[action]")]
    public Role AddRole(Role role)
    {
        return roleService.AddRole(role);
    }


    [HttpGet]
    [Route("[action]")]
    public List<Role> GetAllRoles()
    {
        return roleService.GetAllRoles();
    }

}
