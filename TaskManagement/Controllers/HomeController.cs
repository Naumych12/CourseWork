using Microsoft.AspNetCore.Mvc;
using TaskManagement.File;
using TaskManagement.Models;

namespace TaskManagement.Controllers;

public class HomeController : Controller
{
    private readonly IssueRepository _issueRepository;
    private readonly ProjectRepository _projectRepository;
    private readonly EmployeeRepository _employeeRepository;

    public HomeController(IssueRepository issueRepository,
        ProjectRepository projectRepository, EmployeeRepository employeeRepository)
    {
        _issueRepository = issueRepository;
        _projectRepository = projectRepository;
        _employeeRepository = employeeRepository;
    }

    public IActionResult Index(Guid? id, string filterType)
    {
        var issues = _issueRepository.Issues;

        if (filterType == "Project")
        {
            issues = issues.Where(issue => issue.ProjectId == id).ToList();
        }
        
        if (filterType == "Employee")
        {
            issues = issues.Where(issue => issue.EmployeeId == id).ToList();
        }
            
        return View(issues);
    }
    
    public IActionResult DeleteIssue(Guid id)
    {
        _issueRepository.RemoveIssue(id);
        return RedirectToAction("Index");
    }
    
    public IActionResult EditIssue(Guid id)
    {
        ViewBag.Projects = _projectRepository.GetProjectsListItems();
        ViewBag.Employees = _employeeRepository.GetEmployeesListItems();
        var issue = _issueRepository.GetIssue(id);
        return View(issue);
    }
    
    public IActionResult EditedIssue(Issue issue)
    {
        _issueRepository.UpdateIssue(issue);
        return RedirectToAction("Index");
    }
    
    public IActionResult AddIssue()
    {
        ViewBag.Projects = _projectRepository.GetProjectsListItems();
        ViewBag.Employees = _employeeRepository.GetEmployeesListItems();
        return View("EditIssue", new Issue());
    }
    
    public IActionResult AddedIssue(Issue issue)
    {
        issue.Id = Guid.NewGuid();
        issue.Created = DateTime.Now;
        _issueRepository.AddIssue(issue);
        return RedirectToAction("Index");
    }
}