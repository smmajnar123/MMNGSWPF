using System;
using System.Collections.Generic;

namespace MMNGS.DataAccess.Models;

public partial class UserProfileSummary
{
    public int UserProfileSummaryId { get; set; }

    public int UserId { get; set; }

    public int AdminId { get; set; }

    public string Month { get; set; } = null!;

    public int DaysInMonth { get; set; }

    public int? PersonalLeaves { get; set; }

    public int? SundayDinnerLeaves { get; set; }

    public string MealPlanType { get; set; } = null!;

    public int TotalTiffins { get; set; }

    public decimal RatePerTiffin { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserTransaction> UserTransactions { get; set; } = new List<UserTransaction>();
}
