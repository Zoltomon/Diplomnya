using System;
using System.Collections.Generic;

namespace WebAPI.Models;

/// <summary>
/// информация о продажах(товар, окончательная цена и кол-во)
/// </summary>
public partial class SaleItem
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? SalesId { get; set; }

    public float? Quantity { get; set; }

    public float? UnitPrice { get; set; }

    public int? UserProfileId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Sale? Sales { get; set; }

    public virtual UserProfile? UserProfile { get; set; }
}
