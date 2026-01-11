using Azure.Core;
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
        var result = _employeeService.GetEmployeeById(id);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        return Ok(result);
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
    public IActionResult UpdateEmployee(int id, EmployeeRequestDto request)
    {

        var result = _employeeService.UpdateEmployee(id,request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpPatch("{id}")]
    public IActionResult PatchEmployee(int id, EmployeePatchRequestDto request)
    {
        var result = _employeeService.PatchEmployee(id,request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        var result = _employeeService.DeleteEmployee(id);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }

    

}
