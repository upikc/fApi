using System;
using System.Collections.Generic;

namespace TestApi.Model;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
}
