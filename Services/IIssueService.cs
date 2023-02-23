

public interface IIssueService{
    

    Issue addIssue(issueDto issue);

    List<Issue> getAllIssue();

    Issue UpdateIssueStatus(int issueId);

    Issue DownGradeIssueStatus(int issueId,int level);
}