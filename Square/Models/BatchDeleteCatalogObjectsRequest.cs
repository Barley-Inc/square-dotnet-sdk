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
    /// BatchDeleteCatalogObjectsRequest.
    /// </summary>
    public class BatchDeleteCatalogObjectsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchDeleteCatalogObjectsRequest"/> class.
        /// </summary>
        /// <param name="objectIds">object_ids.</param>
        public BatchDeleteCatalogObjectsRequest(
            IList<string> objectIds = null)
        {
            this.ObjectIds = objectIds;
        }

        /// <summary>
        /// The IDs of the CatalogObjects to be deleted. When an object is deleted, other objects
        /// in the graph that depend on that object will be deleted as well (for example, deleting a
        /// CatalogItem will delete its CatalogItemVariation.
        /// </summary>
        [JsonProperty("object_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ObjectIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BatchDeleteCatalogObjectsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BatchDeleteCatalogObjectsRequest other &&
                ((this.ObjectIds == null && other.ObjectIds == null) || (this.ObjectIds?.Equals(other.ObjectIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1606600759;
            hashCode = HashCode.Combine(this.ObjectIds);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ObjectIds = {(this.ObjectIds == null ? "null" : $"[{string.Join(", ", this.ObjectIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ObjectIds(this.ObjectIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> objectIds;

             /// <summary>
             /// ObjectIds.
             /// </summary>
             /// <param name="objectIds"> objectIds. </param>
             /// <returns> Builder. </returns>
            public Builder ObjectIds(IList<string> objectIds)
            {
                this.objectIds = objectIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BatchDeleteCatalogObjectsRequest. </returns>
            public BatchDeleteCatalogObjectsRequest Build()
            {
                return new BatchDeleteCatalogObjectsRequest(
                    this.objectIds);
            }
        }
    }
}