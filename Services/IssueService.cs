
using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;

public class IssueService : IIssueService
{

    private UserContext userContext;

    public IssueService(UserContext _userContext)
    {
        userContext = _userContext;
    }



    public ResponseModel<Issue> addIssue(issueDto issue)
    {

        var responseModel = new ResponseModel<Issue>();

        try
        {

            Project project = userContext.Find<Project>(issue.ProjectId);
            User Reporter = userContext.Find<User>(issue.ReporterId);


            if (project == null)
            {
                responseModel.Messsage = "No project found";
                responseModel.IsSuccess = false;

            }
            else if (Reporter == null)
            {
                responseModel.Messsage = "No reporter found";
                responseModel.IsSuccess = false;
            }
            else
            {

                Issue issue1 = new Issue()
                {
                    description = issue.description,
                    Project = project,
                    createDate = DateTime.Now,
                    updateDate = DateTime.Now,
                    status = Status.Open.ToString(),
                    Type = ((Type)issue.Type).ToString(),
                    Reporter = Reporter,
                };

                userContext.Add(issue1);
                userContext.SaveChanges();

                responseModel.Messsage = "user added";
                responseModel.Data = issue1;

            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }

        return responseModel;
    }


    public ResponseModel<List<Issue>> getAllIssue()
    {
        var responseModel = new ResponseModel<List<Issue>>();

        try
        {

            responseModel.Data = userContext.Issues.Include(s => s.Reporter).Include(s => s.Assignee).ToList();
            responseModel.Messsage = "Success";

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Issue> UpdateIssueStatus(int issueId, int userId)
    {

        var responseModel = new ResponseModel<Issue>();

        try
        {
            Issue issue = userContext.Find<Issue>(issueId);
            User Assignee = userContext.Find<User>(userId);

            if (issue == null)
            {
                responseModel.Messsage = "No Issue found";
                responseModel.IsSuccess = false;
            }
            else if (Assignee == null)
            {
                responseModel.Messsage = "No user found";
                responseModel.IsSuccess = false;
            }
            else
            {

                Status s;

                Enum.TryParse<Status>(issue.status, out s);
                int value = (int)s;

                if (value == 5)
                {
                    responseModel.Messsage = "issue is completed";
                    responseModel.IsSuccess = true;
                }
                else
                {

                    value++;
                    issue.status = ((Status)value).ToString();
                    issue.updateDate = DateTime.Now;
                    issue.Assignee = Assignee;

                    userContext.Update<Issue>(issue);
                    userContext.SaveChanges();

                    responseModel.Data = issue;
                    responseModel.Messsage = "Success";
                }
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }


    public ResponseModel<Issue> DownGradeIssueStatus(int issueId, int level, int userId)
    {

        var responseModel = new ResponseModel<Issue>();

        try
        {
            Issue issue = userContext.Find<Issue>(issueId);
            User Assignee = userContext.Find<User>(userId);

            if (issue == null)
            {
                responseModel.Messsage = "no issue found";
                responseModel.IsSuccess = false;
            }
            else if (Assignee == null)
            {
                responseModel.Messsage = "No user found";
                responseModel.IsSuccess = false;
            }
            else
            {

                Status s;

                Enum.TryParse<Status>(issue.status, out s);
                int value = (int)s;

                if (value <= level)
                {
                    responseModel.Messsage = "level can't upgraded use update api";
                    responseModel.IsSuccess = false;

                }
                else
                {

                    issue.status = ((Status)level).ToString();
                    issue.updateDate = DateTime.Now;
                    issue.Assignee = Assignee;


                    userContext.Update<Issue>(issue);
                    userContext.SaveChanges();

                    responseModel.Data = issue;
                    responseModel.Messsage = "Success";

                }
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Issue> getIssueById(int issueId)
    {
        var responseModel = new ResponseModel<Issue>();

        try
        {
            Issue issue = userContext.Find<Issue>(issueId);

            if (issue == null)
            {
                responseModel.Messsage = "no issue found";
                responseModel.IsSuccess = false;
            }
            else
            {
                responseModel.Data = issue;
                responseModel.Messsage = "Success";
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Issue> assignIssueToUser(int issueId, int userId)
    {

        var responseModel = new ResponseModel<Issue>();

        try
        {
            Issue issue = userContext.Find<Issue>(issueId);
            User Assignee = userContext.Find<User>(userId);

            if (issue == null)
            {
                responseModel.Messsage = "no issue found";
                responseModel.IsSuccess = false;
            }
            else if (Assignee == null)
            {
                responseModel.Messsage = "No user found";
                responseModel.IsSuccess = false;
            }
            else
            {
                issue.updateDate = DateTime.Now;
                issue.Assignee = Assignee;

                userContext.Update<Issue>(issue);
                userContext.SaveChanges();

                responseModel.Data = issue;
                responseModel.Messsage = "Success";

            }

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
       
    }

    public ResponseModel<Issue> deleteIssue(int issueId)
    {

        var responseModel = new ResponseModel<Issue>();

        try
        {
            Issue issue = userContext.Find<Issue>(issueId);

            if (issue == null)
            {
                responseModel.Messsage = "no issue found";
                responseModel.IsSuccess = false;
            }
            else
            {
                userContext.Issues.Remove(issue);
                userContext.SaveChanges();
                responseModel.Messsage = "Deleted";
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;

    }

    public ResponseModel<Label>? addlabel(Label label)
    {
        var responseModel = new ResponseModel<Label>();

        try
        {
          
               Label l=new Label();
               l.name=label.name;
               l.issue=new List<Issue>();

                userContext.Add(l);
                userContext.SaveChanges();
                responseModel.Messsage = "Deleted";

                responseModel.Data=label;
            
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }
}