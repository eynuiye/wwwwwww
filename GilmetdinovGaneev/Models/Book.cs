using System;
using System.Collections.Generic;

namespace GilmetdinovGaneev.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Autor { get; set; }

    public string? Title { get; set; }

    public string? PublicationDate { get; set; }

    public string? Genre { get; set; }

    public string? Cost { get; set; }

    public int? PublishersId { get; set; }

    public int? ProvidersId { get; set; }

    public virtual Provider? Providers { get; set; }

    public virtual Publisher? Publishers { get; set; }

    public virtual ICollection<ReaderCard> ReaderCards { get; set; } = new List<ReaderCard>();
}
