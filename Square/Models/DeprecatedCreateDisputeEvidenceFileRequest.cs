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
    /// DeprecatedCreateDisputeEvidenceFileRequest.
    /// </summary>
    public class DeprecatedCreateDisputeEvidenceFileRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeprecatedCreateDisputeEvidenceFileRequest"/> class.
        /// </summary>
        /// <param name="idempotencyKey">idempotency_key.</param>
        /// <param name="evidenceType">evidence_type.</param>
        /// <param name="contentType">content_type.</param>
        public DeprecatedCreateDisputeEvidenceFileRequest(
            string idempotencyKey,
            string evidenceType = null,
            string contentType = null)
        {
            this.IdempotencyKey = idempotencyKey;
            this.EvidenceType = evidenceType;
            this.ContentType = contentType;
        }

        /// <summary>
        /// The Unique ID. For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// The type of the dispute evidence.
        /// </summary>
        [JsonProperty("evidence_type", NullValueHandling = NullValueHandling.Ignore)]
        public string EvidenceType { get; }

        /// <summary>
        /// The MIME type of the uploaded file.
        /// The type can be image/heic, image/heif, image/jpeg, application/pdf, image/png, or image/tiff.
        /// </summary>
        [JsonProperty("content_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeprecatedCreateDisputeEvidenceFileRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is DeprecatedCreateDisputeEvidenceFileRequest other &&
                ((this.IdempotencyKey == null && other.IdempotencyKey == null) || (this.IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((this.EvidenceType == null && other.EvidenceType == null) || (this.EvidenceType?.Equals(other.EvidenceType) == true)) &&
                ((this.ContentType == null && other.ContentType == null) || (this.ContentType?.Equals(other.ContentType) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2039641347;
            hashCode = HashCode.Combine(this.IdempotencyKey, this.EvidenceType, this.ContentType);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IdempotencyKey = {(this.IdempotencyKey == null ? "null" : this.IdempotencyKey == string.Empty ? "" : this.IdempotencyKey)}");
            toStringOutput.Add($"this.EvidenceType = {(this.EvidenceType == null ? "null" : this.EvidenceType.ToString())}");
            toStringOutput.Add($"this.ContentType = {(this.ContentType == null ? "null" : this.ContentType == string.Empty ? "" : this.ContentType)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.IdempotencyKey)
                .EvidenceType(this.EvidenceType)
                .ContentType(this.ContentType);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string idempotencyKey;
            private string evidenceType;
            private string contentType;

            public Builder(
                string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
            }

             /// <summary>
             /// IdempotencyKey.
             /// </summary>
             /// <param name="idempotencyKey"> idempotencyKey. </param>
             /// <returns> Builder. </returns>
            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

             /// <summary>
             /// EvidenceType.
             /// </summary>
             /// <param name="evidenceType"> evidenceType. </param>
             /// <returns> Builder. </returns>
            public Builder EvidenceType(string evidenceType)
            {
                this.evidenceType = evidenceType;
                return this;
            }

             /// <summary>
             /// ContentType.
             /// </summary>
             /// <param name="contentType"> contentType. </param>
             /// <returns> Builder. </returns>
            public Builder ContentType(string contentType)
            {
                this.contentType = contentType;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeprecatedCreateDisputeEvidenceFileRequest. </returns>
            public DeprecatedCreateDisputeEvidenceFileRequest Build()
            {
                return new DeprecatedCreateDisputeEvidenceFileRequest(
                    this.idempotencyKey,
                    this.evidenceType,
                    this.contentType);
            }
        }
    }
}