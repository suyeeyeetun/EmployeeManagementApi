namespace EmployeeManagementApi.Dtos;

public class EmployeeGetResponseDtos
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<EmployeeDto> Employee { get; set; }
}

public class EmployeeResponseDto
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
public class EmployeeDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int DepartmentId { get; set; }
}
