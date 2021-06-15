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
    /// InventoryCount.
    /// </summary>
    public class InventoryCount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryCount"/> class.
        /// </summary>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogObjectType">catalog_object_type.</param>
        /// <param name="state">state.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="calculatedAt">calculated_at.</param>
        /// <param name="isEstimated">is_estimated.</param>
        public InventoryCount(
            string catalogObjectId = null,
            string catalogObjectType = null,
            string state = null,
            string locationId = null,
            string quantity = null,
            string calculatedAt = null,
            bool? isEstimated = null)
        {
            this.CatalogObjectId = catalogObjectId;
            this.CatalogObjectType = catalogObjectType;
            this.State = state;
            this.LocationId = locationId;
            this.Quantity = quantity;
            this.CalculatedAt = calculatedAt;
            this.IsEstimated = isEstimated;
        }

        /// <summary>
        /// The Square-generated ID of the
        /// [CatalogObject]($m/CatalogObject) being tracked.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The [type]($m/CatalogObjectType) of the
        /// [CatalogObject]($m/CatalogObject) being tracked. Tracking is only
        /// supported for the `ITEM_VARIATION` type.
        /// </summary>
        [JsonProperty("catalog_object_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectType { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The Square-generated ID of the [Location]($m/Location) where the related
        /// quantity of items is being tracked.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The number of items affected by the estimated count as a decimal string.
        /// Can support up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string Quantity { get; }

        /// <summary>
        /// An RFC 3339-formatted timestamp that indicates when the most recent physical count or adjustment affecting
        /// the estimated count is received.
        /// </summary>
        [JsonProperty("calculated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CalculatedAt { get; }

        /// <summary>
        /// Whether the inventory count is for composed variation (TRUE) or not (FALSE). If true, the inventory count will not be present in the response of
        /// any of these endpoints: [BatchChangeInventory]($e/Inventory/BatchChangeInventory),
        /// [BatchRetrieveInventoryChanges]($e/Inventory/BatchRetrieveInventoryChanges),
        /// [BatchRetrieveInventoryCounts]($e/Inventory/BatchRetrieveInventoryCounts), and
        /// [RetrieveInventoryChanges]($e/Inventory/RetrieveInventoryChanges).
        /// </summary>
        [JsonProperty("is_estimated", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsEstimated { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InventoryCount : ({string.Join(", ", toStringOutput)})";
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

            return obj is InventoryCount other &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogObjectType == null && other.CatalogObjectType == null) || (this.CatalogObjectType?.Equals(other.CatalogObjectType) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.CalculatedAt == null && other.CalculatedAt == null) || (this.CalculatedAt?.Equals(other.CalculatedAt) == true)) &&
                ((this.IsEstimated == null && other.IsEstimated == null) || (this.IsEstimated?.Equals(other.IsEstimated) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1245291455;

            if (this.CatalogObjectId != null)
            {
               hashCode += this.CatalogObjectId.GetHashCode();
            }

            if (this.CatalogObjectType != null)
            {
               hashCode += this.CatalogObjectType.GetHashCode();
            }

            if (this.State != null)
            {
               hashCode += this.State.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            if (this.Quantity != null)
            {
               hashCode += this.Quantity.GetHashCode();
            }

            if (this.CalculatedAt != null)
            {
               hashCode += this.CalculatedAt.GetHashCode();
            }

            if (this.IsEstimated != null)
            {
               hashCode += this.IsEstimated.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.CatalogObjectType = {(this.CatalogObjectType == null ? "null" : this.CatalogObjectType == string.Empty ? "" : this.CatalogObjectType)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity == string.Empty ? "" : this.Quantity)}");
            toStringOutput.Add($"this.CalculatedAt = {(this.CalculatedAt == null ? "null" : this.CalculatedAt == string.Empty ? "" : this.CalculatedAt)}");
            toStringOutput.Add($"this.IsEstimated = {(this.IsEstimated == null ? "null" : this.IsEstimated.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectId(this.CatalogObjectId)
                .CatalogObjectType(this.CatalogObjectType)
                .State(this.State)
                .LocationId(this.LocationId)
                .Quantity(this.Quantity)
                .CalculatedAt(this.CalculatedAt)
                .IsEstimated(this.IsEstimated);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string catalogObjectId;
            private string catalogObjectType;
            private string state;
            private string locationId;
            private string quantity;
            private string calculatedAt;
            private bool? isEstimated;

             /// <summary>
             /// CatalogObjectId.
             /// </summary>
             /// <param name="catalogObjectId"> catalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

             /// <summary>
             /// CatalogObjectType.
             /// </summary>
             /// <param name="catalogObjectType"> catalogObjectType. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectType(string catalogObjectType)
            {
                this.catalogObjectType = catalogObjectType;
                return this;
            }

             /// <summary>
             /// State.
             /// </summary>
             /// <param name="state"> state. </param>
             /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// Quantity.
             /// </summary>
             /// <param name="quantity"> quantity. </param>
             /// <returns> Builder. </returns>
            public Builder Quantity(string quantity)
            {
                this.quantity = quantity;
                return this;
            }

             /// <summary>
             /// CalculatedAt.
             /// </summary>
             /// <param name="calculatedAt"> calculatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder CalculatedAt(string calculatedAt)
            {
                this.calculatedAt = calculatedAt;
                return this;
            }

             /// <summary>
             /// IsEstimated.
             /// </summary>
             /// <param name="isEstimated"> isEstimated. </param>
             /// <returns> Builder. </returns>
            public Builder IsEstimated(bool? isEstimated)
            {
                this.isEstimated = isEstimated;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InventoryCount. </returns>
            public InventoryCount Build()
            {
                return new InventoryCount(
                    this.catalogObjectId,
                    this.catalogObjectType,
                    this.state,
                    this.locationId,
                    this.quantity,
                    this.calculatedAt,
                    this.isEstimated);
            }
        }
    }
}