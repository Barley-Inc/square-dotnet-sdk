
# Checkout Options

## Structure

`CheckoutOptions`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AllowTipping` | `bool?` | Optional | Indicates whether the payment allows tipping. |
| `CustomFields` | [`IList<Models.CustomField>`](../../doc/models/custom-field.md) | Optional | The custom fields requesting information from the buyer. |
| `SubscriptionPlanId` | `string` | Optional | The ID of the subscription plan for the buyer to pay and subscribe.<br>For more information, see [Subscription Plan Checkout](https://developer.squareup.com/docs/checkout-api/subscription-plan-checkout).<br>**Constraints**: *Maximum Length*: `255` |
| `RedirectUrl` | `string` | Optional | The confirmation page URL to redirect the buyer to after Square processes the payment.<br>**Constraints**: *Maximum Length*: `2048` |
| `MerchantSupportEmail` | `string` | Optional | The email address that buyers can use to contact the seller.<br>**Constraints**: *Maximum Length*: `256` |
| `AskForShippingAddress` | `bool?` | Optional | Indicates whether to include the address fields in the payment form. |
| `AcceptedPaymentMethods` | [`Models.AcceptedPaymentMethods`](../../doc/models/accepted-payment-methods.md) | Optional | - |

## Example (as JSON)

```json
{
  "allow_tipping": null,
  "custom_fields": null,
  "subscription_plan_id": null,
  "redirect_url": null,
  "merchant_support_email": null,
  "ask_for_shipping_address": null,
  "accepted_payment_methods": null
}
```

