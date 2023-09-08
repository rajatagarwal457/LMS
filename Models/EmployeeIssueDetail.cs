﻿using System;
using System.Collections.Generic;

namespace LMS.Models;

public partial class EmployeeIssueDetail
{
    public string? IssueId { get; set; }

    public string? EmployeeId { get; set; }

    public string? ItemId { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual EmployeeMaster? Employee { get; set; }

    public virtual ItemMaster? Item { get; set; }
}
