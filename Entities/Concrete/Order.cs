using Core;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int ID { get; set; }
        public string CustomerOrderNo { get; set; }
        public string DepartureAddress { get; set; }
        public string DestinationAddress { get; set; }
        public int Quantity { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuantityTypeEnum QuantityType { get; set; }
        public double Weight { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeightTypeEnum WeightType { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Note { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusEnum Status { get; set; }

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum QuantityTypeEnum
    {
        Quantity,
        PostPacket,
        Package,
        Parcel
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WeightTypeEnum
    {
        Kilogram,
        Tonne
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum StatusEnum
    {
        OrderTaken,
        OrderOnWay,
        DistributionCenter,
        OutForDistribition,
        Delivered,
        UnDelivered
    }
}
