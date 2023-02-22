

using System.ComponentModel.DataAnnotations;

public class Issue
{


    [Key]
    public int issueId { get; set; }

    public String description { get; set; }

    public Project creator { get; set; }
}