using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaBillerBillingGateway.Cls
{
    /// <summary>
    /// 
    /// </summary>
   public  class RemitaBillerUrl
    {
        public static string TEST = "https://remitademo.net/remita/exapp/api/v1/send/api/bgatesvc/billing/";

        public static string LIVE = "https://login.remita.net/remita/exapp/api/v1/send/api/bgatesvc/billing/";

        //GET
        public  const String GET_BILLERS = "billers";
        public const String GET_SERVICE = "/servicetypes";
        public const String GET_SERVICE_TYPE = "servicetypes/";
        public const String GET_RRR_DETAILS = "lookup/";
        public const String PAYMENT_STATUS = "payment/status/";
        
        //POST
        public const String VALIDATE = "validate";
        public const String GENERATE_RRR = "generate";
        public const String NOTIFICATION = "payment/notify";

        public static string GetBillers()
        {
            return GET_BILLERS;
        }

        public static string GetService(String billerId)
        {
            return billerId + GET_SERVICE;
        }

        public static string GetServiceTypes(String serviceTypesId)
        {
            return GET_SERVICE_TYPE + serviceTypesId;
        }

        public static string GetRRRDetails(String rrr)
        {
            return GET_RRR_DETAILS + rrr;
        }

        public static string PaymentStatus(String transactionId)
        {
            return PAYMENT_STATUS + transactionId;
        }

        public static string Validate()
        {
            return VALIDATE;
        }

        public static string Generate()
        {
            return GENERATE_RRR;
        }

        public static string Notification()
        {
            return NOTIFICATION;
        }
    }
}
