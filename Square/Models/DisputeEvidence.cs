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
    /// DisputeEvidence.
    /// </summary>
    public class DisputeEvidence
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisputeEvidence"/> class.
        /// </summary>
        /// <param name="evidenceId">evidence_id.</param>
        /// <param name="id">id.</param>
        /// <param name="disputeId">dispute_id.</param>
        /// <param name="evidenceFile">evidence_file.</param>
        /// <param name="evidenceText">evidence_text.</param>
        /// <param name="uploadedAt">uploaded_at.</param>
        /// <param name="evidenceType">evidence_type.</param>
        public DisputeEvidence(
            string evidenceId = null,
            string id = null,
            string disputeId = null,
            Models.DisputeEvidenceFile evidenceFile = null,
            string evidenceText = null,
            string uploadedAt = null,
            string evidenceType = null)
        {
            this.EvidenceId = evidenceId;
            this.Id = id;
            this.DisputeId = disputeId;
            this.EvidenceFile = evidenceFile;
            this.EvidenceText = evidenceText;
            this.UploadedAt = uploadedAt;
            this.EvidenceType = evidenceType;
        }

        /// <summary>
        /// The Square-generated ID of the evidence.
        /// </summary>
        [JsonProperty("evidence_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EvidenceId { get; }

        /// <summary>
        /// The Square-generated ID of the evidence.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the dispute the evidence is associated with.
        /// </summary>
        [JsonProperty("dispute_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DisputeId { get; }

        /// <summary>
        /// A file to be uploaded as dispute evidence.
        /// </summary>
        [JsonProperty("evidence_file", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DisputeEvidenceFile EvidenceFile { get; }

        /// <summary>
        /// Raw text
        /// </summary>
        [JsonProperty("evidence_text", NullValueHandling = NullValueHandling.Ignore)]
        public string EvidenceText { get; }

        /// <summary>
        /// The time when the evidence was uploaded, in RFC 3339 format.
        /// </summary>
        [JsonProperty("uploaded_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UploadedAt { get; }

        /// <summary>
        /// The type of the dispute evidence.
        /// </summary>
        [JsonProperty("evidence_type", NullValueHandling = NullValueHandling.Ignore)]
        public string EvidenceType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DisputeEvidence : ({string.Join(", ", toStringOutput)})";
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

            return obj is DisputeEvidence other &&
                ((this.EvidenceId == null && other.EvidenceId == null) || (this.EvidenceId?.Equals(other.EvidenceId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.DisputeId == null && other.DisputeId == null) || (this.DisputeId?.Equals(other.DisputeId) == true)) &&
                ((this.EvidenceFile == null && other.EvidenceFile == null) || (this.EvidenceFile?.Equals(other.EvidenceFile) == true)) &&
                ((this.EvidenceText == null && other.EvidenceText == null) || (this.EvidenceText?.Equals(other.EvidenceText) == true)) &&
                ((this.UploadedAt == null && other.UploadedAt == null) || (this.UploadedAt?.Equals(other.UploadedAt) == true)) &&
                ((this.EvidenceType == null && other.EvidenceType == null) || (this.EvidenceType?.Equals(other.EvidenceType) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 139359175;
            hashCode = HashCode.Combine(this.EvidenceId, this.Id, this.DisputeId, this.EvidenceFile, this.EvidenceText, this.UploadedAt, this.EvidenceType);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EvidenceId = {(this.EvidenceId == null ? "null" : this.EvidenceId == string.Empty ? "" : this.EvidenceId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.DisputeId = {(this.DisputeId == null ? "null" : this.DisputeId == string.Empty ? "" : this.DisputeId)}");
            toStringOutput.Add($"this.EvidenceFile = {(this.EvidenceFile == null ? "null" : this.EvidenceFile.ToString())}");
            toStringOutput.Add($"this.EvidenceText = {(this.EvidenceText == null ? "null" : this.EvidenceText == string.Empty ? "" : this.EvidenceText)}");
            toStringOutput.Add($"this.UploadedAt = {(this.UploadedAt == null ? "null" : this.UploadedAt == string.Empty ? "" : this.UploadedAt)}");
            toStringOutput.Add($"this.EvidenceType = {(this.EvidenceType == null ? "null" : this.EvidenceType.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EvidenceId(this.EvidenceId)
                .Id(this.Id)
                .DisputeId(this.DisputeId)
                .EvidenceFile(this.EvidenceFile)
                .EvidenceText(this.EvidenceText)
                .UploadedAt(this.UploadedAt)
                .EvidenceType(this.EvidenceType);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string evidenceId;
            private string id;
            private string disputeId;
            private Models.DisputeEvidenceFile evidenceFile;
            private string evidenceText;
            private string uploadedAt;
            private string evidenceType;

             /// <summary>
             /// EvidenceId.
             /// </summary>
             /// <param name="evidenceId"> evidenceId. </param>
             /// <returns> Builder. </returns>
            public Builder EvidenceId(string evidenceId)
            {
                this.evidenceId = evidenceId;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// DisputeId.
             /// </summary>
             /// <param name="disputeId"> disputeId. </param>
             /// <returns> Builder. </returns>
            public Builder DisputeId(string disputeId)
            {
                this.disputeId = disputeId;
                return this;
            }

             /// <summary>
             /// EvidenceFile.
             /// </summary>
             /// <param name="evidenceFile"> evidenceFile. </param>
             /// <returns> Builder. </returns>
            public Builder EvidenceFile(Models.DisputeEvidenceFile evidenceFile)
            {
                this.evidenceFile = evidenceFile;
                return this;
            }

             /// <summary>
             /// EvidenceText.
             /// </summary>
             /// <param name="evidenceText"> evidenceText. </param>
             /// <returns> Builder. </returns>
            public Builder EvidenceText(string evidenceText)
            {
                this.evidenceText = evidenceText;
                return this;
            }

             /// <summary>
             /// UploadedAt.
             /// </summary>
             /// <param name="uploadedAt"> uploadedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UploadedAt(string uploadedAt)
            {
                this.uploadedAt = uploadedAt;
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
            /// Builds class object.
            /// </summary>
            /// <returns> DisputeEvidence. </returns>
            public DisputeEvidence Build()
            {
                return new DisputeEvidence(
                    this.evidenceId,
                    this.id,
                    this.disputeId,
                    this.evidenceFile,
                    this.evidenceText,
                    this.uploadedAt,
                    this.evidenceType);
            }
        }
    }
}