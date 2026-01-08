using EmployeeManagementApi.Database.AppDbContextModels;
using EmployeeManagementApi.Dtos;

namespace EmployeeManagementApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _db;

    public EmployeeService(AppDbContext db)
    {
        _db = db;
    }

    public EmployeeGetResponseDtos GetEmployee()
    {
        EmployeeGetResponseDtos dto = new EmployeeGetResponseDtos();
        var lst = _db.TblEmployees.Where(x=>x.IsActive == true).ToList();
        var employees = lst.Select(item => new EmployeeDto
        {
            Id = item.Id,
            Name = item.Name,
            Email = item.Email,
            DepartmentId = item.DepartmentId
        }).ToList();
        dto = new EmployeeGetResponseDtos()
        {
            IsSuccess = true,
            Message = "Success",
            Employee = employees
        };
        return dto;
    }

    public EmployeeResponseDto CreateEmployee(EmployeeRequestDto request)
    {
        EmployeeResponseDto dto = new EmployeeResponseDto();
        if(string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.Email)){
            dto = new EmployeeResponseDto()
            {
                IsSuccess = false,
                Message = "Please fill all the values correctly."
            };
            return dto;
        };
        _db.TblEmployees.Add(new TblEmployee
        {
            Name = request.Name,
            Email = request.Email,  
            DepartmentId = request.DepartmentId,
            IsActive = true
        });
        _db.SaveChanges();
        dto = new EmployeeResponseDto
        {
            IsSuccess = true,
            Message = "Success"
        };
        return dto;
    }
}
