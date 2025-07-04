﻿using SDK.Enum;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SDK.Models
{
    public class SensorDataContract
    {
        public int Id { get; set; }

        public int SensorId { get; set; }

        public string Quantity { get; set; }

        public string Value { get; set; }

        public string Unit { get; set; }

        public SensorDataType DataType { get; set; }

        public long Timestamp { get; set; }

        public int Index { get; set; }

        public bool VisibleInApp { get; set; }

        public RangeContract Range { get; set; }

        public static explicit operator SensorDataWriteContract(SensorDataContract contract)
        {
            return new SensorDataWriteContract
            {
                Quantity = contract.Quantity,
                Value = contract.Value,
                Unit = contract.Unit,
                DataType = contract.DataType,
                Timestamp = contract.Timestamp,
                Index = contract.Index,
                VisibleInApp = contract.VisibleInApp,
                SensorId = contract.SensorId,
                Range = contract.Range
            };
        }
    }

    public class SensorDataWriteContract
    {
        [Required]
        [StringLength(255)]
        public string Quantity { get; set; }

        [Required]
        [StringLength(1000)]
        public string Value { get; set; }

        [StringLength(15)]
        public string Unit { get; set; }

        [Required]
        public SensorDataType DataType { get; set; }

        public long Timestamp { get; set; }

        public RangeContract Range { get; set; }

        public int Index { get; set; }

        public bool VisibleInApp { get; set; }

        public int SensorId { get; set; }
    }
}
