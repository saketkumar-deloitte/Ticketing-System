using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{


    private IProjectService projectService;


    public ProjectController(IProjectService _projectService)
    {
        projectService = _projectService;
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult AddProject(projectDto project)
    {
        return Ok(projectService.addProject(project));
    }


    [HttpGet]
    [Route("[action]")]
    public IActionResult GetAllProject()
    {
        return Ok(projectService.getAllProject());
    }


    [HttpPut]
    [Route("[action]")]
    public Project updateProject(Project project)
    {
        return project;
    }



    [HttpDelete]
    [Route("[action]")]
    public IActionResult deleteProject(int projectId)
    {
        return Ok(projectService.deleteProject(projectId));
    }


    [HttpGet]
    [Route("[action]")]
    public IActionResult getProjectDetailById(int id)
    {
        return Ok(projectService.getProjectDetailById(id));
    }


    [HttpGet]
    [Route("[action]")]
    public IActionResult getIssueByProjectId(int projectId)
    {
        return Ok(projectService.getIssueByProjectId(projectId));
    }

}