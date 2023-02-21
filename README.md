# REMITA BILLER SDK .NET
This SDK Outlines the Biller methods available on Remita. This document describes the methods offered by the Software Development Kit (SDK) through which SystemSpecs’ partners can integrate much easier and faster to Remita for facilitating customer payments to billers on their platform.



## OVERVIEW 
Integrating to Remita for Biller payments SDK enables your customers make payments to billers on Remita through your platform. This provides you with the capability to offer your customers access to the vast array of billers and merchants, including schools, churches, service providers and the Federal Government ministries, departments and agencies (MDAs) available on Remita to purchase and subscribe to their various products and services.

The process involves your customers selecting a biller to pay via your platform. They will supply payment details and confirm the details so you can debit their account with AmountDue to credit a designated Funds Holding Account. Your customers will be emailed Remita receipts (which are FGN MDA-recognized for TSA-bound payments) for each transaction.

## PREREQUISITES
- Prior to using the SDK, you need to set up an integration profile on www.remita.net. Each  method call will require you to pass the Public key/Secret key. Note that these values have to be set in the header for any request.
 Your public and secret keys are located at the Billing page at your profile. After you login, click ‘Setup Billing’ at your dashboard >> click ‘Proceed’ on the ‘Yes’ option for the integration question that comes up >> to display the Public/Secret key.
- .NET 2.0 or later
- Visual Studio 2012 or later

## Installing the SDK
To install the billing-gateway-sdk-dotnet from package, run the following command in the 'NuGet Package Manager Console'.

```java PM> Install-Package RemitaBillingGateway -Version 1.0.xxxx```

## CREDENTIALS
Before calling the Biller methods, the SDK needs to be initialized with the Credentials object, see below:
### Credentials attributes
|Field  | Type    | Required   | Description   |   
| ---   | ------  | -----------| -------- |   
| publicKey| String | Yes| Located at the Billing page of your Remita profile on www.remita.net.
| secretKey | String | Yes| Located at the Billing page of your Remita profile on www.remita.net.
| url | String | Yes| RemitaBillerUrl.TEST for Demo server. While RemitaBillerUrl.LIVE for Production server.
| transactionId | String | Yes| The value that is returned to identify a transaction on their system
| readTimeOut | String | Yes| The timeout on waiting to read data.
| connectionTimeOut | String | Yes| The timeout in making the initial connection.

### Sample
```java
   String publicKey = "dC5vbW9udWJpQGdtYWlsLmNvbXxiM2RjMDhjZDRlZTc5ZDIxZDQwMjdjOWM3MmI5ZWY0ZDA3MTk2YTRkNGRkMjY3NjNkMGZkYzA4MjM1MzI4OWFhODE5OGM4MjM0NTI2YWI2ZjZkYzNhZmQzNDNkZmIzYmUwNTkxODlmMmNkOTkxNmM5MjVhNjYwZjk0ZTk1OTkwNw==";
        String secretKey = "95ab7ab7b2dc3152e3ab776c8f4bbe0ec5fe87526ee129617f319fb9edf79263a6fd15f1efe78f38ad6f04634dff993ccf9f075bf91f37aa52b61a9bd61c881e";
        String url = RemitaBillerUrl.TEST;
        String transactionId = "1568886666809"; 
        String readTimeOut = "15000";
        String connectionTimeOut = "15000";
        
    Credentials credentials = new Credentials();
    credentials.publicKey = publicKey;
    credentials.secretKey = secretKey;
    credentials.url = url;
    credentials.transactionId = transactionId;
    credentials.readTimeOut = readTimeOut;
    credentials.connectionTimeOut = connectionTimeOut;
    RemitaBiller.Init(credentials);
```

## METHODS
1.    [GetBillers()](#getbillers) - Gets the list of billers on Remita platform.
2.	[GetServiceTypes(string billerId)](#getservice) - Gets the list of service  Types based on selected billerId.
3. [GetCustomFields(string billId)](#getservicetypeid) - Gets the list of Custom Fields based on selected serviceTypeId.
4. [ValidateResponse ValidateRequest(ValidateRequest validateRequest)](#validate) - Validates request payload.
5. [GenerateRRR(GenerateRRRRequest generateRRRRequest)](#generaterrr) - Generates a Remita Retrieval Reference (RRR) and total amount payable.
6. [GetRRRDetailsResponse GetRRRDetails(string rrr)](#getrrrdetails) - Remita Retrieval Reference (RRR) Lookup.
7. [BillPaymentNotificationResponse BillPaymentNotification(NotificationRequest notificationRequest)](#notificationresponse) - Notifies Remita of payment
8. [PaymentStatusResponse PaymentStatus(string transactionId)](#paymentstatus) - Payment Status.

### 1. GetBillers()
This returns a list of the billers, merchants and MDAs available on Remita.

```java
GetBillersResponse getBillerResponse = Biller.GetBillers();
```
### GetBillersResponse attributes
| Name  | Type    | 
| ---   | ------  | 
| responseCode | String |
| responseMsg | String |  
| appVersionCode | String | 
| responseData  | List< GetBillersResponseData>  |

### GetBillersResponseData attributes
| Name  | Type    |
| ---   | ------  | 
| id | String |
| description | String |  
| label | String | 


### 2. GetServiceTypes(string billerId)
This returns a list of the products and services associated with specified billers on Remita.
```java
GetServiceTypesResponse getServiceTypesResponse = Biller.GetServiceTypes("QATEST")
```
### GetServiceTypesResponse attributes
| Name  | Type    | 
| ---   | ------  | 
| responseCode | String |
| responseMsg | String |  
| appVersionCode | String | 
| responseData  | 'List <GetServiceResponseData>' 

### GetServiceTypesResponseResponseData attributes
| Name  | Type    |
| ---   | ------  | 
| id | String |
| name | String | 

### 3. GetCustomFields(string billId)
Custom fields are additional information specific to a service/product offered for sale by a biller.
```java
 GetCustomFieldsResponse GetCustomFields(string billId)
```
### GetCustomFieldsResponse attributes
| Name  | Type    | 
| ---   | ------  | 
| responseCode | String |
| responseMsg | String |  
| appVersionCode | String | 
| responseData  | 'List <GetCustomFieldsResponseData>' |
| acceptPartPayment | bool | 
| fixedPrice | bool | 
| fixedAmount | double | 
| currency | string | 

### GetCustomFieldsResponseData attributes
| Name  | Type    |
| ---   | ------  | 
| id | String |
| columnName | String | 
| columnType | String | 
| columnLength | String | 
| required | bool | 
| customFieldDropDown |  List< object> | 

### 4. Validate(ValidateRequest validateRequest)
You need to make a request for Remita to execute a validation operation on the details retrieved to check the validity of the data.
```java
 ValidateResponse Validate(ValidateRequest validateRequest)
```
### ValidateResponse attributes
| Name  | Type    | 
| ---   | ------  | 
| responseCode | String |
| responseMsg | String |  
| appVersionCode | String | 
| responseData  | 'List <ValidateResponseData>' |

### ValidateResponseData attributes
| Name  | Type    |
| ---   | ------  | 
| billId | String |
| amount | double | 
| payerPhone | String | 
| currency | String | 
| payerName | String | 
| payerEmail | String | 
| amountDue | double | 
| status | String | 
| customFields  | 'List <ValidateResponseCustomField>' |

### ValidateResponseCustomField attributes
| Name  | Type    | 
| ---   | ------  | 
| id | String | 
| values  | 'List <ValidateResponseValue>' |

### ValidateResponseValue attributes
| Name  | Type    | 
| ---   | ------  | 
| value | String |
| amount | double |  
| quantity | int | 

### 5. GenerateRRR(GenerateRRRRequest generateRRRRequest)
In order to complete the transaction through the Remita Payment Gateway, a Remita Retrieval Reference or RRR is required. This is what uniquely identifies and embodies the payment details of a transaction on the platform ecosystem.
```java
  GenerateRRRResponse GenerateRRR(GenerateRRRRequest generateRRRRequest)
```
### GenerateRRRResponse attributes
| Name  | Type    | 
| ---   | ------  | 
| responseCode | String |
| responseMsg | String |  
| appVersionCode | String | 
| responseData  | 'List <GenerateRRRResponseData>' |

### GenerateRRRResponseData attributes
| Name  | Type    |
| ---   | ------  | 
| amountDue | String | 
| rrr | String | 

### 6.  GetRRRDetails(string rrr)
If your customer already has a Remita Retrieval Reference (RRR), he/she can verify the RRR to display payment details associated with it and complete payment.
```java
   GetRRRDetailsResponse GetRRRDetails(string rrr)
```
### GetRRRDetailsResponse attributes
| Name  | Type    | 
| ---   | ------  | 
| responseCode | String |
| responseMsg | String |  
| appVersionCode | String | 
| responseData  | 'List <GetRRRDetailsResponseData>' |

### GetRRRDetailsResponseData attributes
| Name  | Type    |
| ---   | ------  | 
| amountDue | double | 
| rrr | String | 
| chargeFee  | double |          
| rrrAmount | double |
| payerEmail  | string |
| payerName  | string |
| payerPhone | string |
| description | string |
| currency    | string |
| type  | string |
| acceptPartPayment | bool   |
| frequency | string |
| payerAccountNumber  | string |
| maxNoOfDebits   | object |
| startDate  | string |
| endDate  | string |
| extraData  | List< object> |
| customFields | List< object> |

### 7.  PaymentStatus(string transactionId)
You may need to enquire that status of biller payments your customers have made via Remita. 
```java
    PaymentStatusResponse PaymentStatus(string transactionId)
```
### PaymentStatusResponse attributes
| Name  | Type    | 
| ---   | ------  | 
| responseCode | String |
| responseMsg | String |  
| appVersionCode | String | 
| iResponseCode | object | 
| iResponseMessage | object | 
| responseData  | 'List <PaymentStatusData>' |

### PaymentStatusData attributes
| Name  | Type    |
| ---   | ------  | 
| amountDue | double | 
| rrr | String | 
| totalAmount  | int |          
| balanceDue | int |
| paymentRef  | string |
| paymentDate  | string |
| debittedAccount | string |
| amountDebitted | int |
| extendedData | List< object> |

### 8.  BillPaymentNotification(NotificationRequest notificationRequest)
After you have debit the customer with the RRR amount (amountDue) to process the payment, you are required to notify Remita with details of the transaction. Invoking this method will send a payment notification for the transaction to Remita accordingly.
```java
     BillPaymentNotificationResponse BillPaymentNotification(NotificationRequest notificationRequest)
```
### BillPaymentNotificationResponse attributes
| Name  | Type    | 
| ---   | ------  | 
| responseCode | String |
| responseMsg | String |  
| appVersionCode | String | 
| iResponseCode | object | 
| iResponseMessage | object | 
| responseData  | 'List < BillPaymentNotificationResponseData>' |

### BillPaymentNotificationResponseData attributes
| Name  | Type    |
| ---   | ------  | 
| amountDue | double | 
| rrr | String | 
| totalAmount  | int |          
| balanceDue | int |
| paymentRef  | string |
| paymentDate  | string |
| debittedAccount | string |
| amountDebitted | int |
| extendedData | List< object>|
