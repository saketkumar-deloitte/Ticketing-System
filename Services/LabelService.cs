


public class LabelService : ILabelService
{

    private UserContext userContext;

    public LabelService(UserContext _userContext)
    {
        userContext = _userContext;
    }

    public ResponseModel<Label> addLabel(Label label)
    {
        var responseModel = new ResponseModel<Label>();

        try
        {

            userContext.Add(label);
            userContext.SaveChanges();

            responseModel.Data = label;
            responseModel.Messsage = "Data";

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Issue> addLabelToIssue(int issueId, int labelId)
    {
        var responseModel = new ResponseModel<Issue>();

        try
        {
            var issue = userContext.Issues.FirstOrDefault(a => a.issueId == issueId);
             var label = userContext.Labels.FirstOrDefault(a => a.labelId == labelId);

            if (issue == null)
            {
                responseModel.Messsage = "Error no issue found";
                responseModel.IsSuccess = false;
            }else if(label==null){
                responseModel.Messsage = "Error no label found";
                responseModel.IsSuccess = false;
            }
            else
            {
                if(issue.listLabel==null){
                    issue.listLabel=new List<Label>();
                }
                
                issue.listLabel.Add(label);
                userContext.Update<Issue>(issue);
                userContext.SaveChanges();

                responseModel.Data=issue;
                responseModel.Messsage = "Data";
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Label> deleteLabel(int labelId)
    {
        var responseModel = new ResponseModel<Label>();

        try
        {
            
          
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }
}