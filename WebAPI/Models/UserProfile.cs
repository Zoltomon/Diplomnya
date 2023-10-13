using System;
using System.Collections.Generic;

namespace WebAPI.Models;

/// <summary>
/// данные о юзерах
/// </summary>
public partial class UserProfile
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public int? StatusId { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<PersonalDatum> PersonalData { get; set; } = new List<PersonalDatum>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

    public virtual Status? Status { get; set; }
}
