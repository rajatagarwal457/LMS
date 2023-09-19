using System;
using System.Collections.Generic;

namespace LMS.Models;

public partial class LoanRequest
{
    public Guid? EmployeeId { get; set; }

    public Guid? ItemId { get; set; }

    public Guid? LoanId { get; set; }

    public virtual EmployeeMaster? Employee { get; set; }

    public virtual ItemMaster? Item { get; set; }

    public virtual LoanCardMaster? Loan { get; set; }
}
