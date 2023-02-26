

public interface IProjectService
{


    ResponseModel<List<Project>> getAllProject();

    ResponseModel<Project> getProjectDetailById(int id);

    ResponseModel<Project> addProject(projectDto project);

    ResponseModel<Project> updateProject(Project project);

    ResponseModel<Project> deleteProject(int projectId);
   
    ResponseModel<List<Issue>> getIssueByProjectId(int projectId);


}
