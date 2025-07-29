using AutoMapper;
using payphone.wallet.businesslogic.Dto.Wallet;
using payphone.wallet.businesslogic.Modelos;
using payphone.wallet.persistence.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Transacciones
{

    public class WalletServices : IWallet
    {
        private readonly WalletDbContext _context;
        private readonly IMapper _mapper;

        public WalletServices(WalletDbContext context, IMapper imapper)
        {

            _context = context;
            _mapper = imapper;
        }

        public ResultadoDto CreateWallet(WalletDto wallet)
        {
            var resultado = new ResultadoDto();
            var walletPersis = _mapper.Map<Wallet>(wallet);
            _context.Wallets.Add(walletPersis);
            resultado.Correcto = true;
            return resultado;
        }

        public ResultadoDto DeteleWallet(int idWallet)
        {
            var resultado = new ResultadoDto();
            var walletPersis = _context.Wallets.First(x => x.Id == idWallet);
            _context.Wallets.Remove(walletPersis);
            resultado.Correcto = true;
            return resultado;

        }

        public ResultadoDto<WalletDto> GetWallet(int idWallet)
        {

            var resultado = new ResultadoDto<WalletDto>();
            var walletPersis = _context.Wallets.First(x => x.Id == idWallet);
            var walletDto = _mapper.Map<WalletDto>(walletPersis);
            resultado.Anexo = walletDto;
            resultado.Correcto = true;
            return resultado;
        }

        public ResultadoDto<List<WalletDto>> GetWalletForState(string state)
        {
            var resultado = new ResultadoDto<List<WalletDto>>();
            var walletPersis = _context.Wallets.Where(x => x.State == state).ToList();
            var walletsDto = _mapper.Map<List<WalletDto>>(walletPersis);
            resultado.Anexo = walletsDto;
            resultado.Correcto = true;
            return resultado;
        }

        public ResultadoDto<List<WalletDto>> GetWallet(DateTime initDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ResultadoDto UpdateWallet(WalletDto wallet)
        {

            var resultado = new ResultadoDto();
            var walletPersis = _context.Wallets.First(x => x.Id == wallet.Id);
            _mapper.Map(wallet, walletPersis);
            resultado.Correcto = true;
            return resultado;
        }
    }
}
