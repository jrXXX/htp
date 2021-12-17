using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Akros.Htp.Exchange.Model
{
    /// <summary>
    /// Defines Currency
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyEnum
    {
        /// <summary>
        /// Enum CHF for value: CHF
        /// </summary>
        [EnumMember(Value = "CHF")]
        CHF = 1,

        /// <summary>
        /// Enum EUR for value: EUR
        /// </summary>
        [EnumMember(Value = "EUR")]
        EUR = 2

    }
}