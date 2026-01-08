using System;
using System.Collections.Generic;

namespace EmployeeManagementApi.Database.AppDbContextModels;

public partial class TblSalaryHistory
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public decimal Salary { get; set; }

    public DateTime EffectiveFrom { get; set; }

    public virtual TblEmployee Employee { get; set; } = null!;
}
