using EmployeeManagementApi.Dtos;

namespace EmployeeManagementApi.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeGetResponseDtos> GetEmployee();
        Task<EmployeeGetByIdResponseDto> GetEmployeeById(int id);
        Task<EmployeeResponseDto> CreateEmployee(EmployeeRequestDto request);
        Task<EmployeeResponseDto> UpdateEmployee(int id, EmployeeRequestDto request);
        Task<EmployeeResponseDto> PatchEmployee(int id, EmployeePatchRequestDto request);
        Task<EmployeeResponseDto> DeleteEmployee(int id);
    }
}