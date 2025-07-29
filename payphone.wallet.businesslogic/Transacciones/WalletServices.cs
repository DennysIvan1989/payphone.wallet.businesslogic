using AutoMapper;
using payphone.wallet.businesslogic.Dto.Wallet;
using payphone.wallet.businesslogic.Modelos;
using payphone.wallet.businesslogic.Utils;
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

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="imapper"></param>
        public WalletServices(WalletDbContext context, IMapper imapper)
        {

            _context = context;
            _mapper = imapper;
        }

        /// <summary>
        /// Crea registros de billeteras
        /// </summary>
        /// <param name="wallet"></param>
        /// <returns></returns>
        public ResultadoDto CreateWallet(WalletDto wallet)
        {
            var resultado = new ResultadoDto();
            var walletPersis = _mapper.Map<Wallet>(wallet);
            _context.Wallets.Add(walletPersis);
            resultado.Correcto = true;
            return resultado;
        }

        /// <summary>
        /// Elimina
        /// </summary>
        /// <param name="idWallet"></param>
        /// <returns></returns>
        public ResultadoDto DeteleWallet(int idWallet)
        {
            var resultado = new ResultadoDto();
            var walletPersis = _context.Wallets.First(x => x.Id == idWallet && x.Active);
            if (walletPersis == null)
            {
                throw new WalletException(ErrorEnum.ERROO3.GetDescription(), ErrorEnum.ERROO3.ToString());
            }
            walletPersis.Active = false;
            walletPersis.State = "I";
            resultado.Correcto = true;
            return resultado;

        }

        /// <summary>
        /// Obtiene el detalle
        /// </summary>
        /// <param name="idWallet"></param>
        /// <returns></returns>
        /// <exception cref="WalletException"></exception>
        public ResultadoDto<WalletDto> GetWallet(int idWallet)
        {

            var resultado = new ResultadoDto<WalletDto>();
            var walletPersis = _context.Wallets.FirstOrDefault(x => x.Id == idWallet && x.Active);
            if (walletPersis == null)
            {

                throw new WalletException(ErrorEnum.ERROO3.GetDescription(), ErrorEnum.ERROO3.ToString());
            }

            var walletDto = _mapper.Map<WalletDto>(walletPersis);
            resultado.Anexo = walletDto;
            resultado.Correcto = true;
            return resultado;
        }

        /// <summary>
        /// Obtiene por estado
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public ResultadoDto<List<WalletDto>> GetWalletForState(string state)
        {
            var resultado = new ResultadoDto<List<WalletDto>>();
            var walletPersis = _context.Wallets.Where(x => x.State == state).ToList();
            var walletsDto = _mapper.Map<List<WalletDto>>(walletPersis);
            resultado.Anexo = walletsDto;
            resultado.Correcto = true;
            return resultado;
        }

        /// <summary>
        /// Obtine
        /// </summary>
        /// <param name="initDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResultadoDto<List<WalletDto>> GetWallet(DateTime initDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Actuliza
        /// </summary>
        /// <param name="id"></param>
        /// <param name="wallet"></param>
        /// <returns></returns>
        public ResultadoDto UpdateWallet(int id, WalletDto wallet)
        {

            if(string.IsNullOrEmpty(wallet.UserUpdate))
                throw new WalletException(ErrorEnum.ERROO8.GetDescription(), ErrorEnum.ERROO8.ToString());


            var resultado = new ResultadoDto();
            var walletPersis = _context.Wallets.First(x => x.Id == id);
            walletPersis.UpdateAt = DateTime.Now; 
            _mapper.Map(wallet, walletPersis);
            resultado.Correcto = true;
            return resultado;
        }
    }
}
