using Newtonsoft.Json;
using RemitaBillerBillingGateway.Cls;
using RemitaBillerBillingGateway.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaBillerBillingGateway
{
    public class RemitaBiller
    {
        public static Headers _header;
        public static List<Header> headers;
        public static ErrorResponse errorResponse;

        public static Credentials credentials { get; set; }

        public static void Init(Credentials merchantCredentials)
        {
            credentials = merchantCredentials;
            _header = new Headers();
            headers = new List<Header>();

            headers.Add(new Header { header = "Content-Type", value = "application/json" });
            headers.Add(new Header { header = "publicKey", value = credentials.publicKey });

            _header.headers = headers;
        }

        public static GetBillersResponse GetBillers()
        {
            GetBillersResponse billers = new GetBillersResponse();

            //Console.WriteLine("Getting Error response. . .");
            ErrorResponse errorResponse = validateCredentials(credentials);
            //Console.WriteLine("Error response. . ."+ errorResponse.responseMsg);

            string responseCode = errorResponse.responseCode;
            if (errorResponse.responseCode != "00")
            {
                billers.responseCode = errorResponse.responseCode;
                billers.responseMsg= errorResponse.responseMsg;
                return billers;
            }
            
            try
            {
                var response = WebClientUtil.GetResponse(credentials.url, RemitaBillerUrl.GetBillers(), _header);
                billers = JsonConvert.DeserializeObject<GetBillersResponse>(response);
            }
            catch (Exception)
            {
                throw;
            }
            return billers;
        }

        public static GetServiceTypesResponse GetServiceTypes(string billerId)
        {
            GetServiceTypesResponse services = new GetServiceTypesResponse();

            ErrorResponse errorResponse = validateCredentials(credentials);
            string responseCode = errorResponse.responseCode;
            if (errorResponse.responseCode != "00")
            {
                services.responseCode = errorResponse.responseCode;
                services.responseMsg = errorResponse.responseMsg;
                return services;
            }

            if (String.IsNullOrEmpty(billerId))
            {
                services.responseCode = "12";
                services.responseMsg = "Missing billerId parameter";
                return services;
            }

            try
            {
                var response = WebClientUtil.GetResponse(credentials.url, RemitaBillerUrl.GetService(billerId), _header);

                services = JsonConvert.DeserializeObject<GetServiceTypesResponse>(response);
            }
            catch (Exception)
            {
                throw;
            }
            return services;
        }

        public static GetCustomFieldsResponse GetCustomFields(string billId)
        {
            GetCustomFieldsResponse servicesTypes = new GetCustomFieldsResponse();

            ErrorResponse errorResponse = validateCredentials(credentials);
            string responseCode = errorResponse.responseCode;
            if (errorResponse.responseCode != "00")
            {
                servicesTypes.responseCode = errorResponse.responseCode;
                servicesTypes.responseMsg = errorResponse.responseMsg;
                return servicesTypes;
            }

            if (String.IsNullOrEmpty(billId))
            {
                servicesTypes.responseCode = "14";
                servicesTypes.responseMsg = "Missing billId parameter";
                return servicesTypes;
            }

            try
            {
                var response = WebClientUtil.GetResponse(credentials.url, RemitaBillerUrl.GetServiceTypes(billId), _header);

                servicesTypes = JsonConvert.DeserializeObject<GetCustomFieldsResponse>(response);
            }
            catch (Exception)
            {
                throw;
            }
            return servicesTypes;
        }

        public static ValidateResponse Validate(ValidateRequest validateRequest)
        {
            ValidateResponse validateResponse = new ValidateResponse();

            ErrorResponse errorResponse = validateCredentials(credentials);
            string responseCode = errorResponse.responseCode;
            if (errorResponse.responseCode != "00")
            {
                validateResponse.responseCode = errorResponse.responseCode;
                validateResponse.responseMsg = errorResponse.responseMsg;
                return validateResponse;
            }

           if (validateRequest == null)
           {
                validateResponse.responseCode = "14";
                validateResponse.responseMsg = "Missing Validate Request object";
                return validateResponse;
            }

            String jsonValidateRequest = JsonConvert.SerializeObject(validateRequest);

            try
            {
                var response = WebClientUtil.PostResponse(credentials.url, RemitaBillerUrl.Validate(), jsonValidateRequest, _header);
                validateResponse = JsonConvert.DeserializeObject<ValidateResponse>(response);
            }
            catch (Exception)
            {
                throw;
            }
            return validateResponse;
        }

        public static GenerateRRRResponse GenerateRRR(GenerateRRRRequest generateRRRRequest)
        {
            GenerateRRRResponse generateRRRResponse = new GenerateRRRResponse();

            ErrorResponse errorResponse = validateCredentials(credentials);
            string responseCode = errorResponse.responseCode;
            if (errorResponse.responseCode != "00")
            {
                generateRRRResponse.responseCode = errorResponse.responseCode;
                generateRRRResponse.responseMsg = errorResponse.responseMsg;
                return generateRRRResponse;
            }

            if (generateRRRRequest == null)
            {
                generateRRRResponse.responseCode = "18";
                generateRRRResponse.responseMsg = "Missing Generate RRR Request object";
                return generateRRRResponse;
            }

            String jsonGenerateRRRRequest = JsonConvert.SerializeObject(generateRRRRequest);

            try
            {
                var response = WebClientUtil.PostResponse(credentials.url, RemitaBillerUrl.Generate(), jsonGenerateRRRRequest, _header);
                generateRRRResponse = JsonConvert.DeserializeObject<GenerateRRRResponse>(response);
            }
            catch (Exception)
            {
                throw;
            }
            return generateRRRResponse;
        }

        public static GetRRRDetailsResponse GetRRRDetails(string rrr)
        {
            GetRRRDetailsResponse rrrDetails = new GetRRRDetailsResponse();

            ErrorResponse errorResponse = validateCredentials(credentials);
            string responseCode = errorResponse.responseCode;
            if (errorResponse.responseCode != "00")
            {
                rrrDetails.responseCode = errorResponse.responseCode;
                rrrDetails.responseMsg = errorResponse.responseMsg;
                return rrrDetails;
            }

            if (String.IsNullOrEmpty(rrr))
            {
                rrrDetails.responseCode = "20";
                rrrDetails.responseMsg = "Missing rrr parameter";
                return rrrDetails;
            }
            try
            {
                var response = WebClientUtil.GetResponse(credentials.url, RemitaBillerUrl.GetRRRDetails(rrr), _header);

                rrrDetails = JsonConvert.DeserializeObject<GetRRRDetailsResponse>(response);
            }
            catch (Exception)
            {
                throw;
            }
            return rrrDetails;
        }

        public static PaymentStatusResponse PaymentStatus(string transactionId)
        {
            PaymentStatusResponse paymentStatusResponse = new PaymentStatusResponse();
            ErrorResponse errorResponse = validateCredentials(credentials);
            string responseCode = errorResponse.responseCode;
            if (errorResponse.responseCode != "00")
            {
                paymentStatusResponse.responseCode = errorResponse.responseCode;
                paymentStatusResponse.responseMsg = errorResponse.responseMsg;
                return paymentStatusResponse;
            }

            if (String.IsNullOrEmpty(transactionId))
            {
                paymentStatusResponse.responseCode = "22";
                paymentStatusResponse.responseMsg = "Missing transactionId parameter";
                return paymentStatusResponse;
            }
            try
            {
                var response = WebClientUtil.GetResponse(credentials.url, RemitaBillerUrl.PaymentStatus(transactionId), _header);
                paymentStatusResponse = JsonConvert.DeserializeObject<PaymentStatusResponse>(response);
            }
            catch (Exception)
            {
                throw;
            }
            return paymentStatusResponse;
        }

        public static BillPaymentNotificationResponse BillPaymentNotification(NotificationRequest notificationRequest)
        {
            BillPaymentNotificationResponse notificationResponse = new BillPaymentNotificationResponse();
            ErrorResponse errorResponse = validateCredentials(credentials);
            string responseCode = errorResponse.responseCode;
            if (errorResponse.responseCode != "00")
            {
                notificationResponse.responseCode = errorResponse.responseCode;
                notificationResponse.responseMsg = errorResponse.responseMsg;
                return notificationResponse;
            }

            if (notificationRequest == null)
            {
                notificationResponse.responseCode = "24";
                notificationResponse.responseMsg = "Missing Notification Request Object";
                return notificationResponse;
            }

            var stringToHash = notificationRequest.rrr + notificationRequest.amountDebitted + notificationRequest.fundingSource + notificationRequest.debittedAccount + notificationRequest.paymentAuthCode + credentials.secretKey;
            string hashed = SHA512(stringToHash);
            notificationRequest.hash = hashed;

            String jsonNotificationRequest = JsonConvert.SerializeObject(notificationRequest);
            credentials.transactionId = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString();

            try
            {
                headers.Add(new Header { header = "transactionId", value = credentials.transactionId });
                headers.Add(new Header { header = "TXN_HASH", value = notificationRequest.hash });
                headers.Add(new Header { header = "secretKey", value = credentials.secretKey });
                _header.headers = headers;

                var response = WebClientUtil.PostResponse(credentials.url, RemitaBillerUrl.Notification(), jsonNotificationRequest, _header);
                notificationResponse = JsonConvert.DeserializeObject<BillPaymentNotificationResponse>(response);
            }
            catch (Exception)
            {
                throw;
            }
            return notificationResponse;
        }

        public static string SHA512(string hash_string)
        {
            System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();
            Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hash_string));
            sha512.Clear();
            string hashed = BitConverter.ToString(EncryptedSHA512).Replace("-", "").ToLower();
            return hashed;
        }

        public static ErrorResponse validateCredentials(Credentials credentials)
        {
            errorResponse = new ErrorResponse();
            errorResponse.responseCode = "00";
            errorResponse.responseMsg = "Credentials initialized successfully";

            if (credentials == null)
            {
                errorResponse = new ErrorResponse();
                errorResponse.responseCode = "11";
                errorResponse.responseMsg = "Credentials not initialized";
                return errorResponse;
            }

            if (string.IsNullOrEmpty(credentials.publicKey))
            {
                errorResponse = new ErrorResponse();
                errorResponse.responseCode = "13";
                errorResponse.responseMsg = "Missing public key parameter";
                return errorResponse;
            }

            if (string.IsNullOrEmpty(credentials.secretKey))
            {
                errorResponse = new ErrorResponse();
                errorResponse.responseCode = "15";
                errorResponse.responseMsg = "Missing secret key parameter";
                return errorResponse;
            }
            if (string.IsNullOrEmpty(credentials.url))
            {
                errorResponse = new ErrorResponse();
                errorResponse.responseCode = "17";
                errorResponse.responseMsg = "Missing url parameter";
                return errorResponse;
            }
            if (string.IsNullOrEmpty(credentials.transactionId))
            {
                errorResponse = new ErrorResponse();
                errorResponse.responseCode = "19";
                errorResponse.responseMsg = "Missing transactionId parameter";
                return errorResponse;
            }
            return errorResponse;
        }
    }
}
