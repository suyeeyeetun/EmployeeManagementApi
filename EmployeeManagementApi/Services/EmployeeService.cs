using Azure.Core;
using EmployeeManagementApi.Database.AppDbContextModels;
using EmployeeManagementApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _db;

    public EmployeeService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<EmployeeGetResponseDtos> GetEmployee()
    {
        EmployeeGetResponseDtos dto = new EmployeeGetResponseDtos();
        var lst = await _db.TblEmployees.Where( x => x.IsActive).ToListAsync();
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

    public async Task<EmployeeGetByIdResponseDto> GetEmployeeById(int id)
    {
        EmployeeGetByIdResponseDto dto = new EmployeeGetByIdResponseDto();
        var item = await _db.TblEmployees.Where(x => x.IsActive).FirstOrDefaultAsync(x => x.Id == id);
        if(item is null)
        {
            dto = new EmployeeGetByIdResponseDto()
            {
                IsSuccess = false,
                Message = "Not found!"
            };
            return dto;
        }
        //if(item.Id > i)
        var response = new EmployeeDto()
        {
            Id = item.Id,
            Name = item.Name,
            Email = item.Email,
            DepartmentId = item.DepartmentId
        };
        dto = new EmployeeGetByIdResponseDto()
        {
            IsSuccess = true,
            Message = "Success",
            Employee = response
        };
        return dto;
    }

    public async Task<EmployeeResponseDto> CreateEmployee(EmployeeRequestDto request)
    {
        EmployeeResponseDto dto = new EmployeeResponseDto();
        if (string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.Email)) {
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
        await _db.SaveChangesAsync();
        dto = new EmployeeResponseDto
        {
            IsSuccess = true,
            Message = "Success"
        };
        return dto;
    }

    public async Task<EmployeeResponseDto> UpdateEmployee(int id,EmployeeRequestDto request)
    {
        EmployeeResponseDto dto = new EmployeeResponseDto();
        if (string.IsNullOrEmpty(request.Name) && string.IsNullOrEmpty(request.Email))
        {
            dto = new EmployeeResponseDto()
            {
                IsSuccess = false,
                Message = "Please fill all the values correctly."
            };
            return dto;
        };
        var item = _db.TblEmployees.Where(x => x.IsActive).FirstOrDefault(x => x.Id == id);
        item.Name = request.Name;
        item.Email = request.Email;
        item.DepartmentId = request.DepartmentId;
        await _db.SaveChangesAsync();
        
        dto = new EmployeeResponseDto
        {
            IsSuccess = true,
            Message = "Success"
        };
        return dto;
    }

    public async Task<EmployeeResponseDto> PatchEmployee(int id, EmployeePatchRequestDto request)
    {
        EmployeeResponseDto dto = new EmployeeResponseDto();
        var item = _db.TblEmployees.Where(x => x.IsActive).FirstOrDefault(x => x.Id == id);
        if (!string.IsNullOrEmpty(request.Name))
            item.Name = request.Name;
        if (!string.IsNullOrEmpty(request.Email))
            item.Email = request.Email;
        if (!string.IsNullOrEmpty(request.DepartmentId.ToString()))
            item.DepartmentId = (int)request.DepartmentId;
        await _db.SaveChangesAsync();
        dto = new EmployeeResponseDto
        {
            IsSuccess = true,
            Message = "Success"
        };
        return dto;
    }

    public async Task<EmployeeResponseDto> DeleteEmployee(int id)
    {
        EmployeeResponseDto dto = new EmployeeResponseDto();
        var item = _db.TblEmployees.Where(x=> x.IsActive).FirstOrDefault(x=>x.Id == id);
        item.IsActive = false;
        await _db.SaveChangesAsync();
        dto = new EmployeeResponseDto
        {
            IsSuccess = true,
            Message = "Success"
        };
        return dto;
    }
}

