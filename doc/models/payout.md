
# Payout

An accounting of the amount owed the seller and record of the actual transfer to their
external bank account or to the Square balance.

## Structure

`Payout`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Required | A unique ID for the payout.<br>**Constraints**: *Minimum Length*: `1` |
| `Status` | [`string`](../../doc/models/payout-status.md) | Optional | Payout status types |
| `LocationId` | `string` | Required | The ID of the location associated with the payout.<br>**Constraints**: *Minimum Length*: `1` |
| `CreatedAt` | `string` | Optional | The timestamp of when the payout was created and submitted for deposit to the seller's banking destination, in RFC 3339 format. |
| `UpdatedAt` | `string` | Optional | The timestamp of when the payout was last updated, in RFC 3339 format. |
| `AmountMoney` | [`Models.Money`](../../doc/models/money.md) | Optional | Represents an amount of money. `Money` fields can be signed or unsigned.<br>Fields that do not explicitly define whether they are signed or unsigned are<br>considered unsigned and can only hold positive amounts. For signed fields, the<br>sign of the value indicates the purpose of the money transfer. See<br>[Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)<br>for more information. |
| `Destination` | [`Models.Destination`](../../doc/models/destination.md) | Optional | Information about the destination against which the payout was made. |
| `Version` | `int?` | Optional | The version number, which is incremented each time an update is made to this payout record.<br>The version number helps developers receive event notifications or feeds out of order. |
| `Type` | [`string`](../../doc/models/payout-type.md) | Optional | The type of payout: “BATCH” or “SIMPLE”.<br>BATCH payouts include a list of payout entries that can be considered settled.<br>SIMPLE payouts do not have any payout entries associated with them<br>and will show up as one of the payout entries in a future BATCH payout. |
| `PayoutFee` | [`IList<Models.PayoutFee>`](../../doc/models/payout-fee.md) | Optional | A list of processing fees and any taxes on the fees assessed by Square for this payout. |
| `ArrivalDate` | `string` | Optional | The calendar date, in ISO 8601 format (YYYY-MM-DD), when the payout is due to arrive in the seller’s banking destination. |

## Example (as JSON)

```json
{
  "id": "id0",
  "status": null,
  "location_id": "location_id4",
  "created_at": null,
  "updated_at": null,
  "amount_money": null,
  "destination": null,
  "version": null,
  "type": null,
  "payout_fee": null,
  "arrival_date": null
}
```

