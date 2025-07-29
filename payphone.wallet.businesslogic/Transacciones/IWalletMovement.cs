using payphone.wallet.businesslogic.Dto.Wallet;
using payphone.wallet.businesslogic.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Transacciones
{
    public interface IWalletMovement
    {

        ResultadoDto CreateMovement(WalletMovementDto mov);
        ResultadoDto<WalletMovementDto> DetailMovement(int idMov);
        ResultadoDto<List<WalletMovementDto>> GetMovementRangeDate(DateTime initDate, DateTime endDate, int idWallet);
    }
}
