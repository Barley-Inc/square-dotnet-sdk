
# Search Terminal Refunds Request

## Structure

`SearchTerminalRefundsRequest`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Query` | [`Models.TerminalRefundQuery`](../../doc/models/terminal-refund-query.md) | Optional | - |
| `Cursor` | `string` | Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query. |
| `Limit` | `int?` | Optional | Limits the number of results returned for a single request.<br>**Constraints**: `>= 1`, `<= 100` |

## Example (as JSON)

```json
{
  "limit": 1,
  "query": {
    "filter": {
      "status": "COMPLETED"
    }
  }
}
```

