using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManagement.Models;

public class Issue
{
    [Key]
    public Guid Id { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    
    public Guid? EmployeeId { get; set; }
    [JsonIgnore]
    public Employee Employee { get; set; }
    
    public Guid? ProjectId { get; set; }
    [JsonIgnore]
    public Project Project { get; set; }
    public DateTime Created { get; set; }
}