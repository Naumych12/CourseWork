using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TaskManagement.Db;
using TaskManagement.Models;

namespace TaskManagement.File;

public class IssueRepository
{
    private readonly TaskDbContext _dbContext;

    public List<Issue> Issues => _dbContext.Issues
        .Include(i => i.Employee)
        .Include(i => i.Project)
        .OrderBy(i => i.Created)
        .ToList();
    public List<Employee> Employees => _dbContext.Employees.ToList();
    public List<Project> Projects => _dbContext.Projects.ToList();
    
    public IssueRepository(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public List<SelectListItem> GetIssuesListItems()
    {
        List<SelectListItem> selectListItems = new List<SelectListItem>();
        foreach (var issue in Issues)
        {
            selectListItems.Add(new (issue.Summary, issue.Id.ToString()));
        }
        return selectListItems;
    }
    
    public void RemoveIssue(Guid id)
    {
        var issue = _dbContext.Issues.Find(id);
        _dbContext.Remove(issue);
        _dbContext.SaveChanges();
    }

    public void AddIssue(Issue issue)
    {
        _dbContext.Add(issue);
        _dbContext.SaveChanges();
    }
    
    public void UpdateIssue(Issue issue)
    {
        _dbContext.Update(issue);
        _dbContext.SaveChanges();
    }
    
    public Issue GetIssue(Guid id)
    {
        return Issues.FirstOrDefault(x => x.Id == id);
    }
}
