using payphone.wallet.businesslogic.Dto.Wallet;
using payphone.wallet.businesslogic.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Transacciones
{
    public interface IWallet
    {
        ResultadoDto CreateWallet(WalletDto wallet);
        ResultadoDto UpdateWallet(WalletDto wallet);
        ResultadoDto DeteleWallet(int idWallet);
        ResultadoDto<WalletDto> GetWallet(int idWallet);
        ResultadoDto<List<WalletDto>> GetWalletForState(string state);
        ResultadoDto<List<WalletDto>> GetWallet(DateTime initDate, DateTime endDate);
    }
}
