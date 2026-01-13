using Microsoft.Data.SqlClient;

namespace EmployeeManagementApi.Repositories;

public class EmployeeAdoRepository : IEmployeeAdoRepository
{
    private readonly string _connectionString;
    public EmployeeAdoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public void UpdateSalary(int employeeId, decimal newSalary)
    {
        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();
        using SqlTransaction transaction = conn.BeginTransaction();
        try
        {
            string updateEmployee = @"SELECT TOP 1 Salary
            FROM Tbl_SalaryHistory
            WHERE EmployeeId = @EmployeeId
            ORDER BY EffectiveFrom DESC
            ";

            using SqlCommand cmd1 = new SqlCommand(updateEmployee, conn, transaction);
            cmd1.Parameters.AddWithValue("@Salary", newSalary);
            cmd1.Parameters.AddWithValue("@EmployeeId", employeeId);
            cmd1.ExecuteNonQuery();

            string insertHistory = @"
            INSERT INTO Tbl_SalaryHistory (EmployeeId, Salary, EffectiveFrom)
            VALUES (@EmployeeId, @Salary, GETDATE())";

            using SqlCommand cmd2 = new SqlCommand(insertHistory, conn, transaction);
            cmd2.Parameters.AddWithValue("@Salary", newSalary);
            cmd2.Parameters.AddWithValue("@EmployeeId", employeeId);
            cmd2.ExecuteNonQuery();

            // ✅ Commit transaction
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
        conn.Close();
    }
}
