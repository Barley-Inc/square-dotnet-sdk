
# Loyalty Account Mapping

Represents the mapping that associates a loyalty account with a buyer.

Currently, a loyalty account can only be mapped to a buyer by phone number. For more information, see
[Loyalty Overview](https://developer.squareup.com/docs/loyalty/overview).

## Structure

`LoyaltyAccountMapping`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The Square-assigned ID of the mapping.<br>**Constraints**: *Maximum Length*: `36` |
| `CreatedAt` | `string` | Optional | The timestamp when the mapping was created, in RFC 3339 format. |
| `PhoneNumber` | `string` | Optional | The phone number of the buyer, in E.164 format. For example, "+14155551111". |

## Example (as JSON)

```json
{
  "id": null,
  "created_at": null,
  "phone_number": null
}
```

