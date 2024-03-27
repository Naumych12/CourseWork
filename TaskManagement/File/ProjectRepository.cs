using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Db;
using TaskManagement.Models;

namespace TaskManagement.File;

public class ProjectRepository
{
    private readonly TaskDbContext _dbContext;

    public List<Issue> Issues => _dbContext.Issues
        .Include(i => i.Project)
        .Include(i => i.Project)
        .OrderBy(i => i.Created)
        .ToList();
    public List<Project> Projects => _dbContext.Projects.ToList();
    public List<Employee> Employees => _dbContext.Employees.ToList();
    
    public ProjectRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<SelectListItem> GetProjectsListItems()
    {
        List<SelectListItem> selectListItems = new List<SelectListItem>();
        foreach (var project in Projects)
        {
            selectListItems.Add(new (project.Name, project.Id.ToString()));
        }
        return selectListItems;
    }
    
    public void RemoveProject(Guid id)
    {
        var project = _dbContext.Projects.Find(id);
        _dbContext.Remove(project);
        _dbContext.SaveChanges();
    }

    public void AddProject(Project project)
    {
        _dbContext.Add(project);
        _dbContext.SaveChanges();
    }
    
    public void UpdateProject(Project project)
    {
        _dbContext.Update(project);
        _dbContext.SaveChanges();
    }
    
    public Project GetProject(Guid id)
    {
        return Projects.FirstOrDefault(x => x.Id == id);
    }
    
}