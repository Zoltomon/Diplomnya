using System;
using System.Collections.Generic;

namespace WebAPI.Models;

/// <summary>
/// информация о ролях
/// </summary>
public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
