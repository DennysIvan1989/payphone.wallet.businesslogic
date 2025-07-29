using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic
{
    /// <summary>
    /// Errores
    /// </summary>
    public enum ErrorEnum
    {

        /// <summary>
        /// Saldo no disponible para esta transacción.
        /// </summary>
        [Description("Saldo no disponible para esta transacción.")]
        ERR001,

        /// <summary>
        /// Error al procesar la petición.
        /// </summary>
        [Description("Error al procesar la petición.")]
        ERR999,

        /// <summary>
        /// Billetera no existe.
        /// </summary>
        [Description("Billetera no existe.")]
        ERROO3,

        /// <summary>
        /// Billetera esta inactiva.
        /// </summary>
        [Description("Billetera esta inactiva.")]
        ERROO4,

        /// <summary>
        /// No puede transaccionar con valores negativos ni cero.
        /// </summary>
        [Description("No puede transaccionar con valores negativos ni cero.")]
        ERROO5,

        /// <summary>
        /// Transacción incorrecta, valores deben ser D:Debito o C:Credito
        /// </summary>
        [Description("Transacción incorrecta, valores deben ser D:Debito o C:Credito")]
        ERROO6,

        /// <summary>
        /// No existe detalles de esta transacción.
        /// </summary>
        [Description("No existe detalles de esta transacción.")]
        ERROO7,

        /// <summary>
        /// suario para actualización es requerido
        /// </summary>
        [Description("Usuario para actualización es requerido")]
        ERROO8
    }
}
