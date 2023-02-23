


using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProjectController{


    private IProjectService projectService;


    public ProjectController(IProjectService _projectService)
    {
        projectService=_projectService;
    }

    [HttpPost]
    [Route("[action]")]
    public Project AddProject(projectDto project)
    {
        return projectService.AddProject(project);
    }


    [HttpGet]
    [Route("[action]")]
    public List<Project> GetAllProject()
    {
        return projectService.getAllProject();
    }
    
}