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
    /// Billetera
    /// </summary>
    public class WalletDto : BaseDto
    {

        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// indetificacion
        /// </summary>
        [JsonProperty("identificacion")]
        [MaxLength(100)]
        public string DocumentId { get; set; } = null!;

        /// <summary>
        /// nombre
        /// </summary>
        [JsonProperty("nombre")]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Saldo
        /// </summary>
        [JsonProperty("saldo")]
        public decimal Balance { get; set; }

        /// <summary>
        /// estado de la billetera
        /// </summary>
        [JsonProperty("estado")]
        [MaxLength(1)]
        public string? State { get; set; }

        /// <summary>
        /// valores bloqueados
        /// </summary>
        [JsonProperty("bloqueado")]
        public decimal? Locks { get; set; }

        /// <summary>
        /// UsuarioCreo
        /// </summary>
        [JsonProperty("usuarioCreo")]
        [MaxLength(20)]
        public string UserCreate { get; set; } = null!;

        /// <summary>
        /// fecha de creacion del registro
        /// </summary>
        [JsonProperty("fechaCreacion")]
        public DateTime CreateAt { get; set; }

        /// <summary>
        /// Usuario Actualizo
        /// </summary>
        [JsonProperty("usuarioActualizo")]
        [MaxLength(20)]
        public string UserUpdate { get; set; } = null!;

        /// <summary>
        /// Fecha de actualización del registro
        /// </summary>
        [JsonProperty("fechaActualizacion")]
        public DateTime? UpdateAt { get; set; }

        /// <summary>
        /// Lista de Movimientos de la billetera
        /// </summary>
        [JsonProperty("movimientos")]
        public List<WalletMovementDto> WalletMovements { get; } = new List<WalletMovementDto>();
    }
}
