using EmployeeManagementApi.Dtos;

namespace EmployeeManagementApi.Services
{
    public interface IEmployeeService
    {
        EmployeeGetResponseDtos GetEmployee();
        EmployeeGetByIdResponseDto GetEmployeeById(int id);
        EmployeeResponseDto CreateEmployee(EmployeeRequestDto request);
        EmployeeResponseDto UpdateEmployee(int id, EmployeeRequestDto request);
        EmployeeResponseDto PatchEmployee(int id, EmployeePatchRequestDto request);
        EmployeeResponseDto DeleteEmployee(int id);
    }
}