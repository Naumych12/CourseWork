using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models;

public class Employee
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}