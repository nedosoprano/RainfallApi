﻿namespace Rainfall.Application.Models
{
    /// <summary>
    /// The rainfall reading.
    /// </summary>
    public class RainfallReading
    {
        public DateTime DateMeasured { get; set; }
        public decimal AmountMeasured { get; set; }
    }
}
