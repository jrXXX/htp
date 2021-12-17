// ReSharper disable InconsistentNaming

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Akros.Htp.Vendor.Backend.DataAccess.Model.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Currency
    {
        CHF,

        EUR
    }
}