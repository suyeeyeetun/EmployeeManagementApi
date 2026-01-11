using EmployeeManagementApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeSalaryController : ControllerBase
{
    private readonly IEmployeeAdoRepository _employeeAdoRepository;

    public EmployeeSalaryController(IEmployeeAdoRepository employeeAdoRepository)
    {
        _employeeAdoRepository = employeeAdoRepository;
    }

    [HttpPost("promote/{id}")]
    public IActionResult Promote(int id, decimal newSalary)
    {
        try
        {
            _employeeAdoRepository.UpdateSalary(id, newSalary);
            return Ok("Salary updated successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
