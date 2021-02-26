
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
    public class CreateMobileAuthorizationCodeRequest 
    {
        public CreateMobileAuthorizationCodeRequest(string locationId = null)
        {
            LocationId = locationId;
        }

        /// <summary>
        /// The Square location ID the authorization code should be tied to.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateMobileAuthorizationCodeRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
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

            return obj is CreateMobileAuthorizationCodeRequest other &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -289105183;

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(LocationId);
            return builder;
        }

        public class Builder
        {
            private string locationId;



            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public CreateMobileAuthorizationCodeRequest Build()
            {
                return new CreateMobileAuthorizationCodeRequest(locationId);
            }
        }
    }
}