using System;
using System.Collections.Generic;

namespace EmployeeManagementApi.Database.AppDbContextModels;

public partial class TblEmployee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int DepartmentId { get; set; }

    public bool IsActive { get; set; }

    public virtual TblDepartment Department { get; set; } = null!;

    public virtual ICollection<TblSalaryHistory> TblSalaryHistories { get; set; } = new List<TblSalaryHistory>();
}
