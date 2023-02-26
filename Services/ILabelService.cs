


public interface ILabelService{



    ResponseModel<Label> addLabel(Label label);

    ResponseModel<Label> deleteLabel(int labelId);

     ResponseModel<Issue> addLabelToIssue(int issueId,int labelId);


    
}