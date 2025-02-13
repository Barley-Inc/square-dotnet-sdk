
# Catalog Query Item Variations for Item Option Values

The query filter to return the item variations containing the specified item option value IDs.

## Structure

`CatalogQueryItemVariationsForItemOptionValues`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `ItemOptionValueIds` | `IList<string>` | Optional | A set of `CatalogItemOptionValue` IDs to be used to find associated<br>`CatalogItemVariation`s. All ItemVariations that contain all of the given<br>Item Option Values (in any order) will be returned. |

## Example (as JSON)

```json
{
  "item_option_value_ids": null
}
```

