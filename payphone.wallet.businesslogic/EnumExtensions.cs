using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace payphone.wallet.businesslogic
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum valor)
        {
            FieldInfo campo = valor.GetType().GetField(valor.ToString());
            DescriptionAttribute atributo = campo.GetCustomAttribute<DescriptionAttribute>();

            return atributo != null ? atributo.Description : valor.ToString();
        }
    }
}
