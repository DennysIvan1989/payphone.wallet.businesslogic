using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic
{
    public enum ErrorEnum
    {

        [Description("Saldo no disponible para esta transacción.")]
        ERR001,
        [Description("Error al procesar la petición.")]
        ERROO2,
        [Description("Billetera no existe.")]
        ERROO3,
        [Description("Billetera esta inactiva.")]
        ERROO4,
        [Description("No puede transaccionar con valores negativos ni cero.")]
        ERROO5
    }
}
