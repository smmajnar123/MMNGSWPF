using System;
using System.Collections.Generic;

namespace MMNGS.DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public int AdminId { get; set; }

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string? Address { get; set; }

    public string? FatherPhone { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<UserProfileSummary> UserProfileSummaries { get; set; } = new List<UserProfileSummary>();

    public virtual ICollection<UserTransaction> UserTransactions { get; set; } = new List<UserTransaction>();
}
