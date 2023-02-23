


using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;

public class IssueService : IIssueService
{

    private UserContext userContext;

    public IssueService(UserContext _userContext)
    {
        userContext = _userContext;
    }



    public Issue addIssue(issueDto issue)
    {
        Project project = userContext.Find<Project>(issue.ProjectId);

        Status s;


        Issue issue1 = new Issue()
        {
            description = issue.description,
            creator = project,
            createDate = new DateTime(),
            updateDate = new DateTime(),
            status = Status.Open.ToString(),
            Type = ((Type)issue.Type).ToString()
        };

        userContext.Add(issue1);
        userContext.SaveChanges();

        return issue1;


    }


    public List<Issue> getAllIssue()
    {
        return userContext.Issues.Include(s => s.creator).ToList();
    }

    public Issue UpdateIssueStatus(int issueId)
    {
        Issue issue = userContext.Find<Issue>(issueId);

        Status s;

        Enum.TryParse<Status>(issue.status, out s);
        int value = (int)s;
        value++;
        issue.status = ((Status)value).ToString();

        userContext.Update<Issue>(issue);
        userContext.SaveChanges();

        return issue;
    }


    public Issue DownGradeIssueStatus(int issueId, int level)
    {
        Issue issue = userContext.Find<Issue>(issueId);

        Status s;

        Enum.TryParse<Status>(issue.status, out s);
        int value = (int)s;
        if (value <= level)
        {
            return null;
        }

        issue.status = ((Status)level).ToString();

        userContext.Update<Issue>(issue);
        userContext.SaveChanges();

        return issue;
    }
}