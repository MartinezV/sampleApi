using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdsApi.Api.Classes
{
    public class CustomerInfoClass
    {
        
        public decimal ID { get; set; }
        public string DEALER_NAME { get; set; }
        public decimal ASSOCIATED_CUSTOMER_ID { get; set; }
        public string ADDRESS_1 { get; set; }
        public string ADDRESS_2 { get; set; }
        public string ADDRESS_3 { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string POSTAL_CODE { get; set; }
        public string EMAIL { get; set; }
        public string URL { get; set; }
        public string PHONE { get; set; }
        public string FAX { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public string FACEBOOK_URL { get; set; }
        public string PREMIUM_DEALER { get; set; }
        public string ADS { get; set; }
    }
}