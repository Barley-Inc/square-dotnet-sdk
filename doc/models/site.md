
# Site

Represents a Square Online site, which is an online store for a Square seller.

## Structure

`Site`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The Square-assigned ID of the site.<br>**Constraints**: *Maximum Length*: `32` |
| `SiteTitle` | `string` | Optional | The title of the site. |
| `Domain` | `string` | Optional | The domain of the site (without the protocol). For example, `mysite1.square.site`. |
| `IsPublished` | `bool?` | Optional | Indicates whether the site is published. |
| `CreatedAt` | `string` | Optional | The timestamp of when the site was created, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp of when the site was last updated, in RFC 3339 format. |

## Example (as JSON)

```json
{
  "id": null,
  "site_title": null,
  "domain": null,
  "is_published": null,
  "created_at": null,
  "updated_at": null
}
```

