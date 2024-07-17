using System;
using System.Collections.Generic;

namespace Insurance_Project.Models;

public partial class History
{
    public int Id { get; set; }

    public int Month { get; set; }

    public double Year { get; set; }

    public DateTime DatePayment { get; set; }

    public double Amount { get; set; }

    public string MethodPayment { get; set; } = null!;

    public int IdContract { get; set; }

    public string Note { get; set; } = null!;

    public virtual Payment IdContract1 { get; set; } = null!;

    public virtual Contract IdContractNavigation { get; set; } = null!;
}
