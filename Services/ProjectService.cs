

using Ticketing_System.Models;

public class ProjectService : IProjectService
{

    private UserContext userContext;
    public ProjectService(UserContext _userConext)
    {
        userContext=_userConext;
    }

    public Project AddProject(projectDto project)
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

    public List<Project> getAllProject()
    {
        return userContext.Set < Project > ().ToList();
    }
}