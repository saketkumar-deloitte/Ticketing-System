

public interface IProjectService
{


    List<Project> getAllProject();

    Project getProjectDetailById(int id);

    Project addProject(projectDto project);

    Project updateProject(Project project);

    String deleteProject(int projectId);
   
    List<Issue> getIssueByProjectId(int projectId);


}
