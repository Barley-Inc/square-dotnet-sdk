namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// SearchSubscriptionsFilter.
    /// </summary>
    public class SearchSubscriptionsFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchSubscriptionsFilter"/> class.
        /// </summary>
        /// <param name="customerIds">customer_ids.</param>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="sourceNames">source_names.</param>
        public SearchSubscriptionsFilter(
            IList<string> customerIds = null,
            IList<string> locationIds = null,
            IList<string> sourceNames = null)
        {
            this.CustomerIds = customerIds;
            this.LocationIds = locationIds;
            this.SourceNames = sourceNames;
        }

        /// <summary>
        /// A filter to select subscriptions based on the subscribing customer IDs.
        /// </summary>
        [JsonProperty("customer_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> CustomerIds { get; }

        /// <summary>
        /// A filter to select subscriptions based on the location.
        /// </summary>
        [JsonProperty("location_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// A filter to select subscriptions based on the source application.
        /// </summary>
        [JsonProperty("source_names", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> SourceNames { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchSubscriptionsFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is SearchSubscriptionsFilter other &&
                ((this.CustomerIds == null && other.CustomerIds == null) || (this.CustomerIds?.Equals(other.CustomerIds) == true)) &&
                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.SourceNames == null && other.SourceNames == null) || (this.SourceNames?.Equals(other.SourceNames) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 951931587;
            hashCode = HashCode.Combine(this.CustomerIds, this.LocationIds, this.SourceNames);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CustomerIds = {(this.CustomerIds == null ? "null" : $"[{string.Join(", ", this.CustomerIds)} ]")}");
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.SourceNames = {(this.SourceNames == null ? "null" : $"[{string.Join(", ", this.SourceNames)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerIds(this.CustomerIds)
                .LocationIds(this.LocationIds)
                .SourceNames(this.SourceNames);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> customerIds;
            private IList<string> locationIds;
            private IList<string> sourceNames;

             /// <summary>
             /// CustomerIds.
             /// </summary>
             /// <param name="customerIds"> customerIds. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerIds(IList<string> customerIds)
            {
                this.customerIds = customerIds;
                return this;
            }

             /// <summary>
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

             /// <summary>
             /// SourceNames.
             /// </summary>
             /// <param name="sourceNames"> sourceNames. </param>
             /// <returns> Builder. </returns>
            public Builder SourceNames(IList<string> sourceNames)
            {
                this.sourceNames = sourceNames;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchSubscriptionsFilter. </returns>
            public SearchSubscriptionsFilter Build()
            {
                return new SearchSubscriptionsFilter(
                    this.customerIds,
                    this.locationIds,
                    this.sourceNames);
            }
        }
    }
}