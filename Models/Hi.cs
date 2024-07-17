using System;
using System.Collections.Generic;

namespace Insurance_Project.Models;

public partial class Hi
{
    public int AccId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public double? Balance { get; set; }
}
