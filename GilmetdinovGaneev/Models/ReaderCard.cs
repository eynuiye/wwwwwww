using System;
using System.Collections.Generic;

namespace GilmetdinovGaneev.Models;

public partial class ReaderCard
{
    public int Id { get; set; }

    public string? Date { get; set; }

    public int? BooksId { get; set; }

    public int? WorkersId { get; set; }

    public int? ReadersId { get; set; }

    public virtual Book? Books { get; set; }

    public virtual Reader? Readers { get; set; }

    public virtual Worker? Workers { get; set; }
}
