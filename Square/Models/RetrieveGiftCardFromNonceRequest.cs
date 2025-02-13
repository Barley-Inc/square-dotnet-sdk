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
    /// RetrieveGiftCardFromNonceRequest.
    /// </summary>
    public class RetrieveGiftCardFromNonceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveGiftCardFromNonceRequest"/> class.
        /// </summary>
        /// <param name="nonce">nonce.</param>
        public RetrieveGiftCardFromNonceRequest(
            string nonce)
        {
            this.Nonce = nonce;
        }

        /// <summary>
        /// The payment token of the gift card to retrieve. Payment tokens are generated by the
        /// Web Payments SDK or In-App Payments SDK.
        /// </summary>
        [JsonProperty("nonce")]
        public string Nonce { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveGiftCardFromNonceRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is RetrieveGiftCardFromNonceRequest other &&
                ((this.Nonce == null && other.Nonce == null) || (this.Nonce?.Equals(other.Nonce) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1175736546;
            hashCode = HashCode.Combine(this.Nonce);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Nonce = {(this.Nonce == null ? "null" : this.Nonce == string.Empty ? "" : this.Nonce)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Nonce);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string nonce;

            public Builder(
                string nonce)
            {
                this.nonce = nonce;
            }

             /// <summary>
             /// Nonce.
             /// </summary>
             /// <param name="nonce"> nonce. </param>
             /// <returns> Builder. </returns>
            public Builder Nonce(string nonce)
            {
                this.nonce = nonce;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> RetrieveGiftCardFromNonceRequest. </returns>
            public RetrieveGiftCardFromNonceRequest Build()
            {
                return new RetrieveGiftCardFromNonceRequest(
                    this.nonce);
            }
        }
    }
}