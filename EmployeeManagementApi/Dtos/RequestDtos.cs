namespace EmployeeManagementApi.Dtos
{
    public class EmployeeRequestDto
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int DepartmentId { get; set; }
    }
    public class EmployeePatchRequestDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? DepartmentId { get; set; }
    }
}
