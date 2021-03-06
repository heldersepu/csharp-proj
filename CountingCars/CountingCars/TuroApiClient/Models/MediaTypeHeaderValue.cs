﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace TuroApi.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class MediaTypeHeaderValue
    {
        /// <summary>
        /// Initializes a new instance of the MediaTypeHeaderValue class.
        /// </summary>
        public MediaTypeHeaderValue() { }

        /// <summary>
        /// Initializes a new instance of the MediaTypeHeaderValue class.
        /// </summary>
        public MediaTypeHeaderValue(string charSet = default(string), IList<NameValueHeaderValue> parameters = default(IList<NameValueHeaderValue>), string mediaType = default(string))
        {
            CharSet = charSet;
            Parameters = parameters;
            MediaType = mediaType;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CharSet")]
        public string CharSet { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Parameters")]
        public IList<NameValueHeaderValue> Parameters { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MediaType")]
        public string MediaType { get; set; }

    }
}
