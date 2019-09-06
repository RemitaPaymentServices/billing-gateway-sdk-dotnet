using Newtonsoft.Json;
using RemitaBillerBillingGateway;
using RemitaBillerBillingGateway.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RemitaBillerBillingGateway.Cls;

namespace Testery
{
    public partial class Form1 : Form
    {
        string publicKey = "dC5vbW9udWJpQGdtYWlsLmNvbXxiM2RjMDhjZDRlZTc5ZDIxZDQwMjdjOWM3MmI5ZWY0ZDA3MTk2YTRkNGRkMjY3NjNkMGZkYzA4MjM1MzI4OWFhODE5OGM4MjM0NTI2YWI2ZjZkYzNhZmQzNDNkZmIzYmUwNTkxODlmMmNkOTkxNmM5MjVhNjYwZjk0ZTk1OTkwNw==";
        string secretKey = "95ab7ab7b2dc3152e3ab776c8f4bbe0ec5fe87526ee129617f319fb9edf79263a6fd15f1efe78f38ad6f04634dff993ccf9f075bf91f37aa52b61a9bd61c881e";
        string url = RemitaBillerUrl.LIVE;
        string transactionId = "1568886666809"; 
        int timeOut = 3000;
        Credentials credentials;

        public Form1()
        {
            InitializeComponent();

            credentials = new Credentials();
            credentials = new Credentials();
            credentials.publicKey = publicKey;
            credentials.secretKey = secretKey;
            credentials.url = url;
            credentials.transactionId = transactionId;
            credentials.timeOut = timeOut;
       
            Console.WriteLine("++++++++Credentials: " + JsonConvert.SerializeObject(credentials));

            RemitaBiller.Init(credentials);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //GET Requests +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            txtResponse.Text = JsonConvert.SerializeObject(RemitaBiller.GetBillers());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           txtResponse.Text = JsonConvert.SerializeObject(RemitaBiller.GetServiceTypes("QATEST"));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtResponse.Text = JsonConvert.SerializeObject(RemitaBiller.GetCustomFields("41032401"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtResponse.Text = JsonConvert.SerializeObject(RemitaBiller.GetRRRDetails("250007764609"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ValidateRequest validateRequest = new ValidateRequest();

            List<ValidateRequestValue> valueList = new List<ValidateRequestValue>();
            ValidateRequestValue value = new ValidateRequestValue();
            ValidateRequestValue value2 = new ValidateRequestValue();
            ValidateRequestValue value3 = new ValidateRequestValue();
            List<ValidateRequestCustomField> customFieldList = new List<ValidateRequestCustomField>();
            ValidateRequestCustomField customField = new ValidateRequestCustomField();

            value.amount = 5000;
            value.quantity = 1;
            value.value = "41467392";

            value2.amount = 3000;
            value2.quantity = 1;
            value2.value = "41467390";

            value3.amount = 7500;
            value3.quantity = 1;
            value3.value = "41467393";

            valueList.Add(value);
            valueList.Add(value2);
            valueList.Add(value3);

            customField.id = "41467388";
            customField.values = valueList;
            customFieldList.Add(customField);

            validateRequest.customFields = customFieldList;
            validateRequest.billId = "41467398";
            validateRequest.amount = 15600;
            validateRequest.payerPhone = "08085519759";
            validateRequest.currency = "NGN";
            validateRequest.payerName = "Tokunbo Omonubi";
            validateRequest.payerEmail = "t.omonubi@gmail.com";

            Console.WriteLine("+++++ Response: " + JsonConvert.SerializeObject(validateRequest));

            ValidateResponse validateResponse = RemitaBiller.Validate(validateRequest);

            txtResponse.Text = JsonConvert.SerializeObject(validateResponse);
        }
    }
   

        private void button5_Click(object sender, EventArgs e)
        {
           txtResponse.Text = JsonConvert.SerializeObject(RemitaBiller.PaymentStatus("1540915827487"));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            GenerateRRRRequest generateRRRRequest = new GenerateRRRRequest();
         
             List<GenerateRRRRequestValue> valueList = new List<GenerateRRRRequestValue>();
             GenerateRRRRequestValue value = new GenerateRRRRequestValue();
            List<GenerateRRRRequestCustomField> customFieldList = new List<GenerateRRRRequestCustomField>();
             GenerateRRRRequestCustomField customField = new GenerateRRRRequestCustomField();
            
             value.amount = 1000;
             value.quantity = 0;
             value.value = "45236RGGH985263";
             valueList.Add(value);
            
             customField.id = "41958626";
             customField.values = valueList;
             customFieldList.Add(customField);
            
            generateRRRRequest.customFields = customFieldList;
            generateRRRRequest.billId = "41958627";
            generateRRRRequest.amount = 1000;
            generateRRRRequest.payerPhone = "08085519759";
            generateRRRRequest.currency = "NGN";
            generateRRRRequest.payerName = "Tokunbo Omonubi";
            generateRRRRequest.payerEmail = "t.omonubi@gmail.com";
            
            GenerateRRRResponse generateRRRResponse = RemitaBiller.GenerateRRR(generateRRRRequest);
            List<GenerateRRRResponseData> generateRRRResponseDatas =  generateRRRResponse.responseData;

            txtResponse.Text = JsonConvert.SerializeObject(generateRRRResponse);
        }

        private void button8_Click(object sender, EventArgs e)
        {
             NotificationRequest notificationRequest = new NotificationRequest();
             notificationRequest.rrr = "250007764039";
             notificationRequest.incomeAccount = "0001061499";
             notificationRequest.debittedAccount = "2044863290";
             notificationRequest.paymentAuthCode = "546789096543545678990";
             notificationRequest.paymentChannel = "INTERNETBANKING";
             notificationRequest.tellerName = "INTERNETBANKING";
             notificationRequest.branchCode = "Empty";
             notificationRequest.amountDebitted = 200000;
             notificationRequest.fundingSource = "TOKS" ;
            
             BillPaymentNotificationResponse notificationResponse = RemitaBiller.BillPaymentNotification(notificationRequest);
             txtResponse.Text = JsonConvert.SerializeObject(notificationResponse);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
