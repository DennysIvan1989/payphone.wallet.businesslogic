using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Modelos
{

    /// <summary>
    /// Manejo de resultados
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public partial class ResultadoDto<T>: ResultadoBaseDto
    {
        /// <summary>
        /// datos extras
        /// </summary>
        [JsonProperty("anexo")]
        public T? Anexo { get; set; }

        /// <summary>
        /// detalle
        /// </summary>
        [JsonProperty("detalle")]
        public List<ResultadoDto> Detalle { get; } = new List<ResultadoDto>();

        /// <summary>
        /// Error
        /// </summary>
        [JsonProperty("error")]
        public List<ResultadoDto> Error { get; } = new List<ResultadoDto>();

    }

    public class ResultadoDto : ResultadoDto<dynamic> { }
}
