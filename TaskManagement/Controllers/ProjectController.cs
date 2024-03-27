using Microsoft.AspNetCore.Mvc;
using TaskManagement.File;
using TaskManagement.Models;

namespace TaskManagement.Controllers;

public class ProjectController : Controller
{
    private readonly ProjectRepository _projectRepository;

    public ProjectController(ProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public IActionResult Index()
    {
        return View(_projectRepository.Projects);
    }
    
    public IActionResult DeleteProject(Guid id)
    {
        _projectRepository.RemoveProject(id);
        return RedirectToAction("Index");
    }
    
    public IActionResult EditProject(Guid id)
    {
        var project = _projectRepository.GetProject(id);
        return View(project);
    }
    
    public IActionResult EditedProject(Project project)
    {
        _projectRepository.UpdateProject(project);
        return RedirectToAction("Index");
    }
    
    public IActionResult AddProject()
    {
        return View("EditProject", new Project());
    }
    
    public IActionResult AddedProject(Project project)
    {
        project.Id = Guid.NewGuid();
        _projectRepository.AddProject(project);
        return RedirectToAction("Index");
    }
}