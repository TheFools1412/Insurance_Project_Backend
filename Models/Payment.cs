using System;
using System.Collections.Generic;

namespace Insurance_Project.Models;

public partial class Payment
{
    public int IdContract { get; set; }

    public int IdCustomer { get; set; }

    public string NameCustomer { get; set; } = null!;

    public DateTime DatePayment { get; set; }

    public string TypePayment { get; set; } = null!;

    public double AmountPayment { get; set; }

    public string Description { get; set; } = null!;

    public bool StatusPayment { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Contract IdContractNavigation { get; set; } = null!;

    public virtual Customer IdCustomerNavigation { get; set; } = null!;
}
