using System;
using System.Collections.Generic;

namespace MMNGS.DataAccess.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string MessName { get; set; } = null!;

    public string? Address { get; set; }

    public int? SubscriptionId { get; set; }

    public DateOnly? SubscriptionExpiry { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UserId { get; set; }

    public virtual Subscription? Subscription { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<UserProfileSummary> UserProfileSummaries { get; set; } = new List<UserProfileSummary>();

    public virtual ICollection<UserTransaction> UserTransactions { get; set; } = new List<UserTransaction>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
