//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Text;
//
//namespace RemitaBillerBillingGateway.Cls
//{
//    public class ExtWebClientUtil
//    {
//
//        WebRequest objWebRequest;
//        private int timeout;
//
//        public int Timeout
//        {
//            get
//            {
//                return timeout;
//            }
//            set
//            {
//                timeout = value;
//            }
//        }
//
//        protected override WebRequest GetWebRequest(Uri address)
//        {
//            objWebRequest = base.GetWebRequest(address);
//            objWebRequest.Timeout = this.timeout;
//            return objWebRequest;
//        }
//
//            /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="GET"></param>
//        /// <param name="BaseURL"></param>
//        /// <param name="APIMethod"></param>
//        /// <param name="_Headers"></param>
//        /// <returns></returns>
//        public static string GetResponse(String BaseURL, String APIMethod, Headers _Headers)
//        {
//
//            Console.WriteLine("+++++++++ URL: " + $"{BaseURL}{APIMethod}");
//
//            String response = string.Empty;
//            try
//            {
//                var client = new WebClient();
//                
//                foreach (var i in _Headers.headers)
//                    client.Headers.Add(i.header, i.value);
//                response = client.DownloadString($"{BaseURL}{APIMethod}");
//            }
//            catch (Exception ex)
//            {
//                response = ex.Message;
//            }
//
//            return response;
//        }
//
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="POST"></param>
//        /// <param name="BaseURL"></param>
//        /// <param name="APIMethod"></param>
//        /// <param name="_Headers"></param>
//        /// <returns></returns>
//        public static string PostResponse(String BaseURL, String APIMethod, String body, Headers _Headers)
//        {
//            Console.WriteLine("+++++++++ URL: " + $"{BaseURL}{APIMethod}");
//
//            Console.WriteLine();
//            Console.WriteLine("++++++++++++++Body: " + body);
//            Console.WriteLine();
//
//            String response = string.Empty;
//            try
//            {
//                var client = new WebClient();
//                
//                foreach (var i in _Headers.headers)
//                    client.Headers.Add(i.header, i.value);
//
//                client.Encoding = System.Text.Encoding.UTF8;
//                string method = "POST";
//
//                response = client.UploadString($"{BaseURL}{APIMethod}", method, body);
//            }
//            catch (Exception ex)
//            {
//                response = ex.Message;
//            }
//
//            return response;
//        }
//    }
//}
//