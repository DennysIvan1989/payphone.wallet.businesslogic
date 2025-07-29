using System;
using System.Collections.Generic;

namespace payphone.wallet.persistence.Modelos;

public partial class UserW
{
    public string Cod { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime CreateAt { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<WalletMovement> WalletMovements { get; set; } = new List<WalletMovement>();

    public virtual ICollection<Wallet> WalletUserCreateNavigations { get; set; } = new List<Wallet>();

    public virtual ICollection<Wallet> WalletUserUpdateNavigations { get; set; } = new List<Wallet>();
}
