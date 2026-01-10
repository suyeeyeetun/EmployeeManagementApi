using EmployeeManagementApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IReportDapperRepository _reportDapperRepository;

    public ReportsController(IReportDapperRepository reportDapperRepository)
    {
        _reportDapperRepository = reportDapperRepository;
    }
    [HttpGet("employees-by-department")]
    public async Task<IActionResult> EmployeesByDepartment()
    {
        var result = await _reportDapperRepository.GetEmployeeCountByDepartment();
        return Ok(result);
    }

    [HttpGet("highest-salary")]
    public async Task<IActionResult> HighestSalary()
    {
        var result = await _reportDapperRepository.GetHighestSalary();
        return Ok(result);
    }


}
