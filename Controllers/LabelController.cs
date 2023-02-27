
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class LabelController : ControllerBase
{

    private ILabelService labelService;

    public LabelController(ILabelService _labelService)
    {
        labelService = _labelService;
    }




    [HttpPost]
    [Route("[action]")]
    public IActionResult addLabel(Label label)
    {
        return Ok(labelService.addLabel(label));
    }

    [HttpDelete]
    [Route("[action]")]
    public IActionResult deleteLabel(int labelId)
    {
        return Ok(labelService.deleteLabel(labelId));
    }

    [HttpGet]
    [Route("[action]")]
    public IActionResult addLabelToIssue(int issueId, int labelId)
    {
        return Ok(labelService.addLabelToIssue(issueId, labelId));
    }


    [HttpGet]
    [Route("[action]")]
    public IActionResult getAllLabels()
    {
        return Ok(labelService.getAllLabels());
    }

    [HttpDelete]
    [Route("[action]")]
    public IActionResult deleteLabelToIssue(int issueId, int labelId)
    {
        return Ok(labelService.deleteLabelToIssue(issueId, labelId));
    }
}