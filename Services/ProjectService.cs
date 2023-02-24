

using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;

public class ProjectService : IProjectService
{

    private UserContext userContext;
    public ProjectService(UserContext _userConext)
    {
        userContext=_userConext;
    }


    public List<Project> getAllProject()
    {
        return userContext.Set < Project > ().ToList();
    }

    public Project addProject(projectDto project)
    {
        User user = userContext.Find<User>(project.creatorId);

        Project project1 = new Project()
        {
            description = project.description,
            creator = user
            
        };

        userContext.Add(project1);
        userContext.SaveChanges();

        return project1;
    }


    public Project updateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public string deleteProject(int projectId)
    {
        var project=userContext.Projects.FirstOrDefault(a=>a.projectId==projectId);
        if(project==null){
            return "No project is found";
        }


        userContext.Projects.Remove(project);
        userContext.SaveChanges();

        return "Deleted success";
    }


     public Project getProjectDetailById(int id)
    {
          return userContext.Projects.Include(a=>a.issueList).
          FirstOrDefault(a=>a.projectId==id);
    }

    public List<Issue> getIssueByProjectId(int projectId)
    {
          return getProjectDetailById(projectId).issueList;
    }
}