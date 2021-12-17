using System.Runtime.Serialization;

namespace Akros.Htp.Vendor.Backend.Domain.Model.Room
{
    public enum RoomType
    {
        [EnumMember(Value = "SINGLE")]
        SINGLE,

        [EnumMember(Value = "DOUBLE")]
        DOUBLE,

        [EnumMember(Value = "TRIPLE")]
        TRIPLE,

        [EnumMember(Value = "QUAD")]
        QUAD,

        [EnumMember(Value = "QUEEN")]
        QUEEN,

        [EnumMember(Value = "KING")]
        KING,

        [EnumMember(Value = "TWIN")]
        TWIN,

        [EnumMember(Value = "DOUBLE_DOUBLE")]
        DOUBLE_DOUBLE,

        [EnumMember(Value = "STUDIO")]
        STUDIO
    }
}
