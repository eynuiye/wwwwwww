﻿using System;
using System.Collections.Generic;

namespace GilmetdinovGaneev.Models;

public partial class Provider
{
    public int Id { get; set; }

    public string? Fcs { get; set; }

    public string? Telephone { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
