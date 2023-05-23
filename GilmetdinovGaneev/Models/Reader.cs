using System;
using System.Collections.Generic;

namespace GilmetdinovGaneev.Models;

public partial class Reader
{
    public int Id { get; set; }

    public string? Fcs { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<ReaderCard> ReaderCards { get; set; } = new List<ReaderCard>();

    public virtual ICollection<ReadersSubscription> ReadersSubscriptions { get; set; } = new List<ReadersSubscription>();
}
