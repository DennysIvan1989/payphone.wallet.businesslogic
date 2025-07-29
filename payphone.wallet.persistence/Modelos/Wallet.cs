using System;
using System.Collections.Generic;

namespace payphone.wallet.persistence.Modelos;

public partial class Wallet
{
    public int Id { get; set; }

    public string DocumentId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Balance { get; set; }

    public string? State { get; set; }

    public decimal? Locks { get; set; }

    public DateTime CalendarAt { get; set; }

    public string UserCreate { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public string UserUpdate { get; set; } = null!;

    public DateTime? UpdateAt { get; set; }

    public bool Active { get; set; }

    public virtual UserW UserCreateNavigation { get; set; } = null!;

    public virtual UserW UserUpdateNavigation { get; set; } = null!;

    public virtual ICollection<WalletMovement> WalletMovements { get; set; } = new List<WalletMovement>();
}
