using System;
using System.Collections.Generic;

namespace GilmetdinovGaneev.Models;

public partial class ReadersSubscription
{
    public int Id { get; set; }

    public string? ValidityPeriod { get; set; }

    public string? Cost { get; set; }

    public int? ReadersId { get; set; }

    public int? WorkersId { get; set; }

    public virtual Reader? Readers { get; set; }

    public virtual Worker? Workers { get; set; }
}
