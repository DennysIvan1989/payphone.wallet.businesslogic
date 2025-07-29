using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Dto
{
    public class BaseDto
    {
        /// <summary>
        /// Fecha sistema
        /// </summary>
        [JsonProperty("fechaSistema")]
        public DateTime CalendarAt { get; set; }

        /// <summary>
        /// Registro Activo
        /// </summary>
        [JsonProperty("activo")]
        public bool? Active { get; set; }
    }
}
