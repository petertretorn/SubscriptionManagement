# Instructions

- open solution in Visual Studio
- open package manager console
- select Infrastructure as default project
- run update-database command

Database is seeded with Customer with guid id of 33eb22ad-6700-45db-a209-03b9a6addacb

To view subscriptions of that customer issue GET request to following URL:

GET https://localhost:44338/api/subscription/33eb22ad-6700-45db-a209-03b9a6addacb

To add subscription issue POST requst with customerId and data in payload:

POST https://localhost:44338/api/subscription
ДДД
{
	"customerId": "33eb22ad-6700-45db-a209-03b9a6addacb",
	"start": "2021-05-01T18:18:14.082Z",
	"productId": "44d915f3-caea-4164-a70f-51b2f075d478",
	"level": "Basic",
	"description": "some description",
	"flatFee": 89,
	"monthlyRate": 99,
	"currencyCode": "DKK",
	"subscriptionPeriodInDays": 90
}
ДДД
To delete subscription issue DELETE request with subscripId in URL path:

DELETE https://localhost:44338/api/subscription/&lt;subscripId>