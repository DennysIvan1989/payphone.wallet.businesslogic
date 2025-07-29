using Newtonsoft.Json;
using payphone.wallet.persistence.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Dto.Wallet
{

    /// <summary>
    /// Dto para registrar movimientos de la billetera
    /// </summary>
    public class WalletMovementDto : BaseDto
    {

        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Datos Billetera
        /// </summary>
        [JsonProperty("billeteraId")]
        public int WalletId { get; set; }

        /// <summary>
        /// valor transaccion
        /// </summary>
        [JsonProperty("valor")]
        public decimal Amount { get; set; }

        /// <summary>
        /// tipo D/C
        /// </summary>
        [JsonProperty("Tipo")]
        [MaxLength(1)]
        [RegularExpression("^[DC]$", ErrorMessage = "Solo puede ser D o C")]
        public string Type { get; set; }

        /// <summary>
        /// Disponible
        /// </summary>
        [JsonProperty("disponible")]
        public decimal? Available { get; set; }

        /// <summary>
        /// Usuario creo
        /// </summary>
        [JsonProperty("usuarioCreo")]
        [MaxLength(20)]
        public string UserCreate { get; set; }

        /// <summary>
        /// fechaCreo
        /// </summary>
        [JsonProperty("fechaCreacion")]
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// A que billetera
        /// </summary>
        [JsonProperty("billetera")]
        public WalletDto? Wallet { get; set; }
    }
}
