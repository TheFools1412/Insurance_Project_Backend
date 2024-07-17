using System;
using System.Collections.Generic;

namespace Insurance_Project.Models;

public partial class Contract
{
    public int Id { get; set; }

    public string ContractNumber { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int IdCustomer { get; set; }

    public int IdTypeInsurance { get; set; }

    public double AmountInsurance { get; set; }

    public double Premium { get; set; }

    public string Note { get; set; } = null!;

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual Insurance IdTypeInsuranceNavigation { get; set; } = null!;

    public virtual Payment? Payment { get; set; }
}
