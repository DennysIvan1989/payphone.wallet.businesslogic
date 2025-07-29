using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Dto.Wallet
{
    public class TransferDto
    {

        /// <summary>
        /// billeteraOrigen
        /// </summary>
        [JsonProperty("billeteraOrigen")]
        public int WalletOrigin { get; set; }

        /// <summary>
        /// billeteraDestino
        /// </summary>
        [JsonProperty("billeteraDestino")]
        public int WalletDestination { get; set; }

        /// <summary>
        /// monto
        /// </summary>
        [JsonProperty("monto")]
        public decimal Amount { get; set; }

        /// <summary>
        /// codigoUsuario
        /// </summary>
        [JsonProperty("codigoUsuario")]
        public string CodUser { get; set; }

    }
}
