
# Search Catalog Items Response

Defines the response body returned from the [SearchCatalogItems](../../doc/api/catalog.md#search-catalog-items) endpoint.

## Structure

`SearchCatalogItemsResponse`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Errors` | [`IList<Models.Error>`](../../doc/models/error.md) | Optional | Any errors that occurred during the request. |
| `Items` | [`IList<Models.CatalogObject>`](../../doc/models/catalog-object.md) | Optional | Returned items matching the specified query expressions. |
| `Cursor` | `string` | Optional | Pagination token used in the next request to return more of the search result. |
| `MatchedVariationIds` | `IList<string>` | Optional | Ids of returned item variations matching the specified query expression. |

## Example (as JSON)

```json
{
  "errors": null,
  "items": null,
  "cursor": null,
  "matched_variation_ids": null
}
```

