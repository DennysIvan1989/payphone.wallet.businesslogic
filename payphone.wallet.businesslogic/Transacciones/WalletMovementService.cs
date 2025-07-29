using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class WalletMovementService : IWalletMovement
    {


        private readonly WalletDbContext _context;
        private readonly IMapper _mapper;

        public WalletMovementService(WalletDbContext context, IMapper imapper)
        {
            _context = context;
            _mapper = imapper;
        }


        public ResultadoDto CreateMovement(WalletMovementDto mov)
        {
            var resultado = new ResultadoDto();
            var movPersis = _mapper.Map<WalletMovement>(mov);

            //validacion
            var wallet = _context.Wallets.FirstOrDefault(t => t.Id == mov.WalletId && t.Active);

            if (wallet == null)
            {

                throw new WalletException(ErrorEnum.ERROO3.GetDescription(), ErrorEnum.ERROO3.ToString());
            }

            if (mov.Amount <= 0)
            {

                throw new WalletException(ErrorEnum.ERROO5.GetDescription(), ErrorEnum.ERROO5.ToString());
            }

            if (wallet.State != "A")
            {

                throw new WalletException(ErrorEnum.ERROO4.GetDescription(), ErrorEnum.ERROO4.ToString());
            }

            if (mov.Type == "D" && mov.Amount > wallet.Balance)
            {
                throw new WalletException(ErrorEnum.ERR001.GetDescription(), ErrorEnum.ERR001.ToString());
            }

            var mount = mov.Type == "D" ? (-1) * mov.Amount : mov.Amount;
            wallet.Balance += mount;
            movPersis.Available = wallet.Balance;
            _context.WalletMovements.Add(movPersis);
            resultado.Correcto = true;
            return resultado;
        }

        public ResultadoDto<WalletMovementDto> DetailMovement(int idMov)
        {
            var resultado = new ResultadoDto<WalletMovementDto>();
            var movPresis = _context.WalletMovements.FirstOrDefault(t => t.Id == idMov);
            if (movPresis == null)
            {

                throw new WalletException(ErrorEnum.ERROO7.GetDescription(), ErrorEnum.ERROO7.ToString());
            }
            var movDto = _mapper.Map<WalletMovementDto>(movPresis);
            resultado.Anexo = movDto;
            resultado.Correcto = true;
            return resultado;
        }

        public ResultadoDto<List<WalletMovementDto>> GetMovementRangeDate(DateTime initDate, DateTime endDate, int idWallet)
        {
            var resultado = new ResultadoDto<List<WalletMovementDto>>();
            var wallet = _context.Wallets.FirstOrDefault(t => t.Id == idWallet && t.Active);

            if (wallet == null)
            {
                throw new WalletException(ErrorEnum.ERROO3.GetDescription(), ErrorEnum.ERROO3.ToString());
            }

            var movsWallet = _context.WalletMovements.Where(t => t.CreateAt >= initDate && t.CreateAt <= endDate && t.WalletId == idWallet && t.Active).ToList();
            var infoRes = _mapper.Map<List<WalletMovementDto>>(movsWallet);
            resultado.Anexo = infoRes;
            resultado.Correcto = true;
            return resultado;
        }
    }
}
