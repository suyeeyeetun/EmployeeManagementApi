using Dapper;
using EmployeeManagementApi.Dtos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeManagementApi.Repositories;

public class ReportDapperRepository : IReportDapperRepository
{
    private readonly string _connectionString;
    public ReportDapperRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<IEnumerable<EmployeeByDepartmentReportDto>> GetEmployeeCountByDepartment()
    {
        IDbConnection db = new SqlConnection(_connectionString);
        db.Open();
        string query = @"SELECT d.Name AS DepartmentName,
		Count(e.Id) AS EmployeeCount
From Tbl_Departments d
Join Tbl_Employees e on d.Id = e.DepartmentId
Where e.isActive = 1
Group By d.Name";
        var employee = await db.QueryAsync<EmployeeByDepartmentReportDto>(query);
        return employee;
    }

    public async Task<HighestSalaryReportDto> GetHighestSalary()
    {
        IDbConnection db = new SqlConnection(_connectionString);
        db.Open();
        string query = @"
        SELECT TOP 1 e.Name AS EmployeeName,
              s.Salary
 FROM Tbl_SalaryHistory s
 JOIN Tbl_Employees e ON s.EmployeeId = e.Id
 ORDER BY s.Salary DESC";
        var highestSalary = await db.QueryFirstOrDefaultAsync<HighestSalaryReportDto>(query);
        return highestSalary;
    }

}
