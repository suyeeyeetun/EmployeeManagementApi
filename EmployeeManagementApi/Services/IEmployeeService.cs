using EmployeeManagementApi.Dtos;

namespace EmployeeManagementApi.Services
{
    public interface IEmployeeService
    {
        EmployeeGetResponseDtos GetEmployee();
        EmployeeResponseDto CreateEmployee(EmployeeRequestDto request);
    }
}