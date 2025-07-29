using System;
using System.Collections.Generic;

namespace payphone.wallet.persistence.Modelos;

public partial class WalletMovement
{
    public int Id { get; set; }

    public int WalletId { get; set; }

    public decimal Amount { get; set; }

    public string Type { get; set; } = null!;

    public decimal Available { get; set; }

    public DateTime CalendarAt { get; set; }

    public string UserCreate { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public bool Active { get; set; }

    public virtual UserW UserCreateNavigation { get; set; } = null!;

    public virtual Wallet Wallet { get; set; } = null!;
}
