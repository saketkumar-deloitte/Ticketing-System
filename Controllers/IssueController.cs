
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
    public IActionResult UpdateIssueSatus(int issueId)
    {
        return Ok(issueService.UpdateIssueStatus(issueId));
    }


    [HttpPut]
    [Route("[action]")]
    public IActionResult DownGradeIssueSatus(int issueId, int level)
    {
        return Ok(issueService.DownGradeIssueStatus(issueId, level));
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


    [HttpPost]
    [Route("[action]")]
    public IActionResult addIssueInProject(int issueId, int projectId)
    {
        return Ok(issueService.addIssueInProject(issueId, projectId));
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult getIssueInProject(int issueId, int projectId)
    {
        return Ok(issueService.getIssueInProject(issueId, projectId));
    }

    [HttpPut]
    [Route("[action]")]
    public IActionResult updateIssueInProject(issueDto issuedto, int projectId, int issueId)
    {
        return Ok(issueService.updateIssueInProject(issuedto, projectId, issueId));
    }

    [HttpDelete]
    [Route("[action]")]
    public IActionResult deletedIssueInProject(int issueId, int projectId)
    {
        return Ok(issueService.deletedIssueInProject(issueId, projectId));
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult searchIssueBy(String title, String description)
    {
        return Ok(issueService.searchIssueBy(title, description));
    } 
    
    
   
    [HttpGet]
    [Route("[action]")]
    public IActionResult getIssueGreaterThanCreatedDate(String currentDate){
        return Ok(issueService.getIssueGreaterThanCreatedDate(DateTime.Parse(currentDate)));

    }

     [HttpGet]
    [Route("[action]")]
    public IActionResult getIssueLessThanCreatedDate(String currentDate){
        return Ok(issueService.getIssueLessThanCreatedDate(DateTime.Parse(currentDate)));

    }


     [HttpGet]
    [Route("[action]")]
    public IActionResult getIssueByTypes(String type){
        return Ok(issueService.getIssueByTypes(type));
    }

}