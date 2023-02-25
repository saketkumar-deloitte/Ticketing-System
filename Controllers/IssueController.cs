
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class IssueController : ControllerBase
{


    private IIssueService issueService;

    public IssueController(IIssueService _issueService)
    {
        issueService = _issueService;
    }



    [HttpPost]
    [Route("[action]")]
    public IActionResult AddIssue(issueDto issue)
    {
        return Ok(issueService.addIssue(issue));
    }


    [HttpGet]
    [Route("[action]")]
    public IActionResult GetAllIssues()
    {
        return Ok(issueService.getAllIssue());
    }


    [HttpPut]
    [Route("[action]")]
    public IActionResult UpdateIssueSatus(int issueId, int AssigneeId)
    {
        return Ok(issueService.UpdateIssueStatus(issueId, AssigneeId));
    }


    [HttpPut]
    [Route("[action]")]
    public IActionResult DownGradeIssueSatus(int issueId, int level, int AssigneeId)
    {
        return Ok(issueService.DownGradeIssueStatus(issueId, level, AssigneeId));
    }


    [HttpGet]
    [Route("[action]")]
    public IActionResult getIssueById(int issueId)
    {
        return Ok(issueService.getIssueById(issueId));
    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult assignIssueToUser(int issueId, int userId)
    {
        return Ok(issueService.assignIssueToUser(issueId, userId));
    }

    [HttpDelete]
    [Route("[action]")]
    public IActionResult deleteIssue(int issueId)
    {
        return Ok(issueService.deleteIssue(issueId));
    }


     [HttpPost]
    [Route("[action]")]
    public IActionResult AddLabel(Label label)
    {
        return Ok(issueService.addlabel(label));
    }


}