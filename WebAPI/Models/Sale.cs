using System;
using System.Collections.Generic;

namespace WebAPI.Models;

/// <summary>
/// информация о продажах
/// </summary>
public partial class Sale
{
    public int Id { get; set; }

    public DateOnly? DateSales { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
}
