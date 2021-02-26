
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class InventoryTransfer 
    {
        public InventoryTransfer(string id = null,
            string referenceId = null,
            string state = null,
            string fromLocationId = null,
            string toLocationId = null,
            string catalogObjectId = null,
            string catalogObjectType = null,
            string quantity = null,
            string occurredAt = null,
            string createdAt = null,
            Models.SourceApplication source = null,
            string employeeId = null)
        {
            Id = id;
            ReferenceId = referenceId;
            State = state;
            FromLocationId = fromLocationId;
            ToLocationId = toLocationId;
            CatalogObjectId = catalogObjectId;
            CatalogObjectType = catalogObjectType;
            Quantity = quantity;
            OccurredAt = occurredAt;
            CreatedAt = createdAt;
            Source = source;
            EmployeeId = employeeId;
        }

        /// <summary>
        /// A unique ID generated by Square for the
        /// `InventoryTransfer`.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// An optional ID provided by the application to tie the
        /// `InventoryTransfer` to an external system.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The Square ID of the [Location](#type-location) where the related
        /// quantity of items were tracked before the transfer.
        /// </summary>
        [JsonProperty("from_location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FromLocationId { get; }

        /// <summary>
        /// The Square ID of the [Location](#type-location) where the related
        /// quantity of items were tracked after the transfer.
        /// </summary>
        [JsonProperty("to_location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ToLocationId { get; }

        /// <summary>
        /// The Square generated ID of the
        /// `CatalogObject` being tracked.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The `CatalogObjectType` of the
        /// `CatalogObject` being tracked.Tracking is only
        /// supported for the `ITEM_VARIATION` type.
        /// </summary>
        [JsonProperty("catalog_object_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectType { get; }

        /// <summary>
        /// The number of items affected by the transfer as a decimal string.
        /// Can support up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string Quantity { get; }

        /// <summary>
        /// A client-generated timestamp in RFC 3339 format that indicates when
        /// the transfer took place. For write actions, the `occurred_at` timestamp
        /// cannot be older than 24 hours or in the future relative to the time of the
        /// request.
        /// </summary>
        [JsonProperty("occurred_at", NullValueHandling = NullValueHandling.Ignore)]
        public string OccurredAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format that indicates when Square
        /// received the transfer request.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Provides information about the application used to generate a change.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SourceApplication Source { get; }

        /// <summary>
        /// The Square ID of the [Employee](#type-employee) responsible for the
        /// inventory transfer.
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InventoryTransfer : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"ReferenceId = {(ReferenceId == null ? "null" : ReferenceId == string.Empty ? "" : ReferenceId)}");
            toStringOutput.Add($"State = {(State == null ? "null" : State.ToString())}");
            toStringOutput.Add($"FromLocationId = {(FromLocationId == null ? "null" : FromLocationId == string.Empty ? "" : FromLocationId)}");
            toStringOutput.Add($"ToLocationId = {(ToLocationId == null ? "null" : ToLocationId == string.Empty ? "" : ToLocationId)}");
            toStringOutput.Add($"CatalogObjectId = {(CatalogObjectId == null ? "null" : CatalogObjectId == string.Empty ? "" : CatalogObjectId)}");
            toStringOutput.Add($"CatalogObjectType = {(CatalogObjectType == null ? "null" : CatalogObjectType == string.Empty ? "" : CatalogObjectType)}");
            toStringOutput.Add($"Quantity = {(Quantity == null ? "null" : Quantity == string.Empty ? "" : Quantity)}");
            toStringOutput.Add($"OccurredAt = {(OccurredAt == null ? "null" : OccurredAt == string.Empty ? "" : OccurredAt)}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"Source = {(Source == null ? "null" : Source.ToString())}");
            toStringOutput.Add($"EmployeeId = {(EmployeeId == null ? "null" : EmployeeId == string.Empty ? "" : EmployeeId)}");
        }

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

            return obj is InventoryTransfer other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((ReferenceId == null && other.ReferenceId == null) || (ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((State == null && other.State == null) || (State?.Equals(other.State) == true)) &&
                ((FromLocationId == null && other.FromLocationId == null) || (FromLocationId?.Equals(other.FromLocationId) == true)) &&
                ((ToLocationId == null && other.ToLocationId == null) || (ToLocationId?.Equals(other.ToLocationId) == true)) &&
                ((CatalogObjectId == null && other.CatalogObjectId == null) || (CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((CatalogObjectType == null && other.CatalogObjectType == null) || (CatalogObjectType?.Equals(other.CatalogObjectType) == true)) &&
                ((Quantity == null && other.Quantity == null) || (Quantity?.Equals(other.Quantity) == true)) &&
                ((OccurredAt == null && other.OccurredAt == null) || (OccurredAt?.Equals(other.OccurredAt) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((Source == null && other.Source == null) || (Source?.Equals(other.Source) == true)) &&
                ((EmployeeId == null && other.EmployeeId == null) || (EmployeeId?.Equals(other.EmployeeId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -136136157;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (ReferenceId != null)
            {
               hashCode += ReferenceId.GetHashCode();
            }

            if (State != null)
            {
               hashCode += State.GetHashCode();
            }

            if (FromLocationId != null)
            {
               hashCode += FromLocationId.GetHashCode();
            }

            if (ToLocationId != null)
            {
               hashCode += ToLocationId.GetHashCode();
            }

            if (CatalogObjectId != null)
            {
               hashCode += CatalogObjectId.GetHashCode();
            }

            if (CatalogObjectType != null)
            {
               hashCode += CatalogObjectType.GetHashCode();
            }

            if (Quantity != null)
            {
               hashCode += Quantity.GetHashCode();
            }

            if (OccurredAt != null)
            {
               hashCode += OccurredAt.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (Source != null)
            {
               hashCode += Source.GetHashCode();
            }

            if (EmployeeId != null)
            {
               hashCode += EmployeeId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .ReferenceId(ReferenceId)
                .State(State)
                .FromLocationId(FromLocationId)
                .ToLocationId(ToLocationId)
                .CatalogObjectId(CatalogObjectId)
                .CatalogObjectType(CatalogObjectType)
                .Quantity(Quantity)
                .OccurredAt(OccurredAt)
                .CreatedAt(CreatedAt)
                .Source(Source)
                .EmployeeId(EmployeeId);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string referenceId;
            private string state;
            private string fromLocationId;
            private string toLocationId;
            private string catalogObjectId;
            private string catalogObjectType;
            private string quantity;
            private string occurredAt;
            private string createdAt;
            private Models.SourceApplication source;
            private string employeeId;



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

            public Builder FromLocationId(string fromLocationId)
            {
                this.fromLocationId = fromLocationId;
                return this;
            }

            public Builder ToLocationId(string toLocationId)
            {
                this.toLocationId = toLocationId;
                return this;
            }

            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

            public Builder CatalogObjectType(string catalogObjectType)
            {
                this.catalogObjectType = catalogObjectType;
                return this;
            }

            public Builder Quantity(string quantity)
            {
                this.quantity = quantity;
                return this;
            }

            public Builder OccurredAt(string occurredAt)
            {
                this.occurredAt = occurredAt;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder Source(Models.SourceApplication source)
            {
                this.source = source;
                return this;
            }

            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

            public InventoryTransfer Build()
            {
                return new InventoryTransfer(id,
                    referenceId,
                    state,
                    fromLocationId,
                    toLocationId,
                    catalogObjectId,
                    catalogObjectType,
                    quantity,
                    occurredAt,
                    createdAt,
                    source,
                    employeeId);
            }
        }
    }
}