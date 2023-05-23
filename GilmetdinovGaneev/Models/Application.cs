using System;
using System.Collections.Generic;

namespace GilmetdinovGaneev.Models;

public partial class Application
{
    public int Id { get; set; }

    public string? Date { get; set; }

    public string? Quantity { get; set; }

    public string? Title { get; set; }

    public int? WorkersId { get; set; }

    public virtual Worker? Workers { get; set; }
}
