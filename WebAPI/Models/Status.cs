using System;
using System.Collections.Generic;

namespace WebAPI.Models;

/// <summary>
/// информация о статусах
/// </summary>
public partial class Status
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
