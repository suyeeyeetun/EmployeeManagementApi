using EmployeeManagementApi.Dtos;
using EmployeeManagementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult GetEmployee()
    {
        var result = _employeeService.GetEmployee();
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateEmployee(EmployeeRequestDto request)
    {
        var result = _employeeService.CreateEmployee(request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id)
    {
        return Ok();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchEmployee(int id)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        return Ok();
    }
}
