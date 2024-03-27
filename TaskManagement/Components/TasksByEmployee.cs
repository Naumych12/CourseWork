using Microsoft.AspNetCore.Mvc;
using TaskManagement.File;

namespace TaskManagement.Components
{
    public class TasksByEmployee : ViewComponent
    {
        private readonly EmployeeRepository _employeeRepository;
        public TasksByEmployee(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke()
        {
            var projects = _employeeRepository.Employees.OrderBy(p => p.Name);
            return View(projects);
        }
    }
}
