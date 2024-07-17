using System;
using System.Collections.Generic;

namespace Insurance_Project.Models;

public partial class Insurance
{
    public int IdInsurance { get; set; }

    public string Name { get; set; } = null!;

    public string Optiondate { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public double Price { get; set; }

    public int IdCustomer { get; set; }

    public int TypeInsurance { get; set; }

    public string Note { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
