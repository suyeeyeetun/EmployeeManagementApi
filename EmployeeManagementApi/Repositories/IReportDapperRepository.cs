using EmployeeManagementApi.Dtos;

namespace EmployeeManagementApi.Repositories
{
    public interface IReportDapperRepository
    {
        Task<IEnumerable<EmployeeByDepartmentReportDto>> GetEmployeeCountByDepartment();
        Task<HighestSalaryReportDto> GetHighestSalary();
    }
}