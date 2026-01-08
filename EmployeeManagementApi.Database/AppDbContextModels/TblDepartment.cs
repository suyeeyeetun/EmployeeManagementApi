using System;
using System.Collections.Generic;

namespace EmployeeManagementApi.Database.AppDbContextModels;

public partial class TblDepartment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TblEmployee> TblEmployees { get; set; } = new List<TblEmployee>();
}
