
# Terminal Checkout Query Filter

## Structure

`TerminalCheckoutQueryFilter`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `DeviceId` | `string` | Optional | The `TerminalCheckout` objects associated with a specific device. If no device is specified, then all<br>`TerminalCheckout` objects for the merchant are displayed. |
| `CreatedAt` | [`Models.TimeRange`](../../doc/models/time-range.md) | Optional | Represents a generic time range. The start and end values are<br>represented in RFC 3339 format. Time ranges are customized to be<br>inclusive or exclusive based on the needs of a particular endpoint.<br>Refer to the relevant endpoint-specific documentation to determine<br>how time ranges are handled. |
| `Status` | `string` | Optional | Filtered results with the desired status of the `TerminalCheckout`.<br>Options: PENDING, IN_PROGRESS, CANCELED, COMPLETED |

## Example (as JSON)

```json
{
  "device_id": null,
  "created_at": null,
  "status": null
}
```

