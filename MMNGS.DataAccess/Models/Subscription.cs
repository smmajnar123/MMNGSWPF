using System;
using System.Collections.Generic;

namespace MMNGS.DataAccess.Models;

public partial class Subscription
{
    public int SubscriptionId { get; set; }

    public string PlanName { get; set; } = null!;

    public int DurationMonths { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();
}
