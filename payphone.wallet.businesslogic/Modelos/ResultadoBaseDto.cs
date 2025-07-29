using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Modelos
{
    public class ResultadoBaseDto
    {
        /// <summary>
        /// correcto
        /// </summary>
        [JsonProperty("correcto")]
        public bool Correcto { get; set; }

        /// <summary>
        /// mensaje
        /// </summary>

        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }

        /// <summary>
        /// codigo
        /// </summary>
        [JsonProperty("codigo")]
        public string CodigoError { get; set; }
    }
}
