namespace EmployeeManagementApi.Repositories
{
    public interface IEmployeeAdoRepository
    {
        void UpdateSalary(int employeeId, decimal newSalary);
    }
}