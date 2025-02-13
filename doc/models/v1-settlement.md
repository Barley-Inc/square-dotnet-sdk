
# V1 Settlement

V1Settlement

## Structure

`V1Settlement`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `string` | Optional | The settlement's unique identifier. |
| `Status` | [`string`](../../doc/models/v1-settlement-status.md) | Optional | - |
| `TotalMoney` | [`Models.V1Money`](../../doc/models/v1-money.md) | Optional | - |
| `InitiatedAt` | `string` | Optional | The time when the settlement was submitted for deposit or withdrawal, in ISO 8601 format. |
| `BankAccountId` | `string` | Optional | The Square-issued unique identifier for the bank account associated with the settlement. |
| `Entries` | [`IList<Models.V1SettlementEntry>`](../../doc/models/v1-settlement-entry.md) | Optional | The entries included in this settlement. |

## Example (as JSON)

```json
{
  "id": null,
  "status": null,
  "total_money": null,
  "initiated_at": null,
  "bank_account_id": null,
  "entries": null
}
```

