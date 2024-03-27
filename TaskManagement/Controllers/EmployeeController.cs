using Microsoft.AspNetCore.Mvc;
using TaskManagement.File;
using TaskManagement.Models;

namespace TaskManagement.Controllers;

public class EmployeeController : Controller
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IActionResult Index()
    {
        return View(_employeeRepository.Employees);
    }
    
    public IActionResult DeleteEmployee(Guid id)
    {
        _employeeRepository.RemoveEmployee(id);
        return RedirectToAction("Index");
    }
    
    public IActionResult EditEmployee(Guid id)
    {
        var employee = _employeeRepository.GetEmployee(id);
        return View(employee);
    }
    
    public IActionResult EditedEmployee(Employee employee)
    {
        _employeeRepository.UpdateEmployee(employee);
        return RedirectToAction("Index");
    }
    
    public IActionResult AddEmployee()
    {
        return View("EditEmployee", new Employee());
    }
    
    public IActionResult AddedEmployee(Employee employee)
    {
        employee.Id = Guid.NewGuid();
        _employeeRepository.AddEmployee(employee);
        return RedirectToAction("Index");
    }
}