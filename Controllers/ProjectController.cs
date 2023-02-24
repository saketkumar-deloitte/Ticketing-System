using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProjectController
{


    private IProjectService projectService;


    public ProjectController(IProjectService _projectService)
    {
        projectService = _projectService;
    }

    [HttpPost]
    [Route("[action]")]
    public Project AddProject(projectDto project)
    {
        return projectService.addProject(project);
    }


    [HttpGet]
    [Route("[action]")]
    public List<Project> GetAllProject()
    {
        return projectService.getAllProject();
    }


    [HttpPut]
    [Route("[action]")]
    public Project updateProject(Project project)
    {
        return project;
    }



    [HttpDelete]
    [Route("[action]")]
    public String deleteProject(int projectId)
    {
        return projectService.deleteProject(projectId);
    }


    [HttpGet]
    [Route("[action]")]
    public Project getProjectDetailById(int id)
    {
        return projectService.getProjectDetailById(id);
    }


    [HttpGet]
    [Route("[action]")]
    public List<Issue> getIssueByProjectId(int projectId)
    {
        return projectService.getIssueByProjectId(projectId);
    }

}