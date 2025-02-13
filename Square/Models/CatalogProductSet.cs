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
    /// CatalogProductSet.
    /// </summary>
    public class CatalogProductSet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogProductSet"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="productIdsAny">product_ids_any.</param>
        /// <param name="productIdsAll">product_ids_all.</param>
        /// <param name="quantityExact">quantity_exact.</param>
        /// <param name="quantityMin">quantity_min.</param>
        /// <param name="quantityMax">quantity_max.</param>
        /// <param name="allProducts">all_products.</param>
        public CatalogProductSet(
            string name = null,
            IList<string> productIdsAny = null,
            IList<string> productIdsAll = null,
            long? quantityExact = null,
            long? quantityMin = null,
            long? quantityMax = null,
            bool? allProducts = null)
        {
            this.Name = name;
            this.ProductIdsAny = productIdsAny;
            this.ProductIdsAll = productIdsAll;
            this.QuantityExact = quantityExact;
            this.QuantityMin = quantityMin;
            this.QuantityMax = quantityMax;
            this.AllProducts = allProducts;
        }

        /// <summary>
        /// User-defined name for the product set. For example, "Clearance Items"
        /// or "Winter Sale Items".
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Unique IDs for any `CatalogObject` included in this product set. Any
        /// number of these catalog objects can be in an order for a pricing rule to apply.
        /// This can be used with `product_ids_all` in a parent `CatalogProductSet` to
        /// match groups of products for a bulk discount, such as a discount for an
        /// entree and side combo.
        /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        /// Max: 500 catalog object IDs.
        /// </summary>
        [JsonProperty("product_ids_any", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ProductIdsAny { get; }

        /// <summary>
        /// Unique IDs for any `CatalogObject` included in this product set.
        /// All objects in this set must be included in an order for a pricing rule to apply.
        /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        /// Max: 500 catalog object IDs.
        /// </summary>
        [JsonProperty("product_ids_all", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ProductIdsAll { get; }

        /// <summary>
        /// If set, there must be exactly this many items from `products_any` or `products_all`
        /// in the cart for the discount to apply.
        /// Cannot be combined with either `quantity_min` or `quantity_max`.
        /// </summary>
        [JsonProperty("quantity_exact", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuantityExact { get; }

        /// <summary>
        /// If set, there must be at least this many items from `products_any` or `products_all`
        /// in a cart for the discount to apply. See `quantity_exact`. Defaults to 0 if
        /// `quantity_exact`, `quantity_min` and `quantity_max` are all unspecified.
        /// </summary>
        [JsonProperty("quantity_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuantityMin { get; }

        /// <summary>
        /// If set, the pricing rule will apply to a maximum of this many items from
        /// `products_any` or `products_all`.
        /// </summary>
        [JsonProperty("quantity_max", NullValueHandling = NullValueHandling.Ignore)]
        public long? QuantityMax { get; }

        /// <summary>
        /// If set to `true`, the product set will include every item in the catalog.
        /// Only one of `product_ids_all`, `product_ids_any`, or `all_products` can be set.
        /// </summary>
        [JsonProperty("all_products", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AllProducts { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogProductSet : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogProductSet other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.ProductIdsAny == null && other.ProductIdsAny == null) || (this.ProductIdsAny?.Equals(other.ProductIdsAny) == true)) &&
                ((this.ProductIdsAll == null && other.ProductIdsAll == null) || (this.ProductIdsAll?.Equals(other.ProductIdsAll) == true)) &&
                ((this.QuantityExact == null && other.QuantityExact == null) || (this.QuantityExact?.Equals(other.QuantityExact) == true)) &&
                ((this.QuantityMin == null && other.QuantityMin == null) || (this.QuantityMin?.Equals(other.QuantityMin) == true)) &&
                ((this.QuantityMax == null && other.QuantityMax == null) || (this.QuantityMax?.Equals(other.QuantityMax) == true)) &&
                ((this.AllProducts == null && other.AllProducts == null) || (this.AllProducts?.Equals(other.AllProducts) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -600323794;
            hashCode = HashCode.Combine(this.Name, this.ProductIdsAny, this.ProductIdsAll, this.QuantityExact, this.QuantityMin, this.QuantityMax, this.AllProducts);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.ProductIdsAny = {(this.ProductIdsAny == null ? "null" : $"[{string.Join(", ", this.ProductIdsAny)} ]")}");
            toStringOutput.Add($"this.ProductIdsAll = {(this.ProductIdsAll == null ? "null" : $"[{string.Join(", ", this.ProductIdsAll)} ]")}");
            toStringOutput.Add($"this.QuantityExact = {(this.QuantityExact == null ? "null" : this.QuantityExact.ToString())}");
            toStringOutput.Add($"this.QuantityMin = {(this.QuantityMin == null ? "null" : this.QuantityMin.ToString())}");
            toStringOutput.Add($"this.QuantityMax = {(this.QuantityMax == null ? "null" : this.QuantityMax.ToString())}");
            toStringOutput.Add($"this.AllProducts = {(this.AllProducts == null ? "null" : this.AllProducts.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .ProductIdsAny(this.ProductIdsAny)
                .ProductIdsAll(this.ProductIdsAll)
                .QuantityExact(this.QuantityExact)
                .QuantityMin(this.QuantityMin)
                .QuantityMax(this.QuantityMax)
                .AllProducts(this.AllProducts);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private IList<string> productIdsAny;
            private IList<string> productIdsAll;
            private long? quantityExact;
            private long? quantityMin;
            private long? quantityMax;
            private bool? allProducts;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// ProductIdsAny.
             /// </summary>
             /// <param name="productIdsAny"> productIdsAny. </param>
             /// <returns> Builder. </returns>
            public Builder ProductIdsAny(IList<string> productIdsAny)
            {
                this.productIdsAny = productIdsAny;
                return this;
            }

             /// <summary>
             /// ProductIdsAll.
             /// </summary>
             /// <param name="productIdsAll"> productIdsAll. </param>
             /// <returns> Builder. </returns>
            public Builder ProductIdsAll(IList<string> productIdsAll)
            {
                this.productIdsAll = productIdsAll;
                return this;
            }

             /// <summary>
             /// QuantityExact.
             /// </summary>
             /// <param name="quantityExact"> quantityExact. </param>
             /// <returns> Builder. </returns>
            public Builder QuantityExact(long? quantityExact)
            {
                this.quantityExact = quantityExact;
                return this;
            }

             /// <summary>
             /// QuantityMin.
             /// </summary>
             /// <param name="quantityMin"> quantityMin. </param>
             /// <returns> Builder. </returns>
            public Builder QuantityMin(long? quantityMin)
            {
                this.quantityMin = quantityMin;
                return this;
            }

             /// <summary>
             /// QuantityMax.
             /// </summary>
             /// <param name="quantityMax"> quantityMax. </param>
             /// <returns> Builder. </returns>
            public Builder QuantityMax(long? quantityMax)
            {
                this.quantityMax = quantityMax;
                return this;
            }

             /// <summary>
             /// AllProducts.
             /// </summary>
             /// <param name="allProducts"> allProducts. </param>
             /// <returns> Builder. </returns>
            public Builder AllProducts(bool? allProducts)
            {
                this.allProducts = allProducts;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogProductSet. </returns>
            public CatalogProductSet Build()
            {
                return new CatalogProductSet(
                    this.name,
                    this.productIdsAny,
                    this.productIdsAll,
                    this.quantityExact,
                    this.quantityMin,
                    this.quantityMax,
                    this.allProducts);
            }
        }
    }
}