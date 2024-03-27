using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models;

public class Project
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Client { get; set; }
    public double Budget { get; set; }
}