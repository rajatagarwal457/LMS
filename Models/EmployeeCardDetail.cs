﻿using System;
using System.Collections.Generic;

namespace LMS.Models;

public partial class EmployeeCardDetail
{
    public Guid? EmployeeId { get; set; }

    public Guid? LoanId { get; set; }

    public DateTime? CardIssueDate { get; set; }

    public virtual EmployeeMaster? Employee { get; set; }

    public virtual LoanCardMaster? Loan { get; set; }
}
