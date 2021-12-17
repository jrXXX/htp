using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Akros.Htp.Exchange.Model
{
    /// <summary>
    /// Defines Type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeEnum
    {
        /// <summary>
        /// Enum KING for value: KING
        /// </summary>
        [EnumMember(Value = "KING")]
        KING = 1,

        /// <summary>
        /// Enum QUEEN for value: QUEEN
        /// </summary>
        [EnumMember(Value = "QUEEN")]
        QUEEN = 2,

        /// <summary>
        /// Enum DOUBLE for value: DOUBLE
        /// </summary>
        [EnumMember(Value = "DOUBLE")]
        DOUBLE = 3,

        /// <summary>
        /// Enum SINGLE for value: SINGLE
        /// </summary>
        [EnumMember(Value = "SINGLE")]
        SINGLE = 4,

        /// <summary>
        /// Enum TRIPLE for value: TRIPLE
        /// </summary>
        [EnumMember(Value = "TRIPLE")]
        TRIPLE = 5,

        /// <summary>
        /// Enum QUAD for value: QUAD
        /// </summary>
        [EnumMember(Value = "QUAD")]
        QUAD = 6,

        /// <summary>
        /// Enum TWIN for value: TWIN
        /// </summary>
        [EnumMember(Value = "TWIN")]
        TWIN = 7,

        /// <summary>
        /// Enum DOUBLEDOUBLE for value: DOUBLE_DOUBLE
        /// </summary>
        [EnumMember(Value = "DOUBLE_DOUBLE")]
        DOUBLEDOUBLE = 8,

        /// <summary>
        /// Enum STUDIO for value: STUDIO
        /// </summary>
        [EnumMember(Value = "STUDIO")]
        STUDIO = 9

    }
}