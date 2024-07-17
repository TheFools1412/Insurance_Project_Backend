using System;
using System.Collections.Generic;

namespace Insurance_Project.Models;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string NameCustomer { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public string Adress { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Identification { get; set; }

    public DateTime Created { get; set; }

    public string ProfilePhoto { get; set; } = null!;

    public string? Securitycode { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
