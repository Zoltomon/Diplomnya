using System;
using System.Collections.Generic;

namespace WebAPI.Models;

/// <summary>
/// информация о поставщиках
/// </summary>
public partial class Supplier
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Telephone { get; set; }

    public string? Address { get; set; }

    public string? Itn { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
