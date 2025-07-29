using AutoMapper;
using payphone.wallet.businesslogic.Dto.Wallet;
using payphone.wallet.persistence.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Utils
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Wallet, WalletDto>();
            CreateMap<WalletMovement, WalletMovementDto>();
            CreateMap<WalletDto, Wallet>();
            CreateMap<WalletMovementDto, WalletMovement>();
        }
    }
}
