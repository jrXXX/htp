using Akros.Htp.Vendor.Backend.DataAccess.Model.Enums;
using System;

namespace Akros.Htp.Vendor.Backend.DataAccess.DataAdapter
{
    public sealed class CommonDataModelAdapter
    {
        public static Domain.Model.Common.Currency Map(Currency currency)
        {
            switch (currency)
            {
                case Currency.CHF:
                    return Domain.Model.Common.Currency.CHF;
                case Currency.EUR:
                    return Domain.Model.Common.Currency.EUR;
                default:
                    throw new ArgumentException("currency", $"Unknown currency enum type {currency}");
            }
        }
        
        public static Currency Map(Domain.Model.Common.Currency currency)
        {
            switch (currency)
            {
                case Domain.Model.Common.Currency.CHF:
                    return Currency.CHF;
                case Domain.Model.Common.Currency.EUR:
                    return Currency.EUR;
                default:
                    throw new ArgumentException("currency", $"Unknown currency enum type {currency}");
            }
        }

        public static Domain.Model.Room.RoomType Map(RoomType type)
        {
            switch (type)
            {
                case RoomType.Double:
                    return Domain.Model.Room.RoomType.DOUBLE;
                case RoomType.DoubleDouble:
                    return Domain.Model.Room.RoomType.DOUBLE_DOUBLE;
                case RoomType.King:
                    return Domain.Model.Room.RoomType.KING;
                case RoomType.Quad:
                    return Domain.Model.Room.RoomType.QUAD;
                case RoomType.Single:
                    return Domain.Model.Room.RoomType.SINGLE;
                case RoomType.Studio:
                    return Domain.Model.Room.RoomType.STUDIO;
                case RoomType.Triple:
                    return Domain.Model.Room.RoomType.TRIPLE;
                case RoomType.Queen:
                    return Domain.Model.Room.RoomType.QUEEN;
                case RoomType.Twin:
                    return Domain.Model.Room.RoomType.TWIN;
                default:
                    throw new ArgumentException("type", $"Unknown RoomType <{type}>");
            }
        }
    }
}
