using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Akros.Htp.Vendor.Backend.DataAccess.Model.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoomType
    {
        [EnumMember(Value = "SINGLE")]
        Single = 0,

        [EnumMember(Value = "DOUBLE")]
        Double = 1,

        [EnumMember(Value = "TRIPLE")]
        Triple = 2,

        [EnumMember(Value = "QUAD")]
        Quad = 3,

        [EnumMember(Value = "QUEEN")]
        Queen = 4,

        [EnumMember(Value = "KING")]
        King = 5,

        [EnumMember(Value = "TWIN")]
        Twin = 6,

        [EnumMember(Value = "DOUBLE_DOUBLE")]
        DoubleDouble = 7,

        [EnumMember(Value = "STUDIO")]
        Studio = 8
    }
}