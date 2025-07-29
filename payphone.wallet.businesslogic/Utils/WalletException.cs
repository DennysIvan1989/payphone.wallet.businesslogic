using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic.Utils
{
    public class WalletException : Exception
    {
        public int? StatusCodeHttp { get; set; }
        public string Code { get; set; }

        public WalletException() : base() { }

        public WalletException(string message) : base(message) { }

        public WalletException(string message, int statusCodeHttp) : base(message)
        {

            StatusCodeHttp = statusCodeHttp;
        }

        public WalletException(string message, string code) : base(message)
        {
            Code = code;
        }
    }
}
