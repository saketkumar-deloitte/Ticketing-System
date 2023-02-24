
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class IssueController
{


    private IIssueService issueService;

    public IssueController(IIssueService _issueService)
    {
        issueService = _issueService;
    }



    [HttpPost]
    [Route("[action]")]
    public Issue AddIssue(issueDto issue)
    {
        return issueService.addIssue(issue);
    }


    [HttpGet]
    [Route("[action]")]
    public List<Issue> GetAllIssues()
    {
        return issueService.getAllIssue();
    }


    [HttpGet]
    [Route("[action]")]
    public Issue UpdateIssueSatus(int issueId)
    {
        return issueService.UpdateIssueStatus(issueId);
    }


    [HttpGet]
    [Route("[action]")]
    public Issue DownGradeIssueSatus(int issueId,int level)
    {
        return issueService.DownGradeIssueStatus(issueId,level);
    }


}