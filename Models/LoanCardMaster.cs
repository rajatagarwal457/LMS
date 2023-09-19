using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LMS.Models;

public partial class LoanCardMaster
{
    public Guid LoanId { get; set; }

    public string? LoanType { get; set; }

    public int? DurationInYears { get; set; }

    [JsonIgnore]
    public virtual ICollection<EmployeeCardDetail> EmployeeCardDetails { get; set; } = new List<EmployeeCardDetail>();

    [JsonIgnore]
    public virtual ICollection<LoanRequest> LoanRequests { get; set; } = new List<LoanRequest>();

    [JsonIgnore]
    public virtual Category? LoanTypeNavigation { get; set; }
}
