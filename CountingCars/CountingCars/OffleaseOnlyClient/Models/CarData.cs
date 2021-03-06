﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace OffleaseOnly.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class CarData
    {
        /// <summary>
        /// Initializes a new instance of the CarData class.
        /// </summary>
        public CarData() { }

        /// <summary>
        /// Initializes a new instance of the CarData class.
        /// </summary>
        public CarData(Car car = default(Car), PriceHistory value = default(PriceHistory))
        {
            Car = car;
            Value = value;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "car")]
        public Car Car { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public PriceHistory Value { get; set; }

    }
}
