using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Db;
using TaskManagement.Models;

namespace TaskManagement.File;

public class EmployeeRepository
{
    private readonly TaskDbContext _dbContext;

    public List<Issue> Issues => _dbContext.Issues
        .Include(i => i.Employee)
        .Include(i => i.Project)
        .OrderBy(i => i.Created)
        .ToList();
    public List<Employee> Employees => _dbContext.Employees.ToList();
    public List<Project> Projects => _dbContext.Projects.ToList();
    
    public EmployeeRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<SelectListItem> GetEmployeesListItems()
    {
        List<SelectListItem> selectListItems = new List<SelectListItem>();
        foreach (var employee in Employees)
        {
            selectListItems.Add(new (employee.Name, employee.Id.ToString()));
        }
        return selectListItems;
    }
    
    public void RemoveEmployee(Guid id)
    {
        var employee = _dbContext.Employees.Find(id);
        _dbContext.Remove(employee);
        _dbContext.SaveChanges();
    }

    public void AddEmployee(Employee employee)
    {
        _dbContext.Add(employee);
        _dbContext.SaveChanges();
    }
    
    public void UpdateEmployee(Employee employee)
    {
        _dbContext.Update(employee);
        _dbContext.SaveChanges();
    }
    
    public Employee GetEmployee(Guid id)
    {
        return Employees.FirstOrDefault(x => x.Id == id);
    }
}