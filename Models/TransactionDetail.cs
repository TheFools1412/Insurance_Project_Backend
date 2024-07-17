using System;
using System.Collections.Generic;

namespace Insurance_Project.Models;

public partial class TransactionDetail
{
    public int TransId { get; set; }

    public int? AccId { get; set; }

    public double? TransMoney { get; set; }

    public int? TransType { get; set; }

    public DateTime? DateOfTrans { get; set; }
}
