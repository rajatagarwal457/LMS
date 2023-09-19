using System;
using System.Collections.Generic;

namespace LMS.Models;

public partial class LoanCardMaster
{
    public Guid LoanId { get; set; }

    public string? LoanType { get; set; }

    public int? DurationInYears { get; set; }

    public virtual Category? LoanTypeNavigation { get; set; }
}
