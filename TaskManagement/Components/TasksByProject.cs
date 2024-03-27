using Microsoft.AspNetCore.Mvc;
using TaskManagement.File;

namespace TaskManagement.Components
{
    public class TasksByProject : ViewComponent
    {
        private readonly ProjectRepository _projectRepository;
        public TasksByProject(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IViewComponentResult Invoke()
        {
            var projects = _projectRepository.Projects.OrderBy(p => p.Name);
            return View(projects);
        }
    }
}
