
# Create Gift Card Request

Represents a [CreateGiftCard](../../doc/api/gift-cards.md#create-gift-card) request.

## Structure

`CreateGiftCardRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `IdempotencyKey` | `string` | Required | A unique identifier for this request, used to ensure idempotency. For more information,<br>see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `128` |
| `LocationId` | `string` | Required | The ID of the [location](../../doc/models/location.md) where the gift card should be registered for<br>reporting purposes. Gift cards can be redeemed at any of the seller's locations.<br>**Constraints**: *Minimum Length*: `1` |
| `GiftCard` | [`Models.GiftCard`](../../doc/models/gift-card.md) | Required | Represents a Square gift card. |

## Example (as JSON)

```json
{
  "gift_card": {
    "type": "DIGITAL"
  },
  "idempotency_key": "NC9Tm69EjbjtConu",
  "location_id": "81FN9BNFZTKS4"
}
```

