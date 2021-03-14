# Instructions

The solution is designed according to the onion architecture with the domain model/logic in the center and the dependencies pointing inwards. The middle application layer  implements the usecases and coordinates work between domain and infrastructure layers. The application layer is organized around features so that all code related to a specific feature is colocated. To get solution up and running:

- open solution in Visual Studio
- open package manager console
- select Infrastructure as default project
- run update-database command

Database is seeded with Customer with guid id of 33eb22ad-6700-45db-a209-03b9a6addacb

To view subscriptions of that customer issue GET request to following URL:

GET https://localhost:44338/api/subscription/33eb22ad-6700-45db-a209-03b9a6addacb

To add subscription issue POST requst with customerId and data in payload:

POST https://localhost:44338/api/subscription
```json
{
	"customerId": "33eb22ad-6700-45db-a209-03b9a6addacb",
	"start": "2021-05-01T18:18:14.082Z",
	"productId": "44d915f3-caea-4164-a70f-51b2f075d478",
	"level": "Basic",
	"category": "Broadband",
	"flatFee": 89,
	"monthlyRate": 99,
	"currencyCode": "DKK",
	"subscriptionPeriodInDays": 90
}
```
To delete subscription issue DELETE request with subscripId in URL path:

DELETE https://localhost:44338/api/subscription/ \<subscripId>

I didn't get around to code up a client library, but given the solution provides languange agnostic HTTP endpoints it would be a question of programmatically issuing HTTP requests. In C# that could be done using HttpClient. POST request example:

```C#
var subscriptionCommand = new subscriptionCommand("33eb22ad-6700-45db-a209-03b9a6addacb", ..... etc);

var json = JsonConvert.SerializeObject(person);
var data = new StringContent(json, Encoding.UTF8, "application/json");

var url = "https://localhost:44338/api/subscription";
using var client = new HttpClient();

var response = await client.PostAsync(url, data);

string result = response.Content.ReadAsStringAsync().Result;
```

If the client code resides inside an ASP.NET Core application it can be advantageous to use the HttpClientFactory and possibly create a typed HttpClient that can be registered with the DI container

