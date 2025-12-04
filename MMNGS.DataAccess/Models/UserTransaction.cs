using System;
using System.Collections.Generic;

namespace MMNGS.DataAccess.Models;

public partial class UserTransaction
{
    public int TransactionId { get; set; }

    public int UserId { get; set; }

    public int AdminId { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal TransactionAmount { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public decimal? PendingAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public int? UserProfileSummaryId { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual UserProfileSummary? UserProfileSummary { get; set; }
}
