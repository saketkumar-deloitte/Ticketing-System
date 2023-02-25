

public interface IIssueService{
    

    ResponseModel<Issue> addIssue(issueDto issue);

    ResponseModel<List<Issue>> getAllIssue();

    ResponseModel<Issue> UpdateIssueStatus(int issueId,int userId);

    ResponseModel<Issue> DownGradeIssueStatus(int issueId,int level,int userId);

    ResponseModel<Issue> getIssueById(int issueId);

    ResponseModel<Issue> assignIssueToUser(int issueId,int userId);

    ResponseModel<Issue> deleteIssue(int issueId);
    
     ResponseModel<Label>? addlabel(Label label);
}