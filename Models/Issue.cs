

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Issue
{


    [Key]
    public int issueId { get; set; }

    public String description { get; set; }


    public String status { get; set; }

    public String Type { get; set; }


    public DateTime createDate { get; set; }

    public DateTime updateDate { get; set; }


    [JsonIgnore]
    public Project creator { get; set; }


}