using System;
using System.Collections.Generic;

namespace GilmetdinovGaneev.Models;

public partial class Worker
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Fcs { get; set; }

    public string? Post { get; set; }

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual ICollection<ReaderCard> ReaderCards { get; set; } = new List<ReaderCard>();

    public virtual ICollection<ReadersSubscription> ReadersSubscriptions { get; set; } = new List<ReadersSubscription>();
}
