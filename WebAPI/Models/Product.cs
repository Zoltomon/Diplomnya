using System;
using System.Collections.Generic;

namespace WebAPI.Models;

/// <summary>
/// информация о товарах
/// </summary>
public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Article { get; set; }

    public string? Barcode { get; set; }

    public float? Volume { get; set; }

    public float? Price { get; set; }

    public float? Weight { get; set; }

    public int? ProductCategoryId { get; set; }

    public float? Quantity { get; set; }

    public int? SupplierId { get; set; }

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual Supplier? Supplier { get; set; }
}
