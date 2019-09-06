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
            String jsonValidateRequest = JsonConvert.SerializeObject(validateRequest);
            ValidateResponse validateResponse = new ValidateResponse();
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
            String jsonGenerateRRRRequest = JsonConvert.SerializeObject(generateRRRRequest);
            GenerateRRRResponse generateRRRResponse = new GenerateRRRResponse();
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
            var stringToHash = notificationRequest.rrr + notificationRequest.amountDebitted + notificationRequest.fundingSource + notificationRequest.debittedAccount + notificationRequest.paymentAuthCode + credentials.secretKey;
            string hashed = SHA512(stringToHash);
            notificationRequest.hash = hashed;

            String jsonNotificationRequest = JsonConvert.SerializeObject(notificationRequest);
            credentials.transactionId = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString();

            BillPaymentNotificationResponse notificationResponse = new BillPaymentNotificationResponse();

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

    }
}
