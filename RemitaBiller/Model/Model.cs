using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaBillerBillingGateway.Model
{
    /// <summary>
    /// API Config Object
    /// </summary>
    public class Credentials
    {
       public string publicKey { get; set; }
       public string secretKey { get; set; }
       public string url { get; set; }
       public string transactionId { get; set; }
       public string TXN_HASH { get; set; }
       public string readTimeOut { get; set; }
       public string connectionTimeOut { get; set; }
       public int timeOut { get; set; }
    }
    
    /// <summary>
    /// API Header Object
    /// </summary>
    public class Header
    {
        /// <summary>
        /// header
        /// </summary>
        public string header { get; set; }
        /// <summary>
        /// value
        /// </summary>
        public string value { get; set; }
    }

    /// <summary>
    /// API Headers Object 
    /// </summary>
    public class Headers
    {
        /// <summary>
        /// Header List Object
        /// </summary>
        public List<Header> headers { get; set; }
    }

    /// <summary>
    /// GetBillersResponse Object Model
    /// </summary>
    public class GetBillersResponseData
    {
        public string id { get; set; }
        public string description { get; set; }
        public string label { get; set; }
    }

    public class GetBillersResponse
    {
        public string responseCode { get; set; }
        public List<GetBillersResponseData> responseData { get; set; }
        public string responseMsg { get; set; }
        public object appVersionCode { get; set; }
    }


    /// <summary>
    /// GetServiceResponse Object Model
    /// </summary>
    public class GetServiceTypesResponseData
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class GetServiceTypesResponse
    {
        public string responseCode { get; set; }
        public List<List<GetServiceTypesResponseData>> responseData { get; set; }
        public string responseMsg { get; set; }
        public object appVersionCode { get; set; }
    }

    /// <summary>
    /// GetServiceTypeResponse Object Model
    /// </summary>
    public class GetCustomFieldsResponseData
    {
        public string id { get; set; }
        public string columnName { get; set; }
        public string columnType { get; set; }
        public List<object> customFieldDropDown { get; set; }
        public string columnLength { get; set; }
        public bool required { get; set; }
    }

    public class GetCustomFieldsResponse
    {
        public string responseCode { get; set; }
        public List<GetCustomFieldsResponseData> responseData { get; set; }
        public string responseMsg { get; set; }
        public object appVersionCode { get; set; }
        public bool acceptPartPayment { get; set; }
        public bool fixedPrice { get; set; }
        public double fixedAmount { get; set; }
        public string currency { get; set; }
    }


    /// <summary>
    /// GetRRRDetailsResponseData Object Model
    /// </summary>
    public class GetRRRDetailsResponseData
    {
        public string rrr { get; set; }
        public double amountDue { get; set; }
        public double chargeFee { get; set; }
        public double rrrAmount { get; set; }
        public string payerEmail { get; set; }
        public string payerName { get; set; }
        public string payerPhone { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public bool acceptPartPayment { get; set; }
        public string frequency { get; set; }
        public string payerAccountNumber { get; set; }
        public object maxNoOfDebits { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public List<object> extraData { get; set; }
        public List<object> customFields { get; set; }
    }

    public class GetRRRDetailsResponse
    {
        public string responseCode { get; set; }
        public List<GetRRRDetailsResponseData> responseData { get; set; }
        public string responseMsg { get; set; }
        public object appVersionCode { get; set; }
    }

    /// <summary>
    /// GetPaymentStatusResponse Object Model
    /// </summary>
    public class PaymentStatusData
    {
        public string rrr { get; set; }
        public int totalAmount { get; set; }
        public int balanceDue { get; set; }
        public string paymentRef { get; set; }
        public string paymentDate { get; set; }
        public string debittedAccount { get; set; }
        public int amountDebitted { get; set; }
        public List<object> extendedData { get; set; }
    }

    public class PaymentStatusResponse
    {
        public string responseCode { get; set; }
        public string responseMsg { get; set; }
        public object iResponseCode { get; set; }
        public object iResponseMessage { get; set; }
        public object appVersionCode { get; set; }
        public List<PaymentStatusData> responseData { get; set; }
    }

    /// <summary>
    /// ValidateRequest Object Model
    /// </summary>
    public class ValidateRequestValue
    {
        public string value { get; set; }
        public int quantity { get; set; }
        public double amount { get; set; }
    }

    public class ValidateRequestCustomField
    {
        public string id { get; set; }
        public List<ValidateRequestValue> values { get; set; }
    }

    public class ValidateRequest
    {
        public List<ValidateRequestCustomField> customFields { get; set; }
        public string billId { get; set; }
        public double amount { get; set; }
        public string payerPhone { get; set; }
        public string currency { get; set; }
        public string payerName { get; set; }
        public string payerEmail { get; set; }
    }

    /// <summary>
    /// ValidateResponse Object Model
    /// </summary>
    public class ValidateResponseValue
    {
        public string value { get; set; }
        public double amount { get; set; }
        public int quantity { get; set; }
    }

    public class ValidateResponseCustomField
    {
        public string id { get; set; }
        public List<ValidateResponseValue> values { get; set; }
    }

    public class ValidateResponseData
    {
        public List<ValidateResponseCustomField> customFields { get; set; }
        public string billId { get; set; }
        public double amount { get; set; }
        public string payerPhone { get; set; }
        public string currency { get; set; }
        public string payerName { get; set; }
        public string payerEmail { get; set; }
        public double amountDue { get; set; }
        public string status { get; set; }
    }

    public class ValidateResponse
    {
        public string responseCode { get; set; }
        public List<ValidateResponseData> responseData { get; set; }
        public string responseMsg { get; set; }
        public object appVersionCode { get; set; }
    }

    /// <summary>
    /// GenerateRRRRequest Object Model
    /// </summary>
    public class GenerateRRRRequestValue
    {
        public string value { get; set; }
        public int quantity { get; set; }
        public int amount { get; set; }
    }

    public class GenerateRRRRequestCustomField
    {
        public string id { get; set; }
        public List<GenerateRRRRequestValue> values { get; set; }
    }

    public class GenerateRRRRequest
    {
        public List<GenerateRRRRequestCustomField> customFields { get; set; }
        public string billId { get; set; }
        public int amount { get; set; }
        public string payerPhone { get; set; }
        public string currency { get; set; }
        public string payerName { get; set; }
        public string payerEmail { get; set; }
    }

    /// <summary>
    /// GenerateRRRResponse Object Model
    /// </summary>

    public class GenerateRRRResponseData
    {
        public string amountDue { get; set; }
        public string rrr { get; set; }
    }

    public class GenerateRRRResponse
    {
        public string responseCode { get; set; }
        public List<GenerateRRRResponseData> responseData { get; set; }
        public string responseMsg { get; set; }
        public object appVersionCode { get; set; }
    }

    /// <summary>
    /// NotificationRequest
    /// </summary>
    public class NotificationRequest
    {
        public string rrr { get; set; }
        public string incomeAccount { get; set; }
        public string debittedAccount { get; set; }
        public string paymentAuthCode { get; set; }
        public string paymentChannel { get; set; }
        public string tellerName { get; set; }
        public string branchCode { get; set; }
        public long amountDebitted { get; set; }
        public string fundingSource { get; set; }
        public string hash { get; set; }
    }

    /// </summary>
    /// NotificationResponse
    /// </summary>
    public class BillPaymentNotificationResponseData
    {
        public string rrr { get; set; }
        public int totalAmount { get; set; }
        public int balanceDue { get; set; }
        public string paymentRef { get; set; }
        public string paymentDate { get; set; }
        public string debittedAccount { get; set; }
        public int amountDebitted { get; set; }
        public List<object> extendedData { get; set; }
    }

    public class BillPaymentNotificationResponse
    {
        public string responseCode { get; set; }
        public string responseMsg { get; set; }
        public object iResponseCode { get; set; }
        public object iResponseMessage { get; set; }
        public object appVersionCode { get; set; }
        public List<BillPaymentNotificationResponseData> responseData { get; set; }
    }

}
